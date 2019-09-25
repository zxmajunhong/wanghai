using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;


namespace EtNet_Web.Pages.Index
{
    /// <summary>
    /// Welcome 的摘要说明
    /// </summary>
    public class WelcomeHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            MarkDisperse(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 依据mark值到相应的处理方法
        /// </summary>
        private void MarkDisperse(HttpContext context)
        {
            string str = context.Request.QueryString["mark"] == null ? "0" : context.Request.QueryString["mark"].Trim();
            switch (str)
            {
                case "0":
                    break;

                case "1":
                    LoadContentData(context, "");
                    break;

                case "2":
                    ModifyPanelMenu(context);
                    break;

                case "3":
                    GetListPanelMenu(context);
                    break;

                case "4":
                    AddPanelMenu(context);
                    break;

                case "5":
                    DelPanelMenu(context);
                    break;

                case "6":
                    RefreshPanelMenu(context);
                    break;

                case "7":
                    ModifyPanelMenuTitle(context);
                    break;
            }


        }

        /// <summary>
        /// 加载每一个面板菜单的数据条目,第二个参数可以指定加载的数据的类型
        /// </summary>
        private void LoadContentData(HttpContext context, string direct)
        {
            string direction = "";

            if (direct == "")
            {
                direction = context.Request.QueryString["direction"];
                direction = direction.Substring(7);
            }
            else
            {
                direction = direct.Trim();
            }
            string loginid = ((EtNet_Models.LoginInfo)context.Session["login"]).Id.ToString();
            string strsetsql = " createrid=" + loginid;
            DataTable tblset = EtNet_BLL.InitializeUserSetManager.GetList(strsetsql);  //获取用户参数
            int topcount = int.Parse(tblset.Rows[0]["panelcount"].ToString());
 
            string strdata = "";
            DataTable tbl = null;
            switch (direction)
            {
                //共享文档数据 
                case "1":
                    tbl = EtNet_BLL.ViewBLL.ViewDocumentShareManager.getList(" top " + topcount + " * ", "acceptpeopleid=" + loginid + "  order by id  desc");

                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li>" + "<img class='imglistarrow' src='../../Images/index/index/panel_arrow.png' alt='列表'>";
                            strdata += "<a href='../Knowledge/Document/ReadDocument.aspx?login=" + ((EtNet_Models.LoginInfo)context.Session["login"]).Id + "&documentid=" + tbl.Rows[i]["documentid"] + "'>";
                            strdata += tbl.Rows[i]["cname"].ToString() + "</a></li>";
                        }
                        strdata += "</ul><br />";                
                    }
                  
                    context.Response.Write(strdata);
                    break;


                //公告
                case "2":

                    string departid = ((EtNet_Models.LoginInfo)context.Session["login"]).Departid.ToString();
                    string strsql = " visiblecode=1 AND statusid=2 ";
                          strsql += "AND (sortid=1 OR (sortid=2 AND ',' + departlist +','  like '%," + departid + ",%' ))";
                    tbl = EtNet_BLL.AnnouncementInfoManager.GetList(topcount, strsql, " id desc ");
                
                    if(tbl.Rows.Count != 0)
                    {
                        for (int i = 0; i < tbl.Rows.Count; i++ )
                        {
                            strdata += "<ul class='panelul'>";         
                            strdata += "<li><img class='imglistarrow' src='../../Images/Index/panel_arrow.png' alt='列表'>";

                            if (tbl.Rows[i]["sortid"].ToString() == "1")
                            {
                                strdata += "<a href='../Announcement/AnnouncementReadFirm.aspx?id=" + tbl.Rows[i]["id"] + "'>" + tbl.Rows[i]["title"];
                            }
                            else
                            {
                                strdata += "<a href='../Announcement/AnnouncementRead.aspx?id=" + tbl.Rows[i]["id"] + "'>" + tbl.Rows[i]["title"];
                            }    
                            strdata += "</a></li>";                      
                        }
                        strdata += "</ul>";
                    }
                    strdata += "<div style='width:100%;font-size:10px;text-align:right;'>";
                    strdata += "<a href='../Announcement/AnnouncementSearch.aspx'><img src='../../Images/Index/more.png' alt='更多'></a></div>";
                    context.Response.Write(strdata);
                    break;


                //签到管理
                case "4":
                    strdata += "<a id='sign' href='../Sign/Sign.aspx'><img src='../../Images/Button/btn_signin.jpg' alt='签到'/>&nbsp;";
                    strdata += "<img src='../../Images/Button/btn_signout.jpg' alt='签退'/></a>";
                    context.Response.Write(strdata);

                    break;



                //个人消息提醒
                case "5":
           
                    string sqlinfo = " recipientid=" + loginid + " AND sendtime <= '" + DateTime.Now.ToString() + "' ";
                    sqlinfo += " AND sortid in(1,3,7) ";
                    sqlinfo += " AND remind='是' order by id desc";

                    tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(" top " + topcount + " * ",sqlinfo );
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<a href='../Information/ReplyInformation.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                            strdata += CommonlyUsed.Conversion.StrConversion(tbl.Rows[i]["contents"].ToString());
                            strdata += "(" + tbl.Rows[i]["txt"].ToString() + ")</a></li>";
                        }
                        strdata += "</ul><br/>";                  
                    }
                    strdata += "<div style='width:100%;font-size:10px;text-align:right;'>";
                    strdata += "<a href='../Information/ReceiveInformationShow.aspx'><img src='../../Images/Index/more.png' alt='更多'></a></div>";
                    context.Response.Write(strdata);
                    break;



                //审核数据
                case "7":

                    tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(" top " + topcount + " * ", " reviewerid=" + loginid + " AND nowreviewer ='T' AND auditstatus in('01','02')" + " order by id desc");
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<span>" + tbl.Rows[i]["cname"].ToString() + " (" + tbl.Rows[i]["sorttxt"].ToString() + ")</span>";
                            if (tbl.Rows[i]["sort"].ToString() == "01")
                            {
                                strdata += "<a href='../Job/ReimbursedForm/AuditReimbursedForm.aspx?jobflowid=" + tbl.Rows[i]["jobflowid"] + "&login=" + loginid + "'>";
                            }
                           
                            else if (tbl.Rows[i]["sort"].ToString() == "02")
                            {
                                strdata += "<a href='../Order/AuditOrder.aspx?jobflowid=" + tbl.Rows[i]["jobflowid"] + "&login=" + loginid + "'>";
                            }
                            else if (tbl.Rows[i]["sort"].ToString() == "03")
                            {
                                strdata += "<a href='../CusInfo/AuditCus.aspx?jobflowid=" + tbl.Rows[i]["jobflowid"] + "&login=" + loginid + "'>";
                            }
                            else if (tbl.Rows[i]["sort"].ToString() == "04")
                            {
                                strdata += "<a href='../Announcement/AnnouncementAuditFirm.aspx?jobflowid=" + tbl.Rows[i]["jobflowid"] + "&login=" + loginid + "'>";
                            }
                            else if (tbl.Rows[i]["sort"].ToString() == "05")
                            {
                                strdata += "<a href='../Financial/AuditPayment.aspx?jobflowid=" + tbl.Rows[i]["jobflowid"] + "&login=" + loginid + "'>";
                            }
                            else
                            { 
                            
                            }
                            strdata += "&nbsp;<img src='../../Images/index/addvoucher.gif' alt='现在审核'/></a></li>";

                        }
                        strdata += "</ul><br/>";
                        strdata += "<div style='width:100%;font-size:10px;text-align:right;'>";
                        strdata += "<a href='../Job/AuditJobFlow.aspx'><img src='../../Images/Index/more.png' alt='更多'></a></div>";
                        context.Response.Write(strdata);
                    }
                    break;


                //请假单
                case "8":

                    tbl = EtNet_BLL.ViewBLL.ViewJobFlowManager.getList(" top "+ topcount+" * ", " founderid=" + loginid + " AND sort='01'");
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<span>" + tbl.Rows[i]["cname"].ToString() + " (" + tbl.Rows[i]["savestatus"].ToString() + ")</span>";
                            if (tbl.Rows[i]["savestatus"].ToString() == "已提交")
                            {
                                strdata += "<span>(审核状态:" + tbl.Rows[i]["auditstutastxt"].ToString() + ")</span>&nbsp;";
                                strdata += "<a href='../Job/LeaveForm/SearchLeaveForm.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagesearch.gif' alt='查看审核情况'/></a></li>";
                            }
                            else if (tbl.Rows[i]["auditstatus"].ToString() == "01" && tbl.Rows[i]["savestatus"].ToString() == "草稿")
                            {
                                strdata += "<a href='../Job/LeaveForm/ModifyLeaveForm.aspx?id=" + tbl.Rows[i]["id"] + "&login=" + loginid + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagedit.gif' alt=' 现在修改'/> </a></li>";
                            }

                        }

                        strdata += "</ul>";                   
                        context.Response.Write(strdata);
                    }

                    break;

                //报销单
                case "9":
                    tbl = EtNet_BLL.ViewBLL.ViewJobFlowManager.getList(" top "+topcount+" * ", " founderid=" + loginid + " AND sort='01'");
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<span>" + tbl.Rows[i]["cname"].ToString() + " (" + tbl.Rows[i]["savestatus"].ToString() + ")</span>";
                            if (tbl.Rows[i]["savestatus"].ToString() == "已提交")
                            {
                                strdata += "<span>(审核状态:" + tbl.Rows[i]["auditstutastxt"].ToString() + ")</span>&nbsp;";
                                strdata += "<a href='../Job/ReimbursedForm/SearchReimbursedForm.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagesearch.gif' alt='查看审核情况'/></a></li>";
                            }
                            else if (tbl.Rows[i]["auditstatus"].ToString() == "01" && tbl.Rows[i]["savestatus"].ToString() == "草稿")
                            {
                                strdata += "<a href='../Job/ReimbursedForm/ModifyReimbursedForm.aspx?id=" + tbl.Rows[i]["id"] + "&login=" + loginid + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagedit.gif' alt=' 现在修改'/></a></li>";
                            }

                        }

                        strdata += "</ul><br/>";
                        strdata += "<div style='width:100%;font-size:10px;text-align:right;'>";
                        strdata += "<a href='../Job/ReimbursedForm/ShowReimbursedForm.aspx'><img src='../../Images/Index/more.png' alt='更多'></a></div>";
                        context.Response.Write(strdata);
                    }

                    break;

                //公章
                case "10":
                    tbl = EtNet_BLL.ViewBLL.ViewJobFlowManager.getList(" top "+topcount+" * ", " founderid=" + loginid + " AND sort='04'");
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<span>" + tbl.Rows[i]["cname"].ToString() + " (" + tbl.Rows[i]["savestatus"].ToString() + ")</span>";
                            if (tbl.Rows[i]["savestatus"].ToString() == "已提交")
                            {
                                strdata += "<span>(审核状态:" + tbl.Rows[i]["auditstutastxt"].ToString() + ")</span>&nbsp;";
                                strdata += "<a href='../Job/SealForm/SearchSealForm.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagesearch.gif' alt='查看审核情况'/></a></li>";
                            }
                            else if (tbl.Rows[i]["auditstatus"].ToString() == "01" && tbl.Rows[i]["savestatus"].ToString() == "草稿")
                            {
                                strdata += "<a href='../Job/SealForm/ModifySealForm.aspx?id=" + tbl.Rows[i]["id"] + "&login=" + loginid + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagedit.gif' alt='现在修改'/> </a></li>";
                            }

                        }

                        strdata += "</ul>";                     
                        context.Response.Write(strdata);
                    }

                    break;


                //办公用品
                case "11":
                    tbl = EtNet_BLL.ViewBLL.ViewJobFlowManager.getList(" top "+topcount+" * ", " founderid=" + loginid + " AND sort='02'");
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<span>" + tbl.Rows[i]["cname"].ToString() + " (" + tbl.Rows[i]["savestatus"].ToString() + ")</span>";
                            if (tbl.Rows[i]["savestatus"].ToString() == "已提交")
                            {
                                strdata += "<span>(审核状态:" + tbl.Rows[i]["auditstutastxt"].ToString() + ")</span>&nbsp;";
                                strdata += "<a href='../Job/OfficeSuppyForm/SearchOfficeSuppyForm.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagesearch.gif' alt='查看审核情况'/></a></li>";
                            }
                            else if (tbl.Rows[i]["auditstatus"].ToString() == "01" && tbl.Rows[i]["savestatus"].ToString() == "草稿")
                            {
                                strdata += "<a href='../Job/OfficeSuppyForm/ModifyOfficeSuppyForm.aspx?id=" + tbl.Rows[i]["id"] + "&login=" + loginid + "'>";
                                strdata += "&nbsp;<img src='../../Images/index/pagedit.gif' alt='现在修改'/> </a></li>";
                            }

                        }
                        strdata += "</ul>";
                    }                 
                    context.Response.Write(strdata);
                    break;


                //公告消息提醒
                case "13":         
                    string strannoun= " recipientid=" + loginid + " AND sendtime <= '" + DateTime.Now.ToString() + "' ";
                    strannoun += " AND sortid in(8) ";
                    strannoun += " AND remind='是' order by id desc";

                    tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(" top " + topcount + " * ",strannoun);
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<a href='../Information/ReplyInformation.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                            strdata += CommonlyUsed.Conversion.StrConversion(tbl.Rows[i]["contents"].ToString());
                            strdata += "(" + tbl.Rows[i]["txt"].ToString() + ")</a></li>";
                        }
                        strdata += "</ul><br/>";                  
                    }
                    strdata += "<div style='width:100%;font-size:10px;text-align:right;'>";                 
                    strdata += "<a href='../Information/ReceiveInformationShow.aspx'><img src='../../Images/Index/more.png' alt='更多'></a></div>";
                    context.Response.Write(strdata);
                    break;
                
                //审核消息提醒
                case "14":         
                    string straudit= " recipientid=" + loginid + " AND sendtime <= '" + DateTime.Now.ToString() + "' ";
                    straudit += " AND sortid in(2,4,5,6,9,10) ";
                    straudit += " AND remind='是' order by id desc";

                    tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(" top " + topcount + " * ",straudit );
                    if (tbl.Rows.Count != 0)
                    {
                        strdata += "<ul class='panelul'>";
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            strdata += "<li><img class='imglistarrow' src='../../Images/index/panel_arrow.png' alt='列表'>";
                            strdata += "<a href='../Information/ReplyInformation.aspx?id=" + tbl.Rows[i]["id"] + "'>";
                            strdata += CommonlyUsed.Conversion.StrConversion(tbl.Rows[i]["contents"].ToString());
                            strdata += "(" + tbl.Rows[i]["txt"].ToString() + ")</a></li>";
                            // strdata += "<a href='../Job/AuditJobFlow.aspx'><img src='../../Images/Index/addvoucher.gif' alt='现在审核'></a></li>";
                        }
                        strdata += "</ul><br/>";                  
                    }
                    strdata += "<div style='width:100%;font-size:10px;text-align:right;'>";
                    strdata += "<a href='../Information/ReceiveInformationShow.aspx'><img src='../../Images/Index/more.png' alt='更多'></a></div>";
                    context.Response.Write(strdata);
                    break;
            }

        }

        /// <summary>
        /// 判断所属列的位置
        /// </summary>
        private int JudgeColsPosition(string cols)
        {
            int colsnum = 1;
            switch (cols.Trim())
            {
                case "columnleft":
                    colsnum = 1;
                    break;

                case "columncenter":
                    colsnum = 2;
                    break;
                case "columnright":
                    colsnum = 3;
                    break;


            }

            return colsnum;

        }

        /// <summary>
        /// 修改面板菜单位置
        /// </summary>
        private void ModifyPanelMenu(HttpContext context)
        {
            string[] dtlist = context.Request.QueryString["datalist"].Split(',');
            string[] data = null;
            EtNet_Models.PanelMenu model = null;
            for (int i = 0; i < dtlist.Length - 1; i++)
            {

                data = dtlist[i].Split('_');
                model = EtNet_BLL.PanelMenuManager.GetModel(int.Parse(data[0].Substring(7)));
                string strd = data[1];
                model.colsnum = JudgeColsPosition(data[1]);

                model.rowsnum = int.Parse(data[2]);
                EtNet_BLL.PanelMenuManager.Update(model);

            }
            context.Response.Write("已修改!");

        }

        /// <summary>
        /// 加载菜单列表
        /// </summary>
        private void GetListPanelMenu(HttpContext context)
        {
            string loginid = ((EtNet_Models.LoginInfo)context.Session["login"]).Id.ToString();
            string strsql = " createrid=" + loginid;
            DataTable tblset = EtNet_BLL.InitializeUserSetManager.GetList(strsql);  //获取用户参数

            string strSql = " id in(" + tblset.Rows[0]["panellistall"] + ")"; //筛选用户可添加的面板菜单

            DataTable tbl = EtNet_BLL.PanelMenuListManager.GetList(strSql);
            string str = "<ul>";
            string strdata = "";

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                strdata += "<li><img src='" + tbl.Rows[i]["imageload"].ToString() + "'/>";
                strdata += "<span>" + tbl.Rows[i]["cname"].ToString() + "</span>";
                strdata += "<img class='addmenu' src='../../Images/Index/add.gif' alt='" + tbl.Rows[i]["id"] + "' />";
                strdata += "</li>";
            }

            if (strdata != "")
            {
                str += strdata + "</ul>";
            }
            context.Response.Write(str);

        }

        /// <summary>
        /// 新加菜单面板
        /// </summary>
        private void AddPanelMenu(HttpContext context)
        {
            int id = int.Parse(context.Request.QueryString["id"].Trim());

            EtNet_Models.PanelMenuList model = EtNet_BLL.PanelMenuListManager.GetModel(id);
            string str = " founderid=" + ((EtNet_Models.LoginInfo)context.Session["login"]).Id + " AND colsnum='1' ";


            if (model != null)
            {
                int rows = EtNet_BLL.PanelMenuManager.GetList(str).Rows.Count;

                EtNet_Models.PanelMenu menumodel = new EtNet_Models.PanelMenu();
                menumodel.colsnum = 1;
                menumodel.rowsnum = rows + 1;
                menumodel.title = model.cname;
                menumodel.imageload = model.imageload;
                menumodel.direction = model.num;
                menumodel.founderid = ((EtNet_Models.LoginInfo)context.Session["login"]).Id;



                if (EtNet_BLL.PanelMenuManager.Add(menumodel))
                {

                    string strdata = " <div id='portlet" + EtNet_BLL.PanelMenuManager.MaxId().ToString() + "' class='portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all'>";
                    strdata += "<div class='portlet-header ui-widget-header ui-corner-all'>";
                    strdata += "<span class='ui-icon-del'></span><span class='ui-icon ui-icon-expand'></span>";
                    strdata += "<span class='ui-icon-edit'></span><span class='ui-icon-refresh'></span><span class='portlet-header-title'>" + model.cname + "</span></div>";
                    strdata += "<div id='content" + model.num + "' class='portlet-content' style='display:block;'>";

                    context.Response.Write(strdata);
                    LoadContentData(context, model.num.Trim());

                    strdata = "</div></div>";
                    context.Response.Write(strdata);

                }
            }
        }

        //删除一个面板菜单
        private void DelPanelMenu(HttpContext context)
        {
            int id = int.Parse(context.Request.QueryString["menuid"].Substring(7));

            EtNet_Models.PanelMenu model = EtNet_BLL.PanelMenuManager.GetModel(id);
            if (model != null)
            {

                if (EtNet_BLL.PanelMenuManager.Delete(id))
                {
                    int closnum = model.colsnum; //所属行的位置
                    int rowsnum = model.rowsnum; //所属列的位置
                    string str = " founderid=" + ((EtNet_Models.LoginInfo)context.Session["login"]).Id;
                    str += "  AND colsnum =" + closnum;
                    str += "  AND rowsnum >" + rowsnum;
                    str += " order by rowsnum asc ";

                    DataTable tbl = EtNet_BLL.PanelMenuManager.GetList(str);
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        model = new EtNet_Models.PanelMenu();
                        model.id = int.Parse(tbl.Rows[i]["id"].ToString());
                        model.imageload = tbl.Rows[i]["imageload"].ToString();
                        model.title = tbl.Rows[i]["title"].ToString();
                        model.colsnum = int.Parse(tbl.Rows[i]["colsnum"].ToString());
                        model.direction = tbl.Rows[i]["direction"].ToString();
                        model.founderid = int.Parse(tbl.Rows[i]["founderid"].ToString());
                        model.rowsnum = int.Parse(tbl.Rows[i]["rowsnum"].ToString()) - 1;
                        EtNet_BLL.PanelMenuManager.Update(model);
                    }
                }
            }
        }

        //刷新一个面板菜单
        private void RefreshPanelMenu(HttpContext context)
        {
            string direct = context.Request.QueryString["id"].Trim().Substring(7);
            LoadContentData(context, direct);
        }
        //修改菜单面板的标题
        private void ModifyPanelMenuTitle(HttpContext context)
        {
            string[] str = context.Request.QueryString["id"].ToString().Split(',');
            int id = int.Parse(str[0].Trim().Substring(7).ToString());

            EtNet_Models.PanelMenu model = EtNet_BLL.PanelMenuManager.GetModel(id);
            model.title = str[1];
            EtNet_BLL.PanelMenuManager.Update(model);
        }
    }
}
