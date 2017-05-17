using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
namespace DbAccess
{
    public class HtmlDataByPage
    {
        /// <summary>
        /// 存储过程分页查询
        /// </summary>
        /// <param name="TableName">表名称</param>
        /// <param name="PrimaryKey">主键名称</param>
        /// <param name="Fields">显示的字段（*代表全部）</param>
        /// <param name="Sql_where">查询条件（and开头）</param>
        /// <param name="OrderItem">排序字段</param>
        /// <param name="Order">升序或降序（true降序 false升序）</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="PageItems">分页控件显示个数</param>
        /// <param name="PageId">分页控件Id</param>
        /// <param name="OutSelectSql">输出sql语句（调试用）</param>
        /// <returns>返回dataset</returns>

     
        public static DataSet DataPage(string connectionString,string TableName, string PrimaryKey, string Fields, string Sql_where, string OrderItem, bool Order, int PageSize, int PageItems, HtmlGenericControl PageId, string NoData = "对不起，暂无数据......", string OutSelectSql = "")
        {
            PageId.Attributes.Add("class", "page");
            int pageIndex = 1;                                    //当前页
            if (HttpContext.Current.Request.QueryString["page"] != null && IsInteger(HttpContext.Current.Request.QueryString["page"]))
            {
                string cpage = HttpContext.Current.Request.QueryString["page"];
                if (IsInteger(cpage))
                {
                    pageIndex = Int32.Parse(cpage);
                }
            }
            int PageCount;  //总页数
            int Counts;     //总记录数
            DataSet ds = new DataSet();
            DbAccess.RunProcedure RunProcedure = new DbAccess.RunProcedure();
            ds = RunProcedure.ReturnPageList(connectionString,"ProcDataPaging", TableName, PrimaryKey, Fields, PageSize, pageIndex, OrderItem, Order, Sql_where, false, out PageCount, out Counts, out OutSelectSql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                PageId.InnerHtml = "<div class='nodata'>"+NoData+"</div>";
            }
            else
            { 
                string FirstPage =numpage(pageIndex,1);
                string PrePage = numpage(pageIndex, pageIndex-1);
                string NextPage = numpage(pageIndex, pageIndex + 1);
                string LastPage = numpage(pageIndex, PageCount);
                if (pageIndex > PageCount)
                {
                    string nava = numpage(pageIndex, PageCount);
                    HttpContext.Current.Response.Redirect(nava);
                }

                int avg_l = 0;
                int avg_r = 0;
                int start = 1;
                int end = PageCount;
                if (PageItems % 2 == 0)
                {
                    avg_l = PageItems / 2;
                    avg_r = (PageItems - 1) / 2;
                }
                else if (PageItems % 2 != 0)
                {
                    avg_l = avg_r = PageItems / 2;
                }
                if (PageItems < PageCount)
                {
                    if (pageIndex - avg_l - 1 <= 0)
                    {
                        end = PageItems;
                    }
                    else if (pageIndex + avg_r > PageCount)
                    {
                        start = PageCount - PageItems + 1;
                    }
                    else
                    {
                        start = pageIndex - avg_l;
                        end = pageIndex + avg_r;
                    }
                }
                PageId.InnerHtml = "<span class='pageleft'>第<strong>" + pageIndex + "</strong>页共<strong>" + PageCount + "</strong>页</span>";
                if (pageIndex == 1)
                {
                    PageId.InnerHtml += "<span class='page_btn'><span>首 页</span><span>上一页</span></span>";
                }
                else
                {
                    PageId.InnerHtml += "<span class='page_btn'><a href='" +  FirstPage + "'>首 页</a><a href='" + PrePage + "'>上一页</a></span>";
                }
                for (int i = start; i <= end; i++)
                {
                    if (i == pageIndex)
                    {
                        PageId.InnerHtml += "<span class='page_now'>" +i + "</span>";
                    }
                    else
                    {
                        PageId.InnerHtml += "<a href='" + numpage(pageIndex,i) + "'>" + i + "</a>";
                    }
                }
                if (pageIndex == PageCount)
                {
                    PageId.InnerHtml += "<span class='page_btn'><span>下一页</span><span>尾 页</span></span>";
                }
                else
                {
                    PageId.InnerHtml += "<span class='page_btn'><a href='" + NextPage + "'>下一页</a><a href='" +LastPage + "'>尾 页</a></span>";
                }
                if (ds.Tables[0].Rows.Count <= 0 || Counts <= PageSize)
                {
                    PageId.Visible = false;
                }
            }
            return ds;
        }
        /// <summary>
        /// 判断字符串是否是整数
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static bool IsInteger(string source)
        {
            if (source == null || source == "")
            {
                return false;
            }
            if (Regex.IsMatch(source, "^[1-9][0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string numpage(int pageIndex, int num)
        {
            string re = "";
            Common.URL url = new Common.URL();
            string items = url.UrlParams;
            string name = url.StaticPageName();
            string[] names = name.Split('.');
            string staticurl = url.StaticUrl;
            string urlleft = staticurl.Substring(0, staticurl.LastIndexOf("/"));
            string urlright = staticurl.Substring(staticurl.LastIndexOf("/"));
            if (HttpContext.Current.Request.QueryString["page"] == null || HttpContext.Current.Request.QueryString["page"] == "")
            {
                re = Common.WebConfig.domain + urlleft + "/page" + num + urlright;
            }
            else
            {
                urlleft = urlleft.Replace("/page" + pageIndex, "");
                re = Common.WebConfig.domain + urlleft + "/page" + num + urlright;
            }
            return re;
        }
    }
}
