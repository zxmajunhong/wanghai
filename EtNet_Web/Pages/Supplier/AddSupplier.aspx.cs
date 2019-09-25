using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Supplier
{
    public partial class AddSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(((LoginInfo)Session["Login"]).Id).Cname;
                this.lblMadeTime.Value = DateTime.Now.ToString("yyyy-MM-dd");

                IsEditCuscode();
            }
        }
        /// <summary>
        /// 付款单位代码字段是否填写
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1") //流水号
            {
                this.factCode.Disabled = true;
                this.txtshow.InnerHtml = "(自动生成)";
            }
            else
            {
                this.txtshow.InnerHtml = "*";
            }
        }

        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00002'";
            DataTable tbl = ModuleCodingInfoManager.GetList(strsql);
            if (tbl.Rows.Count == 1)
            {
                return tbl;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 检验是否能成功产生单据名称
        /// </summary>
        /// <param name="cuscode">输入的付款单位代码</param>
        /// <param name="cname">付款单位代码全称</param>
        /// <param name="attachment">>付款单位代码不包含流水号</param>
        /// <param name="txt">流水号</param>
        private bool StrNumbers(string strcuscode, out string cuscode, out string codeformat, out string ordernum)
        {
            bool result = true;
            cuscode = ""; //付款单位代码全称
            codeformat = ""; //名称，不包含流水号
            ordernum = ""; //流水号

            DataTable tbl = GetModuleCoding(); //自动编码
            string txtformat = tbl.Rows[0]["txtformat"].ToString(); //名称的格式
            string usecode = tbl.Rows[0]["usecode"].ToString(); //流水号
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString()); //流水号长度

            DataTable facttbl = null;
            string strsql = ""; //查询字符窜
            if (usecode == "0")
            {
                if (strcuscode.Trim() != "")
                {
                    strsql = "  factCode ='" + strcuscode + "'";
                    facttbl = FactoryManager.getList(strsql);
                    //custbl = CustomerManager.GetList(strsql);
                    if (facttbl.Rows.Count != 0)
                    {
                        result = false;
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败, 付款单位代码已存在!')</script>");
                    }
                    else
                    {
                        cuscode = strcuscode; //付款单位代码全称
                    }
                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,付款单位代码不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //名称
                strsql = "  codeformat= '" + codeformat + "' AND LEN(ordernum) =" + len.ToString();
                facttbl = FactoryManager.GetList(1, strsql, " id desc ");

                if (facttbl.Rows.Count >= 1)
                {
                    if (facttbl.Rows[0]["ordernum"].ToString() != "")
                    {
                        num = int.Parse(facttbl.Rows[0]["ordernum"].ToString()) + 1; //流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,流水号长度不够!')</script>");
                        }

                    }
                }
                ordernum = num.ToString().PadLeft(len, '0'); //流水号
                cuscode = codeformat + ordernum; //付款单位代码全称
            }
            return result;
        }





        /// <summary>
        /// 返回名称,不包含流水号
        /// </summary>
        private string Numbers(string txtformat)
        {
            string result = ""; //返回的名称        
            if (txtformat.Contains("[YYYY]"))
            {
                txtformat = txtformat.Replace("[YYYY]", DateTime.Now.ToString("yyyy"));
            }
            if (txtformat.Contains("[YY]"))
            {
                txtformat = txtformat.Replace("[YY]", DateTime.Now.ToString("yy"));
            }
            if (txtformat.Contains("[MM]"))
            {
                txtformat = txtformat.Replace("[MM]", DateTime.Now.ToString("MM"));
            }
            if (txtformat.Contains("[DD]"))
            {
                txtformat = txtformat.Replace("[DD]", DateTime.Now.ToString("dd"));
            }
            result = txtformat;
            return result;
        }







        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string factCode = this.factCode.Value.ToString();
            string factshortname = this.cusshortname.Value.ToString();
            string factCName = this.cusCName.Value.ToString();

            string str = "";
            //if (CustomerManager.getCode(cusCode, 0))
            //{
            //    str += "付款单位代码已存在\\n";
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            //    return;
            //}
            if (FactoryManager.getSName(factshortname, 0))
            {
                str += "付款单位简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            if (FactoryManager.getCName(factCName, 0))
            {
                str += "付款单位全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);

        }




        /// <summary>
        /// 添加付款单位信息
        /// </summary>
        private void AddBase(string sort)
        {
            string cuscode = "";  //公司代码全称
            string codeformat = ""; //公司代码，不包含流水号
            string ordernum = "";  //流水号
            if (StrNumbers(this.factCode.Value, out cuscode, out codeformat, out ordernum))
            {

                EtNet_Models.JobFlow model = new JobFlow();
                model.attachment = codeformat;
                model.txt = ordernum;
                model.cname = cuscode;
                model.sort = "03"; //付款单位管理申请
                model.auditsort = "";
                model.auditstatus = "01";
                model.createtime = DateTime.Now; //默认是当前时间
                model.endtime = DateTime.Now;
                model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id     
                //model.ruleid = int.Parse(this.ddlrule.SelectedValue);
                //if (sort == "save")
                //{
                //    model.savestatus = "草稿";
                //}
                //else
                //{
                //    model.savestatus = "已提交";
                //}
                //int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(model); //工作流的id值
                //基本信息
                EtNet_Models.Factory fact = new EtNet_Models.Factory();
                fact.FactCode = cuscode;
                fact.Codeformat = codeformat;
                fact.Ordernum = ordernum;
                fact.FactType = Convert.ToInt32(this.HidTypeID.Value);
                // cus.Province = this.ddlProvince.SelectedValue;
                //cus.City = this.ddlCity.SelectedValue;
                fact.FactshortName = this.cusshortname.Value.ToString();
                string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
                fact.Province = addre[0].ToString();
                fact.City = addre[1].ToString();


                fact.FactCName = this.cusCName.Value.ToString();
                fact.FactCAddress = this.cusCAddress.Value.ToString();
                fact.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);

                //联系人                                                                                 
                fact.LinkeName = this.linkName.Value.ToString();
                fact.Duty = this.linkPost.Value.ToString();
                fact.Telephone = this.linkTel.Value.ToString();
                fact.Mobile = this.linkMobile.Value.ToString();
                fact.Fax = this.linkFax.Value.ToString();
                fact.Email = this.linkEmail.Value.ToString();
                fact.QQ = this.linkMsn.Value.ToString();
                fact.Skype = this.linkSkype.Value.ToString();


                //银行信息
                fact.Bank = this.bankName.Value.ToString();
                fact.AccountID = this.bankCard.Value.ToString();
                fact.AccountName = this.bankMan.Value.ToString();
                fact.Remark = this.bankremark.Value;
                fact.Inputname = ((LoginInfo)Session["login"]).Id;
                fact.Inputdate = DateTime.Now;
                int count = FactoryManager.addFactory(fact);
                if (count > 0)
                {

                    addlink();
                    addbank();

                    if (sort == "save")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');location.href='../Supplier/Supplier.aspx'", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('送审成功！');location.href='../Supplier/Supplier.aspx'", true);
                    }
                }
            }
        }



        //次要联系人
        private void addlink()
        {
            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.FactLinkman factLink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    factLink = new EtNet_Models.FactLinkman();
                    cell = row[i].Split('|');
                    factLink.LinkName = cell[0];
                    factLink.Duty = cell[1];
                    factLink.Telephone = cell[2];
                    factLink.Fax = cell[3];
                    factLink.Mobile = cell[4];
                    factLink.Email = cell[5];
                    factLink.QQ = cell[6];
                    factLink.Skype = cell[7];
                    factLink.FactId = FactoryManager.getLastOneID().Id;
                    FactLinkmanManager.addFactLinkman(factLink);
                }
            }
        }

        //其他银行
        private void addbank()
        {
            string banklist = this.hidbank.Value;
            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.FactBank factbank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                for (int i = 0; i < row.Length; i++)
                {
                    factbank = new EtNet_Models.FactBank();
                    cell = row[i].Split('|');
                    factbank.Bank = cell[0];
                    factbank.AccountId = cell[1];
                    factbank.AccountName = cell[2];
                    factbank.Remark = cell[3];
                    factbank.FactId = FactoryManager.getLastOneID().Id;
                    FactBankManager.addFactBank(factbank);

                }
            }
        }






        //送审
        protected void imgbtnaudisend_Click(object sender, ImageClickEventArgs e)
        {
            string factCode = this.factCode.Value.ToString();
            string factshortname = this.cusshortname.Value.ToString();
            string factCName = this.cusCName.Value.ToString();

            string str = "";
            //if (CustomerManager.getCode(cusCode, 0))
            //{
            //    str += "付款单位代码已存在\\n";
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            //    return;
            //}
            if (FactoryManager.getSName(factshortname, 0))
            {
                str += "付款单位简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;

            }
            if (FactoryManager.getCName(factCName, 0))
            {
                str += "付款单位全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Supplier/" + Request.QueryString["backURL"]);
        }

    }
}