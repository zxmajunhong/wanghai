<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressListSearch.aspx.cs" Inherits="Pages.AddressList.AddressListSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>显示通讯录</title>
    <style type="text/css">     
       body{ margin:0; padding:0; font-size:13px; width:250px;}
      .clstotal{ background-color:#F7F7F7; height:100%;width:100%;}
      .clstxt{width:240px; background-color:White; margin:0px 0px 2px 0px; border:3px solid #CAE1FF;}
      .clsline{ border-bottom:1px solid #C6E2FF;}
      .clswidth{ display:inline-block; width:25px;}
    </style>
</head>
<body>
  <form id="form1" runat="server">
    <div class="clstotal">
      <asp:Repeater runat="server" ID="rptdata">
        <ItemTemplate>
          <div class="clstxt">
            <table>
              <tr>
               <td>中文名称:</td>
               <td><%# Eval("cname") %></td>
              </tr>
              <tr>
               <td>英文名称:</td>
               <td><%# Eval("ename") %></td>
              </tr>
              <tr>
               <td>性<span class="clswidth"></span>别:</td>
               <td><%# Eval("sex") %></td>
              </tr>
              <tr>
               <td>部<span class="clswidth"></span>门:</td>
               <td><%# Eval("departcname") %></td>
              </tr>
              <tr>     
               <td>职<span class="clswidth"></span>务:</td>
               <td><%# Eval("positiontxt") %></td>
              </tr>
              <tr>
               <td>电话号码:</td>
               <td><%# Eval("phone") %></td>           
              </tr>
              <tr> 
               <td>手机号码:</td>
               <td><%# Eval("cellphone")%></td>
              </tr>
              <tr>
               <td>手机短号:</td>
               <td><%# Eval("scellphone")%></td>
              </tr>
              <tr> 
               <td>邮箱地址:</td>
               <td><%# ShowMailbox( Eval("mailbox").ToString()) %></td>
              </tr>
              <tr>
               <td>备<span class="clswidth"></span>注:</td>
               <td><%# Eval("remark") %></td>
              </tr>
            </table>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
   </form>
</body>
</html>
