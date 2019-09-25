<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PictureFolder.aspx.cs" Inherits="EtNet_Web.Pages.Picture.PictureFolder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图库管理</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px 40px 10px 40px;}
       .clsdata{ width:100%; background-color:#B9D3EE; margin-top:10px;}
       .clsdata tr td{ background-color:White; height:30px; text-align:center;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{ width:200px;}
       img{ cursor:pointer; border:0;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
       .clstitleimg{ background-image:url('../../Images/public/list_tit.png');height:24px; text-align:center; color:White; font-weight:bold;}
       .clstitleimg:hover{ color: Black;}
       .buttonStyle{ background:url('../../Images/Common/buticon.gif'); 
                    height:22px;
                    width:64px; 
                    display:none;
                    float:right; 
                    margin-right:5px;
                    text-align:center;
                    line-height:22px;
                    cursor:pointer;
                    border:0; 
                    display:inline-block;
       }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(function () {

                $(".clsdata tr:first td").css({ "height": "24" })
                $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

                $("#addimg,.clsedit").click(function () {
                    var titletxt = "";
                    if ($(this).attr("alt") == "添加新项") {
                        titletxt = "新增图库";
                        $("#hidsel").val(""); //新增
                    }
                    else {
                        titletxt = "编辑图库";
                        $("#iptmc").val($(this).parent("td").prev("td").text());
                        $("#hidsel").val($(this).attr("id")); //编辑                 
                    }
                    $("#sharebox").show();
                    $("#sharebox").dialog({
                        width: 300,
                        height: 100,
                        resizable: false,
                        closable: false,
                        title: titletxt,
                        modal: true
                    });
                })

                //确定
                $("#btns").click(function () {
                    $("#hidtxt").val($("#iptmc").val());
                    if ($("#hidsel").val() == "") {
                        $("#imgbtnadd").click();
                    }
                    else {

                        $("#imgbtnedit").click();
                    }
                })

                //取消
                $("#btnc").click(function () {
                    $("#hidtxt").val("");
                    $("#hidsel").val("");
                    $("#iptmc").val("");
                    $("#sharebox").dialog("close");
                })


               

            })
    </script>
</head>
<body>
  <form id="form1" runat="server">
     <input runat="server" type="hidden" id="hidsel" />
     <input runat="server" type="hidden" id="hidtxt" />
     <div class="clstop">
     <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
       <table style=" width:100%; height:100%;">
        <tr>
         <td class="toptitletxt">图库目录</td>
        </tr>
       </table>
      </div>
      <div style=" background:#4CB0D5; height:5px;"></div>          
    </div>
    <div class="clsbottom">
      <div style="text-align:right;">
          <img alt="添加新项" id="addimg" src="../../Images/Button/btn_add.jpg" />   
      </div>
      <table class="clsdata" cellpadding="0" cellspacing="1">
        <thead>
          <tr>
           <td class="clstitleimg">图库目录</td>
           <td class="clstitleimg" style=" width:40px;">编辑</td>
           <td class="clstitleimg" style=" width:40px;">删除</td>  
         </tr>
        </thead>
        <tbody>
          <asp:Repeater runat="server" ID="rptdata" OnItemCommand="rptdata_ItemCommand">
            <ItemTemplate>
              <tr>
               <td><%# Eval("cname") %></td>
               <td style=" width:40px;"> <img class="clsedit" alt="编辑" id='<%# Eval("id") %> ' title="编辑" src="../../Images/Public/edit.gif" /> </td>
               <td style=" width:40px;"> 
                 <asp:ImageButton  runat="server" title="删除"  CommandName="del" CommandArgument='<%# Eval("id") %>'  OnClientClick="return confirm('确定删除'); "  AlternateText="删除" ImageUrl="~/Images/Public/delete.gif" />
                </td>
              </tr>
            </ItemTemplate>
          </asp:Repeater>  
        </tbody>
      </table>
    </div>
    
    <!-- 功能按钮-->
    <div style=" width:0px; height:0px;">
      <asp:ImageButton runat="server" ID="imgbtnadd"  Width="0" Height="0" 
            ImageUrl="~/Images/Button/btn_add.jpg" onclick="imgbtnadd_Click" />
      <asp:ImageButton runat="server" ID="imgbtnedit"  Width="0" Height="0"
            ImageUrl="~/Images/Button/btn_modify.jpg" onclick="imgbtnedit_Click"  /> 
    </div>
   
   <div id='sharebox' style=" display:none;">
     <div>
      <table>
       <tr>
        <td>图库名称:</td>
        <td><input type="text" class="clsunderline" id="iptmc" /></td>
       </tr>
      </table>
    </div>
    <div style='text-align:right;padding-top:5px;'>
        <span id='btnc' class='buttonStyle'>取消</span>
        <span id='btns' class='buttonStyle'>确定</span>
     </div>
  </div>   

  </form>
</body>
</html>
