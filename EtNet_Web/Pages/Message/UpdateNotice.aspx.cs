using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using EtNet_Models;
using System.Data;

namespace Pages.Message
{
    public partial class UpdateNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                createifpublic();
                createattr();
                createsort();
                LoadNotice(); //加载公告数据
            }

        }


        /// <summary>
        /// 创建列表，绑定公告范围下拉控件
        /// </summary>
        public void createifpublic()
        {

            DataTable tblifpublic = new DataTable();
            tblifpublic.Columns.Add("seltxt", typeof(String));
            tblifpublic.Columns.Add("selvalue", typeof(Int32));
            DataRow row = tblifpublic.NewRow();
            row[0] = "-请选中-";
            row[1] = -1;
            tblifpublic.Rows.Add(row);

            row = tblifpublic.NewRow();
            row[0] = "销售部";
            row[1] = 0;
            tblifpublic.Rows.Add(row);

            row = tblifpublic.NewRow();
            row[0] = "企划部";
            row[1] = 1;
            tblifpublic.Rows.Add(row);
            this.selifpublic.DataSource = tblifpublic;
            this.selifpublic.DataTextField = "seltxt";
            this.selifpublic.DataValueField = "selvalue";
            this.selifpublic.DataBind();
        }



        /// <summary>
        /// 创建列表，绑定公告分类下拉控件
        /// </summary>
        public void createsort()
        {

            DataTable tblsort = new DataTable();
            tblsort = EtNet_BLL.SortInfoManager.SortTbl("");
            DataRow row = tblsort.NewRow();
            row["sortid"] = -1;
            row["sortname"] = "-请选中-";
            tblsort.Rows.InsertAt(row, 0);

            this.selsort.DataSource = tblsort;
            this.selsort.DataTextField = "sortname";
            this.selsort.DataValueField = "sortid";
            this.selsort.DataBind();
        }


        /// <summary>
        /// 创建列表，绑定属性下拉控件
        /// </summary>
        public void createattr()
        {

            DataTable tblattr = new DataTable();
            tblattr.Columns.Add("seltxt", typeof(String));
            tblattr.Columns.Add("selvalue", typeof(Int32));
            DataRow row = tblattr.NewRow();
            row[0] = "-请选中-";
            row[1] = -1;
            tblattr.Rows.Add(row);

            row = tblattr.NewRow();
            row[0] = "草稿";
            row[1] = 0;
            tblattr.Rows.Add(row);

            row = tblattr.NewRow();
            row[0] = "通过";
            row[1] = 1;
            tblattr.Rows.Add(row);
            this.selattr.DataSource = tblattr;
            this.selattr.DataTextField = "seltxt";
            this.selattr.DataValueField = "selvalue";
            this.selattr.DataBind();

        }


        /// <summary>
        /// 加载公告数据
        /// </summary>
        public void LoadNotice()
        {
            int id = int.Parse(Request.QueryString["noticeid"]);

            NoticeInfo model = new NoticeInfo();
            model = EtNet_BLL.NoticeInfoManager.getNoticeInfoById(id);
            this.ipthead.Value = model.Title; //公告的标题
            this.iptbegintime.Value = model.Begintime.ToString(); //公告的启示时间
            this.iptendtime.Value = model.Endtime.ToString();  //公告的结束时间
            this.iptaccesfile.Value = model.Accressory; //公告的附件,不可见
            this.lblfromuser.Text = model.Fromuser;
            this.selifpublic.Value = model.Ifpublic.ToString();
            this.selsort.Value = model.Sortid.Sortid.ToString();
            this.selattr.Value = model.Attribute.ToString();
            this.context.Value = model.Context;


        }





        //上传方法
        protected void upFile()
        {
            string saveUrl = "../../UploadFile/Message/";
            string filename = this.fpaccessory.FileName;
            string fileExt = Path.GetExtension(filename).ToLower();
            if (String.IsNullOrEmpty(fileExt))
            {
                // Response.Write("<script>alert('上传失败');</script>");
                ScriptManager.RegisterStartupScript(this.btnUpload, this.btnUpload.GetType(), "no", "alert('上传失败！')", true);
            }
            else
            {
                string newFile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                this.fpaccessory.SaveAs(HttpContext.Current.Server.MapPath(saveUrl + newFile));
                ViewState["FileUrl"] = saveUrl + newFile;
                this.iptaccesfile.Value = ViewState["FileUrl"].ToString(); //保存新上传的文件的路径

                //Response.Write("<script>alert('上传成功');</script>");
                ScriptManager.RegisterStartupScript(this.btnUpload, this.btnUpload.GetType(), "ok", "alert('上传成功！')", true);

            }

        }



        protected void btnUpload_Click(object sender, EventArgs e)
        {
            upFile();//保存文件


        }

        private void Update()
        {

            NoticeInfo model = new NoticeInfo();
            model.Accressory = this.iptaccesfile.Value;
            model.Attribute = int.Parse(this.selattr.Value);
            model.Begintime = DateTime.Parse(this.iptbegintime.Value);
            model.Endtime = DateTime.Parse(this.iptendtime.Value);
            model.Context = this.context.Value;
            model.Fromuser = this.lblfromuser.Text;
            model.Ifpublic = int.Parse(this.selifpublic.Value);
            model.Noticeid = int.Parse(Request.QueryString["noticeid"]);
            model.Sortid = EtNet_BLL.SortInfoManager.getSortInfoById(int.Parse(this.selsort.Value));
            model.Title = this.ipthead.Value;
            int result = EtNet_BLL.NoticeInfoManager.updateNoticeInfo(model);
            if (result >= 1)
            {
                ScriptManager.RegisterStartupScript(this.ibtnfix, this.ibtnfix.GetType(), "okfix", "alert('修改成功！');window.location='Notice.aspx'", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this.ibtnfix, this.ibtnfix.GetType(), "nofix", "alert('修改失败！')", true);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnfix_Click(object sender, ImageClickEventArgs e)
        {
            Update();
        }


        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
        {
            LoadNotice();
        }
    }
}