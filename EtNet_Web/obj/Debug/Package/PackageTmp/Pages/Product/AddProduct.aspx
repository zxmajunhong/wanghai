<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="EtNet_Web.Pages.Product.AddProduct" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <link href="../../kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="../../kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="../../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../../kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <style type="text/css">
        BODY{font-size: 14px;font-family: "宋体";}
        OL LI{margin: 8px;}
        #con{font-size: 12px;margin: 0px auto;width: 600px;}
        #tags{padding-right: 0px;padding-left: 0px;padding-bottom: 0px;margin: 0px 0px 0px 10px;width: 90%;padding-top: 0px;height: 23px;}
        #tags LI{background: url(../../images/public/tagleft.gif) no-repeat left bottom;float: left;margin-right: 1px;list-style-type: none;height: 23px;}
        #tags LI A{padding-right: 10px;padding-left: 10px;background: url(../../images/public/tagright.gif) no-repeat right bottom;float: left;padding-bottom: 0px;color: #999;line-height: 23px;padding-top: 0px;height: 23px;text-decoration: none;}
        #tags LI.emptyTag{background: none transparent scroll repeat 0% 0%;width: 4px;}
        #tags LI.selectTag{background-position: left top;margin-bottom: -2px;position: relative;height: 25px;}
        #tags LI.selectTag A{background-position: right top;color: #000;line-height: 25px;height: 25px;}
        #tagContent{border-right: #aecbd4 1px solid;padding-right: 1px;border-top: #aecbd4 1px solid;padding-left: 1px;padding-bottom: 1px;border-left: #aecbd4 1px solid;padding-top: 1px;border-bottom: #aecbd4 1px solid;background-color: #fff;height:90%}
        .tagContent{padding-right: 10px;display: none;padding-left: 10px;background: url(../Customers/images/bg.gif) repeat-x;padding-bottom: 10px;width: auto;color: #474747;padding-top: 10px;height: 100%;}
        #tagContent DIV.selectTag{display: block;}
        /*demo所用元素值*/
        #need{margin: 0 auto 0;width: 90%;}
        #need li
        {height: 26px;width: auto;font: 12px/26px Arial, Helvetica, sans-serif;border-bottom: 1px dashed #E0E0E0;display: block;cursor: text;padding: 7px 0px 7px 10px !important;padding: 5px 0px 5px 10px;}
        #need input{background-color: transparent;line-height: 14px;height: 14px;width: 300px;border: 0px solid #E0E0E0;vertical-align: middle;padding: 6px;border-bottom: 1px solid #C6E2FF;outline:none;}
        #need span input{width:15px;}
        #need label{padding-left: 10px;}
        #need dfn{display: none;}
        .border{font-size: 12px;border: 1px solid #4CB0D5;padding: 10px 0px 30px 0px;height:90%;}
        .frameBtn{float:right;margin-right:10px;margin-top:0px}
    </style>
    <meta content="MSHTML 6.00.2800.1589" name="GENERATOR">
</head>
<body>
    <form runat="server" id="myform">
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
        <div id="con">
            <ul id="tags">
                <li class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">
                    基础资料</a> </li>
                <li><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">保险条款</a>
                </li>
                <li style="float:right;background:none;width:210px;">
                    <asp:ImageButton CssClass="frameBtn" OnClientClick="return CheckProData()"
                        ID="btnAdd" ImageUrl="../../Images/Button/btn_save.jpg" OnClick="btnAdd_Click" runat="server" />
                </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <%--<div class="border">--%>
                        <table id="need">
                            <tr>
                                <td align="right">所属险种：</td>
                                <td><input type='text' id='txtType' readonly="readonly" runat="server" /><dfn></dfn></td>
                            </tr>
                            <tr>
                                <td align="right">项目名称：</td>
                                <td><input type='text' id='txtName' runat="server" /><dfn id="msg"></dfn></td>
                            </tr>
                            <tr>
                                <td align="right">是否为主险种：</td>
                                <td><asp:CheckBox style="padding:0px;margin:0px" ID="chkMain" runat="server" /><dfn></dfn></td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">备注：</td>
                                <td><textarea style="resize:none;height:200px;width:300px" id="txtMark" runat="server"></textarea><dfn></dfn></td>
                            </tr>
                        </table>
                        <%--<ol id="need">
                            <li>
                                <label class="">所属险种：</label>
                                <input type='text' id='txtType' readonly="readonly" runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">项目名称：</label>
                                <input type='text' id='txtName' runat="server" /><dfn id="msg"></dfn></li>
                            <li>
                                <span>
                                    <label class="">是否为主险种：</label>
                                    <asp:CheckBox style="padding:0px;margin:0px" ID="chkMain" runat="server" /><dfn></dfn>
                                </span>
                            </li>
                            <li style="border-bottom:none;margin-bottom:20px">
                                <table>
                                    <tr>
                                        <td valign="top"><label style="margin-top:0px;padding-top:0px" class="">备注：</label></td>
                                        <td><textarea style="resize:none;height:70px;width:300px" id="txtMark" runat="server"></textarea><dfn></dfn></td>
                                    </tr>
                                </table>
                            </li>
                        </ol>--%>
                    <%--</div>--%>
                </div>
                <div class="tagContent" id="tagContent1">
                    <%--<div class="border">--%>
                        <textarea id="txtBrief" cols="20" rows="2" style="width:100%;height:280px;visibility:hidden;" runat="server"></textarea>
                        <%--<ol id="need">
                            <li>
                                <label class="">
                                    保险条款：
                                </label>
                                <textarea id="txtBrief" cols="20" rows="2" runat="server"></textarea><dfn></dfn></li>
                        </ol>--%>
                    <%--</div>--%>
                </div>
                <%--<asp:Button ID="btnAdd" runat="server" CssClass="aui_button" Text="Button" onclick="btnAdd_Click" />--%>
                
            </div>
        </div>
    <script type="text/javascript">
        function selectTag(showContent, selfObj) {
            // 操作标签
            var tag = document.getElementById("tags").getElementsByTagName("li");
            var taglength = tag.length;
            for (i = 0; i < taglength; i++) {
                tag[i].className = "";
            }
            selfObj.parentNode.className = "selectTag";
            // 操作内容
            for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                j.style.display = "none";
            }
            document.getElementById(showContent).style.display = "block";
        }

        function CheckProData() {
            if ($("#txtName").val() == "") {
                $("#msg").html("险种名称为必填项，请填写！").show();
                return false;
            }
            else if ($("#txtName").val().length > 60) {
                $("#msg").html("险种名称为必填项，请填写！").show();
                return false;
            }
            else {
                $("#msg").hide();
            }

            getHtml();
        }

        function goBack() {
            var origin = artDialog.open.origin;
            var btn = origin.document.getElementById('btnPro');
            btn.click();
            art.dialog.close();
        }

        function getHtml() {
            $("#hidHtml").val(window.encodeURI(editer.html()));
            editer.html("");
            return true;
        }

        window.editer = null;
        KindEditor.ready(function (K) {
           editer= K.create('#txtBrief', {
                items: [
						'bold', 'italic', 'underline', 'fontname', 'fontsize', 'forecolor', 'hilitecolor', 'plug-align', 'plug-order', 'plug-indent', 'link', 'table', '|', 'justifyleft',
                        'justifycenter', 'justifyright', 'justifyfull', '|', 'insertorderedlist', 'insertunorderedlist',''
					]
            });
        });
    </script>
    <input id="hidHtml" type="hidden" runat="server" />
    </form>
</body>
</html>
