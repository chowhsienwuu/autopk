using Autopk.Util;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopk.WebPage
{
    //js dialog 弹出时,会调用此类.比如登陆时,叫要求输入密码的弹窗.
    class AllJsDialogHandler : IJsDialogHandler
    {
        const string TAG = "AllJsDialogHandler";

        const string VALIED_NG = "验证码不正确";
        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {
            Log.ShowLog(TAG, "OnDialogClosed ");
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            Log.ShowLog(TAG, "OnJSBeforeUnload " + message);
            return false;
        }

        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            Log.ShowLog(TAG, "OnJSDialog " + messageText);
            if (messageText.Contains(VALIED_NG))
            {
              //  return true;
            }
            return false;
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {
            Log.ShowLog(TAG, "OnResetDialogState " + browserControl.Address);
        }
    }
}
