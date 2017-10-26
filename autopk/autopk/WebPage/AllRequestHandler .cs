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

namespace Autopk
{
    class AllRequestHandler : IRequestHandler
    {
        public event Action<byte[]> NotifyData;

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
         //   Console.WriteLine(" GetResourceResponseFilter ");
            var url = new Uri(request.Url);
            if (url.AbsoluteUri.Contains(LoginPage.CHECKSUM_STRING))
            {
                var filter = FilterManager.CreateFilter(request.Identifier.ToString());

                return filter;
            }

            if (saveAllRespnseForDebug)
            {//save all file to 
                var filter = FilterManager.CreateFilter(request.Identifier.ToString());

                return filter;
            }

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
            if (request.Url.Contains(LoginPage.CHECKSUM_STRING))
            {
                var filter = FilterManager.GetFileter(request.Identifier.ToString()) as CompletedResponseFilter;

                NotifyData?.Invoke(filter.dataAll.ToArray());

                FilterManager.DelFileter(request.Identifier.ToString());
            }

            // for test.
            if (saveAllRespnseForDebug)
            {//save all file to 
                var filter = FilterManager.GetFileter(request.Identifier.ToString()) as CompletedResponseFilter;

                //  NotifyData?.Invoke(filter.dataAll.ToArray());
                var rawurl = request.Url;
                if (rawurl.EndsWith("/"))
                {
                    rawurl = rawurl.Remove(rawurl.Length - 1);
                }

                var pos = rawurl.LastIndexOf('/');
                string url = rawurl.Substring(pos);
                 url =  url.Replace('?', '_').Replace('*', '_').Replace('|', '_').Replace('<', '_').Replace('>', '_').Replace(':', '_');

                if (url.Length > 100)
                {
                    url = url.Substring(url.Length - 10);
                }
                File.WriteAllBytes("D://htmlsave//" + url, filter?.dataAll.ToArray());
             //  FilterManager.DelFileter(request.Identifier.ToString());
            }
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
