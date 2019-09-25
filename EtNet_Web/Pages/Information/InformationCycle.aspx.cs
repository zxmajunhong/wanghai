using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL.DataPage;

namespace EtNet_Web.Pages.Information
{
    public partial class InformationCycle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InfoCycleSet();
                LoadInformationNoticeData();
            }
        }


        /// <summary>
        /// 消息的循环周期
        /// </summary>
        public void InfoCycleSet()
        {
            string loginid = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strsetsql = " createrid=" + loginid;
            DataTable tbl = EtNet_BLL.InitializeUserSetManager.GetList(strsetsql);  //获取用户参数
            int count = int.Parse(tbl.Rows[0]["infocycle"].ToString());
            if (count == 0)
            {
                count = 24 * 60 * 60 * 1000;
            }
            else
            {
                count = count * 60 * 1000;
            }
            this.hidcycle.Value = count.ToString();
        }


        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='105'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "105";
                pageset.Pagecount = 2;
                pageset.Pageitem = 2;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }


        /// <summary>
        /// 依据消息的id值，查询是否具有附件
        /// </summary>
        public string clsfile(string informationid)
        {
            string strsql = " informationid=" + informationid;
            DataTable tbl = EtNet_BLL.InformationFileManager.GetList(strsql);
            string cls = "";
            if (tbl.Rows.Count >= 1)
            {
                cls = "clsfileshow";
            }
            else
            {
                cls = "clsfilehide";
            }
            return cls;
        }

        /// <summary>
        /// 取消提醒
        /// </summary>
        /// <param name="id">消息通知id值</param>
        private void canelremind(int id)
        {
            EtNet_Models.InformationNotice model = EtNet_BLL.InformationNoticeManager.GetModel(id);
            if (model != null)
            {
                model.remind = "否";
                if (EtNet_BLL.InformationNoticeManager.Update(model))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "remind", "<script>alert('提醒取消成功')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "remind", "<script>alert('提醒取消失败')</script>", false);
                }
            }
        }


       

        protected void rptinformation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "remind":
                    canelremind(int.Parse(e.CommandArgument.ToString()));
                    LoadInformationNoticeData();
                    break;
     
                case "del":
                    int id = int.Parse(e.CommandArgument.ToString()); //通知消息的id值
                    EtNet_BLL.InformationNoticeManager.Delete(id);
                    LoadInformationNoticeData();
                    break;

            }


        }


        //加载数据
        private void LoadInformationNoticeData()
        {
            DataTable strtbl = Exists();
            string strfixed = " AND recipientid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strfixed += " AND sendtime <= '" + DateTime.Now.ToString() + "' ";
            strfixed += " AND remind='是'";

            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());

            EtNet_BLL.DataPage.Data data = new Data();
            DataSet tbl = data.DataPage("ViewInformationNotice", "id", "*", strfixed, "id", true, pitem, pcount, pages);
            this.rptinformation.DataSource = tbl;
            this.rptinformation.DataBind();

        }

        protected void imgdel_Click(object sender, ImageClickEventArgs e)
        {
            CheckBox box = null;
            ImageButton imgbtn = null;
            int id = 0;
            int len = this.rptinformation.Controls.Count;
            for (int i = 0; i < len; i++)
            {
                box = this.rptinformation.Controls[i].Controls[1] as CheckBox;
                imgbtn = this.rptinformation.Controls[i].Controls[5] as ImageButton;
                if (box != null && imgbtn != null)
                {
                    if (box.Checked && imgbtn.CommandArgument != "")
                    {
                        id = int.Parse(imgbtn.CommandArgument.ToString());
                        EtNet_BLL.InformationNoticeManager.Delete(id);
                    }
                }
            }
            LoadInformationNoticeData();
        }


        //取消提醒，阅读状态改为已阅读
        protected void imgread_Click(object sender, ImageClickEventArgs e)
        {

            CheckBox box = null;
            ImageButton imgbtn = null;
            EtNet_Models.InformationNotice model = null;
            int id = 0;
            int len = this.rptinformation.Controls.Count;
            for (int i = 0; i < len; i++)
            {
                box = this.rptinformation.Controls[i].Controls[1] as CheckBox;
                imgbtn = this.rptinformation.Controls[i].Controls[5] as ImageButton;

                if (box != null && imgbtn != null)
                {
                    if (box.Checked && imgbtn.CommandArgument != "")
                    {
                        id = int.Parse(imgbtn.CommandArgument.ToString());
                        model = EtNet_BLL.InformationNoticeManager.GetModel(id);
                        if (model != null)
                        {
                            model.remind = "否";
                            EtNet_BLL.InformationNoticeManager.Update(model);
                        }
                    }

                }
            }
            LoadInformationNoticeData();

        }



    }
}