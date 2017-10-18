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

namespace autopk.Ui
{
    public partial class MainForm : Form
    {

        private readonly ChromiumWebBrowser browser;

        public MainForm()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser(string.Empty)
            {
                Dock = DockStyle.Fill,
            };
            browerpanel.Controls.Add(browser);



            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;

          //  browser.RequestHandler += this;
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            // urlText.Text = e.Address;
            Console.WriteLine("OnBrowserAddressChanged " + e.Address);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
         
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs e)
        {
            Console.WriteLine("OnBrowserStatusMessage " + e.Value);
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Console.WriteLine("OnBrowserConsoleMessage " + e.Message);
            Console.WriteLine("OnBrowserConsoleMessage " + e.Source);
            Console.WriteLine("OnBrowserConsoleMessage " + e.Line);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            Console.WriteLine("OnLoadingStateChanged " + e.ToString());
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
            browser.ExecuteScriptAsync(jspstring);

            var url = browser.GetFocusedFrame().Url;
            var source = browser.GetFocusedFrame().GetHashCode();
            Console.WriteLine("focusedframe url is  : " + url);


            var identifiers = browser.GetBrowser().GetFrameIdentifiers();
            Console.WriteLine("identifiers count " + identifiers.Count);
            foreach (var i in identifiers)
            {
               IFrame frame = browser.GetBrowser().GetFrame(i);
                Console.WriteLine("mainframe i  : " + i + "name " + frame.Name + " " + frame.Identifier);
                Console.WriteLine("mainframe url is  : " + frame.Url);
            }
          //  browser.GetBrowser().GetFrameIdentifiers();
            // Console.WriteLine("mainframe url is  : " + browser.GetMainFrame().Url);
            //  browser.getf
        }
    }
}
