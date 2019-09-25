using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;

namespace EtNet_Web.Pages.Index
{
    /// <summary>
    /// TopHandler 的摘要说明
    /// </summary>
    public class TopHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.Expires = 0;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "private");
            context.Response.CacheControl = "no-cache";
            SortExecute(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 依据sort参数，导航到不同的功能实现中去
        /// </summary>
        /// <param name="context"></param>
        public void SortExecute(HttpContext context)
        {
            string sort = context.Request.Params["sort"] != null ? context.Request.Params["sort"] : "0";
            string dt = context.Request.Params["dtime"];

            switch (sort)
            {

                case "1":
                    getInformation(context);
                    break;

                case "2":
                    getNewInfo(context);
                    break;

                case "3":
                    getInfoData(context);
                    break;

                case "4":
                    IsCycleInformation(context);
                    break;

            }

        }


        /// <summary>
        /// 指示是否需要显示循环消息显示框
        /// </summary>
        private void IsCycleInformation(HttpContext context)
        {
            string loginid = ((EtNet_Models.LoginInfo)context.Session["login"]).Id.ToString();

            string result = "f"; //f表示无消息,t表示有消息
            string strsql = " recipientid = " + loginid;
            strsql += " AND sendtime <= '" + DateTime.Now.ToString() + "' ";
            strsql += " AND remind='是'";

            DataTable tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(strsql);
            if (tbl.Rows.Count >= 1)
            {
                result = "t";
            }

            string strsetsql = " createrid=" + loginid;
            DataTable tblset = EtNet_BLL.InitializeUserSetManager.GetList(strsetsql);  //获取用户参数
            int count = int.Parse(tblset.Rows[0]["infocycle"].ToString());
            if (count == 0)
            {
                count = 24 * 60 * 60 * 1000;
            }
            else
            {
                count = count * 60 * 1000;
            }
            result = result.ToString() + "_" + count.ToString();


            context.Response.Write(result);


        }






        /// <summary>
        ///获取消息数据描述
        /// </summary>
        private void getInformation(HttpContext context)
        {
            if (context.Session["login"] != null)
            {
                string str = " recipientid =" + ((EtNet_Models.LoginInfo)context.Session["login"]).Id;
                str += "  AND sendtime <= '" + DateTime.Now.ToString() + "'  AND  remind='是'";
                DataTable tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getListCount(str);
                int doc = 0;
                int personal = 0;
                int voucher = 0;
                int item = 0;
                int announcement = 0;  //公告消息数量
                string num = "";

                num += "{total:" + tbl.Rows.Count.ToString() + ",msg:\"";
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    switch (tbl.Rows[i]["sortid"].ToString())
                    {
                        case "1":
                            personal++;
                            break;
                        case "3":
                            doc++;
                            break;
                        case "7":
                            item++;
                            break;
                        case "8":
                            announcement++;
                            break;
                        default:
                            voucher++;
                            break;
                    }
                }
                if (tbl.Rows.Count >= 1)
                {
                    num += "未读";
                }
                else
                {
                    num += "未读消息0条";
                }
                num += personal != 0 ? ("个人消息" + personal + "条") : "";
                num += doc != 0 ? ("文档消息" + doc + "条") : "";
                num += item != 0 ? ("项目消息" + item + "条") : "";
                num += voucher != 0 ? ("审核消息" + voucher + "条") : "";
                num += announcement != 0 ? ("公告消息" + announcement + "条") : "";
                num += "\"}";
                context.Response.Write(num);
            }
            else
            {
                context.Response.Redirect("~/Login.aspx");
            }
        }




        //获取新消息
        private void getNewInfo(HttpContext context)
        {
            if (context.Session["login"] != null)
            {
                string maxid = context.Request.Params["maxid"].ToString();
                string str = " recipientid=" + ((EtNet_Models.LoginInfo)context.Session["login"]).Id;
                str += "  AND id > " + maxid;
                str += "  AND sendtime <= '" + DateTime.Now.ToString() + "' order by id desc";
                DataTable tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(str);
                int len = tbl.Rows.Count;
                string result = "{\"count\":" + len.ToString() + ",\"list\":[";
                for (int i = 0; i < len; i++)
                {
                    result += "{\"txt\":\"内容:" + tbl.Rows[i]["contents"].ToString() + "</br>";
                    result += "来自:" + tbl.Rows[i]["cname"].ToString() + "\"},";
                }
                if (len != 0)
                {
                    result = result.Substring(0, result.Length - 1);
                    result += "],\"mid\":" + tbl.Rows[0]["id"] + "}";
                }
                else
                {
                    result += "],\"mid\":" + maxid + "}";
                }
                context.Response.Write(result);
            }
            else
            {
                context.Response.Redirect("~/Login.aspx");
            }

        }


        /// <summary>
        /// 取没有查看到消息
        /// </summary>
        private void getInfoData(HttpContext context)
        {
            if (context.Session["login"] != null)
            {
                string str = " recipientid=" + ((EtNet_Models.LoginInfo)context.Session["login"]).Id;
                str += " AND sendtime <= '" + DateTime.Now.ToString() + "' AND remind='是' ";

                DataTable tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(str);
                string result = "";
                result += "{\"count\":" + tbl.Rows.Count.ToString() + ",\"list\":[";

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    result += "{\"txt\":\"内容:" + tbl.Rows[i]["contents"].ToString() + "</br>";
                    result += "来自:" + tbl.Rows[i]["cname"].ToString() + "\"},";
                }
                if (tbl.Rows.Count != 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }
                result += "]}";
                context.Response.Write(result);
            }
            else
            {
                context.Response.Redirect("~/Login.aspx");
            }

        }






    }
}