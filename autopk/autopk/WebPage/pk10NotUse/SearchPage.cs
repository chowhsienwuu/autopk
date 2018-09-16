using Autopk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopk.WebPage
{
    class SearchPage
    {

        public static string DEFAULT_PAGE = "n668.cc282.com";

        private static string Input_SearchBoxName = "wd";
        private static string Button_SearchBoxId = "su";

        public static string InputSearchCode(string text)
        {
            var inputsearchcodescipt = JavaScriptGen.InputStringByName(Input_SearchBoxName, text);

            return inputsearchcodescipt.ToString();
        }

        public static string StartSearchJumpPage()
        {
            var temp = JavaScriptGen.ButtonClickById(Button_SearchBoxId);
            return temp.ToString() ;
        }

    }
}
