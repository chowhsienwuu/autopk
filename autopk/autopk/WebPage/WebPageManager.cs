using Autopk.Util;
using Autopk.WebPage;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopk.WebPage
{
    class WebPageManager
    {
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
                    }
                    break;
                case PAGE_MAIN_BUSS:
                    break;
                default:
                    break;
            }
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

        public void ExecJs(IFrame frame ,string text)
        {
            Log.ShowLog(TAG, "exec js on url " + frame.Url + "\n" + "js: " + text);

            var task = frame.EvaluateScriptAsync(text, null);
            
            //task.ContinueWith(t =>
            //{
            //    if (!t.IsFaulted)
            //    {
            //        var response = t.Result;
            //    }
            //}, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
