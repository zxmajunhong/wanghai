using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using EtNet_BLL.DataPage;

namespace EtNet_Web.Pages.Customers
{
    public partial class AddCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void add_Click(object sender, EventArgs e)
        {
            AddBase();
        }


        /// <summary>
        /// 添加客户信息
        /// </summary>
        private void AddBase()
        {
            //基本信息
            EtNet_Models.Customer cus = new EtNet_Models.Customer();
            cus.CusCode = this.cusCode.Value.ToString();
            cus.CusType = Convert.ToInt32(this.cusType.Value.ToString());
            // cus.Province = this.ddlProvince.SelectedValue;
            //cus.City = this.ddlCity.SelectedValue;

            string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
            cus.Province = addre[0].ToString();
            cus.City = addre[1].ToString();



            cus.CusCName = this.cusCname.Value.ToString();
            cus.CompanyURL = this.comURL.Value.ToString();
            cus.CusCAddress = this.cusCAdd.Value.ToString();
            cus.CusPro = 1;
            cus.CusType = 1;

            //cus.Used = 0;                                                                          

            //联系人                                                                                 
            cus.LinkName = this.linkname.Value.ToString();
            cus.Post = this.linkpost.Value.ToString();
            cus.Telephone = this.linktel.Value.ToString();
            cus.Mobile = this.linkmobile.Value.ToString();
            cus.Fax = this.linkfax.Value.ToString();
            cus.Email = this.linkemail.Value.ToString();
            cus.Msn = this.linkmsn.Value.ToString();
            cus.Skype = this.linkskype.Value.ToString();


            //银行信息
            cus.Bank = this.cusBank.Value.ToString();
            cus.CardId = this.cusBankID.Value.ToString();
            cus.CardName = this.cusBankName.Value.ToString();
            cus.Remark = this.cusRemark.Value.ToString();

            int count = CustomerManager.addCustomer(cus);
            if (count > 0)
            {
                this.none.Text = "1";
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('添加成功')", true);
               // linkman();
                cleardata();
               
            }



        }

      
        private void AddBank()
        {
            //银行信息
            //EtNet_Models.CusBank cusBank = new CusBank();
            //cusBank.CustomerId = CustomerManager.getLastOneID().Id;
            //cusBank.Bank = this.bank.Value.ToString();
            //cusBank.CardName = this.cardName.Value.ToString();
            //cusBank.Remark = this.remark.Value.ToString();
            //cusBank.CardId = this.cardId.Value.ToString();
            //CusBankManager.addCusBank(cusBank);

        }


        private void cleardata()
        {
            this.cusShort.Value = "";
            this.cusCode.Value = "";
            this.cusType.Value = "";
            this.address.Text = "";
            this.cusCname.Value = "";
            this.comURL.Value = "";
            this.cusCAdd.Value = "";
            this.linkname.Value = "";
            this.linkpost.Value = "";
            this.linktel.Value = "";
            this.linkmobile.Value = "";
            this.linkfax.Value = "";
            this.linkemail.Value = "";
            this.linkmsn.Value = "";
            this.linkskype.Value = "";
            this.cusBank.Value = "";
            this.cusBankID.Value = "";
            this.cusBankName.Value = "";
            this.cusRemark.Value = "";

        }



        private void linkman()
        {
            string id = CustomerManager.getLastOneID().Id.ToString();
            IList<CusLinkman> cusLinkman = CusLinkmanManager.getCusLinkmanByCusId(Convert.ToInt32(id));
            if (cusLinkman.Count == 0)
            {
                tip.InnerHtml = "<div style='line-height:60px;height:60px;width:100%;text-align:center;'><p style='color:gray;width:200px;margin:0 auto;background:#FFFFFF;border:solid 0px #ccc; text-algin:center'>暂无联系人信息<p></div>";
            }
            else
            {
                linklist.DataSource = cusLinkman;
            }
            linklist.DataBind();
        }
    }
}