using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace autopk
{
    class TestRequestHandler : IRequestHandler
    {
        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return false;;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            var url = new Uri(request.Url);

            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            Console.WriteLine(" OnBeforeBrowse " + frame.Url + " " + request.Headers);
            return false;;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            Uri url;



            //Example of setting User-Agent in every request.
            //var headers = request.Headers;

            //var userAgent = headers["User-Agent"];
            //headers["User-Agent"] = userAgent + " CefSharp";

            //request.Headers = headers;

            //NOTE: If you do not wish to implement this method returning false is the default behaviour
            // We also suggest you explicitly Dispose of the callback as it wraps an unmanaged resource.
            //callback.Dispose();
            //return false;

            //NOTE: When executing the callback in an async fashion need to check to see if it's disposed
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    if (request.Method == "POST")
                    {
                        using (var postData = request.PostData)
                        {
                            if (postData != null)
                            {
                                var elements = postData.Elements;

                                var charSet = request.GetCharSet();

                                foreach (var element in elements)
                                {
                                    if (element.Type == PostDataElementType.Bytes)
                                    {
                                        var body = element.GetBody(charSet);
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine("OnBeforeResourceLoad " + request.Method + request.PostData);
                    //Note to Redirect simply set the request Url
                    //if (request.Url.StartsWith("https://www.google.com", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    request.Url = "https://github.com/";
                    //}

                    //Callback in async fashion
                    //callback.Continue(true);
                    //return CefReturnValue.ContinueAsync;
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
            Console.WriteLine("OnResourceLoadComplete " + response.ToString());
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            Console.WriteLine("OnResourceResponse " + response.ToString());
            return false;;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return false;;
        }
    }
}
