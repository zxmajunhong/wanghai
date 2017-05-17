﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using System.Data;

namespace EtNet_Web.Pages.Information
{
    public partial class AddInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }


        /// <summary>
        /// 上传附件，返回上传文件的路径的集合
        /// </summary>
        private string[] FileUp(HttpFileCollection item)
        {
            string[] str = new string[7] { "", "", "", "", "", "", "0" };
            string fileload = ""; //文件的路径
            //str[6] = "0";0为没有文件，1为有上传文件
            int num = 1;
            string saveUrl = "~/UploadFile/Information/";
            HttpPostedFile postfile = null;
            for (int i = 0; i < item.Count; i++)
            {
                postfile = item[i];
                if (postfile.FileName == "")
                {

                }
                else if (String.IsNullOrEmpty(Path.GetExtension(postfile.FileName).ToLower()))
                {
                    str[0] = postfile.FileName + "文件拓展名出错，导致上传失败";
                    str[6] = "0";
                    if (num == 1)
                    {
                        return str;
                    }
                    else
                    {
                        for (int j = 1; j < num; j++)
                        {
                            fileload = str[j].Substring(0, str[j].LastIndexOf("|"));
                            File.Delete(HttpContext.Current.Server.MapPath(fileload));
                        }
                        return str;
                    }
                }
                else
                {
                    if (postfile.ContentLength <= (1024 * 1024))
                    {
                        string fileExt = Path.GetExtension(postfile.FileName).ToLower();
                        //上传文件的名称包括拓展名
                        string orfilename = postfile.FileName.Substring(postfile.FileName.LastIndexOf("\\") + 1);
                        string newFile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + orfilename;
                        postfile.SaveAs(HttpContext.Current.Server.MapPath(saveUrl + newFile));
                        str[num] = saveUrl + newFile + "|" + postfile.ContentLength + "|" + orfilename;
                        str[6] = "1";
                        num++;

                    }
                    else
                    {
                        str[0] = postfile.FileName + "文件太大，导致上传失败";
                        str[6] = "0";
                        if (num == 1)
                        {
                            return str;
                        }
                        else
                        {
                            for (int j = 1; j < num; j++)
                            {
                                fileload = str[j].Substring(0, str[j].LastIndexOf("|"));
                                File.Delete(HttpContext.Current.Server.MapPath(fileload));

                            }
                            return str;
                        }
                    }

                }

            }

            return str;

        }



        /// <summary>
        /// 保存附件的路径
        /// </summary>
        /// <param name="filelist">附件的路径的列表</param>
        /// <param name="jobflowid">工作流的id值</param>
        private void CreateDocumentFile(string[] filelist, int informationid)
        {
            EtNet_Models.InformationFile model = null;

            for (int i = 1; i < 6; i++)
            {
                if (filelist[i] != "")
                {
                    model = new EtNet_Models.InformationFile();
                    model.downloadnum = 0;
                    model.fileload = filelist[i].Substring(0, filelist[i].IndexOf("|"));
                    model.createtime = DateTime.Now;
                    model.filename = filelist[i].Substring(filelist[i].LastIndexOf("|") + 1);
                    model.filesize = int.Parse(filelist[i].Split('|')[1]);
                    model.informationid = informationid;
                    EtNet_BLL.InformationFileManager.Add(model);
            
                }
            }
        }



        /// <summary>
        /// 创建收信人通知列表
        /// </summary>
        private void CreateInformationNotice(string peoplelist,int informationid)
        {
            if (peoplelist != "")
            {
                string strsql = "  id in(" + peoplelist + ")";
                DataTable tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
                EtNet_Models.InformationNotice model = null;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    model = new EtNet_Models.InformationNotice();
                    model.informationid = informationid;
                    model.recipientid = int.Parse(tbl.Rows[i]["id"].ToString());
                    model.remind = "是";
                    EtNet_BLL.InformationNoticeManager.Add(model);
                }
            }
        }

   

        /// <summary>
        /// 添加消息
        /// </summary>  
        protected void imgbtnsend_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = FileUp(Request.Files);
            if (str[0] != "")
            {
                ClearData();
                string strerror = "<script>alert('" + str[0] + "')</script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "fileup", strerror, false);    
            }
            else
            {
                EtNet_Models.Information model = new EtNet_Models.Information();
                model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                model.contents = Server.UrlDecode(this.tracontents.Value);
                model.createtime = DateTime.Now;
                model.sendtime = this.rbtnleft.Checked ? DateTime.Now : DateTime.Parse(this.iptdate.Value);
                model.sortid = 1;
                model.associationid = 1;       
                if (EtNet_BLL.InformationManager.Add(model))
                {
                    int maxid = EtNet_BLL.InformationManager.GetMaxId();
                    CreateInformationNotice(this.ipthidrecipient.Value, maxid);
                    if (str[6] == "1")
                    {
                        CreateDocumentFile(str, maxid);
                    }
                    Response.Redirect("SendInformationShow.aspx");       

                }
               
            }

        }



        /// <summary>
        /// 清空填写的内容
        /// </summary>
        private void ClearData()
        {
            this.ipthidrecipient.Value = "";
            this.recipient.Text = "";
            this.iptdate.Value = "";
            this.tracontents.Value = "";
            this.rbtnleft.Checked = true;
            this.rbtnright.Checked = false;

        }


   
    }
}