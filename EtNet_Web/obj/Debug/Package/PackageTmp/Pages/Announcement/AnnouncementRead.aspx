<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementRead.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementRead" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>阅读部门公告</title>
    <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
      .clsdata{ width:100%;border:1px solid #CDC9C9;}
      .clsdata tr td{ height:24px;}
      .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
      .topimgtxt{
                   font-size:12px;
                   font-weight:bold; 
                   color:#718ABE;
                   cursor:pointer;
                   display:inline-block;
                   margin-top:4px; 
                   margin-right:6px;
                  }   
      .topimgtxt img{ height:14px; width:14px;  margin-bottom:-2px;}
      img{border:0; cursor:pointer;}
      .buttonStyle{ background:url('../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
      #originalfile{width:400px; background-color:#B9D3EE}
      #originalfile tr td{ background-color:White; text-align:center; height:20px;}
      .clstitleimg{ background-image:url('../../Images/Public/list_tit.png');height:24px; text-align:center;}
      .clstxt{border:1px solid #1E90FF; margin:0px 50px 2px 50px;background-color:#F8F8FF;}
      .clsremark{ margin:0px 50px 0px 50px;}
      #lbltitle{ text-align:center;  font-weight:bold; font-size:20px;}
      #lbltxt{ margin:10px;}
     
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //显示文档历史对话框
            function sdilog() {
                var diag = new Dialog();
                diag.Width = 620;
                diag.Height = 320;
                diag.Title = "查看历史记录";
                diag.URL = "AnnouncementRecord.aspx?id=" + $("#hidid").val();
                diag.OKEvent = function () {
                    diag.close();
                };
                diag.show();
            }

            $("#record").click(function () {
                sdilog();
            })




        })   
    </script>
</head>
<body style=" height:500px;">
  <form id="form1" runat="server">
     <input type="hidden" runat="server" id="hidid" />
     <div class="clstop">
       <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <table style=" width:100%; height:100%;">
            <tr>
              <td class="toptitletxt">阅读部门公告</td>
              <td style=" text-align:right; padding-right:20px;">
               <span class="topimgtxt" runat="server" id="record">
                 <img alt="查看记录" src="../../Images/Public/record.gif" />
                 <span>历史记录</span>
              </span>
           </td>
            </tr>
          </table>
       </div>
       <div style=" background:#4CB0D5; height:5px;"></div>
     </div>
     <div class="clsbottom">
        <div style="text-align:right;">
          <asp:ImageButton runat="server" ID="imgbtnback" 
                ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click" />
        </div>
        <table class="clsdata">
          <tr>
            <td align="center"><asp:Label runat="server" ID="lbltitle"></asp:Label></td>
          </tr>
          <tr>
           <td>
             <div class="clstxt">
               <div runat="server" id="lbltxt"></div>
             </div>
           </td>
          </tr>
          <tr>
           <td>
             <div class="clsremark">
               <div>
                <span style=" color:Red;">注意:</span>
                <span runat="server" id="lblperiodtxt"></span>
                <span runat="server" style="color:Blue;" id="lblpast"></span>
               </div>
               <div>
                 <table id="originalfile" cellpadding="0" cellspacing="1" runat="server">
                   <tr>
                    <td class="clstitleimg" style=" width:20px;"></td>
                    <td class="clstitleimg">名称</td>
                    <td class="clstitleimg" style=" width:40px;">下载</td>
                  </tr>
                 </table>
               </div>
               <div class="clscreate">
                <table style="float:right;">
                 <tr>
                  <td>公告类型:</td>
                  <td align="left" style=" color:Red;"><asp:Label runat="server" ID="lblsort"></asp:Label></td>
                  <td>发布人员:</td>
                  <td align="left" style=" color:Red;"><asp:Label runat="server" ID="lblcreater"></asp:Label></td>
                  <td>发布时间:</td>
                  <td align="left" style=" color:Red;"><asp:Label runat="server" ID="lbldate"></asp:Label></td>
                 </tr>             
                </table>
               </div> 
             </div>
           </td>
          </tr>
        </table>
     </div>
  </form>
</body>
</html>
