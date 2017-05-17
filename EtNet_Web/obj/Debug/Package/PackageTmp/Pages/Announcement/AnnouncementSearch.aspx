<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementSearch.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告查看</title>
      <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
      <link href="../../Css/page.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:5px 40px 10px 40px;}
      .clsdata{ width:100%; background-color:#B9D3EE}
      .clsdata tr td{ background-color:White; height:30px; text-align:center;}
      .clssift{ width:100%;}
      .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsdatalist{ width:200px;}
      .clstitleimg{ background-image:url('../../Images/public/list_tit.png');color:White; height:24px; font-weight:bold; text-align:center;}
      .clstitleimg:hover{ color:Black;}
      .topbtnimg{width:0px;height:0px;}
      .topimgtxt{font-size:12px;
                  font-weight:bold; 
                  color:#718ABE;
                  cursor:pointer;
                  display:inline-block;
                  margin-top:4px; 
                  margin-right:6px;
                 }   
       .topimgtxt img{ height:14px; width:14px; margin-right:-6px; margin-bottom:-2px;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
       .buttonStyle{ background:url('../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
       .datebox{ border:0;}
       .combo-text{width:200px; border:0; border-bottom:1px solid #C6E2FF;}
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                window.location = "AnnouncementAdd.aspx";
            })


            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();

            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");
                }
                else {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }

            })



            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=001&dt=" + new Date().toString(), window.self, strmodal);
            })


            //指定时间
            $("#selimgdt").click(function () {
                cdate({ sid: "customdate", hid: "hidcdate" });
                $("#ddldate").val(4);
            })

            //选时间段
            $("#ddldate").change(function () {
                if ($(this).val() == "4") {
                    $("#selimgdt").click();
                }
                else {
                    $("#customdate").text("");
                    $("#hidcdate").val("");
                }
            })



        })
    </script>
</head>
<body>
   <form id="form1" runat="server">
     <input type="hidden" runat="server" id="hidsift" value="0" />
     <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png');  text-align:left; background-repeat:no-repeat; height:25px;">
          <table style=" width:100%;">
            <tr>
              <td class="toptitletxt">
                公告查看列表
              </td>
              <td style=" text-align:right; padding-right:20px;"> 
                <span class="topimgtxt" id="editpage">
                  <img alt="页面编辑" src="../../Images/Public/layoutedit.png" />
                  <span>页面设置</span>
                </span>
                <span class="topimgtxt" id="sifttxt" >
                  <img alt="筛选" />
                  <span>筛选</span>
                </span>
              </td>   
            </tr>
          </table>   
        </div>
        <div style=" background:#4CB0D5; height:5px;"></div>
     </div>
     <div class="clsbottom">
        <table class="clssift">
          <tr>
           <td style=" width:60px;">公告标题:</td>
           <td><input type="text" runat="server" id="ipttitle" class="clsunderline" /></td>
           <td style=" width:60px;">公告分类:</td>
           <td>
             <asp:DropDownList runat="server" ID="ddlsort" CssClass="clsdatalist"></asp:DropDownList>                      
           </td> 
           <td>发布人员:</td>
           <td><asp:DropDownList runat="server" ID="ddlpeople" CssClass="clsdatalist"></asp:DropDownList></td>
          </tr>
          <tr>
           <td>创建时间:</td>
           <td colspan="5">
             <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddldate">
               <asp:ListItem  Text="——请选择——" Value="0"></asp:ListItem>
               <asp:ListItem Text="——今天——" Value="1"></asp:ListItem>
               <asp:ListItem Text="——7天内——" Value="2"></asp:ListItem>
               <asp:ListItem Text="——15天内——" Value="3"></asp:ListItem>
               <asp:ListItem Text="——指定范围——" Value="4"></asp:ListItem>
             </asp:DropDownList>
             <img src="../../Images/Public/calendar.png" id="selimgdt" style=" cursor:pointer;" alt="选取时间范围" />
             <br />
             <span id="customdate"></span>
             <input type="hidden" runat="server" id="hidcdate"/>
           </td>
          </tr>
          <tr>
            <td colspan="6" style=" text-align:right;">
              <asp:ImageButton runat="server" ID="imgbtnsearch" 
                    ImageUrl="~/Images/Button/btn_search.jpg" onclick="imgbtnsearch_Click" />
              <asp:ImageButton runat="server" ID="mgbtnreset" 
                    ImageUrl="~/Images/Button/btn_reset.jpg" onclick="mgbtnreset_Click"  />
            </td>
          </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
          <tr>
            <td class="clstitleimg" style=" width:200px;">标题</td>
            <td class="clstitleimg" style=" width:80px;">分类</td>
            <td class="clstitleimg">有效时间</td>
            <td class="clstitleimg" style=" width:100px;">发布人员</td>  
            <td class="clstitleimg" style=" width:100px;">创建时间</td> 
            <td class="clstitleimg" style=" width:40px;">操作</td>
          </tr>
          <tbody>
            <asp:Repeater runat="server" ID="rptdata" onitemcommand="rptdata_ItemCommand">
              <ItemTemplate>
                <tr>
                  <td><%# Eval("title") %>    </td>
                  <td><%# Eval("sorttxt") %>  </td>
                  <td><%# ShowValidPeriod(Eval("starttime").ToString(),Eval("endtime").ToString(),Eval("period").ToString()) %></td>
                  <td><%# Eval("creatertxt") %></td>            
                  <td><%# DateTime.Parse(Eval("createtime").ToString()).ToString("yyyy-MM-dd") %></td>          
                  <td>
                    <asp:ImageButton  runat="server" title="详情" CommandName="details" AlternateText="详情" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/Public/searchform.png" />       
                  </td>
                </tr>             
              </ItemTemplate>
            </asp:Repeater>
          </tbody>
        </table>
        <div runat="server" id="pages"></div>
     </div>
  </form>
</body>
</html>
