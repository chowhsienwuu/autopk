using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopk.WebPage
{
    class LoginPage
    {
        public static string DEFAULT_PAGE = SearchPage.DEFAULT_PAGE +  "/search.aspx";

        public static string CHECKSUM_STRING = "checknum.aspx?ts=";

        public static string Input_username = "txt_U_name";
        public static string Input_password = "txt_U_Password";
        public static string Input_Validata = "txt_validate";
        public static string Button_Login = "longinbtn";
        public static string Check_ismobile = "ismobile";

        public static string Script_login = "CheckLogin()";
    }
}
