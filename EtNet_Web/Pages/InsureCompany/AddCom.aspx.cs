using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.InsureCompany
{
    public partial class AddCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(((LoginInfo)Session["Login"]).Id).Cname;
                this.lblMadeTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                //bindList();
                IsEditCuscode();
            }
        }



        /// <summary>
        /// 客户代码字段是否填写
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1") //流水号
            {
                this.comCode.Disabled = true;
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
        /// 检验是否能成功产生公司代码名称
        /// </summary>
        /// <param name="strcuscode">输入的公司代码</param>
        /// <param name="cuscode">公司代码全称</param>
        /// <param name="codeformat">>公司代码不包含流水号</param>
        /// <param name="ordernum">流水号</param>
        private bool StrNumbers(string strcuscode, out string cuscode, out string codeformat, out string ordernum)
        {
            bool result = true;
            cuscode = ""; //公司代码全称
            codeformat = ""; //名称，不包含流水号
            ordernum = ""; //流水号

            DataTable tbl = GetModuleCoding(); //自动编码
            string txtformat = tbl.Rows[0]["txtformat"].ToString(); //名称的格式
            string usecode = tbl.Rows[0]["usecode"].ToString(); //流水号
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString()); //流水号长度


            DataTable custbl = null;
            string strsql = ""; //查询字符窜
            if (usecode == "0")
            {
                if (strcuscode.Trim() != "")
                {
                    strsql = "  comCode ='" + strcuscode + "'"; //判断是否存在相同公司代码的
                    custbl =   CompanyManager.GetList(strsql);
                    if (custbl.Rows.Count != 0)
                    {
                        result = false;
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,公司代码已存在!')</script>");
                    }
                    else
                    {
                        cuscode = strcuscode; //公司代码全称
                    }
                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,公司代码不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //名称
                strsql = "  codeformat= '" + codeformat + "' AND LEN(ordernum) =" + len.ToString();
                custbl = CompanyManager.GetList(1, strsql, " id desc ");

                if (custbl.Rows.Count >= 1)
                {
                    if (custbl.Rows[0]["ordernum"].ToString() != "")
                    {
                        num = int.Parse(custbl.Rows[0]["ordernum"].ToString()) + 1; //流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,流水号长度不够!')</script>");
                        }

                    }
                }
                ordernum = num.ToString().PadLeft(len, '0'); //流水号
                cuscode = codeformat + ordernum; //公司代码全称
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









        /// <summary>
        /// 添加基本信息
        /// </summary>
        private void addBase()
        {
            string cuscode =""; //公司代码
            string codeformat =""; //公司代码不包含流水号
            string ordernum = ""; //流水号

            if (StrNumbers(this.comCode.Value, out cuscode, out codeformat, out ordernum))
            {

                //基本信息
                EtNet_Models.Company com = new Company();
                com.ComCode = cuscode;
                com.Codeformat = codeformat;
                com.Ordernum = ordernum;

                // com.Province = this.ddlProvince.SelectedValue;
                //com.City = this.ddlCity.SelectedValue;

                string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');//省份城市
                com.Province = addre[0].ToString();//省份
                com.City = addre[1].ToString();//城市


                com.ComShortName = this.comshort.Value.ToString(); //公司简称
                com.ComCname = this.comCName.Value.ToString(); //公司全称
                com.ComUrl = this.companyURL.Value.ToString(); //公司网址
                com.ComCAddress = this.comCAddress.Value.ToString(); //公司地址
                //com.ComPro = Convert.ToInt32(this.ddlList.SelectedItem.Value);
                if (this.HidTypeID.Value == "") //公司类别id判断公司类别时常联系还是。。。。
                {
                    com.ComType = 0;
                }
                else
                {
                    com.ComType = Convert.ToInt32(this.HidTypeID.Value);
                }
                

                com.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value); //得到是否启用

                //联系人                                                                                 
                com.LinkName = this.linkName.Value.ToString(); //联系人名
                com.Post = this.linkPost.Value.ToString(); //联系人所属职务
                com.Telephone = this.linkTel.Value.ToString(); //联系人联系电话
                com.Mobile = this.linkMobile.Value.ToString(); //联系人手机号码
                com.Fax = this.linkFax.Value.ToString(); //联系人传真
                com.Email = this.linkEmail.Value.ToString(); //联系人邮箱地址
                com.Msn = this.linkMsn.Value.ToString(); //联系人QQ
                com.Skype = this.linkSkype.Value.ToString(); //联系人skype

                com.Madefrom = ((LoginInfo)Session["login"]).Id; //制单人员id
                com.MadeTime = DateTime.Now; //制单时间
                //银行信息
                com.Bank = this.bankName.Value.ToString(); //开户银行
                com.CardId = this.bankCard.Value.ToString(); //银行账号
                com.CardName = this.bankMan.Value.ToString(); //开户户名
                com.Remark = this.bankremark.Value.ToString(); //银行备注

                int count = CompanyManager.addCompany(com);
                if (count > 0)
                {
                    addcomlink();
                    addcombank();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');location.href='../InsureCompany/Insure.aspx'", true);
                }
            }
        }





        /// <summary>
        /// 添加次要联系人
        /// </summary>
        private void addcomlink()
        {
            string strList = this.hidlink.Value; //得到次要联系人信息
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.ComLinkman comLink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); } //判断是否有多行数据
                else { row = new string[1] { strList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    comLink = new ComLinkman();
                    cell = row[i].Split('|');
                    comLink.LinkName = cell[0]; //联系人
                    comLink.Post = cell[1]; //职务
                    comLink.Telephone = cell[2]; //联系电话
                    comLink.Fax = cell[3]; //联系传真
                    comLink.Mobile = cell[4]; //手机
                    comLink.Email = cell[5]; //电子邮件
                    comLink.Msn = cell[6]; //QQ
                    comLink.Skype = cell[7]; //Skype
                    comLink.CompanyId = CompanyManager.getLastOneID().Id; //得到公司信息中最后面的一个id数据，也就是刚刚添加的公司信息的id
                    ComLinkmanManager.addComLinkman(comLink); //添加次要联系人

                }
            }
        }


        /// <summary>
        /// 添加其他银行
        /// </summary>
        private void addcombank()
        {
            string banklist = this.hidbank.Value; //得到其他银行信息
            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.ComBank combank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                for (int i = 0; i < row.Length; i++)
                {
                    combank = new ComBank();
                    cell = row[i].Split('|');
                    combank.Bank = cell[0]; //开户银行
                    combank.CardId = cell[1]; //银行账号
                    combank.CardName = cell[2]; //户名
                    combank.Remark = cell[3]; //备注
                    combank.CompanyId = CompanyManager.getLastOneID().Id;
                    ComBankManager.addComBank(combank);

                }
            }
        }




        //绑定公司类别
        //private void bindList()
        //{
        //    this.ddlList.Items.Clear();
        //    IList<ComType> typelist = ComTypeManager.getComTypeAll();
        //    foreach (var item in typelist)
        //    {
        //        ListItem list = new ListItem(item.TypeName, item.Id.ToString());
        //        this.ddlList.Items.Add(list);
        //    }
        //    ListItem ltem = new ListItem("选择类别", "-1");//添加第一行默认值
        //    this.ddlList.Items.Insert(0, ltem);//添加第一行默认值
        //}

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string comCode = this.comCode.Value.ToString(); //公司代码
            string comShortName = this.comshort.Value.ToString(); //公司简称
            string comCname = this.comCName.Value.ToString(); //公司全称
            string str = "";
            //if (CompanyManager.getCode(comCode))
            //{
            //    str += "公司代码已存在\\n";
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            //    return;
            //}
            //判断公司简称是否存在
            if (CompanyManager.getSName(comShortName,0))
            {
                str += "公司简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            //判断公司全称是否存在
            if (CompanyManager.getCName(comCname,0))
            {
                str += "公司全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            addBase();


        }



        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../InsureCompany/Insure.aspx");
        }




    }
}