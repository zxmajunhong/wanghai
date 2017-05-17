<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusListAssign.aspx.cs" Inherits="EtNet_Web.Pages.CusInfo.CusListAssign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户分配</title>
    <link href="default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .clsbottom{ font-size: 12px; border: 1px solid #4CB0D5; padding:5px;}     
       .clsdata{width: 100%; background-color: #B9D3EE;   }
        .clsdata tr td{ background-color: White; height: 30px; text-align: center; }   
       .toptitletxt{color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;font-weight: bold;}              
       .clstitleimg{ background-image: url('../../Images/public/list_tit.png'); color:White; font-weight:bold; }
       .clstitleimg:hover{ color: Black;  }
    </style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">

        function sharelist(cid) {
            art.dialog.open('ShareCusList.aspx?id=' + cid, { title: '客户分配', width: 700, close: function () { window.location = window.location; } }).lock();
        }

        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

           
        })
    
    </script>
</head>
<body>
  <form id="form1" runat="server">
    <div class="clstop">
      <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left; background-repeat: no-repeat; height: 25px;">        
         <table style="width: 100%;">
           <tr>
            <td class="toptitletxt">客户分配</td>   
          </tr>
         </table>
      </div>
      <div style="background: #4CB0D5; height: 5px;"></div>
    </div>
    <div class="clsbottom">
       <table class="clsdata" cellspacing="1" cellpadding="0">
         <thead>
          <tr>
           <td class="clstitleimg" style=" width:200px;">用户列表</td>
           <td class="clstitleimg">所属部门</td>
           <td class="clstitleimg" style=" width:100px;"  >设置</td>
          </tr>
         </thead>
         <tbody>
           <asp:Repeater runat="server" ID="rptdata" OnItemCommand="rptdata_ItemCommand">
               <ItemTemplate>
                  <tr>
                    <td><%# Eval("cname")  %></td>  
                    <td><%# ShowDepart(Eval("departid").ToString()) %> </td>          
                    <td>
                       <asp:ImageButton title="共享" runat="server" CommandName="Share" CommandArgument='<%# Eval("id") %>'  ImageUrl="~/Images/public/group.gif" />
                    </td>
                  </tr>
                </ItemTemplate>
             </asp:Repeater>
         </tbody>    
       </table>

    </div>
  </form>
</body>
</html>
