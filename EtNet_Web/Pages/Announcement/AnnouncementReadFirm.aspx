<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementReadFirm.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementReadFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>阅读公司公告</title>
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
      #lblfirmtop{ font-size:29px; font-family:楷体_GB2312; color:Red; font-weight:bold; text-decoration:underline;}
      #lblsfirm,#lblyear,#lblorder{ font-size:16px; margin-right:5px;}     
      #lbltitle{ font-size:24px; font-weight:bold;}
      .clstxt{border:1px solid #1E90FF; margin:0px 50px 20px 50px;background-color:#F8F8FF;}
      #lbltxt{ font-size:18px; margin:10px;}
      #lblfirmbottom,#lbldate,#lbldate{font-size:17px;}
      .clscommon
      {
          font-size:17px;
          margin:0px 50px 20px 50px;  
          border:0;
          border-bottom:1px solid #000;
      }
      .clsp
      {
        display:inline-block; width:100px;
       
      }
      img{border:0; cursor:pointer;}
      #originalfile{width:400px; background-color:#B9D3EE;margin:0px 50px 0px 50px;}
      #originalfile tr td{ background-color:White; text-align:center; height:20px;}
      .clstitleimg{ background-image:url('../../Images/Public/list_tit.png');height:24px; text-align:center;}
      
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $(window).load(function () {
                var imghd = $("#sealpath").height();
                $("#brtxt").height(imghd);
                var hd = $("#brtxt").height();
                var wd = $("#brtxt").width();
                $("<div id='sealshow' style='text-align:right;'><div>").appendTo($("body"));
                $("#sealshow").width(wd);
                $("#sealshow").height(hd);
                $("#sealshow").offset($("#brtxt").offset());
                $("#sealpath").appendTo($("#sealshow"));
                $("#sealpath").show();
                $("#sealpath").css({"opacity":0.4});
            })



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
<body>
  <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidid" />
    <div class="clstop">
       <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <table style=" width:100%; height:100%;">
            <tr>
              <td class="toptitletxt">阅读公司公告</td>
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
           <td style="text-align:center">
              <span id="lblfirmtop" runat="server"></span>
           </td>    
          </tr>
          <tr>
            <td style="text-align:center">
              <span id="lblsfirm" runat="server"></span>
              <span id="lblyear"  runat="server"></span>
              <span id="lblorder" runat="server"></span>
            </td>                  
          </tr>
          <tr>
           <td style="text-align:center">
             <span id="lbltitle" runat="server"></span>
           </td>
          </tr>
          <tr>
           <td>
            <div class="clstxt">
             <div id="lbltxt" runat="server"></div>

             <table style="width:100%;">
               <tr>
                 <td ></td>
                 <td align="right" style=" width:400px;">
                   <table id="brtxt" style="text-align:center;">
                     <tr style=" height:40px;">
                      <td></td>
                     </tr>
                     <tr>
                       <td><span id="lblfirmbottom" runat="server"></span></td>                               
                     </tr>
                     <tr>
                       <td><span id="lbldate" runat="server"></span></td>                                                 
                     </tr>     
                     <tr style=" height:40px;">
                      <td></td>
                     </tr>      
                    </table>                      
                 </td>
               </tr>       
             </table>

            </div>    

           </td>
          </tr>
          <tr>
           <td>
             <div class="clscommon" style=" font-weight:bold;" >
               <span style="display:inline-block; width:90px;">主题词语:</span>  
               <span id="lblword" runat="server"></span>              
             </div> 
             <div class="clscommon" >
               <span style="display:inline-block; width:90px;font-weight:bold;">抄送部门:</span>  
               <span id="lblcarboncopy" runat="server"></span>              
             </div>
             <div class="clscommon" >
               <span style="display:inline-block; width:90px;font-weight:bold;">印发时间:</span>  
               <span id="lblprintime" runat="server"></span>         
             </div>
             <div class="clscommon" >
               <span class="clsp" style="font-weight:bold;">拟稿人员:</span>  
               <span id="lblcreater" runat="server" class="clsp"></span> 
               <span class="clsp" style="font-weight:bold;">校对人员:</span>
               <span id="lblcheckp"  runat="server" class="clsp"></span>
               <span class="clsp" style="font-weight:bold;">签发人员:</span>
               <span id="lblsignp"   runat="server" class="clsp"></span>
             </div>
           </td>
          </tr>
          <tr>
           <td>
             <table id="originalfile" cellpadding="0" cellspacing="1" runat="server">
               <tr>
                <td class="clstitleimg" style=" width:20px;"></td>
                <td class="clstitleimg">名称</td>
                <td class="clstitleimg" style=" width:40px;">下载</td>
               </tr>
             </table>      
           </td>
          </tr>

        </table>
     </div>
     <img id="sealpath" style=" display:none;" runat="server" />  
  </form>
</body>
</html>
