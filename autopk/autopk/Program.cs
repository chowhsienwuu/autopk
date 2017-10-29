using autopk.WebPage;
using Autopk.Ui;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopk
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            var setting = new CefSharp.CefSettings();

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"d\":\"[{\\\"Rows\\\":[{\\\"memberno\\\":\\\"kca115\\\",\\\"membername\\\":\\\"a\\\",\\\"opena\\\":true,\\\"openb\\\":false,\\\"openc\\\":false,\\\"opend\\\":false,\\\"opene\\\":false,\\\"credittype\\\":2,\\\"accounttype\\\":2,\\\"creditquota\\\":99.4902,\\\"usecreditquota\\\":0.00,\\\"usecreditquota2\\\":0.00,\\\"allowcreditquota\\\":99.49}]},99.4902]\"}");

            
         //   while (true)
            {



            }

            // 设置语言
            setting.Locale = "zh-CN";
            CefSharp.Cef.Initialize(setting);
            CefSharp.Cef.EnableHighDPISupport();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
