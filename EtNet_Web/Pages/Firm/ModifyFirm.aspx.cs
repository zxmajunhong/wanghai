using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Pages.Firm
{
    public partial class ModifyFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
              if(!IsPostBack)
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
               this.iptcaddress.Value = model.caddress;
               this.iptcname.Value = model.cname;
               this.ipteaddress.Value = model.eaddress;
               this.iptename.Value = model.ename;
               this.iptfax.Value = model.fax;
               this.iptfirmcode.Value = model.firmcode;
               this.iptorgcode.Value = model.orgcode;
               this.iptpostal.Value = model.postalcode;
               this.traremark.Value = model.remark;
               this.iptshortname.Value = model.sname;
               this.ipttaxnum.Value = model.taxnum;
               this.ipttel.Value = model.telephone;
               this.iptwedsite.Value = model.website;
               this.iptmailbox.Value = model.mailbox;
               this.hidfirm.Value = "";
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
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            if (tbl.Rows.Count == 0)
            {
                row = new HtmlTableRow();

                cell = new HtmlTableCell();
                cell.InnerHtml = "<input type='text' />";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "<input type='text' />";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "<input type='text' class='clshdate' />";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "<input type='text' />";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.Attributes.Add("align","center");
                cell.InnerHtml = "<input type='text' value='" + tbl.Rows[0]["id"].ToString() +"' class='clsdetail' /><div title='新增一行' class='imgadd'></div>";
                row.Cells.Add(cell);
             
                this.accountlist.Rows.Add(row);

            }
            else
            {
                for (int i = 0; i < tbl.Rows.Count; i++ )
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["bankname"].ToString() + "' />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["account"].ToString() + "' />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + Convert.ToDateTime(tbl.Rows[i]["ystime"].ToString()).ToString("yyyy-MM-dd") + "' class='clshdate' />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["amount"].ToString() + "' />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.Attributes.Add("align", "center");
                    if (i == 0)
                    {
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsdetail' /><div title='新增一行' class='imgadd'></div>";
                      
                    }
                    else
                    {
                        cell.InnerHtml += "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsdetail' /><div title='删除一行' class='imgdel'></div>";     
                    }
                    row.Cells.Add(cell);
                    this.accountlist.Rows.Add(row);
                }
            }
            
        }


        /// <summary>
        /// 删除原有的公司logo
        /// </summary>
        private void DeleteLogoImg(string path)
        {
            if (path != "")
            {
                File.Delete(Server.MapPath(path));
            }
        }


        //保存公司logo图,mod为true表示修改成功，反之为失败
        private string ModifyLogoImg(string path,out bool mod)
        {
            mod = true;
            string result = path;
            if (this.iptlogopath.HasFile)
            {
                if (this.iptlogopath.PostedFile.ContentLength < (1024 * 1024))
                {
                    DeleteLogoImg(path);
                    string strfile = this.iptlogopath.FileName.ToLower();
                    string strpath = "../../UploadFile/Firm/" + DateTime.Now.ToString("yyyyMMddHHmmss") + strfile;
                    this.iptlogopath.SaveAs(Server.MapPath(strpath));
                    result = strpath;
                }
                else
                {
                    mod = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modimg", "<script>alert('公司logo上传失败,请勿上传大于1M的图!')</script>", false);
                }
            }
            return result;
        }



        //修改银行账号资料
        private void ModifyAccount(int firmid)
        {
            //string strdel = " firmid=" +  firmid.ToString();
            //EtNet_BLL.FirmAccountInfoManager.Del(strdel);
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
                    alist = list[i].Split(',');
                    model = EtNet_BLL.FirmAccountInfoManager.GetModel(int.Parse(alist[4]));
                    if (model == null)
                    {
                        model = new EtNet_Models.FirmAccountInfo();
                        model.bankname = alist[0];
                        model.account = alist[1];
                        model.ystime = DateTime.Parse(alist[2]);
                        model.amount = alist[3] != "" ? decimal.Parse(alist[3]) : 0;
                        model.remark = "";
                        model.firmid = firmid;
                        EtNet_BLL.FirmAccountInfoManager.Add(model);
                    }
                    else
                    {
                        model.bankname = alist[0];
                        model.account = alist[1];
                        model.ystime = DateTime.Parse(alist[2]);
                        model.amount = alist[3] != "" ? decimal.Parse(alist[3]) : 0;
                        model.remark = "";
                        model.firmid = firmid;
                        EtNet_BLL.FirmAccountInfoManager.Update(model);
                    }
                }
            }

            string ids = this.hiddetailidlist.Value.TrimEnd(',');
            if (ids != "")
            {
                string sql = " id in (" + ids + ")";
                EtNet_BLL.FirmAccountInfoManager.Del(sql);
            }
        }


        /// <summary>
        /// 检测公司代码是否与其他公司的代码相同，如相同不允许修改
        /// </summary>
        private bool TestModify(int id)
        {
            bool isadd = true;
            string stradd = " firmcode='" + this.iptfirmcode.Value.Trim() + "'";
            stradd += "  AND id not in( "+id+" )";
            DataTable tbl = EtNet_BLL.FirmInfoManager.GetList(stradd);
            if (tbl.Rows.Count != 0)
            {
                isadd = false;
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "addtset", "<script>alert('添加失败,公司代码已被其他公司使用!')</script>");
            }

            return isadd;
        }


        /// <summary>
        /// 修改公司资料
        /// </summary>
        private void SaveModifyFirm()
        {
            int id = int.Parse(Request.Params["id"]);
            if (TestModify(id))
            {
                string str = "";
                EtNet_Models.FirmInfo model = EtNet_BLL.FirmInfoManager.GetModel(id);
                if (model != null)
                {
                    bool mod; //检测公司logo是否上传成功
                    string path = ModifyLogoImg(model.imgpath.Trim(),out mod);
                    if (mod)
                    {
                        model.caddress = this.iptcaddress.Value;
                        model.cname = this.iptcname.Value;
                        model.eaddress = this.ipteaddress.Value;
                        model.ename = this.iptename.Value;
                        model.fax = this.iptfax.Value;
                        model.firmcode = this.iptfirmcode.Value;
                        model.mailbox = this.iptmailbox.Value;
                        model.orgcode = this.iptorgcode.Value;
                        model.postalcode = this.iptpostal.Value;
                        model.remark = this.traremark.Value;
                        model.sname = this.iptshortname.Value;
                        model.taxnum = this.ipttaxnum.Value;
                        model.telephone = this.ipttel.Value;
                        model.website = this.iptwedsite.Value;
                        model.imgpath = path;
                        if (EtNet_BLL.FirmInfoManager.Update(model))
                        {
                            ModifyAccount(id);
                            str = "<script>alert('修改成功!'); window.location ='ShowFirm.aspx'</script>";
                        }
                        else
                        {
                            str = "<script>alert('修改失败!'); window.location ='ShowFirm.aspx'</script>";
                        }
                    }
                    else
                    {
                        str = "<script>alert('修改失败!'); window.location ='ShowFirm.aspx'</script>";
                    }
                }
                else
                {
                    str = "<script>alert('操作失败,该公司资料可能已删除!'); window.location ='ShowFirm.aspx'</script>";

                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "mod", str, false);
            }
            else
            {
                LoadFirmData(); //重置
            }
            
           
        }


        //保存修改后的资料
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            SaveModifyFirm();
        }

        //重置
        protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            LoadFirmData();
        }


        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowFirm.aspx");
        }


        //删除公司logo
        protected void btndel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.Params["id"]);
            EtNet_Models.FirmInfo model = EtNet_BLL.FirmInfoManager.GetModel(id);
            if(model != null)
            {
                DeleteLogoImg(model.imgpath);
                model.imgpath = "";
                EtNet_BLL.FirmInfoManager.Update(model);
            }
            LoadFirmData();
        }

    }
}