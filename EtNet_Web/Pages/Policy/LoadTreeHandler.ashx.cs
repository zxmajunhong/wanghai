using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using System.Text;

namespace EtNet_Web.Pages.Policy
{
    /// <summary>
    /// LoadTreeHandler 的摘要说明
    /// </summary>
    public class LoadTreeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<string> treenodes = new List<string>(); //存储列表数据

            object id = context.Request.QueryString["id"]; //根据id值查找该公司下的险种数据
            if (id == null || id.ToString() == string.Empty)
            {
                context.Response.Write("{'id':'1','pid':'0','name':'暂无数据'}");
                context.Response.End();
            }

            ProductTypeManager proType = new ProductTypeManager();

            DataTable dt = proType.GetAllList();

            IList<CompanyProd> comList = CompanyProdManager.GetListByPro(Convert.ToInt32(id));
            if (comList.Count == 0)
            {
                context.Response.Write("[{'id':'1','pid':'0','name':'暂无数据','nocheck':'true'}]");
                context.Response.End();
            }

            StringBuilder ids = new StringBuilder();
            foreach (CompanyProd com in comList)
            {
                ids.Append("'");
                ids.Append(com.ProdTypeId);
                ids.Append("',");
            }

            DataRow[] rows = dt.Select(string.Format("ProdTypeNo in ({0}) ", ids.ToString().TrimEnd(',')));

            List<string> parentList = new List<string>();
            DataRow[] parents = dt.Select(string.Format("ParentId='0'"));
            foreach (DataRow parent in parents)
            {
                parentList.Add(parent["ProdTypeNo"].ToString().Trim());
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'open':'true','nocheck':'true'}}",
                                       parent["ProdTypeNo"].ToString().Trim(), parent["ParentId"].ToString().Trim(), parent["ProdTypeName"]);
                treenodes.Add(node);
            }

            foreach (DataRow row in rows)
            {
                if (HasChildren(row["ProdTypeNo"]))
                    continue;
                string parent = "";
                foreach (string item in parentList)
                {
                    if (row["ParentId"].ToString().StartsWith(item))
                    {
                        parent = item;
                        break;
                    }
                }
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}'}}",
                                       row["ProdTypeNo"].ToString().Trim(), parent, row["ProdTypeName"]);
                treenodes.Add(node);
            }
            string NodesData = string.Join(",", treenodes.ToArray());

            context.Response.Write("[" + NodesData + "]");
            context.Response.End();
        }

        private bool HasChildren(object pid)
        {
            ProductTypeManager proType = new ProductTypeManager();
            DataTable dt = proType.GetList(string.Format("ParentId='{0}'", pid));
            return dt.Rows.Count > 0 ? true : false;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}