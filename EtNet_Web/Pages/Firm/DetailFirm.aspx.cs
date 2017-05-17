using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using EtNet_Models;
using EtNet_BLL;

namespace Pages.Firm
{
    public partial class DetailFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadFirmData();
                }
            }
        }


        /// <summary>
        /// 加载公司资料
        /// </summary>
        private void LoadFirmData()
        {
            int id = int.Parse(Request.Params["id"]);
            EtNet_Models.FirmInfo model = EtNet_BLL.FirmInfoManager.GetModel(id);
            string str = "<script>alert('加载数据失败!'); window.location ='ShowFirm.aspx'</script>";
            if (model != null)
            {

                this.lblcaddress.Text = model.caddress;
                this.lblcname.Text = model.cname;
                this.lbleaddress.Text = model.eaddress;
                this.lblename.Text = model.ename;
                this.lblfax.Text = model.fax;
                this.lblfirmcode.Text = model.firmcode;
                this.lblorgcode.Text = model.orgcode;
                this.lblpostal.Text = model.postalcode;
                this.remark.InnerHtml = model.remark;
                this.lblshortname.Text = model.sname;
                this.lbltaxnum.Text = model.taxnum;
                this.lbltel.Text = model.telephone;
                this.lblwedsite.Text = model.website;
                this.lblmailbox.Text = model.mailbox;
                LoadAccountData(id);
                LoadLogoImg(model.imgpath);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "load", str, false);
            }

        }


        /// <summary>
        /// 加载公司logo
        /// </summary>
        /// <param name="path">图片路径</param>
        private void LoadLogoImg(string path)
        {
            if (path.Trim() != "")
            {
                this.imglogopath.Src = path;

            }
            else
            {
                this.imglogopath.Src = "../../UploadFile/Firm/df.gif";
            }
        }




        /// <summary>
        /// 加载银行账户资料
        /// </summary>
        /// <param name="firmid">公司的id值</param>
        private void LoadAccountData(int firmid)
        {
            string strsql = " firmid=" + firmid.ToString();
            DataTable tbl = EtNet_BLL.FirmAccountInfoManager.GetList(strsql);
            //HtmlTableRow row = null;
            //HtmlTableCell cell = null;

            //for (int i = 0; i < tbl.Rows.Count; i++)
            //{
            //    row = new HtmlTableRow();
            //    cell = new HtmlTableCell();
            //    cell.InnerHtml =  tbl.Rows[i]["bankname"].ToString();
            //    row.Cells.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.InnerHtml = tbl.Rows[i]["account"].ToString();
            //    row.Cells.Add(cell);
            //    row.Cells.Add(cell);
            //    this.accountlist.Rows.Add(row);
            //}
            rptAccount.DataSource = tbl;
            rptAccount.DataBind();

        }


        public string getamount(object id)
        {
            int firmid = 0;
            int.TryParse(id.ToString(), out firmid);
            FirmAccountInfo model = FirmAccountInfoManager.GetModel(firmid);
            decimal collect = FirmAccountInfoManager.GetMoneySum(id.ToString(), "1", model.ystime.ToString("yyyy-MM-dd"));
            decimal pay = FirmAccountInfoManager.GetMoneySum(id.ToString(), "0", model.ystime.ToString("yyyy-MM-dd"));

            return (model.amount + collect - pay).ToString();
        }



        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowFirm.aspx");
        }


    }
}