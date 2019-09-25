<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusUpdate.aspx.cs" Inherits="EtNet_Web.Pages.Customers.CusUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">
        BODY
        {
            font-size: 14px;
            font-family: "宋体";
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
            font-family: "宋体";
        }
        a
        {
            text-decoration: none;
        }
        /*demo所用元素值*/
        #need
        {
            margin: 0 auto 0;
            width: auto;
        }
        #need li
        {
            height: 20px;
            width: auto;
            font: 12px/26px Arial, Helvetica, sans-serif;
            border-bottom: 1px dashed #E0E0E0;
            display: block;
            cursor: text;
            padding: 7px 0px 7px 10px !important;
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
    </style>
    <meta content="MSHTML 6.00.2800.1589" name="GENERATOR">
</head>
<body>
    <form runat="server" id="myform">
    <div style="background-image: url('../../Images/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold;">修改信息</span>
    </div>
    <div class="border">
        <div id="con">
            <ul id="tags">
                <li class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">
                    基本信息</a> </li>
                <li><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">联系人</a>
                </li>
                <li><a onclick="selectTag('tagContent2',this)" href="javascript:void(0)">银行信息</a>
                </li>
                <div style="text-align: right">
                    <asp:Button ID="submit" runat="server" Text="确定提交" OnClick="submit_Click" /></div>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <div class="border">
                        <ol id="need">
                            <li>
                                <label class="">
                                    客&nbsp;&nbsp; 户&nbsp;&nbsp;代&nbsp;&nbsp; 码：</label><input type='text' id='cusCode'
                                        runat="server" /><dfn>客户代码</dfn></li>
                            <li>
                                <label class="">
                                    客&nbsp;&nbsp; 户&nbsp;&nbsp;分&nbsp;&nbsp; 类：</label><input type='text' id='cusType'
                                        runat="server" /><dfn>客户分类</dfn></li>
                            <li>
                                <label class="">
                                    客&nbsp;&nbsp; 户&nbsp;&nbsp;属&nbsp;&nbsp; 性：</label>
                                <asp:DropDownList ID="ddlList" runat="server">
                                    <asp:ListItem Value="0">潜在客户</asp:ListItem>
                                    <asp:ListItem Value="1">正式客户</asp:ListItem>
                                </asp:DropDownList>
                                <dfn>客户属性</dfn></li>
                            <li>
                                <label class="">
                                    客&nbsp;&nbsp; 户&nbsp;&nbsp;简&nbsp;&nbsp; 称：</label><input type='text' id='cusShort'
                                        runat="server" /><dfn> 客户简称</dfn></li>
                            <li>
                                <label class="">
                                    客户中文名称：</label><input type='text' id='cusCname' runat="server" /><dfn>客户中文名称：
                                </dfn></li>
                            <li>
                                <label class="">
                                    公&nbsp;&nbsp; 司&nbsp;&nbsp;网&nbsp;&nbsp; 址：</label><input type='text' id='comURL'
                                        runat="server" /><dfn>公司网址</dfn></li>
                            <li>
                                <label class="">
                                    省 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    份：</label><input type='text' id='cusProvince' runat="server" /><dfn>省份</dfn></li>
                            <li>
                                <label class="">
                                    城 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    市：</label><input type='text' id='cusCity' runat="server" /><dfn>城市</dfn></li>
                            <li>
                                <label class="">
                                    中 &nbsp;&nbsp; 文&nbsp;&nbsp;地&nbsp;&nbsp;址：</label>
                                <input type='text' id='cusCAdd' runat="server" /><dfn>中文地址</dfn></li>
                        </ol>
                    </div>
                </div>
                <div class="tagContent" id="tagContent1">
                    <div class="border">
                        <ol id="need">
                            <li>
                                <label class="">
                                    联系人名称：
                                </label>
                                <input type='text' id='linkName' runat="server" /><dfn>联系人名称</dfn></li>
                            <li>
                                <label class="">
                                    职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;务：
                                </label>
                                <input type='text' id='post' runat="server" /><dfn>职务</dfn></li>
                            <li>
                                <label class="">
                                    电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：
                                </label>
                                <input type='text' id='tel' runat="server" /><dfn> 电话</dfn></li>
                            <li>
                                <label class="">
                                    传&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;真：</label><input
                                        type='text' id='fax' runat="server" /><dfn>传真： </dfn></li>
                            <li>
                                <label class="">
                                    移&nbsp;动&nbsp;&nbsp;电&nbsp;话：</label><input type='text' id='mobile' runat="server" /><dfn>移动电话</dfn></li>
                            <li>
                                <label class="">
                                    电&nbsp;子&nbsp;&nbsp;邮&nbsp;件：</label><input type='text' id='email' runat="server" /><dfn>电子邮件</dfn></li>
                            <li>
                                <label class="">
                                    &nbsp;&nbsp;&nbsp;&nbsp;M&nbsp;S&nbsp;N：&nbsp;&nbsp;&nbsp;&nbsp;
                                </label>
                                <input type='text' id='msn' runat="server" /><dfn>MSN</dfn></li>
                            <li>
                                <label class="">
                                    &nbsp;&nbsp;S&nbsp;k&nbsp;y&nbsp;p&nbsp;e：&nbsp;
                                </label>
                                <input type='text' id='skype' runat="server" />
                                <dfn>Skype</dfn></li>
                        </ol>
                    </div>
                </div>
                <div class="tagContent" id="tagContent2">
                    <div class="border">
                        <ol id="need">
                            <li>
                                <label class="">
                                    开户银行：
                                </label>
                                <input type='text' id='bank' runat="server" /><dfn>开户银行</dfn></li>
                            <li>
                                <label class="">
                                    银行帐号：
                                </label>
                                <input type='text' id='cardId' runat="server" /><dfn>银行帐号</dfn></li>
                            <li>
                                <label class="">
                                    收款名称：
                                </label>
                                <input type='text' id='cardName' runat="server" /><dfn> 收款名称</dfn></li>
                            <li>
                                <label class="">
                                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</label><input type='text' id='remark'
                                        runat="server" /><dfn>备注 </dfn></li>
                        </ol>
                    </div>
                </div>
            </div>
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
    </script>
    </form>
</body>
</html>
