using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using Autopk.WebPage;
using System.Threading;
using Autopk.Util;
using autopk.WebPage;

namespace Autopk.Ui
{
    public partial class MainForm : Form
    {
        private const string TAG = "MainFrom";

        private readonly ChromiumWebBrowser browser;

        public MainForm()
        {
            InitializeComponent();
          
            browser = new ChromiumWebBrowser(string.Empty);

            browser.Dock = DockStyle.Fill;
            browerpanel.Controls.Add(browser);

            InitBrowser();
        }

        private void InitBrowser()
        {
            browser.LoadingStateChanged += OnLoadingStateChanged;

           // browser.StatusMessage += OnBrowserStatusMessage;
           // browser.TitleChanged += OnBrowserTitleChanged;
           // browser.AddressChanged += OnBrowserAddressChanged;
            browser.ConsoleMessage += Browser_ConsoleMessage;
            browser.FrameLoadEnd += OnFrameLoadEnd;

            browser.RequestHandler = new AllRequestHandler();

            var requesthander = browser.RequestHandler as AllRequestHandler;
            requesthander.NotifyData += Requesthander_NotifyData;

          //  browser.JsDialogHandler = new AllJsDialogHandler();

            _WebPageManager = new WebPageManager(browser);

            if (Uri.IsWellFormedUriString(urlText.Text, UriKind.RelativeOrAbsolute))
            {
                browser.Load(urlText.Text);
            }
        }

        WebPageManager _WebPageManager;
        private void Browser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Log.ShowLog(TAG, "consoleMessage " + e.Message);
        }

        private void RefrshWebpageFrames()
        {
            this.BeginInvoke(new Action(() => {
                var identifiers = browser.GetBrowser().GetFrameIdentifiers();
                framecheckboxlist.Items.Clear();

                foreach (var i in identifiers)
                {
                    try
                    {
                        var frame = browser.GetBrowser().GetFrame(i);
                        framecheckboxlist.Items.Add(frame.Url);

                        Log.ShowLog(TAG, "frame name " + frame.Name + " url " + frame.Url + " identifier: " + i);
                    }
                    catch
                    {
                    }
                }
            }));
        }

        private void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            Log.ShowLog(TAG, " OnFrameLoadEnd ");
            RefrshWebpageFrames();

            _WebPageManager.OnOnePageLoad(e);
        }

        private void Requesthander_NotifyData(byte[] obj, string reason)
        {
            byte[] data = obj as byte[];
            
            switch (reason)
            {
                case PageUrlCharacteristic.MEMBERINFO_END:
                    memberinfo.UpdateMemberInfo(data);
                    break;
                case PageUrlCharacteristic.CHECKSUM_MID:
                    Image image = Image.FromStream(new MemoryStream(data));
                    Bitmap bitmap = new Bitmap(image);
                    imagebutton.Image = bitmap;
                    break;
                default:
                    break;
            }

        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            // urlText.Text = e.Address;
         //   Log.ShowLog(TAG, "OnBrowserAddressChanged " + e.Address);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
         
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs e)
        {
            Log.ShowLog(TAG, "OnBrowserStatusMessage " + e.Value);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            Log.ShowLog(TAG, "OnLoadingStateChanged " + e.ToString());
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(urlText.Text, UriKind.RelativeOrAbsolute))
            {
                _WebPageManager.WhichPage = WebPageManager.PAGE_INIT;
                browser.Load(urlText.Text);
            }
        }

        private void jspinput_Click(object sender, EventArgs e)
        {
            var jspstring = jsptext.Text;
            Console.WriteLine("jsptext is  : " + jspstring);

            string selecturl = framecheckboxlist.SelectedItem.ToString();
            if (string.IsNullOrEmpty(selecturl))
            {
                return;
            }

            var identifiers = browser.GetBrowser().GetFrameIdentifiers();
          //  Console.WriteLine("identifiers count " + identifiers.Count);
            IFrame frame = null;
            foreach (var i in identifiers)
            {
                if (browser.GetBrowser().GetFrame(i).Url.Equals(selecturl)){
                    frame = browser.GetBrowser().GetFrame(i);
                }
                //Console.WriteLine("mainframe i  : " + i + "name " + frame.Name + " " + frame.Identifier);
                //Console.WriteLine("mainframe url is  : " + frame.Url);
            }

            frame?.ExecuteJavaScriptAsync(jspstring);
        }

        private void login_Click(object sender, EventArgs e)
        {
            _WebPageManager.LoginIn("kca115", "qw123123", checksum.Text);
        }

        private void debugsaveCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var requesthander = browser.RequestHandler as AllRequestHandler;
            requesthander.SaveAllRespnseForDebug = debugsaveCheckbox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _WebPageManager.SetOdersTwoSidedebug(null);
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            _WebPageManager.ClearAllOder();
        }

        private void tackorder_Click(object sender, EventArgs e)
        {
            _WebPageManager.TackOrder2();
        }
    }
}
