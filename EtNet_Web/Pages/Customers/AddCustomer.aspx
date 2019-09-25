<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="EtNet_Web.Pages.Customers.AddCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设置</title>
    <style>
@charset "utf-8";
/*元素初始值*/
html {background: #FFF;}
body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,form,fieldset,p,blockquote,th,td,ins,hr{margin: 0px;padding: 0px;}
p{cursor: text;}
h1,h2,h3,h4,h5,h6{font-size:100%;}
ol,ul{list-style-type: none;}
address,caption,cite,code,dfn,em,th,var{font-style:normal;font-weight:normal;}
table,td{ height:25px;}
fieldset,img{border:0;}
img{display:block;}
caption,th{text-align:left;}
body{position: relative;font-size:62.5%;font-family: "宋体" ; }
a{text-decoration: none;}
span{ font-size:15px; font-style:inherit; color:blue;}
.clsdata{ width:95%; border:1px solid #CDC9C9;}
/*所用元素值*/
#need {margin: 0 auto 0;width: auto;}
#need li {height: 26px;width: auto;font: 12px/26px Arial, Helvetica, sans-serif;background: white;border-bottom: 1px dashed #E0E0E0;display: block;cursor: text;padding: 7px 0px 7px 10px!important;padding: 5px 0px 5px 10px;}
#need li:hover,#need li.hover {background: white;}
input {line-height: 14px;background: white;height: 14px;width: 200px;border: 0px solid #E0E0E0;vertical-align: middle;padding: 6px;border-bottom:1px solid #C6E2FF;}
#need label {padding-left: 30px;}
#need label.old_password {background-position: 0 -277px;}
#need label.new_password {background-position: 0 -1576px;}
#need label.rePassword {background-position: 0 -1638px;}
#need label.email {background-position: 0 -429px;}
#need dfn {display: none;}
#need li:hover dfn, #need li.hover dfn {display:inline;margin-left: 7px;color: #676767;}
.border{ font-size:12px; border:1px solid #4CB0D5; padding:10px 0px 30px 0px;}
</style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../SystemSetting/iframeTools.js" type="text/javascript"></script>
    <script src="../SystemSetting/artDialog.js" type="text/javascript"></script>
    <script src="../../JS/NbspSlider/jquery.nbspSlider.1.1.min.js" type="text/javascript"></script>
    <link href="../SystemSetting/default.css" rel="stylesheet" type="text/css" />
    <link href="css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function suckerfish(type, tag, parentId) {
            if (window.attachEvent) {
                window.attachEvent("onload", function () {
                    var sfEls = (parentId == null) ? document.getElementsByTagName(tag) : document.getElementById(parentId).getElementsByTagName(tag);
                    type(sfEls);
                });
            }
        }
        hover = function (sfEls) {
            for (var i = 0; i < sfEls.length; i++) {
                sfEls[i].onmouseover = function () {
                    this.className += " hover";
                }
                sfEls[i].onmouseout = function () {
                    this.className = this.className.replace(new RegExp(" hover\\b"), "");
                }
            }
        }
        suckerfish(hover, "li");

        $(function () {
            //滑动效果
            $("#slider").nbspSlider({
                effect:	"vertical"
            });
        })
        
    </script>
</head>
<body style="padding: 10px;">
    <div style="background-image: url('../../Images/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold;">添加客户</span>
    </div>
    <div class="border" id="slider">
        <ul>
            <li style="padding-right: 25px; padding-left: 25px;">
                <table class="clsdata" style="padding-left: 20px; ">
                    <tr>
                        <td colspan="2" align="center">
                            <label>
                                <span>基 本 信 息</span></label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            客户代码：
                        </td>
                        <td>
                            <input name='' type='text' id='' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            客户分类：
                        </td>
                        <td>
                            <input name='' type='text' id='Text1' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            客户简称：
                        </td>
                        <td>
                            <input name='' type='text' id='' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            客户中文名称：
                        </td>
                        <td>
                            <input name='' type='text' id='Text2' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            公司网址：
                        </td>
                        <td>
                            <input name='' type='text' id='' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            省份：
                        </td>
                        <td>
                            <input name='' type='text' id='Text3' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            城市：
                        </td>
                        <td>
                            <input name='' type='text' id='' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            中文地址：
                        </td>
                        <td>
                            <input name='' type='text' id='Text4' style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </li>
            <li style="padding-right: 25px; padding-left: 25px;">
                <table class="clsdata" style="padding-left: 20px; padding-right:20px;">
                    <tr>
                        <td colspan="2" align="center">
                            <label>
                                <span>主 要 联 系 人</span></label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">
                            联系人名称：
                        </td>
                        <td>
                            <input name='' type='text' id='Text5' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            职务：
                        </td>
                        <td>
                            <input name='' type='text' id='Text6' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电话：
                        </td>
                        <td>
                            <input name='' type='text' id='Text7' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            传真：
                        </td>
                        <td>
                            <input name='' type='text' id='Text8' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            移动电话：
                        </td>
                        <td>
                            <input name='' type='text' id='Text9' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电子邮件：
                        </td>
                        <td>
                            <input name='' type='text' id='Text10' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MSN：
                        </td>
                        <td>
                            <input name='' type='text' id='Text11' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Skype：
                        </td>
                        <td>
                            <input name='' type='text' id='Text12' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </li>

            <li style="padding-right: 250px; padding-left: 25px;">
                <table class="clsdata" style="padding-left: 20px;">
                    <tr>
                        <td colspan="2" align="center">
                            <label>
                                <span>主 要 银 行 信 息</span></label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">
                            开户银行：
                        </td>
                        <td>
                            <input name='' type='text' id='Text13' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            银行帐号：
                        </td>
                        <td>
                            <input name='' type='text' id='Text14' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            收款名称：
                        </td>
                        <td>
                            <input name='' type='text' id='Text15' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备注：
                        </td>
                        <td>
                            <input name='' type='text' id='Text16' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </li>
            <%--     <li style="float: left">
                <label class="">
                    客户代码：</label><input name='' type='text' id='' /></li>
            <li style="float: left">
                <label class="">
                    客户分类：</label><input name='' type='text' id='' /></li>
            <li>
                <label class="">
                    XXX：</label><input name='' type='text' id='' /></li>
            <li style="float: left">
                <label class="">
                    客户简称：</label><input name='' type='text' id='' /></li>
            <li>
                <label class="">
                    &nbsp;&nbsp;&nbsp;中文名称：</label><input name='' type='text' id='Text1' /></li>
            <li>
                <label class="">
                    客户中文地址：</label><input name='' type='text' id='Text2' style="width: 600px;" /></li>
            <li style="float: left">
                <label class="">
                    省份：</label><input name='' type='text' id='Text3' /></li>
            <li style="float: left">
                <label class="">
                    城市：</label><input name='' type='text' id='Text4' /></li>
            <li>
                <label class="">
                    公司地址：</label><input name='' type='text' id='Text5' style="width: 200px;" /></li>
            <li style="text-align: center">
                <label>
                    <span>主要联系人</span></label>
            </li>
            <li style="float: left">
                <label class="">
                    联系人名称：</label><input name='' type='text' id='Text6' /></li>
            <li style="float: left">
                <label class="">
                    职务：</label><input name='' type='text' id='Text7' /></li>
            <li style="float: left">
                <label class="">
                    电话：</label><input name='' type='text' id='Text8' /></li>
            <li>
                <label class="">
                    传真：</label><input name='' type='text' id='Text9' /></li>
            <li style="text-align: center">
                <label>
                    <span>主要银行信息人</span></label>
            </li>
            <li style="float: left">
                <label class="">
                    开 户&nbsp; 银 行：</label><input name='' type='text' id='Text10' /></li>
            <li>
                <label class="">
                    银行帐号：</label><input name='' type='text' id='Text11' style="width: 300px;" /></li>
            <li style="float: left">
                <label class="">
                    收款人名称：</label><input name='' type='text' id='Text12' /></li>
            <li>
                <label class="">
                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：</label><input name='' type='text'
                        id='Text13' style="width: 300px;" /></li>--%>
        </ul>
    </div>
</body>
</html>
