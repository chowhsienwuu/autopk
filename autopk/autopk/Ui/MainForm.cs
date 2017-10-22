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
using autopk.WebPage;
using System.Threading;

namespace autopk.Ui
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

            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.ConsoleMessage += Browser_ConsoleMessage;
            browser.FrameLoadEnd += OnFrameLoadEnd;

            browser.RequestHandler = new AllRequestHandler();

            var requesthander = browser.RequestHandler as AllRequestHandler;
            requesthander.NotifyData += Requesthander_NotifyData;
        }

        private void Browser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Util.Log(TAG, "consoleMessage " + e.Message);
        }

        JavaScriptGen JavaScriptGen = new JavaScriptGen();
        private void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            this.BeginInvoke(new Action(()=> {
                var identifiers = browser.GetBrowser().GetFrameIdentifiers();
                framecheckboxlist.Items.Clear();
                foreach (var i in identifiers)
                {
                    framecheckboxlist.Items.Add(browser.GetBrowser().GetFrame(i).Url);
                }
            }));

            Util.Log(TAG, " OnFrameLoadEnd ");
            ///////////////////////////////////////////////
            // step 1 search page jump to login page.
            //if (browser.GetBrowser().urlText)
            var inputsearchcodescipt = JavaScriptGen.InputStringByName(SearchPage.Input_SearchBoxName, "36136");
            Util.Log(TAG, " inputsearchcodescipt " + inputsearchcodescipt);
            browser.GetMainFrame().ExecuteJavaScriptAsync(inputsearchcodescipt);

            Thread.Sleep(100);
            var temp = JavaScriptGen.ButtonClickById(SearchPage.Button_SearchBoxId);
            Util.Log(TAG, " temp " + temp);
            browser.GetMainFrame().ExecuteJavaScriptAsync(temp);

            ///////////////////////////////////////////////////////
            //step 2, login page to mainpage
 

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
            Util.Log(TAG, "OnBrowserAddressChanged " + e.Address);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
         
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs e)
        {
            Util.Log(TAG, "OnBrowserStatusMessage " + e.Value);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            Util.Log(TAG, "OnLoadingStateChanged " + e.ToString());
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
            ////  browser.GetMainFrame().ExecuteJavaScriptAsync(jspstring);

            //  var identifiers = browser.GetBrowser().GetFrameIdentifiers();
            //  Console.WriteLine("identifiers count " + identifiers.Count);
            //  IFrame frame = null;
            //  foreach (var i in identifiers)
            //  {
            //      frame = browser.GetBrowser().GetFrame(i);
            //      Console.WriteLine("mainframe i  : " + i + "name " + frame.Name + " " + frame.Identifier);
            //      Console.WriteLine("mainframe url is  : " + frame.Url);
            //  }

            //  frame.ExecuteJavaScriptAsync(jspstring);

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

            //var frame = browser.GetBrowser().GetFrame(selectname);
            frame?.ExecuteJavaScriptAsync(jspstring);

            //  var url = browser.GetFocusedFrame().Url;
            //  var source = browser.GetFocusedFrame().GetHashCode();
            //  Console.WriteLine("focusedframe url is  : " + url);


            //  var identifiers = browser.GetBrowser().GetFrameIdentifiers();
            //  Console.WriteLine("identifiers count " + identifiers.Count);
            //  foreach (var i in identifiers)
            //  {
            //     IFrame frame = browser.GetBrowser().GetFrame(i);
            //      Console.WriteLine("mainframe i  : " + i + "name " + frame.Name + " " + frame.Identifier);
            //      Console.WriteLine("mainframe url is  : " + frame.Url);
            //    //  frame.
            //  }

            ////  browser.GetBrowser().GetFrameIdentifiers();
            //  // Console.WriteLine("mainframe url is  : " + browser.GetMainFrame().Url);
            //  browser.getf
            //Bitmap bitmap = new Bitmap(this.Width, this.Height);
            ////      browser.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            ////    browser.ScreenshotAsync();
            ////   DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            //bitmap = ControlSnapshot.Snapshot(browser);
            //imagebutton.Image = bitmap;
            //bitmap.Save("D://1.bmp");

            // string str = "chk('1');";
            // browser.GetMainFrame().ExecuteJavaScriptAsync(str);
        }

        private void login_Click(object sender, EventArgs e)
        {
            var identifiers = browser.GetBrowser().GetFrameIdentifiers();
            Console.WriteLine("identifiers count " + identifiers.Count);
            IFrame frame = null;
            foreach (var i in identifiers)
            {
                frame = browser.GetBrowser().GetFrame(i);
                Console.WriteLine("mainframe i  : " + i + "name " + frame.Name + " " + frame.Identifier);
                Console.WriteLine("mainframe url is  : " + frame.Url);
            }
            var logtemp = JavaScriptGen.InputStringById(LoginPage.Input_username, "kca115");
            Util.Log(TAG, " LoginPage.Input_username " + logtemp);
            frame?.ExecuteJavaScriptAsync(logtemp); //add username
            Thread.Sleep(100);
            logtemp = JavaScriptGen.InputStringById(LoginPage.Input_password, "qw123123");
            Util.Log(TAG, " LoginPage.Input_password " + logtemp);
            frame?.ExecuteJavaScriptAsync(logtemp); //add paswd

            //
            // add checksum
            Thread.Sleep(100);
            logtemp = JavaScriptGen.InputStringById(LoginPage.Input_Validata, checksum.Text);
            Util.Log(TAG, " LoginPage.Input_Validata  " + logtemp);
            frame?.ExecuteJavaScriptAsync(logtemp); //add paswd

            Thread.Sleep(100);
            //login
            frame?.ExecuteJavaScriptAsync(LoginPage.Script_login);

            Thread.Sleep(100);

            // step 3. agreement page 
            identifiers = browser.GetBrowser().GetFrameIdentifiers();
            Console.WriteLine("identifiers count " + identifiers.Count);
            foreach (var i in identifiers)
            {
                frame = browser.GetBrowser().GetFrame(i);
                Console.WriteLine("mainframe i  : " + i + "name " + frame.Name + " " + frame.Identifier);
                Console.WriteLine("mainframe url is  : " + frame.Url);
            }
            frame?.ExecuteJavaScriptAsync(AgreementPage.Script_OK);
        }
    }
}
