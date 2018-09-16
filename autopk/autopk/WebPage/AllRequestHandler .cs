using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Drawing;
using Autopk.Ui;
using Autopk.WebPage;
using Autopk.Util;
using Autopk.WebPage;

namespace Autopk
{
    class AllRequestHandler : IRequestHandler
    {
        const string TAG = "AllRequestHandler";

        public event Action<byte[], string> NotifyData;

        private bool saveAllRespnseForDebug;

        public bool SaveAllRespnseForDebug
        {
            get
            {
                return saveAllRespnseForDebug;
            }

            set
            {
                saveAllRespnseForDebug = value;
            }
        }

        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return false;;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            if (saveAllRespnseForDebug)
            {//save all file to 
                var filter = FilterManager.CreateFilter(request.Identifier.ToString());
                return filter;
            }

            //   Console.WriteLine(" GetResourceResponseFilter ");
            //var url = new Uri(request.Url);
            //if (url.AbsoluteUri.Contains(PageUrlCharacteristic.QRCODE))
            //{
            //    var filter = FilterManager.CreateFilter(request.Identifier.ToString());

            //    return filter;
            //}

            //if (request.Url.EndsWith(PageUrlCharacteristic.MEMBERINFO_END) && response.StatusCode == 200)
            //{ //用户信息.
            //    var filter = FilterManager.CreateFilter(request.Identifier.ToString());
            //    return filter;
            //}

            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
       //     Console.WriteLine(" OnBeforeBrowse " + frame.Url + " " + request.Headers);
            return false;;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            return false;;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
           
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            return false;;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return false;;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
           
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {

           
            Log.ShowLog(TAG, "OnResourceLoadComplete " + request.Url);
            //if (request.Url.Contains(PageUrlCharacteristic.QRCODE)) //验证码
            //{
            //    var filter = FilterManager.GetFileter(request.Identifier.ToString()) as CompletedResponseFilter;

            //    NotifyData?.Invoke(filter.dataAll.ToArray(), PageUrlCharacteristic.QRCODE);

            //    if (!saveAllRespnseForDebug)
            //    {
            //        FilterManager.DelFileter(request.Identifier.ToString());
            //    }
            //}

            //if (request.Url.EndsWith(PageUrlCharacteristic.MEMBERINFO_END) && response.StatusCode == 200)
            // { //用户信息.
            //    var filter = FilterManager.GetFileter(request.Identifier.ToString()) as CompletedResponseFilter;
            //    if (!saveAllRespnseForDebug)
            //    {
            //        FilterManager.DelFileter(request.Identifier.ToString());
            //    }
            //    NotifyData?.Invoke(filter.dataAll.ToArray(), PageUrlCharacteristic.MEMBERINFO_END);
            //    Log.ShowLog(TAG, "MEMINFO_END " + Encoding.Default.GetString(filter.dataAll.ToArray()));
            //}

            #region test
            // for test.
            if (saveAllRespnseForDebug)
            {//save all file to 
                var filter = FilterManager.GetFileter(request.Identifier.ToString()) as CompletedResponseFilter;
                if (filter == null)
                {
                    return;
                }

                //  NotifyData?.Invoke(filter.dataAll.ToArray());
                var url = request.Url;

                 url =  url.Replace('?', '_').Replace('*', '_').Replace('|', '_').Replace('<', '_').Replace('>', '_')
                    .Replace(':', '_').Replace('/', '_');

                if (url.Length > 200)
                {
                    url = url.Substring(0, 200);
                }
                File.WriteAllBytes("E://htmlsave//" + url, filter?.dataAll.ToArray());
             //  FilterManager.DelFileter(request.Identifier.ToString());
            }
            #endregion 
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
         //   Console.WriteLine("OnResourceResponse " +  request.ResourceType + " content-lenght " + response.ResponseHeaders["Content-Length"]);

            return false;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return false;;
        }
    }
}
