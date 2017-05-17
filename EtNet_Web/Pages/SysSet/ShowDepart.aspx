<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDepart.aspx.cs" Inherits="Pages.SysSet.ShowDepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门管理</title>
    <link href="../../Styles/page.css" rel="stylesheet" type="text/css" />
    <style  type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px 40px 10px 40px;}
      .clsdata{ width:100%; background-color:#B9D3EE}
      .clsdata tr td{ background-color:White; height:30px; text-align:center;}
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
    </style>

    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


            $("#addtxt").click(function () {
                $("#imgbtnadd").click();
            })



        })
    
    </script>
</head>
<body>
  <form id="form1" runat="server">
    <div class="clstop">
      <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
         <table style=" width:100%; height:100%;">
            <tr>
              <td class="toptitletxt">部门管理</td>
              <td style=" text-align:right; padding-right:20px;">
                <span class="topimgtxt" id="addtxt">   
                   <img alt="新增"  src="../../Images/public/pagedit.png" />
                   <span>新增部门</span>         
                 </span>  
              </td>
            </tr>
           </table>
        </div>
         <div style="background: #4CB0D5; height: 5px;">
      </div>
      <div class="clsbottom">
        <table class="clsdata" cellpadding="0" cellspacing="1">
         <thead>
           <tr>
            <th class="clstitleimg"  style=" width:35%;">中文名称</th>
            <th class="clstitleimg"  style=" width:35%;">英文名称</th>
            <th class="clstitleimg"  style=" width:20%;">自动编码标识符</th>
            <th class="clstitleimg" style=" width:10%;">操作</th>
          </tr>
         </thead>
         <tbody>
           <asp:Repeater runat="server" ID="rptdepartdata" 
                 onitemcommand="rptdepartdata_ItemCommand">
             <ItemTemplate>
               <tr>
                 <td><%# Eval("departcname") %></td>
                 <td><%# Eval("departename") %></td>
                 <td><%# Eval("autocode") %></td>
                 <td>
                  <asp:ImageButton runat="server" CommandName="showuser"  CommandArgument='<%# Eval("departid") %>' ImageUrl="~/Images/public/group.gif" title="显示部门下的用户" />
                  <asp:ImageButton runat="server" CommandArgument='<%# Eval("departid") %>' CommandName="edit" title="编辑" AlternateText="编辑" ImageUrl="~/Images/public/edit.gif" />
                  <asp:ImageButton runat="server" CommandArgument='<%# Eval("departid") %>' OnClientClick="if( !confirm('确定删除!')){ return false}" CommandName="del" AlternateText="删除" title="编辑"  ImageUrl="~/Images/public/delete.gif" />
                 </td>
               </tr>
             </ItemTemplate>
           </asp:Repeater>
         </tbody> 
       </table>
      </div>
      <div id="pages" runat="server"></div>
      <div>
       <asp:ImageButton runat="server" ID="imgbtnadd" CssClass="topbtnimg"
              ImageUrl="../../Images/Button/btn_add.jpg" onclick="imgbtnadd_Click" />
      </div>
  </form>
</body>
</html>
