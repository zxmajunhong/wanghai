<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="EtNet_Web.Pages.Index.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<META http-equiv="X-UA-Compatible" content="IE=10" >
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<head>
    
    <title>显示菜单</title>
    <link href="left.css" rel="stylesheet" type="text/css" />
    <script src="ext-base.js" type="text/javascript"></script>
    <script src="ext-all.js" type="text/javascript"></script>
    <script src="prototype.lite.js" type="text/javascript"></script>
    <script src="moo.fx.js" type="text/javascript"></script>
    <script src="moo.fx.pack.js" type="text/javascript"></script>
    <script src="left.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
      window.onload = function () {
        menulist.init();
      }
    </script>
</head>
<body background="../../Images/Index/leftbg.jpg">
    <div style="margin-top: 10px; text-align: center">
        <table width="100%" height="280" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="182" valign="top" id="panel">
                    <div id="subPanel" style="display: none;">
                        <h1 class="type">
                            <a href="javascript:void(0);">[#Name]</a></h1>
                        <div class="content" ch="[#Height]">
                            <ul class="MM">
                                [#SubMenu]</ul>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
