using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopk.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Autopk.Ui
{
    public partial class Memberinfo : UserControl
    {
        const string TAG = "Memberinfo";

        public Memberinfo()
        {
            InitializeComponent();
        }
        public void UpdateMemberInfo(byte[] rawdata)
        {
            var text = Encoding.Default.GetString(rawdata);
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            try
            {
                JObject jsonraw = JObject.Parse(text);
                var dataroot_d = jsonraw["d"];

                JArray darray_val = JArray.Parse(dataroot_d.ToString());

                var rows_all = darray_val[0];
                JObject rowarray_all = JObject.Parse(rows_all.ToString());

                JArray rowsarray = JArray.Parse(rowarray_all["Rows"].ToString());
                var real = JObject.Parse(rowsarray[0].ToString());

                var memberno = real.GetValue("memberno").ToString();
                var opena = real.GetValue("opena").ToString();
                var openb = real.GetValue("openb").ToString();
                var openc = real.GetValue("openc").ToString();
                var opend = real.GetValue("opend").ToString();
                var opene = real.GetValue("opene").ToString();
                var creditquotastring = real.GetValue("creditquota").ToString();
                var allowcreditquotastring = real.GetValue("allowcreditquota").ToString();

                var whichpan = "";
                if (Boolean.Parse(opena))
                {
                    whichpan = "a";
                }
                else if (Boolean.Parse(openb))
                {
                    whichpan = "b";
                }else if (Boolean.Parse(openc))
                {
                    whichpan = "c";
                }else if (Boolean.Parse(opend))
                {
                    whichpan = "d";
                }else if (Boolean.Parse(opene))
                {
                    whichpan = "e";
                }

                this.BeginInvoke(new Action(() => {
                    var showmemberno = memberno + "(" + whichpan + "盘)";
                    this.memberno.Text = showmemberno;
                    this.creditquota.Text = "" + creditquotastring;
                    this.allowcrediaquota.Text = "" + allowcreditquotastring;
                }));
            }
            catch (Exception e)
            {
                Log.ShowLog(TAG, "showmeminfo error" + e.ToString());
            }

        }
    }
}
