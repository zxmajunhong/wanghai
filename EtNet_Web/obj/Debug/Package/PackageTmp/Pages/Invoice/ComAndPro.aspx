<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComAndPro.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.ComAndPro" %>

<%@ Register TagPrefix="yyc" Assembly="YYControls" Namespace="YYControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Product/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <script src="../Product/artDialog.js" type="text/javascript"></script>
    <script src="../Product/iframeTools.js" type="text/javascript"></script>
    <link href="css/demo.css" rel="stylesheet" type="text/css" />
    <link href="css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Product/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #container
        {
            height: 450px;
            padding-left: 10px;
            padding-top: 10px;
        }
        .txtline
        {
            width: 150px;
            border-bottom: 1px solid #A4C2E0;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: 0;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            margin-bottom: 0px;
        }
        .list-com
        {
            height: 100%;
            border: 0px;
            float: left;
        }
        .selected
        {
            background-color: #ECE9E8;
        }
        h3
        {
            background: url("images/bg.png") no-repeat rgb(255, 255, 255);
            font-weight: normal;
            padding: 0px 0px 0px 15px;
            height: 27px;
            line-height: 27px;
            color: rgb(57, 57, 57);
            font-size: 12px;
        }
        ul#CompanyList
        {
            height: 400px;
            overflow: auto;
            float: left;
            margin-right: 10px;
            background: none repeat scroll 0% 0% rgb(255, 255, 255);
        }
        ul#CompanyList li
        {
            list-style: none;
            height: 20px;
            line-height: 20px;
        }
        .box_r a
        {
            line-height: 20px;
            text-decoration: none;
            display: block;
            float: left;
            width: 300px;
            line-height: 26px;
            border-bottom: 1px dashed #ccc;
            margin-bottom: -1px;
            color: rgb(0, 0, 0);
            padding-left: 5px;
        }
        .box_r a:hover
        {
            color: #01b4f4;
        }
        .box_r
        {
            background: #fff;
            padding: 5px 10px 0 12px;
            border-left: 1px solid #ccc;
            border-right: 1px solid #ccc;
            float: left;
            width: 300px;
        }
        .box_r ul li a
        {
            float: left;
            width: 300px;
            line-height: 26px;
            border-bottom: 1px dashed #ccc;
            margin-bottom: -1px;
        }
        .box-bottom
        {
            position: relative;
            background: #fff;
            width: 234px;
            height: 6px;
            margin: 0 0 10px 0;
            border-left: 1px solid rgb(204, 204, 204);
            border-right: 1px solid rgb(204, 204, 204);
            border-bottom: 1px solid rgb(204, 204, 204);
            clear: both;
        }
        #left
        {
            float: left;
            margin-right: 20px;
        }
        #right
        {
            float: left;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $('ul#CompanyList a').each(function () {
                $(this).click(function () {
                    $(this).addClass('selected').parent().siblings().find('a').removeClass('selected');
                });
            });
        });

        function Save() {
            if ($('#HidComId').val() == "") {
                alert("请选择公司");
                return;
            }

            var origin = artDialog.open.origin;
            var company = origin.document.getElementById('txtUnit');

            company.value = $('#HidComName').val();


            art.dialog.close();
        }

        function myfunction(id, name) {
            $('#HidComId').val(id);
            $('#HidComName').val(name);

        }

        function Cancel() {
            art.dialog.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="top">
            单位名称:<input id="Text1" type="text" runat="server" class="txtline" />
            <asp:ImageButton ID="ibtnSearch" ImageUrl="../../Images/Button/btn_search.jpg" runat="server" />
        </div>
        <div id="left">
            <div class="box_r">
                <asp:Repeater ID="RpCompany" runat="server">
                    <HeaderTemplate>
                        <ul id="CompanyList">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><a href="javascript:void(0);" onclick='myfunction(<%# "\""+ Eval("id").ToString() +"\",\""+ Eval("comCname").ToString()+"\"" %>)'>
                            <%# Eval("comCname")%></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left; position: fixed; bottom: 0px;">
            <a href="javascript:void(0);" onclick="Save()" id="save">
                <img alt="保存" src="../../Images/Button/btn_sure.jpg" /></a> <a href="javascript:void(0);"
                    onclick="Cancel()" id="camcel">
                    <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a></div>
    </div>
    <input id="HidComId" type="hidden" />
    <input id="HidComName" type="hidden" />
    </form>
</body>
</html>
