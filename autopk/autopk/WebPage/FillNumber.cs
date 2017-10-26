using Autopk.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopk.WebPage
{
    class FillNumber
    {
        //611;612;613;614;615;616;617;618;619;620;621;622;623;624;625;626;627;628;629;630;631;632;633;634;635;636;637;";//27
        //var x = document.getElementsByName("r622_1");x[0].value='1'; //下注钱.
        public const string TAG = "FillNumber";

        public void SetNums(Hashtable keys, List<int> val)
        {
            Log.ShowLog(TAG, "setnumbs");
            if(keys.Count != val.Count  || keys.Count > 11)
            {
                throw new Exception("too large");
            } 
            for (int i = 0; i < keys.Count; i++)
            {

            }


        }

    }
}
