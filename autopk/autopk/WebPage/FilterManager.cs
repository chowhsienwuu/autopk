using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopk.Ui
{
    class FilterManager
    {
        private static Dictionary<string, IResponseFilter> dataList = new Dictionary<string, IResponseFilter>();

        public static IResponseFilter CreateFilter(string guid)
        {
            lock (dataList)
            {
                var filter = new CompletedResponseFilter();
                dataList.Add(guid, filter);

                return filter;
            }
        }

        public static IResponseFilter GetFileter(string guid)
        {
            if (!(dataList.ContainsKey(guid)))
            {
                return null;
            }

            lock (dataList)
            {
                return dataList[guid];
            }
        }

        public static void DelFileter(string guid)
        {
            lock (dataList)
            {
                dataList.Remove(guid);
            }
        }
    }
}
