<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementDetialFirm.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementDetialFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看公司公告</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
      .clsdata{ width:100%;border:1px solid #CDC9C9;}
      .clsdata tr td{ height:24px;}
      .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
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
      .clsauditxt{margin:0px 50px 0px 50px;}
      .clsauditpic{border:1px solid #63B8FF; margin:0px 50px 0px 50px;}
      .clsborder{border:1px solid red!important;}         
      #optiniontxt{ border:1px solid #63B8FF; 
                  margin:0px 50px 0px 50px;
                  height:60px;
                  background-color:#F2F2F2;
                  padding-top:5px;
                  line-height:20px;
                  overflow:auto;
                 }         
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
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
                $("#sealpath").css({ "opacity": 0.4 });

                $("#auditpic div").each(function () {
                    var vpath = $(this).css("background-image");
                    if (vpath.lastIndexOf('.') != -1) {
                        var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                        $(this).css({ "background-image": str });
                    }
                })

                if ($("#hidlist").val() == "-1") {
                    $("#start").addClass("clsborder");
                }
                else if ($("#hidlist").val() == "0") {
                    $("#end").addClass("clsborder");
                }
                else {
                    var str = $("#hidlist").val();
                    var list = null;
                    if (str.indexOf(',') != -1) {
                        list = str.split(',');
                    }
                    else {
                        list = [str];
                    }
                    for (var i = 0; i < list.length; i++) {
                        if ($(".cls" + $.trim(list[i])).length != 0) {
                            $(".cls" + $.trim(list[i])).addClass("clsborder");
                        }
                    }
                }
        
            })


        })
    </script>

</head>
<body>
  <form id="form1" runat="server">
    <input type="hidden" id="hidlist" runat="server"/>
    <div class="clstop">
       <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <table style=" width:100%; height:100%;">
            <tr>
              <td class="toptitletxt">查看公司公告</td>
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
           <td style="text-align:center;">
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
               <span style="display:inline-block; width:90px; font-weight:bold;">抄送部门:</span>  
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
          <tr>
           <td><div class="clsauditxt">审批流程图:</div></td>
          </tr>
          <tr>
            <td>
              <div id="auditpic" class="clsauditpic" runat="server"></div>
            </td>
          </tr>
          <tr>
           <td><div class="clsauditxt">审批意见:</div></td>
          </tr>
          <tr>
            <td><div id="optiniontxt" runat="server"></div></td>
          </tr>
        </table>
     </div>
     <img id="sealpath" style=" display:none;" runat="server" />  
  </form>
</body>
</html>
