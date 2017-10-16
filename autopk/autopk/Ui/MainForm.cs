using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(urlText.Text, UriKind.RelativeOrAbsolute))
            {
                browser.Load(urlText.Text);
            }
        }

    }
}
