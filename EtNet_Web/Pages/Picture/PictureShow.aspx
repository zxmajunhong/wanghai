<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PictureShow.aspx.cs" Inherits="EtNet_Web.Pages.Picture.PictureShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>显示图片列表</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; border:1px solid #B9D3EE; padding:2px;  height:320px; overflow:auto;}
       .clssift{ width:100%;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{ width:200px;}
       .clstitleimg{ background-image:url('../../Images/Public/list_tit.png'); color:White; height:24px; font-weight:bold; text-align:center;}
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
       .pictotal{float:left;border:1px solid #CAE1FF; width:120px;margin:15px;}
       .pictotal:hover{border:1px solid #AA11C1;}
       .pictop{ text-align:center; width:100%; height:80px; line-height:80px;  background:#FAFAFA;}       
       .pictop img{ max-width:70px; max-height:70px; margin-top:5px;}
       .piccenter{ text-align:center; min-height:25px; max-width:120px; overflow:hidden;}
       .picbottom{ text-align:right; height:25px; }
       .picbtne,.picbtnd{ background-image:url('../../Images/public/btn.png'); 
                   border:1px solid #E6E6FA;
                   cursor:pointer;
                   width:40px;
                   margin-right:4px;
                   height:20px; 
                   display:inline-block;
                   text-align:center;
                   line-height:20px;}
    </style>
   

    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {


            //新增
            $("#addtxt").click(function () {
                window.location = "PictureAdd.aspx";
            })

            //查看共享
            $("#share").click(function () {
                window.location = "PictureShareShow.aspx";
            })



            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=009&dt=" + new Date().toString(), window.self, strmodal);
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



            //点击编辑
            $(".picbtne").click(function () {
                window.location = "PictureModify.aspx?id=" + $(this).attr("id") + "&dt=" + new Date().toString()
               
            })



            //点击删除
            $(".picbtnd").click(function () {
                if (confirm('确定删除')) {
                    $("#hiddel").val($(this).attr("id"));
                    $("#btndel").click();
                }
                else {
                    $("#hiddel").val("");
                }
            })




        })
    </script>


   
</head>
<body>
    <form id="form1" runat="server" >
    <input type="hidden" id="hidsift" runat="server" value="0" />
    <input type="hidden" id="hiddel" runat="server" />
    <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
           <table style=" width:100%; height:100%;">
             <tr>
               <td class="toptitletxt">
                 查看个人图片
               </td>
               <td style=" text-align:right; padding-right:20px;">
                 <span class="topimgtxt" id="editpage">
                   <img  alt="页面编辑" src="../../Images/public/layoutedit.png" />
                   <span>页面编辑</span>
                 </span>
                 <span class="topimgtxt" id="addtxt">   
                   <img alt="新增"  src="../../Images/public/pagedit.png" />
                   <span>新增图片</span>         
                 </span>
                 <span class="topimgtxt" id="share">   
                   <img alt="查看共享"  src="../../Images/public/zoom.gif" />
                   <span>查看共享</span>         
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
        <td style="width:60px;">图片名称:</td>
        <td style="width:240px;">
          <input type="text" runat="server" id="iptcname" class="clsunderline"/>
        </td>                
        <td style="width:60px;" >所属图集:</td>
        <td style="width:240px;">
          <asp:DropDownList ID="ddlfolder" runat="server" CssClass="clsdatalist"></asp:DropDownList>
        </td>
        <td style="width:60px;">图片格式:</td>
        <td style="width:240px;">
          <asp:DropDownList ID="ddlformat" runat="server" CssClass="clsdatalist"></asp:DropDownList>
        </td>       
       </tr>
       <tr>
         <td colspan="6" align="right">
            <asp:ImageButton runat="server" ID="btnsearch" AlternateText="查询"  
                 ImageUrl="~/Images/Button/btn_search.jpg" onclick="btnsearch_Click" />
            <asp:ImageButton runat="server" ID="btnreset"  AlternateText="重置"  
                 ImageUrl="~/Images/Button/btn_reset.jpg" onclick="btnreset_Click" /> 
          </td>
       </tr>
      </table>     
      <div id="picturedata" class="clsdata" runat="server"></div>
      <div id="pages" runat="server"></div>
     </div>

     <!-- 功能按钮-->
     <div style=" display:none;">
       <asp:Button runat="server" ID="btndel" Width="0" Height="0" onclick="btndel_Click" />
     </div>
   </form>
</body>
</html>
