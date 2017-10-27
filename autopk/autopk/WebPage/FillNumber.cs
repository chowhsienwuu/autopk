using Autopk.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopk.WebPage
{
    public class FillNumber
    {
        //611;612;613;614;615;616;617;618;619;620;621;622;623;624;625;626;627;628;629;630;631;632;633;634;635;636;637;";//27
        //var x = document.getElementsByName("r622_1");x[0].value='1'; //下注钱.
        public const string TAG = "FillNumber";
     
        public string SetNums(KeyValuePair<string, int>[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var ___name;");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j].Value > 0)
                    {
                        sb.Append("___name = document.getElementsByName(\"" + matrix[i][j].Key + "\");x[0].value='" + matrix[i][j].Value + "';");
                    }
                }
            }

            return sb.ToString();
        }

        private const int MAX_MATRIX_D1 = 11;
        public KeyValuePair<string, int>[][] CreateEmptyMatrix()
        {
            // maxtrix[第几名,如冠军][下注类型.如大,单] == keyvaluepair<name r621_, 下注金额>                    
            KeyValuePair<string, int>[][] matrix = new KeyValuePair<string, int>[MAX_MATRIX_D1][];

            // step 1. init.size
            for (int i = 0; i < MAX_MATRIX_D1; i++)
            {
                if (i < 6)
                {  //大
                    matrix[i] = new KeyValuePair<string, int>[6];
                }else
                {
                    matrix[i] = new KeyValuePair<string, int>[4];
                }
            }
            //1-10 大.
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    switch (j)
                    {
                        case 0: // 大
                            matrix[i][ j] = new KeyValuePair<string, int>("r62" + (i+1).ToString() + "_1", 0);
                            break;
                        case 1: //小
                            matrix[i][ j] = new KeyValuePair<string, int>("r62" + (i + 1).ToString() + "_2", 0);
                            break;
                        case 2://单
                            matrix[i][ j] = new KeyValuePair<string, int>("r61" + (i + 1).ToString() + "_1", 0);
                            break;
                        case 3: //双
                            matrix[i][ j] = new KeyValuePair<string, int>("r61" + (i + 1).ToString() + "_2", 0);
                            break;
                        case 4: //龙
                            if (i < 6)
                            {
                                matrix[i][ j] = new KeyValuePair<string, int>("r63" + (i + 1).ToString() + "_1", 0);
                            }
                            break;
                        case 5: // 虎
                            if (i < 6)
                            {
                                matrix[i][ j] = new KeyValuePair<string, int>("r63" + (i + 1).ToString() + "_2", 0);
                            }
                            break;
                    }
                }
            }
            //和数大
            matrix[10][0] = new KeyValuePair<string, int>("r637_1", 0);
            //和数小
            matrix[10][1] = new KeyValuePair<string, int>("r637_2", 0);
            //和数单
            matrix[10][2] = new KeyValuePair<string, int>("r636_1", 0);
            //和数小
            matrix[10][3] = new KeyValuePair<string, int>("r636_2", 0);

            return matrix;
        }
    }
}
