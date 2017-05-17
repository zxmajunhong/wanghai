using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectUser : System.Web.UI.Page
    {
        public string NodesData = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> treenodes = new List<string>();

            IList<DepartmentInfo> departmentList = DepartmentInfoManager.getDepartmentInfoAll();

            foreach (DepartmentInfo deparment in departmentList)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}','isParent':'true', 'open':'true','icon':'../../images/public/folder_user.gif'}}",
                                       "dp" + deparment.Departid, 0, deparment.Departcname);
                treenodes.Add(node);
            }

            IList<LoginInfo> loginList = LoginInfoManager.getLoginInfoAll();

            foreach (LoginInfo login in loginList)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'icon':'../../images/public/group.gif'}}",
                                       login.Id, "dp" + login.Departid, login.Cname);
                treenodes.Add(node);
            }

            NodesData = string.Join(",", treenodes.ToArray());
        }
    }
}