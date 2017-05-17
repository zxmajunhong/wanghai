using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.Firm
{
    public partial class AddFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        //保存公司logo图
        private string SaveLogoImg()
        {
            string result = "";
            if (this.iptlogopath.HasFile)
            {
                if (this.iptlogopath.PostedFile.ContentLength < (1024*1024))
                {
                    string strfile = this.iptlogopath.FileName.ToLower();
                    string strpath = "../../UploadFile/Firm/" + DateTime.Now.ToString("yyyyMMddHHmmss") + strfile;
                    this.iptlogopath.SaveAs(Server.MapPath(strpath));
                    result = strpath;     
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ad", "<script>alert('公司logo上传失败,请勿上传大于1M的图!')</script>", false);
                }
            }
            return result;
        }



        //保存银行账号资料
        private void SaveAccount(int firmid)
        {
            string str = this.hidfirm.Value;
            if (str != "")
            {
                string[] list = null;
                if (str.IndexOf('|') != -1)
                {
                    list = str.Split('|');
                }
                else
                {
                    list = new string[1] { str };
                }
                EtNet_Models.FirmAccountInfo model = null;
                string[] alist = null;
                for (int i = 0; i < list.Length; i++)
                {
                   model = new EtNet_Models.FirmAccountInfo();
                   alist = list[i].Split(',');
                   model.bankname = alist[0];
                   model.account = alist[1];
                   model.ystime = DateTime.Parse(alist[2]);
                   model.amount = alist[3] != "" ? decimal.Parse(alist[3]) : 0;
                   model.remark = "";
                   model.firmid = firmid;
                   EtNet_BLL.FirmAccountInfoManager.Add(model);
                }
            }
        }

        /// <summary>
        /// 检测公司代码是否已存在，如存在不允许添加
        /// </summary>
        private bool TestAdd()
        {
            bool isadd = true;
            string stradd = " firmcode='" + this.iptfirmcode.Value.Trim() + "'" ;
            DataTable tbl = EtNet_BLL.FirmInfoManager.GetList(stradd);
            if (tbl.Rows.Count != 0)
            {
                isadd = false;
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(),"addtset","<script>alert('添加失败,公司代码已存在!')</script>");
            }

            return isadd;
        }


        /// <summary>
        /// 添加公司资料
        /// </summary>
        private void SaveFirm()
        {
            if (TestAdd())
            {
                EtNet_Models.FirmInfo model = new EtNet_Models.FirmInfo();
                model.caddress = this.iptcaddress.Value;
                model.cname = this.iptcname.Value;
                model.eaddress = this.ipteaddress.Value;
                model.ename = this.iptename.Value;
                model.fax = this.iptfax.Value;
                model.firmcode = this.iptfirmcode.Value;
                model.imgpath = SaveLogoImg();
                model.mailbox = this.iptmailbox.Value;
                model.orgcode = this.iptorgcode.Value;
                model.postalcode = this.iptpostal.Value;
                model.remark = this.traremark.Value;
                model.sname = this.iptshortname.Value;
                model.taxnum = this.ipttaxnum.Value;
                model.telephone = this.ipttel.Value;
                model.website = this.iptwedsite.Value;
                int id = EtNet_BLL.FirmInfoManager.Add(model);
                SaveAccount(id);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script> window.location ='ShowFirm.aspx'</script>", false);
            }
            else
            {
                this.hidfirm.Value = "";
            }
        }

       
   

        //保存
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            SaveFirm();
        }

        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowFirm.aspx");
        }


    }
}