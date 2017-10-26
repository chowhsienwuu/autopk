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

            //   browser.JsDiaShowLogHandler = new AllJsDiaShowLogHandler();
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
                    var frame = browser.GetBrowser().GetFrame(i);
                    framecheckboxlist.Items.Add(frame.Url);

                    Log.ShowLog(TAG, "frame name " + frame.Name + " url " + frame.Url + " identifier: " + i);
                }
            }));
        }

        private void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            Log.ShowLog(TAG, " OnFrameLoadEnd ");
            RefrshWebpageFrames();

            _WebPageManager.OnOnePageLoad(e);
        }

        private void Requesthander_NotifyData(byte[] obj)
        {
            byte[] data = obj as byte[];
            Image image = Image.FromStream(new MemoryStream(data));

            Bitmap bitmap = new Bitmap(image);
            imagebutton.Image = bitmap;
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
                browser.Load(urlText.Text);
            }
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            // document.getElementById('su').click();
            var id = clickem.Text;
            string jsp = "document.getElementById('" + id + "').click()";
            Console.WriteLine("click jsp : " + jsp);
            browser.ExecuteScriptAsync(jsp);
        }

        private void input_Click(object sender, EventArgs e)
        {
            var id = inputID.Text;
            var text = inputval.Text;
            //  "document.getElementById('testid2').value='123'"
      //      string jsp = "document.getElementById('" + id + "').value='" + text + "'";

            string jsp = "var x = document.getElementsByName(\"" + id + "\");x[0].value='" + text + "'";
            Console.WriteLine("input jsp : " + jsp);
            browser.ExecuteScriptAsync(jsp);
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
    }
}
