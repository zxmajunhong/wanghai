<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCus.aspx.cs" Inherits="EtNet_Web.Pages.Customers.AddCus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">
        BODY
        {
            font-size: 14px;
            font-family: "����";
        }
        OL LI
        {
            margin: 8px;
        }
        #con
        {
            font-size: 12px;
            margin: 0px auto;
            width: 100%;
        }
        #tags
        {
            padding-right: 0px;
            padding-left: 0px;
            padding-bottom: 0px;
            margin: 0px 0px 0px 10px;
            width: 90%;
            padding-top: 0px;
            height: 23px;
        }
        #tags LI
        {
            background: url(images/tagleft.gif) no-repeat left bottom;
            float: left;
            margin-right: 1px;
            list-style-type: none;
            height: 23px;
        }
        #tags LI A
        {
            padding-right: 10px;
            padding-left: 10px;
            background: url(images/tagright.gif) no-repeat right bottom;
            float: left;
            padding-bottom: 0px;
            color: #999;
            line-height: 23px;
            padding-top: 0px;
            height: 23px;
            text-decoration: none;
        }
        #tags LI.emptyTag
        {
            background: none transparent scroll repeat 0% 0%;
            width: 4px;
        }
        #tags LI.selectTag
        {
            background-position: left top;
            margin-bottom: -2px;
            position: relative;
            height: 25px;
        }
        #tags LI.selectTag A
        {
            background-position: right top;
            color: #000;
            line-height: 25px;
            height: 25px;
        }
        #tagContent
        {
            border-right: #aecbd4 1px solid;
            padding-right: 1px;
            border-top: #aecbd4 1px solid;
            padding-left: 1px;
            padding-bottom: 1px;
            border-left: #aecbd4 1px solid;
            padding-top: 1px;
            border-bottom: #aecbd4 1px solid;
            background-color: #fff;
        }
        .tagContent
        {
            padding-right: 10px;
            display: none;
            padding-left: 10px;
            background: url(images/bg.gif) repeat-x;
            padding-bottom: 10px;
            width: auto;
            color: #474747;
            padding-top: 10px;
            height: 100%;
        }
        #tagContent DIV.selectTag
        {
            display: block;
        }
        
        
        html
        {
            background: #FFF;
        }
        body, div, dl, dt, dd, ul, ol, li, h1, h2, h3, h4, h5, h6, pre, form, fieldset, p, blockquote, th, td, ins, hr
        {
            margin: 0px;
            padding: 0px;
        }
        p
        {
            cursor: text;
        }
        h1, h2, h3, h4, h5, h6
        {
            font-size: 100%;
        }
        ol, ul
        {
            list-style-type: none;
        }
        address, caption, cite, code, dfn, em, th, var
        {
            font-style: normal;
            font-weight: normal;
        }
        table
        {
            border-collapse: collapse;
        }
        fieldset, img
        {
            border: 0;
        }
        img
        {
            display: block;
        }
        caption, th
        {
            text-align: left;
        }
        body
        {
            position: relative;
            font-size: 62.5%;
            font-family: "����";
        }
        a
        {
            text-decoration: none;
        }
        /*demo����Ԫ��ֵ*/
        #need
        {
            margin: 0 auto 0;
            width: auto;
        }
        #need li
        {
            height: 16px;
            width: auto;
            font: 12px/26px Arial, Helvetica, sans-serif;
            border-bottom: 1px dashed #E0E0E0;
            display: block;
            cursor: text;
            padding: 0px 0px 10px 0px !important;
            padding: 5px 0px 5px 10px;
        }
        #need li:hover, #need li.hover
        {
        }
        #need input
        {
            background-color: transparent;
            line-height: 14px;
            height: 14px;
            width: 200px;
            border: 0px solid #E0E0E0;
            vertical-align: middle;
            padding: 6px;
            border-bottom: 1px solid #C6E2FF;
        }
        #need label
        {
            padding-left: 30px;
        }
        #need label.old_password
        {
            background-position: 0 -277px;
        }
        #need label.new_password
        {
            background-position: 0 -1576px;
        }
        #need label.rePassword
        {
            background-position: 0 -1638px;
        }
        #need label.email
        {
            background-position: 0 -429px;
        }
        #need dfn
        {
            display: none;
        }
        #need li:hover dfn, #need li.hover dfn
        {
            display: inline;
            margin-left: 7px;
            color: #676767;
        }
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 30px 0px;
        }
        #ddlList
        {
            width: 100px;
        }
        #none
        {
            display: none;
        }
    </style>
    <link href="main.css" rel="stylesheet" type="text/css" />
    <meta content="MSHTML 6.00.2800.1589" name="GENERATOR">
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <link href="default.css" rel="stylesheet" type="text/css" />
    <script src="iframeTools.js" type="text/javascript"></script>
    <script src="../../Scripts/jNotify.jquery.js" type="text/javascript"></script>
    <link href="../../CSS/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">


        function clickAdd(id) {
            art.dialog.open('Add.aspx?id=' + id).lock().title('��Ӵ�Ҫ��ϵ��');
        }

        $(function () {
            $("#add").click(function () {

                var str = "";
                if ($("#cusCode").val() == "") {
                    str += "�ͻ��������<br/>";
                }
                if ($("#cusType").val() == "") {
                    str += "�ͻ�������<br/>";
                }
                if ($("#cusShort").val() == "") {
                    str += "�ͻ���Ʊ���<br/>";
                }

                if ($("#cusCname").val() == "") {
                    str += "�������Ʊ���<br/>";
                }
                if ($("#linkname").val() == "") {
                    str += "��ϵ�����Ʊ���<br/>";
                }
                if ($("#linkfax").val() == "") {
                    str += "��ϵ�˴������<br/>";
                }
                if ($("#linkemail").val() == "") {
                    str += "��ϵ���������<br/>";
                }
                if ($("#linktel").val() == "") {
                    str += "��ϵ�˵绰����";
                }

                if (str) {
                    jNotify(str, {
                        HorizontalPosition: "center",
                        VerticalPosition: "center"
                    });
                    return false;
                }
                else {
                    return true;
                }
            })
        })
    </script>
</head>
<body onload='init();'>
    <form runat="server" id="myform">
    <div style="background-image: url('../../Images/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold;">��ӿͻ�</span>
    </div>
    <div class="border">
        <div id="con">
            <ul id="tags">
                <li class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">
                    ������Ϣ</a> </li>
                <li><a id="link" onclick="selectTag('tagContent1',this)" href="javascript:void(0)">��ϵ��</a>
                </li>
                <li><a id="abank" onclick="selectTag('tagContent2',this)" href="javascript:void(0)">
                    ����������Ϣ</a> </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <div class="border">
                        <ol id="need">
                            <li>������Ϣ</li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp; ��&nbsp;&nbsp;��&nbsp;&nbsp; �룺</label><input type='text' id='cusCode'
                                        runat="server" /><dfn style="color: Red">������</dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp; ��&nbsp;&nbsp;��&nbsp;&nbsp; �ࣺ</label><input type='text' id='cusType'
                                        runat="server" /><dfn style="color: Red">������</dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp; ��&nbsp;&nbsp;��&nbsp;&nbsp; �ƣ�</label><input type='text' id='cusShort'
                                        runat="server" /><dfn style="color: Red"> ������</dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp; ��&nbsp;&nbsp;��&nbsp;&nbsp; �ԣ�</label>
                                <asp:DropDownList ID="ddlList" runat="server">
                                    <asp:ListItem Value="0">Ǳ�ڿͻ�</asp:ListItem>
                                    <asp:ListItem Value="1">��ʽ�ͻ�</asp:ListItem>
                                </asp:DropDownList>
                                <dfn></dfn></li>
                            <li>
                                <label class="">
                                    �ͻ��������ƣ�</label><input type='text' id='cusCname' runat="server" /><dfn style="color: Red">������
                                    </dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp; ˾&nbsp;&nbsp;��&nbsp;&nbsp; ַ��</label><input type='text' id='comURL'
                                        runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">
                                    ʡ&nbsp;&nbsp; ��&nbsp;&nbsp;��&nbsp;&nbsp; �У�</label>
                                <script src="select.js" type="text/javascript" charset="gb2312"></script>
                                <%--<input id="address" name="address" type="text"  style="width: 100px;" />--%>
                                <asp:TextBox ID="address" name="address" runat="server" Style="width: 100px;"></asp:TextBox>
                                <select name="sheng" onchange="select()">
                                </select>
                                <select name="shi" onchange="select()">
                                </select>
                                <dfn></dfn></li>
                            <li>
                                <label class="">
                                    �� &nbsp;&nbsp; ��&nbsp;&nbsp;��&nbsp;&nbsp;ַ��</label>
                                <input type='text' id='cusCAdd' runat="server" /><dfn style="color: Red">������</dfn></li>
                            <li>��Ҫ��ϵ�� </li>
                            <li>
                                <label class="">
                                    ��ϵ�����ƣ�</label><input type='text' id='linkname' runat="server" /><dfn style="color: Red">������</dfn></li>
                            <li>
                                <label class="">
                                    ְ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ��</label><input
                                        type='text' id='linkpost' runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����</label>
                                <input type='text' id='linktel' runat="server" />
                                <dfn style="color: Red">������</dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �棺</label><input
                                        type='text' id='linkfax' runat="server" /><dfn style="color: Red"> ������</dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;��&nbsp;��&nbsp;����</label><input type='text' id='linkmobile' runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;��&nbsp;��&nbsp;����</label><input type='text' id='linkemail' runat="server" /><dfn
                                        style="color: Red">������</dfn></li>
                            <li>
                                <label class="">
                                    &nbsp;&nbsp; MSN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ��</label><input type='text' id='linkmsn'
                                        runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">
                                    &nbsp; Skype&nbsp;&nbsp;&nbsp;&nbsp; ��</label><input type='text' id='linkskype' runat="server" /><dfn></dfn></li>
                            <li>������Ϣ</li>
                            <li>
                                <label class="">
                                    �������У�
                                </label>
                                <input type='text' id='cusBank' runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">
                                    �����ʺţ�
                                </label>
                                <input type='text' id='cusBankID' runat="server" /><dfn></dfn></li>
                            <li>
                                <label class="">
                                    �տ����ƣ�
                                </label>
                                <input type='text' id='cusBankName' runat="server" /><dfn> </dfn></li>
                            <li>
                                <label class="">
                                    ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ע��</label><input type='text' id='cusRemark'
                                        runat="server" /><dfn> </dfn></li>
                        </ol>
                    </div>
                    <div style="text-align: left; padding-top: 4px;">
                        <asp:Button ID="add" runat="server" Text="ȷ���ύ" OnClick="add_Click" /></div>
                </div>
                <div class="tagContent" id="tagContent1">
                    <div class="border" id="slider">
                        <table class="usertableborder" cellspacing="1" cellpadding="3" width="96%" align="center"
                            border="0">
                            <thead>
                                <tr>
                                    <%--<th width="5%">
                            <input id="allClick" type="checkbox" onchange="ReSelectCheckBox()" />
                        </th>--%>
                                    <th width="60px;">
                                        ����
                                    </th>
                                    <th width="60px">
                                        ְ��
                                    </th>
                                    <th width="90px">
                                        �绰
                                    </th>
                                    <th width="90px">
                                        ����
                                    </th>
                                    <th width="90px">
                                        �ƶ��绰
                                    </th>
                                    <th width="120px">
                                        �����ʼ�
                                    </th>
                                    <th width="120px">
                                        MSN
                                    </th>
                                    <th width="80px">
                                        Skype
                                    </th>
                                </tr>
                            </thead>
                            <tbody align="center">
                                <asp:Repeater ID="linklist" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <%--<td align="center">
                                    <input id="Checkbox1" type="checkbox" />
                                </td>--%>
                                            <td>
                                                <%#Eval("linkName")%>
                                            </td>
                                            <td>
                                                <%#Eval("post")%>
                                            </td>
                                            <td>
                                                <%#Eval("telephone")%>
                                            </td>
                                            <td>
                                                <%#Eval("fax")%>
                                            </td>
                                            <td>
                                                <%#Eval("mobile")%>
                                            </td>
                                            <td>
                                                <%#Eval("email")%>
                                            </td>
                                            <td>
                                                <%#Eval("msn")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("skype")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tr align="left">
                                <td colspan="8">
                                    <a onclick="clickAdd(2)" id="addnew" href="#">
                                        <img src="images/add.png" style="display: inline" />�����ϵ��</a>
                                </td>
                            </tr>
                        </table>
                        <div id="tip" runat="server">
                        </div>
                    </div>
                </div>
                <div class="tagContent" id="tagContent2">
                    <div class="border" id="Div1">
                        <table class="usertableborder" cellspacing="1" cellpadding="3" width="96%" align="center"
                            border="0">
                            <thead>
                                <tr>
                                    <%--<th width="5%">
                            <input id="allClick" type="checkbox" onchange="ReSelectCheckBox()" />
                        </th>--%>
                                    <th width="60px;">
                                        ��������
                                    </th>
                                    <th width="60px">
                                        ���п���
                                    </th>
                                    <th width="90px">
                                        �տ�����
                                    </th>
                                    <th width="90px">
                                        ��ע
                                    </th>
                                </tr>
                            </thead>
                            <tbody align="center">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <%--<td align="center">
                                    <input id="Checkbox1" type="checkbox" />
                                </td>--%>
                                            <td>
                                                <%#Eval("linkName")%>
                                            </td>
                                            <td>
                                                <%#Eval("post")%>
                                            </td>
                                            <td>
                                                <%#Eval("telephone")%>
                                            </td>
                                            <td>
                                                <%#Eval("fax")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tr align="left">
                                <td colspan="8">
                                    <a onclick="clickAdd(2)" id="a1" href="#">
                                        <img src="images/add.png" style="display: inline" />���������Ϣ</a>
                                </td>
                            </tr>
                        </table>
                        <div id="Div2" runat="server">
                        </div>
                    </div>
                </div>
                <asp:Label ID="none" runat="server" Text="1"></asp:Label>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function selectTag(showContent, selfObj) {
            // ������ǩ
            var tag = document.getElementById("tags").getElementsByTagName("li");


            var tag = document.getElementById("tags").getElementsByTagName("li");
            var taglength = tag.length;
            for (i = 0; i < taglength; i++) {
                tag[i].className = "";
            }

            selfObj.parentNode.className = "selectTag";

            // ��������
            for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                j.style.display = "none";
            }
            document.getElementById(showContent).style.display = "block";
        }
        var tip = document.getElementById("none").innerHTML;

        if (tip == 0) {
            document.getElementById("link").onclick = void (0);
            document.getElementById("abank").onclick = void (0);
        }
    </script>
    </form>
</body>
</html>
