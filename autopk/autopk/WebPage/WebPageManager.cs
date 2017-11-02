using Autopk.Util;
using Autopk.WebPage;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autopk.WebPage
{
    public class WebPageManager
    {
        //
        private const string TAG = "webpageManager";
        private ChromiumWebBrowser _browser;
        public WebPageManager(ChromiumWebBrowser browser)
        {
            _browser = browser;
            WhichPage = PAGE_INIT;
        }

        public const int PAGE_INIT = 0;
        public const int PAGE_SEARCH = 1;
        public const int PAGE_LOGIN = 2;
        public const int PAGE_AGREEMNT = 3;
        public const int PAGE_MAIN_BUSS = 4;

        private int whichPage;

        public int WhichPage
        {
            get
            {
                return whichPage;
            }

            set
            {
                whichPage = value;
            }
        }

        public void Reset()
        {
            WhichPage = WebPageManager.PAGE_INIT;
            if (workerThread != null)
            {
                KeepCheck = false;
                threadhasstart = false;
                workerThread.Abort();
            }
        }


        public string _realloginiframeurl = string.Empty;
        public string _mainbussinesurlbase = string.Empty;

        public void OnOnePageLoad(FrameLoadEndEventArgs e)
        {
            //先会加载子iframe, 后才会加载 top frame.
            Log.ShowLog(TAG, "OnOnePageLoad url: " + e.Url + " frame url: " + e.Frame.Url);
            var currenturl = e.Frame.Url;
            var frame = e.Frame;

            switch (WhichPage)
            {
                case PAGE_INIT: // 
                    if (currenturl.Contains(SearchPage.DEFAULT_PAGE))
                    {
                        WhichPage = PAGE_SEARCH;
                        ExecJs(frame, SearchPage.InputSearchCode("36136"));
                        ExecJs(frame, SearchPage.StartSearchJumpPage());
                    }
                    break;
                case PAGE_SEARCH:
                    if (currenturl.Contains(LoginPage.TOPFRAME_TAIL)) // login in page load end.
                    {
                        WhichPage = PAGE_LOGIN;

                        var identifiers = _browser.GetBrowser().GetFrameIdentifiers();
                        IFrame tempframe = null;
                        foreach (var i in identifiers)
                        {
                            tempframe = _browser.GetBrowser().GetFrame(i);
                            if (!currenturl.Contains(tempframe.Url))
                            {
                                _realloginiframeurl = tempframe.Url;
                                Log.ShowLog(TAG, "find real url is : " + _realloginiframeurl);
                            }
                        }
                    }
                    break;
                case PAGE_LOGIN://agreen.
                    if (currenturl.Contains(AgreementPage.TOPFRAME_TAIL))
                    {
                        WhichPage = PAGE_AGREEMNT;
                        _mainbussinesurlbase = currenturl.Substring(0, currenturl.LastIndexOf('/') + 1);

                        var identifiers = _browser.GetBrowser().GetFrameIdentifiers();
                        IFrame tempframe = null;
                        foreach (var i in identifiers)
                        {
                            tempframe = _browser.GetBrowser().GetFrame(i);
                        }
                        ExecJs(tempframe, AgreementPage.Script_OK);
                    }

                    break;
                case PAGE_AGREEMNT:
                    if (currenturl.Contains(_mainbussinesurlbase + Pk10MainPage.BJSC_MAINBODY_PAGE_ADD))
                    {
                        WhichPage = PAGE_MAIN_BUSS;
                        Log.ShowLog(TAG, "login in success : ");
                        try
                        {
                            if (!threadhasstart)
                            {
                                workerThread = new Thread(new ThreadStart(DoLoopWork));
                                KeepCheck = true;
                                workerThread.Start();
                                threadhasstart = true;
                            }
                        }
                        catch
                        {
                        }
                    }
                    break;
                case PAGE_MAIN_BUSS:
                    break;
                default:
                    break;
            }
        }

       
        private bool threadhasstart = false;
        Thread workerThread = null;
        private bool KeepCheck = false;
        private void DoLoopWork()
        {
            string getpagestatusjs = "function ___statuscheck(){	return (document.getElementById(\"t_LID\").innerHTML + \"~~~~\" + document.getElementById(\"hClockTime_C\").innerHTML + \"~~~~\" +  document.getElementById(\"hClockTime_O\").innerHTML);}___statuscheck(); ";
            while (KeepCheck)
            {
                Log.ShowLog(TAG, "doloopwork check");

                var rettask = ExecJs(GetPk10frame(PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_MAINBODY), getpagestatusjs);
                if (rettask == null)
                {
                    continue;
                }
                var retstr = rettask.Result.Result.ToString();
                if (!string.IsNullOrEmpty(retstr))
                {
                    continue;
                }
                retstr.Split(new string[] { "~~~~" }, StringSplitOptions.RemoveEmptyEntries);



                Thread.Sleep(1000); // sleep 1sec.
            }
        }




        private FillNumber _FillNumber = new FillNumber();
        public void SetOdersTwoSidedebug(Dictionary<string, int>[][] srcdata)
        {
            var datamat = _FillNumber.CreateEmptyMatrix();

            for (int i = 0; i < datamat.Length; i++)
            {
                for (int j = 0; j < datamat[i].Length; j++)
                {
                    Dictionary<string, int> d = datamat[i][j];
                    d[d.Keys.ElementAt(0)] = 10 * (i + 1) + j;
                }
            }

            var js = _FillNumber.SetNums(datamat);

            ExecJs(GetPk10frame(PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_MAINBODY), js);
        }

        internal void ClearAllOder()
        {
            var js = Pk10MainPage.JS_CLEAR_ALL;

            ExecJs(GetPk10frame(PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_MAINBODY), js);
        }

       internal void TackOrder2()
        {
            var js = Pk10MainPage.JS_ORDER2_STRING2;

            ExecJs(GetPk10frame(PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_MAINBODY), js);
        }

        enum PK10_TWOSIDE_IFRAME{
            PK10_TWOSIDE_MAINBODY,
            PK10_TWOSIDE_LEFT,
            PK10_TWOSIDE_MAIN_ASP,
        };

        private IFrame GetPk10frame(PK10_TWOSIDE_IFRAME page)
        {
            if (!HasLogin())
            {
                return null;
            }

            var identifiers = _browser.GetBrowser().GetFrameIdentifiers();

            foreach (var i in identifiers)
            {
                var _frame = _browser.GetBrowser().GetFrame(i);
                
                switch (page){
                    case PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_LEFT:
                        break;
                    case PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_MAINBODY:
                        if (_frame.Url.Contains(_mainbussinesurlbase + Pk10MainPage.BJSC_MAINBODY_PAGE_ADD))
                        {
                            return _frame;
                        }
                        break;
                    case PK10_TWOSIDE_IFRAME.PK10_TWOSIDE_MAIN_ASP:
                        break;
                    default:
                        break;
                }
            }

            return null;
        }


        public bool HasLogin()
        {
            return WhichPage == PAGE_MAIN_BUSS;
        }

        public void LoginIn(string username, string passwd, string vilValidatatext)
        {
            WhichPage = PAGE_LOGIN;
            var identifiers = _browser.GetBrowser().GetFrameIdentifiers();
            IFrame tempframe = null;
            foreach (var i in identifiers)
            {
                tempframe = _browser.GetBrowser().GetFrame(i);
                if (tempframe.Url.Contains(_realloginiframeurl))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(JavaScriptGen.InputStringById(LoginPage.Input_username, username));
                    sb.Append(";");
                    sb.Append(JavaScriptGen.InputStringById(LoginPage.Input_password, passwd));
                    sb.Append(";");
                    sb.Append(JavaScriptGen.InputStringById(LoginPage.Input_Validata, vilValidatatext));
                    sb.Append(";");
                    sb.Append(LoginPage.Script_login);
                    sb.Append(";");

                    ExecJs(tempframe, sb.ToString());
                }
            }
        }

        public Task<JavascriptResponse> ExecJs(IFrame frame ,string text)
        {
            if (frame == null || string.IsNullOrEmpty(text))
            {
                Log.ShowLog(TAG, "do not run this js");
                return null;
            }

            Log.ShowLog(TAG, "exec js on url " + frame.Url + "\n" + "js: " + text);

            var task = frame.EvaluateScriptAsync(text, null);
            if (task != null)
            {
              //  task.Wait();
                if (!task.IsFaulted)
                {
                    return task;
                }
            }

            return null;

            //task.ContinueWith(t =>
            //{
            //    if (!t.IsFaulted)
            //    {
            //        var response = t.Result;
            //        Log.ShowLog(TAG, "response:" + response.Result + " Message :" + 
            //            response.Message + " success:" + response.Success);
            //    }
            //});
        }

    }
}
