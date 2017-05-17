using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections;
using EtNet_BLL;

namespace EtNet_Web.Pages.AuditRole
{
    public partial class ModifyAddAuditRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Page.GetPostBackEventReference(selhide);
            if(!IsPostBack)
            {
                selhide.Attributes.Add("onchange", s);
                LoadJobSort();           
                LoadAuditRoleData();

            }
        }



        /// <summary>
        /// 加载工作流的分类数据
        /// </summary>
        private void LoadJobSort()
        {
            DataTable tbl = EtNet_BLL.JobFlowSortManager.GetList("");
            DataRow row = tbl.NewRow();
            row["num"] = "00";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.seljobflowsort.DataSource = tbl;
            this.seljobflowsort.DataTextField = "txt";
            this.seljobflowsort.DataValueField = "num";
            this.seljobflowsort.DataBind();

        }


     

        /// <summary>
        /// 加载审核规则数据
        /// </summary>
        private void LoadAuditRoleData()
        {
            int id = int.Parse( Request.QueryString["id"]);
            EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(id);
            string[] stridgroup = null;
            
            if(model != null)
            {
                this.hidlist.Value = "";
                this.hidaudit.Value = "";
                this.iptcname.Value = model.cname;
                this.selauditsort.Value = model.sort;
                this.seljobflowsort.Value = model.jobflowsort;
                this.iptdepartlist.Value = model.departidtxt;
                this.hiddepartlist.Value = model.departidlist;
                this.teratxt.Value = model.txt;
                this.iptfile.Value = model.rolepic;
                this.selhide.Value = model.showpattern.ToString();
                
                stridgroup =  model.idgourp.Split(',');
                ListItem list = null;
                EtNet_Models.LoginInfo loginmodel = null;
                for (int i = 0; i < stridgroup.Length; i++ )
                {
                    loginmodel = EtNet_BLL.LoginInfoManager.getLoginInfoById(int.Parse(stridgroup[i]));
                    list = new ListItem();
                    list.Value = stridgroup[i];
                    list.Text = loginmodel.Cname;
                    this.lbtake.Items.Add(list);         
                }

                IList<EtNet_Models.LoginInfo> loginlist = EtNet_BLL.LoginInfoManager.getLoginInfoAll();
                for (int j = 0; j < loginlist.Count; j++ )
                {
                    for (int len = 0; len < stridgroup.Length; len++ )
                    {
                        if (loginlist[j].Id.ToString() == stridgroup[len])
                        {
                            break;
                        }
                        else if ((len + 1) == stridgroup.Length)
                        {
                            list = new ListItem();
                            list.Value = loginlist[j].Id.ToString();
                            list.Text = loginlist[j].Cname;
                            this.lbuntake.Items.Add(list);   

                        }
                        else
                        { }
                    }
                }
     
               this.auditpic.InnerHtml =  File.ReadAllText(Server.MapPath(model.rolepic));           
            
            }
               
        }


        //加载默认审核流程图
        private void ShowAuditImg()
        {
            string sort = this.selauditsort.Value;
            string path = "~/UploadFile/AuditRole/defaudit";
            string str = "";
            this.auditpic.InnerHtml = ""; //审核流程图
            this.hidlist.Value = "";  //实际审核人员列表
            this.hidtxtlist.Value = ""; //实际审核人员的名称列表
            bool addlist = true; //添加审核人员
            switch (sort)
            {
                case "单审":
                    if (this.lbtake.Items.Count == 1)
                    {
                        path += "ds1.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 2)
                    {
                        path += "ds2.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 3)
                    {
                        path += "ds3.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 4)
                    {
                        path += "ds4.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 5)
                    {
                        path += "ds5.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else
                    {
                        addlist = false;
                    }
                    break;

                case "选审":
                    if (this.lbtake.Items.Count == 2)
                    {
                        path += "xs2.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 3)
                    {
                        path += "xs3.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 4)
                    {
                        path += "xs4.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 5)
                    {
                        path += "xs5.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else
                    {
                        addlist = false;
                    }
                    break;

                case "会审":
                    if (this.lbtake.Items.Count == 2)
                    {
                        path += "hs2.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 3)
                    {
                        path += "hs3.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 4)
                    {
                        path += "hs4.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else if (this.lbtake.Items.Count == 5)
                    {
                        path += "hs5.txt";
                        str = File.ReadAllText(Server.MapPath(path), Encoding.Default);
                    }
                    else
                    {
                        addlist = false;
                    }
                    break;

                default:
                    break;
            }
            this.auditpic.InnerHtml = str;
            if (addlist)
            {
                if (selhide.Value == "1")
                {
                    for (int i = 0; i < this.lbtake.Items.Count; i++)
                    {
                        if (this.hidlist.Value == "")
                        {
                            int postid = LoginInfoManager.getLoginInfoById(Convert.ToInt32(this.lbtake.Items[i].Value)).Postid;
                            string postname = To_PostManager.getTo_PostById(postid).Postname;

                            this.hidtxtlist.Value = postname;

                            this.hidlist.Value += this.lbtake.Items[i].Value;

                        }
                        else
                        {
                            int postid = LoginInfoManager.getLoginInfoById(Convert.ToInt32(this.lbtake.Items[i].Value)).Postid;
                            string postname = To_PostManager.getTo_PostById(postid).Postname;

                            this.hidtxtlist.Value += "," + postname;
                            this.hidlist.Value += "," + this.lbtake.Items[i].Value;
                        }

                    }
                }
                else if (selhide.Value == "2")
                {
                    for (int i = 0; i < this.lbtake.Items.Count; i++)
                    {
                        if (this.hidlist.Value == "")
                        {
                            int postid = LoginInfoManager.getLoginInfoById(Convert.ToInt32(this.lbtake.Items[i].Value)).Postid;
                            string postname = To_PostManager.getTo_PostById(postid).Postname;

                            this.hidtxtlist.Value = postname + "<br/>" + "(" + this.lbtake.Items[i].Text + ")";

                            this.hidlist.Value += this.lbtake.Items[i].Value;

                        }
                        else
                        {
                            int postid = LoginInfoManager.getLoginInfoById(Convert.ToInt32(this.lbtake.Items[i].Value)).Postid;
                            string postname = To_PostManager.getTo_PostById(postid).Postname;

                            this.hidtxtlist.Value += "," + postname + "<br/>" + "(" + this.lbtake.Items[i].Text + ")";
                            this.hidlist.Value += "," + this.lbtake.Items[i].Value;
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < this.lbtake.Items.Count; i++)
                    {
                        if (this.hidlist.Value == "")
                        {
                            int postid = LoginInfoManager.getLoginInfoById(Convert.ToInt32(this.lbtake.Items[i].Value)).Postid;
                            string postname = To_PostManager.getTo_PostById(postid).Postname;

                            this.hidtxtlist.Value = this.lbtake.Items[i].Text;

                            this.hidlist.Value += this.lbtake.Items[i].Value;

                        }
                        else
                        {
                            int postid = LoginInfoManager.getLoginInfoById(Convert.ToInt32(this.lbtake.Items[i].Value)).Postid;
                            string postname = To_PostManager.getTo_PostById(postid).Postname;

                            this.hidtxtlist.Value += "," + this.lbtake.Items[i].Text;
                            this.hidlist.Value += "," + this.lbtake.Items[i].Value;
                        }

                    }
                }
            }

        }



        /// <summary>
        /// 加载可选审核人员的数据
        /// </summary>
        private void LoadReviewerData()
        {
            IList<EtNet_Models.LoginInfo> Reviewerlist = EtNet_BLL.LoginInfoManager.getLoginInfoAll();
            ListItem item = null;

            for (int i = 0; i < Reviewerlist.Count; i++)
            {
                item = new ListItem();
                item.Text = Reviewerlist[i].Cname;
                item.Value = Reviewerlist[i].Id.ToString();
                this.lbuntake.Items.Add(item);
            }

        }



        /// <summary>
        /// 将审核流程图保存到服务器上的一个文件中
        /// </summary>
        private void SaveFile(string path)
        {
            string str = Server.UrlDecode(this.hidaudit.Value);
            File.WriteAllText(Server.MapPath(path), str);    
        }


        /// <summary>
        /// 将选中的审核人员添加到右边的多选框中
        /// </summary>
        protected void imgright_Click(object sender, ImageClickEventArgs e)
        {
            ListItem item = null;
            Stack list = new Stack();
            for (int i = 0; i < this.lbuntake.Items.Count; i++)
            {
                if (this.lbuntake.Items[i].Selected)
                {

                    item = this.lbuntake.Items[i];
                    this.lbtake.Items.Add(item);
                    list.Push(item);      
                }      
            }
            while (list.Count != 0)
            {
                item = (ListItem)list.Pop();
                this.lbuntake.Items.Remove(item);
            }
            ShowAuditImg();
            Reducestr();

        }



        /// <summary>
        ///将选定的审核人员返回到左边的可选框中
        /// </summary>
        protected void imgleft_Click(object sender, ImageClickEventArgs e)
        {
            ListItem item = null;
            Stack list = new Stack();
            for (int i = 0; i < this.lbtake.Items.Count; i++)
            {
                if (this.lbtake.Items[i].Selected)
                {

                    item = this.lbtake.Items[i];
                    this.lbuntake.Items.Add(item);
                    list.Push(item);
                }             
            }
            while (list.Count != 0)
            {
                item = (ListItem)list.Pop();
                this.lbtake.Items.Remove(item);
            }
            ShowAuditImg();
            Reducestr();
        }




        /// <summary>
        /// 选定的审核人员上移
        /// </summary>
        protected void imgup_Click(object sender, ImageClickEventArgs e)
        {
            ListItem list = this.lbtake.SelectedItem;

            int i = 0;
            if (list != null)
            {
                i = this.lbtake.SelectedIndex;
                if (i != 0)
                {
                    this.lbtake.Items.RemoveAt(i);
                    this.lbtake.Items.Insert(i - 1, list);
                }
            }
            ShowAuditImg();
            Reducestr();


        }



        /// <summary>
        /// 选定的审核人员下移
        /// </summary>
        protected void imgdown_Click(object sender, ImageClickEventArgs e)
        {
            ListItem list = this.lbtake.SelectedItem;
            int i = 0;
            if (list != null)
            {
                i = this.lbtake.SelectedIndex;
                if (i != (this.lbtake.Items.Count - 1))
                {
                    this.lbtake.Items.RemoveAt(i);
                    this.lbtake.Items.Insert(i + 1, list);
                }

            }
            ShowAuditImg();
            Reducestr();
        }




        /// <summary>
        /// 重新设置审核人员
        /// </summary>
        protected void imgrefresh_Click(object sender, ImageClickEventArgs e)
        {
            this.lbuntake.Items.Clear();
            this.lbtake.Items.Clear();
            this.auditpic.InnerHtml = "";
            this.hidaudit.Value = "";
            this.hidlist.Value = "";
            this.hidtxtlist.Value = "";
            LoadReviewerData();
            Reducestr();
            
        }




        /// <summary>
        /// 对字符窜进行解码
        /// </summary>
        private void Reducestr()
        {
            string str = Server.UrlDecode(this.teratxt.Value);
            this.teratxt.Value = str;
        }

        //保存
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string path = this.iptfile.Value;
            string stridgroup = "";
            EtNet_Models.ApprovalRule model = new EtNet_Models.ApprovalRule();
            model.cname = this.iptcname.Value.Trim();
            model.jobflowsort = this.seljobflowsort.Value;
            model.rolepic = path; // 保存文件的路径
            model.sort = this.selauditsort.Value;
            model.departidtxt = this.iptdepartlist.Value;
            model.departidlist = this.hiddepartlist.Value;
            model.txt = Server.UrlDecode(this.teratxt.Value);
            model.id = int.Parse(Request.QueryString["id"]);
            model.showpattern =Convert.ToInt32( this.selhide.Value);

            for (int i = 0; i < this.lbtake.Items.Count; i++)
            {
                stridgroup += this.lbtake.Items[i].Value + ",";
            }
            model.idgourp = stridgroup.Substring(0, stridgroup.Length - 1);
            if (EtNet_BLL.ApprovalRuleManager.Update(model))
            {
                SaveFile(path);
                Response.Redirect("SearchAuditRole.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('修改失败！')</script>", false);
            }

        }

        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SearchAuditRole.aspx");
        }


        //重置
        protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
        {   
            this.lbtake.Items.Clear();
            this.lbuntake.Items.Clear();
            LoadAuditRoleData();
        }
        public void hide_serverchange(object sender, EventArgs e)
        {
            ShowAuditImg();
        }


    }
}