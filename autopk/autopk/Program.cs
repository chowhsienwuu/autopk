using Autopk.WebPage;
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
            string raw = "648483~~~~距离开盘：<b>09</b>:<b>03</b>:<b>57</b>~~~~距离开奖：<b style=\"color: Red; \">09</b>:<b style=\"color: Red; \">09</b>:<b style=\"color: Red; \">58</b>";

            StringBuilder sb = new StringBuilder(raw);
            raw = raw.Trim();
            while (raw.IndexOf("<") > 0)
            {
                var first = raw.IndexOf("<");
                var second = raw.IndexOf(">");
                if (second > first)
                {
                    raw = raw.Remove(first, second - first + 1);
                }
                else
                {
                    raw = raw.Remove(second);
                }
            }


            var setting = new CefSharp.CefSettings();
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
