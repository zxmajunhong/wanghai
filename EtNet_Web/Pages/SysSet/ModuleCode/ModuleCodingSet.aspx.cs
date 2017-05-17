using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.SysSet.ModuleCode
{
    public partial class ModuleCodingSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadModuleCodingData();
            }
        }


        /// <summary>
        /// 加载自动编码模块的数据
        /// </summary>
        private void LoadModuleCodingData()
        {
            DataTable tbl = EtNet_BLL.ModuleCodingInfoManager.GetList("");
            this.rptdata.DataSource = tbl;
            this.rptdata.DataBind();
        }

        //检测自动编码是否启用
        public bool TestChecked(string usecode)
        {
            if (usecode == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            CheckBox box = null;
            TextBox tbx = null;
            EtNet_Models.ModuleCodingInfo model = EtNet_BLL.ModuleCodingInfoManager.GetModel(id);
            if (model != null)
            {
                box = e.Item.Controls[1] as CheckBox;   
                if (box != null)
                {
                    if (box.Checked)
                    {
                        model.usecode = 1;
                        model.usetxt = "启用";
                        
                    }
                    else
                    {
                        model.usecode = 0;
                        model.usetxt = "禁用";
                    }
                }

                tbx = e.Item.Controls[3] as TextBox;
                if (tbx != null)
                {
                    model.txtformat = tbx.Text;
                    if (model.usecode == 1 && model.txtformat =="")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", "<script>alert('编辑失败,表达式不能为空!')</script>", false);
                        return;
                    }
                   
                }

                tbx = e.Item.Controls[5] as TextBox;
                if (tbx != null)
                {
                    model.orderlen = int.Parse(tbx.Text);
                }
                model.createtime = DateTime.Now;
                if (EtNet_BLL.ModuleCodingInfoManager.Update(model))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", "<script>alert('编辑成功!')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", "<script>alert('编辑失败!')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", "<script>alert('编辑失败!')</script>", false);
                LoadModuleCodingData();
            }
           
        }


    }
}