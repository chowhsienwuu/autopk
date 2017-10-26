using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopk.WebPage
{
    class Pk10MainPage
    {
        public static string ALL_WRAP_PAGE = "http://n668.cc282.com/search.aspx"; //没用,包基本个业务页面.
        //包含有　iframe 
        //  <iframe  "  src="left.aspx" name="left" id="left"></iframe> //左边的页面．显示前有多少钱．下了什么注．
        //    http://60xxdgw.777ssd.com/cp3-10-mb/ch/left.aspx

        //<!--framePath //<!--frame0-->-->
      　 // http://60xxdgw.777ssd.com/cp3-10-mb/ch/main.aspx

        //    ／／pk１０选号的页面．下注等页面  mainbody
        //    mainframe url is  : http://60xxdgw.777ssd.com/cp3-10-mb/ch/bjsc_twosides.aspx?gameno=11
        //   mainbody


        public static string BUS_BASE_PAGE = " http://60xxdgw.777ssd.com/cp3-10-mb/ch/";

        public static string LEFT_PAGE_ADD = "left.aspx";
        public static string UPSIE_PAGE_ADD = "main.aspx";
        public static string BJSC_MAINBODY_PAGE_ADD = "bjsc_twosides.aspx?gameno=11";

        /*****下注***/
        //直接调用下注的函数.末知
    //        parent.window.frames["mainbody"].order.reader();
    //SetOrderOddsString(1); ClearTimeOut(); SendOrder();
    //        document.getElementById('btn_order2').click();
        // mainbody
        public static string JS_ORDER2_STRING1 = "SetOrderOddsString(1); ClearTimeOut(); SendOrder();";
        public static string JS_ORDER2_STRING2 = "document.getElementById('btn_order2').click();";

        public static string BUTTON_ID_ORDER2 = "btn_order2"; // mainbody

        public static string JS_CLEAR_ALL = "$(\".kuaijie input:text[name ^= 'r']\").each(function () { " + 
                        "if ($(this).next().css(\"display\") == \"none\") {" +
                            "$(this).parent().prev().removeClass(\"kuaijie_xz\");" +
                            "$(this).val(\"\");  }});";
        //打印log 
        //  jsptext is  : var x = 2;
        // console.log("Sample log" + x);
        /**下注确认与取消*/ //.aspx main.aspx
        public static string JS_ORDER2_CONFIERM = "hwProwin._config.retype = \"ok\";hwProwin.close();";
        public static string JS_ORDER2_CHAC = "hwProwin.close();";
    }
}
