using Autopk.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopk.WebPage
{
    public class FillNumber
    {
        //611;612;613;614;615;616;617;618;619;620;621;622;623;624;625;626;627;628;629;630;631;632;633;634;635;636;637;";//27
        //var x = document.getElementsByName("r622_1");x[0].value='1'; //下注钱.
        public const string TAG = "FillNumber";
     
        public string SetNums(Dictionary<string, int>[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var ___name;");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                   
                    if (matrix[i][j].ElementAt(0).Value > 0)
                    {
                        sb.Append("___name = document.getElementsByName(\"" + matrix[i][j].ElementAt(0).Key +
                            "\");___name[0].value='" + matrix[i][j].ElementAt(0).Value + "';");
                    }
                }
            }

            return sb.ToString();
        }

        private const int MAX_MATRIX_D1 = 11;
        public Dictionary<string, int>[][] CreateEmptyMatrix()
        {
            // maxtrix[第几名,如冠军][下注类型.如大,单] == Dictionary<name r621_, 下注金额>                    
            Dictionary<string, int>[][] matrix = new Dictionary<string, int>[MAX_MATRIX_D1][];

            // step 1. init.size
            for (int i = 0; i < MAX_MATRIX_D1; i++)
            {
                if (i < 6)
                {  //大
                    matrix[i] = new Dictionary<string, int>[6];
                }else
                {
                    matrix[i] = new Dictionary<string, int>[4];
                }
            }
            //1-10 大.
            for (int i = 0; i < matrix.Length - 2; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    switch (j)
                    {
                        case 0: // 大
                            matrix[i][j] = new Dictionary<string, int>();
                            matrix[i][j]["r62" + (i+1).ToString() + "_1"] = (0);
                            break;
                        case 1: //小
                            matrix[i][j] = new Dictionary<string, int>();
                            matrix[i][j]["r62" + (i + 1).ToString() + "_2"] = (0);
                            break;
                        case 2://单
                            matrix[i][j] = new Dictionary<string, int>();
                            matrix[i][j]["r61" + (i + 1).ToString() + "_1"] = (0);
                            break;
                        case 3: //双
                            matrix[i][j] = new Dictionary<string, int>();
                            matrix[i][j]["r61" + (i + 1).ToString() + "_2"] = (0);
                            break;
                        case 4: //龙
                            if (i < 6)
                            {
                                matrix[i][j] = new Dictionary<string, int>();
                                matrix[i][j]["r63" + (i + 1).ToString() + "_1"] = (0);
                            }
                            break;
                        case 5: // 虎
                            if (i < 6)
                            {
                                matrix[i][j] = new Dictionary<string, int>();
                                matrix[i][j]["r63" + (i + 1).ToString() + "_2"] = (0);
                            }
                            break;
                    }
                }
            }
            //10 begain
            matrix[9][0] = new Dictionary<string, int>();
            matrix[9][0]["r630_1"] = (0);
            //和数小
            matrix[9][1] = new Dictionary<string, int>();
            matrix[9][1]["r630_2"] = (0);
            //和数单
            matrix[9][2] = new Dictionary<string, int>();
            matrix[9][2]["r620_1"] = (0);
            //和数小
            matrix[9][3] = new Dictionary<string, int>();
            matrix[9][3]["r620_2"] = (0);
            //10 over


            //11 begain
            //和数大
            matrix[10][0] = new Dictionary<string, int>();
            matrix[10][0]["r637_1"] = (0);

            //和数小
            matrix[10][1] = new Dictionary<string, int>();
            matrix[10][1]["r637_2"] = (0);
            //和数单
            matrix[10][2] = new Dictionary<string, int>();
            matrix[10][2]["r636_1"] = (0);
            //和数小
            matrix[10][3] = new Dictionary<string, int>();
            matrix[10][3]["r636_2"] = (0);

            return matrix;
        }
    }
}
