using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 页面数据校验类
    /// Copyright (C) Maticsoft 2004-2011
    /// </summary>
    public class PageValidate
    {
        private static Regex RegString = new Regex("^[_a-zA-Z]+[a-zA-Z0-9]*$");
        private static Regex RegPhone = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegPosiNumber = new Regex("^[1-9][0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegEn = new Regex("^[a-zA-Z]*$");
        private static Regex RegAge = new Regex("^(?:[1-9][0-9]?|1[01][0-9]|120)$");

        public PageValidate()
        {
        }



        #region 数字字符串检查
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否字符串
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsString(string inputData)
        {
            Match m = RegString.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否英文
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsEn(string inputData)
        {
            Match m = RegEn.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否年龄
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsAge(string inputData)
        {
            Match m = RegAge.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 检查Request查询字符串的键值，是否是数字，最大长度限制
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request的键值</param>
        /// <param name="maxLen">最大长度</param>
        /// <returns>返回Request查询字符串</returns>
        public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
        {
            string retVal = string.Empty;
            if (inputKey != null && inputKey != string.Empty)
            {
                retVal = req.QueryString[inputKey];
                if (null == retVal)
                    retVal = req.Form[inputKey];
                if (null != retVal)
                {
                    retVal = SqlText(retVal, maxLen);
                    if (!IsNumber(retVal))
                        retVal = string.Empty;
                }
            }
            if (retVal == null)
                retVal = string.Empty;
            return retVal;
        }
        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否正整数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsPosiNumber(string inputData)
        {
            Match m = RegPosiNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 邮件地址
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 日期格式判断
        /// <summary>
        /// 日期格式字符串判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    DateTime.Parse(str);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 其他

        /// <summary>
        /// 检查字符串最大长度，返回指定长度的串
        /// </summary>
        /// <param name="sqlInput">输入字符串</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>			
        public static string SqlText(string sqlInput, int maxLength)
        {
            if (sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)//按最大长度截取字符串
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }
        /// <summary>
        /// 字符串编码
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }
        /// <summary>
        /// 设置Label显示Encode的字符串
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="txtInput"></param>
        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = HtmlEncode(txtInput);


        }
        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }
        //字符串清理
        public static bool SubmitError(string ElementTip, string inputString,  int? minLength = null,int? maxLength=null, string format = "all")
        {
            ElementTip = "<div class=\"yz_tip_tit\">" + ElementTip +"</div>";
            string tipcon = "<div class=\"yz_tip_con\">";
            bool re = false;
            inputString = inputString.Trim();
            int inputLength = inputString.Length;
            if (minLength != null && maxLength == null && inputLength < minLength)
            {
                InputError(ElementTip + tipcon + "长度不得少于 " + minLength + " 位");
            }
            if (minLength == null && maxLength != null && inputLength > maxLength)
            {
                InputError(ElementTip + tipcon + "长度不得大于 " + maxLength + " 位");
            }
            if (minLength != null && maxLength != null && inputLength < minLength || inputLength > maxLength)
            {
                InputError(ElementTip + tipcon + "长度必须在 [" + minLength + "-" + maxLength + "] 位之间");
            }
            if (minLength != null && maxLength != null && maxLength == minLength && (inputLength > maxLength || inputLength < minLength))
            {
                InputError(ElementTip + tipcon + "长度必须是 " + minLength + " 位");
            }

            if (format != "all")
            {
                switch (format)
                {
                    case ("email"): if (IsEmail(inputString)) { re = true; } else { InputError(ElementTip + tipcon + "不合Email格式</div>"); }; break;
                    case ("int"): if (IsNumber(inputString)) { re = true; } else { InputError(ElementTip + tipcon + "不合整数格式</div>"); }; break;
                    case ("phone"): if (IsPhone(inputString)) { re = true; } else { InputError(ElementTip + tipcon + "不合电话格式</div>"); }; break;
                    case ("string"): if (IsString(inputString)) { re = true; } else { InputError(ElementTip + tipcon + "不合字符串格式</div>"); }; break;
                    case ("en"): if (IsEn(inputString)) { re = true; } else { InputError(ElementTip + tipcon + "不合英文格式</div>"); }; break;
                    case ("age"): if (IsAge(inputString)) { re = true; } else { InputError(ElementTip + tipcon + "不合年龄格式</div>"); }; break;
                }
            }
            else
            {
                re = true;
            }
            return re;
        }
        private static void InputError(string ElementTip)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">window.parent.res_error('" + ElementTip + "');</script>");
            HttpContext.Current.Response.End();
        }
        public static void SubmitSuccess(string LinkUrl="", string title = "提示", string content = "操作成功！")
        {
            if (LinkUrl == "")
            {
                Common.URL url = new URL();
                LinkUrl = url.StaticPageName();
            }
         
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">window.parent.res_ok('" + LinkUrl + "','" + title + "','"+content+"');</script>");
            HttpContext.Current.Response.End();
        }
        public static void SubmitTip( string content = "操作失败！")
        {
            string ElementTip = "<div class=\"yz_tip_tit\">" + content + "</div>";
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">window.parent.res_error('" + ElementTip + "');</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }
        /// <summary>
        ///解析html成 普通文本
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }

        public static string SqlTextClear(string sqlText)
        {
            if (sqlText == null)
            {
                return null;
            }
            if (sqlText == "")
            {
                return "";
            }
            sqlText = sqlText.Replace(",", "");//去除,
            sqlText = sqlText.Replace("<", "");//去除<
            sqlText = sqlText.Replace(">", "");//去除>
            sqlText = sqlText.Replace("--", "");//去除--
            sqlText = sqlText.Replace("'", "");//去除'
            sqlText = sqlText.Replace("\"", "");//去除"
            sqlText = sqlText.Replace("=", "");//去除=
            sqlText = sqlText.Replace("%", "");//去除%
            sqlText = sqlText.Replace(" ", "");//去除空格
            return sqlText;
        }
        #endregion

        #region 是否由特定字符组成
        public static bool isContainSameChar(string strInput)
        {
            string charInput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                charInput = strInput.Substring(0, 1);
            }
            return isContainSameChar(strInput, charInput, strInput.Length);
        }

        public static bool isContainSameChar(string strInput, string charInput, int lenInput)
        {
            if (string.IsNullOrEmpty(charInput))
            {
                return false;
            }
            else
            {
                Regex RegNumber = new Regex(string.Format("^([{0}])+$", charInput));
                //Regex RegNumber = new Regex(string.Format("^([{0}]{{1}})+$", charInput,lenInput));
                Match m = RegNumber.Match(strInput);
                return m.Success;
            }
        }
        #endregion

        #region 检查输入的参数是不是某些定义好的特殊字符：这个方法目前用于密码输入的安全检查
        /// <summary>
        /// 检查输入的参数是不是某些定义好的特殊字符：这个方法目前用于密码输入的安全检查
        /// </summary>
        public static bool isContainSpecChar(string strInput)
        {
            string[] list = new string[] { "123456", "654321" };
            bool result = new bool();
            for (int i = 0; i < list.Length; i++)
            {
                if (strInput == list[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion

    }
}
