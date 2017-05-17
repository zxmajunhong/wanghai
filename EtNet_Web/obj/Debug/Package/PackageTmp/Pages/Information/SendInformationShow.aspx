<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendInformationShow.aspx.cs" Inherits="EtNet_Web.Pages.Information.SendInformationShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送的消息</title> 
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css"> 
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; background-color:#B9D3EE}
       .clsdata tr td{ background-color:White; height:30px; text-align:center;}
       .clssift{ width:100%;}
       .clsdatalist{ width:200px;}
       .clstitleimg{ background-image:url('../../Images/public/list_tit.png'); color:White; height:24px; font-weight:bold; text-align:center;}
       .clstitleimg:hover{color:Black; }
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
       .clsfilehide{ display:none;}
       .datebox{ border:0;}
       .combo-text{width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsbtntxt{ width:80px; 
                   height:20px; 
                   line-height:20px;
                   cursor:pointer;
                   float:right;
                   background:url('../../Images/public/btn.png');
                   margin-right:5px;
                   text-align:center;              
                   border:1px solid #4CB0D5;}
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
                window.location = "AddInformation.aspx";
            })


            //导出数据
            $("#datago").click(function () {
                $("#imgbtndata").trigger("click");
            })



            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=008&dt=" + new Date().toString(), window.self, strmodal);
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


            //指定时间
            $("#selimgdt").click(function () {
                cdate({ sid: "customdate", hid: "hidcdate" });
                $("#ddldate").val(6);
            })

            //选时间段
            $("#ddldate").change(function () {
                if ($(this).val() == "6") {
                    $("#selimgdt").click();
                }
                else {
                    $("#customdate").text("");
                    $("#hidcdate").val("");
                }
            })



            //删除选中数据项
            $("#btnalldel").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中删除项');
                }
                else {
                    if (confirm('确定删除选中项')) {
                        $("#imgdel").click();
                    }
                }
            })

            //全选或全部选
            $("#btnchkdel").click(function () {
                if ($(".clschkb :checkbox").length == $(".clschkb :checked").length) {
                    $(".clschkb :checkbox").removeAttr("checked");
                }
                else {
                    $(".clschkb :checkbox").attr("checked", "checked");
                }
            })

            


        })
    </script>


   
</head>
<body>
    <form id="form1" runat="server" >
    <input type="hidden" id="hidsift" runat="server" value="0" />
    <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
           <table style=" width:100%; height:100%;">
             <tr>
               <td class="toptitletxt">
                 发送消息管理
               </td>
               <td style=" text-align:right; padding-right:20px;">
                 <span class="topimgtxt" id="editpage">
                   <img  alt="页面编辑" src="../../Images/public/layoutedit.png" />
                   <span>页面编辑</span>
                 </span>
                 <span class="topimgtxt" id="addtxt">   
                   <img alt="新增"  src="../../Images/public/pagedit.png" />
                   <span>新增消息</span>
                 </span>  
                
                 <span class="topimgtxt" id="sifttxt">
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
        <td style="width:40px;">分类:</td>
        <td style="width:240px;"><asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddlsort"></asp:DropDownList></td>                
        <td style="width:40px;" >状态:</td>
        <td style="width:240px;">
          <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddlstatus">
            <asp:ListItem Text="——请选中——"></asp:ListItem>
            <asp:ListItem Text="已发" Value="已发"></asp:ListItem>
            <asp:ListItem Text="待发" Value="待发"></asp:ListItem>
          </asp:DropDownList>
        </td>
        <td style="width:60px;">创建时间:</td>
        <td>
            <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddldate">
               <asp:ListItem  Text="——请选择——" Value="0"></asp:ListItem>
               <asp:ListItem Text="——今天——" Value="1"></asp:ListItem>
               <asp:ListItem Text="——今天之前——" Value="2"></asp:ListItem>
               <asp:ListItem Text="——昨天——" Value="3"></asp:ListItem>
               <asp:ListItem Text="——7天内——" Value="4"></asp:ListItem>
               <asp:ListItem Text="——15天内——" Value="5"></asp:ListItem>
               <asp:ListItem Text="——指定范围——" Value="6"></asp:ListItem>
             </asp:DropDownList>
             <img src="../../Images/Public/calendar.png" id="selimgdt" style=" cursor:pointer;" alt="选取时间范围" />
             <br />
             <span id="customdate"></span>
             <input type="hidden" runat="server" id="hidcdate"/>
        </td>
       </tr>
       <tr>
         <td colspan="6" align="right">
            <asp:ImageButton runat="server" ID="btnsearch" AlternateText="查询" onclick="imgbtnsearch_Click" ImageUrl="~/Images/Button/btn_search.jpg" />
            <asp:ImageButton runat="server" ID="btnreset"  AlternateText="重置" onclick="imgbtnreset_Click"  ImageUrl="~/Images/Button/btn_reset.jpg" /> 
          </td>
       </tr>
      </table>     
     <table class="clsdata" cellspacing="1" cellpadding="0">
         <thead> 
           <tr>
            <td class="clstitleimg" style=" width:40px"></td>
            <td class="clstitleimg" style=" width:100px;">发送人  </td>
            <td class="clstitleimg" style=" width:150px;">创建时间</td>
            <td class="clstitleimg" style=" width:100px;">分类    </td>
            <td class="clstitleimg">内容    </td>     
            <td class="clstitleimg" style=" width:60px;">消息附件 </td>
            <td class="clstitleimg" style=" width:60px;">操作     </td>
           </tr>
         </thead>
         <tbody>
           <asp:Repeater ID="rptinformation" runat="server" onitemcommand="rptinformation_ItemCommand">     
             <ItemTemplate>
               <tr>
                 <td><asp:CheckBox  CssClass="clschkb" runat="server" /></td>
                 <td> <%# Eval("cname") %>      </td>
                 <td> <%# Eval("createtime") %> </td>
                 <td> <%# Eval("txt") %>        </td>
                 <td style="text-align:left;"> <%# CommonlyUsed.Conversion.StrConversion(Eval("contents").ToString()) %> </td>
                 <td>
                   <asp:ImageButton runat="server" title="查看附件" CommandName="lookfile" ImageUrl="~/Images/Public/lookfile.gif" CommandArgument='<%# Eval("id")%>'  /> 
                    <img class='<%# clsfile( Eval("id").ToString()) %>' alt="附件" src="../../Images/Public/enclosure.png" />
                 </td>
                 <td> 
                   <asp:ImageButton runat="server" title="删除" OnClientClick=" return confirm('确定删除');" ImageUrl="~/Images/Public/delete.gif" CommandName="del" CommandArgument='<%# Eval("id")%>' />
                 </td>
               </tr>
             </ItemTemplate>
            </asp:Repeater>
          </tbody>
          <tfoot>
             <tr>
               <td colspan="7" style=" text-align:right;">
                 <div id="btnalldel" class="clsbtntxt">删除选中项</div>
                 <div id="btnchkdel" class="clsbtntxt" title="全部选中时点击将取消所有选中项">全选/全不选</div>
               </td>
             </tr>
           </tfoot>
        </table> 
      <div id="pages" runat="server"></div>
     </div>

     <!-- 功能按钮隐藏区 -->
     <div>
       <asp:ImageButton runat="server" ID="imgdel" Width="0" Height="0" ImageUrl="~/Images/public/btn.png"  onclick="imgdel_Click" />                           
     </div>

   </form>
</body>
</html>
