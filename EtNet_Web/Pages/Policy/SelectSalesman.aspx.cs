using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Policy
{
    public partial class SelectSalesman : System.Web.UI.Page
    {
        public string NodesData = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hiddepartid.Value = Request.QueryString["depart"];
            List<string> treenodes = new List<string>();

            IList<DepartmentInfo> departmentList = DepartmentInfoManager.getDepartmentInfoAll();

            foreach (DepartmentInfo deparment in departmentList)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'open':'true','nocheck':'true','icon':'../../images/public/folder_user.gif'}}",
                                       "dp" + deparment.Departid, 0, deparment.Departcname);
                treenodes.Add(node);
            }

            IList<LoginInfo> loginList = LoginInfoManager.getLoginInfoAll();

            foreach (LoginInfo login in loginList)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'open':'true','nocheck':'true','icon':'../../images/public/group.gif'}}",
                                       login.Id, "dp" + login.Departid, login.Cname);
                treenodes.Add(node);
            }

            NodesData = string.Join(",", treenodes.ToArray());
        }
    }
}