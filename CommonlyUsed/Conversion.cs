using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonlyUsed
{
    public class Conversion
    {

       
        /// <summary>
        /// 将“大于小于号”转换为相应的html字符
        /// </summary>
        public static string StrConversion(string str)
        {
            string newstr = str;
            newstr = newstr.Replace("<", "&lt;");
            newstr = newstr.Replace(">", "&gt;");
            return newstr;
            
        }

        /// <summary>
        /// 检测查询条件是否为空，如果不为空返回一个查询恒等式
        /// </summary>
        public  static string ExistsEmpty(string strand)
        {
            string returnstr = "";

            if (strand.Trim() == "")
            {
                returnstr = "";
            }
            else
            {
                returnstr = " 1 = 1 ";
            }
            return returnstr;
        }



        /// <summary>
        /// 日期转换为中文字符串
        /// </summary>
        /// <param name="date">日期参数</param>
        public static string ConversionDate(DateTime date,int sort)
        {
            string result = "";
            switch (sort)
            { 
                case 1:
                    string[] list = new string[13];
                    list[0] = "〇";
                    list[1] = "一";
                    list[2] = "二";
                    list[3] = "三";
                    list[4] = "四";
                    list[5] = "五";
                    list[6] = "六";
                    list[7] = "七";
                    list[8] = "八";
                    list[9] = "九";
                    list[10] = "十";
                    list[11] = "十一";
                    list[12] = "十二";
                   
                   
                    char[] ylist = date.Year.ToString().ToArray();
                    int m = date.Month;
                    char[] dlist = date.Day.ToString().ToArray();


                    foreach (char cy in ylist)
                    {
                        result += list[Convert.ToInt32(cy.ToString())];
                    }
                    result += "年";
                    result += list[m] + "月";

                    if (dlist.Length == 1)
                    {
                        foreach (char cd in ylist)
                        {
                            result += list[Convert.ToInt32(cd.ToString())];
                        }
                        result += "日";
                    }
                    else
                    {
                        if (dlist[0] == '1' && dlist[1] == '0')
                        {
                            result += "十日";
                        }
                        else if (dlist[0] == '1' && dlist[1] != '0')
                        {
                            result += "十" + list[Convert.ToInt32(dlist[1].ToString())] + "日" ;
                        }
                        else if (dlist[0] == '2' && dlist[0] == '0')
                        {
                            result += "二十日";
                        }
                        else if (dlist[0] == '2' && dlist[0] != '0')
                        {
                            result += "二十" + list[Convert.ToInt32(dlist[1].ToString())] + "日";
                        }
                        else if (dlist[0] == '3' && dlist[0] == '0')
                        {
                            result += "三十日";
                        }
                        else if (dlist[0] == '3' && dlist[0] != '0')
                        {
                            result += "三十" + list[Convert.ToInt32(dlist[1].ToString())] + "日";
                        }
                        else { 
                
                        }
                    }
                    break;

                case 2:
                    result = date.Year.ToString() + "年";
                    result += date.Month.ToString() + "月";
                    result += date.Day.ToString() + "日";
                    break;
            
        
            
            }
  
            return result;
        }


      






    }
}
