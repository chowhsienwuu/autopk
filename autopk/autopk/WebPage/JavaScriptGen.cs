using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopk.WebPage
{
    class JavaScriptGen
    {
       public string InputStringById(string id, string text)
        {
           // string jsp = "document.getElementById('" + id + "').value='" + text + "'"; 
            StringBuilder sb = new StringBuilder();
            sb.Append("document.getElementById('");
            sb.Append(id);
            sb.Append("')");
            sb.Append(".value='");
            sb.Append(text);
            sb.Append("';");

            return sb.ToString();
        }


        public string InputStringByName(string id, string text)
        {
            //var x = document.getElementsByName("wd");x[0].value='36136'
            StringBuilder sb = new StringBuilder();
            sb.Append("var x = document.getElementsByName(\"");
            sb.Append(id);
            sb.Append("\")");
            sb.Append(";x[0].value='");
            sb.Append(text);
            sb.Append("';");

            return sb.ToString();
        }

        public   string ButtonClickById(string id)
        {
        //    string jsp = "document.getElementById('" + id + "').click()";

            StringBuilder sb = new StringBuilder();
            sb.Append("document.getElementById('");
            sb.Append(id);
            sb.Append("')");
            sb.Append(".click()");

            return sb.ToString();
        }
    }
}
