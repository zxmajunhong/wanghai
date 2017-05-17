using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace EtNet_Web.Pages.Information
{
    /// <summary>
    /// Information 的摘要说明
    /// </summary>
    public class Information : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           switch(context.Request.QueryString["msg"])
           {
               case "dialog":
                   List(context);
                   break;

               case "del":
                   Del(context);  //发送人删除消息
                   break;

               case "acceptdel":
                   DelInformationNotice(context);  //接收人删除消息，删除消息通知列表中的数据
                   break;
               
               case "remind":
                   RemindInformationNotice(context); //取消提醒
                   break;
           }
            
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// 获取人员列表
        /// </summary>
        private void List(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string str = "";
            IList<EtNet_Models.LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoAll();
            EtNet_Models.DepartmentInfo model = null;
            for (int i = 0; i < list.Count; i++)
            {
                model = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(list[i].Departid);
                str += "<li id='" + list[i].Id + "'>" + list[i].Cname + "(" + model.Departcname + ")</li>";
            }
            context.Response.Write(str);
        
        }


        /// <summary>
        /// 删除服务器上的文件，以及数据库中的附件表中数据
        /// </summary>
        private void DelFile(HttpContext context,int informationid)
        {
            string str = " informationid = " + informationid;
            DataTable tbl = EtNet_BLL.InformationFileManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string strfile = tbl.Rows[i]["fileload"].ToString();
                    File.Delete(context.Server.MapPath(strfile));
                    EtNet_BLL.InformationFileManager.Delete(int.Parse(tbl.Rows[i]["id"].ToString()));
                }
            }
       
        }
       

    
        /// <summary>
        /// 删除消息数据
        /// </summary>
        private void Del(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["id"] != null)
            {
                int informationid = int.Parse(context.Request.QueryString["id"]);
                DelFile(context,informationid);
                EtNet_BLL.InformationNoticeManager.Del(" informationid=" + informationid);
                EtNet_BLL.InformationManager.Delete(informationid);
                
                context.Response.Write("1_删除成功!");      
            }
            else
            { 
               context.Response.Write("0_删除失败!");      
            }
           
            
        }


        /// <summary>
        /// 删除通知列表的数据
        /// </summary>
        private void DelInformationNotice( HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["noticeid"] != null)
            {
                int id = int.Parse(context.Request.QueryString["noticeid"]);
                EtNet_BLL.InformationNoticeManager.Delete(id);
                context.Response.Write("1_删除成功!");
            }
            else
            {
                context.Response.Write("0_删除失败!");
            }
        
        }



        /// <summary>
        /// 提醒修改
        /// </summary>
        private void RemindInformationNotice(HttpContext context)
        {        
            if (context.Request.QueryString["noticeid"] != null)
            {
                int id = int.Parse(context.Request.QueryString["noticeid"]);
                EtNet_Models.InformationNotice model = EtNet_BLL.InformationNoticeManager.GetModel(id);       
                model.remind = "否";
                EtNet_BLL.InformationNoticeManager.Update(model);              
            }     
        }

    }
}