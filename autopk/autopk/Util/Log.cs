using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopk.Util
{
    class Log
    {
        public static void ShowLog(string TAG, string msg)
        {
            Console.WriteLine(" " + TAG + " : " + msg);
        }
    }
}
