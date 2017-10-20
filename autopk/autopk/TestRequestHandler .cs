using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Drawing;
using autopk.Ui;

namespace autopk
{
    class TestRequestHandler : IRequestHandler
    {
        private TestResponseFilter filter = null;
        public event Action<byte[]> NotifyData;

        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            Console.WriteLine(" GetAuthCredentials ");
            return false;;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            Console.WriteLine(" GetResourceResponseFilter ");
            var url = new Uri(request.Url);
            if (url.AbsoluteUri.Contains(@"/checknum.aspx?ts="))
            {
                var filter = FilterManager.CreateFilter(request.Identifier.ToString());

                return filter;
            }
            return null;
        }

        private void filter_NotifyData(byte[] obj)
        {
            byte[] data = obj as byte[];
          //  File.WriteAllBytes("D://test.jpg", data);
            Image image = Image.FromStream(new MemoryStream(data));

            Bitmap bitmap = new Bitmap(image);
            bitmap.Save("D://test.bmp");
        }

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            Console.WriteLine(" OnBeforeBrowse " + frame.Url + " " + request.Headers);
            return false;;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            Uri url;

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    Console.WriteLine("OnBeforeResourceLoad " + request.Method + request.Url + " referurl " + request.ReferrerUrl 
                       + " request type " + request.ResourceType);
                }
            }

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
            Console.WriteLine("OnQuotaRequest " + originUrl);
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
            Console.WriteLine("OnResourceLoadComplete receivedContentLength " + receivedContentLength);
            if (request.Url.Contains(@"/checknum.aspx?ts="))
            {
                var filter = FilterManager.GetFileter(request.Identifier.ToString()) as TestResponseFilter;

                // filter_NotifyData(filter.dataAll.ToArray());
                NotifyData?.Invoke(filter.dataAll.ToArray());
            }
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            Console.WriteLine("OnResourceResponse " +  request.ResourceType + " content-lenght " + response.ResponseHeaders["Content-Length"]);

            return false;

        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return false;;
        }
    }
}
