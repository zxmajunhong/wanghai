<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComDetial.aspx.cs" Inherits="EtNet_Web.Pages.InsureCompany.ComDetial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公司详情</title>
    <link href="../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
        }
        .clsdata
        {
            width: 100%;
            border: 1px solid #CDC9C9;
        }
        .clstxt
        {
            width: 200px;
            display: inline-block;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        #tablelink, #tablebank
        {
            background-color: #E3E3E3;
            width: 100%;
            border: 0;
        }
        #tablelink tr td
        {
            background-color: #F0F8FF;
        }
        #tablebank tr td
        {
            background-color: #F0F8FF;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
        }
        .clstitleimg:hover
        {
            color: White;
        }
        .style2
        {
            height: 20px;
        }
        .TD
        {
            border-bottom: #ccc 1px solid;
            border-left: #ccc 1px solid;
            width: 50px;
            border-collapse: collapse;
            border-top: #ccc 1px solid;
            border-right: #ccc 1px solid;
        }
       .clsauditpic{border:1px solid #63B8FF; margin-top:5px;}
        .clsborder{border:1px solid red!important;}
        .content{padding:5px;}
        .content caption{background-color:#fff;border:0px;}
        table.dataBox{width:100%;}
        td.fieldTitle{width:80px;text-align:right;color:#444;}
        table.dataBox td{padding:5px;}
        table.dataBox td.fieldTitle{font-family: 宋体;font-weight:normal;color: #333;border-right: 1px solid #C1DAD7;border-bottom: 1px solid #C1DAD7;border-top: 1px solid #C1DAD7;letter-spacing: 2px;text-transform: uppercase;text-align: center;font-weight:bold;}
        .lineTable td{border: 1px solid #C1DAD7;padding-left:5px;}
        .lineTable tr{height:20px;line-height:20px;}
        .lineTable{border: 1px solid #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: #000000;}
        
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .dataBox{border: 1px none #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: black;}
        #mytable2{border-collapse: collapse;width: 100%;}
        #mytable2 tr{background-color: #FFFFFF;}
        #mytable2 th{border: 1px solid #DED6DC;}
        #mytable2 tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        #mytable2 tr .sum-title{text-align:right;}
        .invoiceCol{display:none;}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">查看保险公司</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="../../Images/button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <div class="content">
            <table class="dataBox lineTable">
            <tr>
                <td colspan="6" style="text-align: center;background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                </td>
            </tr>
          
            <tr>
                <td class="fieldTitle" style="height: 20px;">
                    公司代码
                </td>
                <td style="width:23%;">
                    <asp:Label runat="server" ID="lblcomcode"></asp:Label>
                </td>
                <td class="fieldTitle">
                    公司类别
                </td>
                <td  style="width:23%;">
                 <%--<asp:Label runat="server" CssClass="clstxt" ID="lblused"></asp:Label>--%>
                    <asp:Label runat="server" ID="lblcomtype"></asp:Label>
                </td>
                <td class="fieldTitle">
                    是否启用
                </td>
                <td  style="width:23%;">
                   <%-- <asp:Label runat="server" CssClass="clstxt" ID="lblcomtype"></asp:Label>--%>
                   <asp:Label runat="server" ID="lblused"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style=" height: 20px;" class="fieldTitle">
                    公司简称
                </td>
                <td>
                    <asp:Label runat="server" ID="lblshort"></asp:Label>
                </td>
                <td class="fieldTitle">
                    公司全称
                </td>
                <td colspan="3">
                    <%--<asp:Label runat="server" CssClass="clstxt" ID="lbladdress"></asp:Label>--%>
                    <asp:Label runat="server" ID="lblcname"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="fieldTitle">
                    省份城市
                </td>
                <td>
              <%--<asp:Label runat="server" CssClass="clstxt" ID="lblcname"></asp:Label>--%>
              <asp:Label runat="server" ID="lbladdress"></asp:Label>
                </td>
                <td class="fieldTitle">
                    公司地址
                </td>
                <td >
                    <asp:Label runat="server" ID="lblcaddress"></asp:Label>
                </td>
                <td class="fieldTitle">
                    公司网址
                </td>
                <td >
                    <asp:Label runat="server" ID="lblcompanyurl"></asp:Label>
                </td>
              
            </tr>
          <tr>
                <td style="text-align: center;background: #F0F0F0;"" colspan="6" >
                    <span style="font-weight: bold; font-size: 14px;">联系方式</span>
                </td>
            </tr>
           
            <tr>
                <td class="fieldTitle">
                    联系人名
                </td>
                <td style="width:20%;">
                    <asp:Label runat="server"  ID="lbllinkname"></asp:Label>
                </td>
                <td  class="fieldTitle">
                    所属职务
                </td>
                <td style="width:20%;">
                    <asp:Label runat="server"  ID="lbllinkpost" ></asp:Label>
                </td>
                <td  class="fieldTitle"">
                   手机号码
                </td>
                <td style="width:20%;">
                    <asp:Label runat="server" ID="lbllinkmobile"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  class="fieldTitle" style="height: 20px">
                    联系电话
                </td>
                <td  style="width:20%;">
                    <asp:Label runat="server" ID="lbllinktel"></asp:Label>
                </td>
                <td  class="fieldTitle" style="height: 20px">
                    联系传真</td>
                <td  style="width:20%;">
                    <asp:Label runat="server" ID="lbllinkfax"></asp:Label>
                </td>
                <td  class="fieldTitle" style="height: 20px">
                    电子邮件</td>
                <td class="style2"  style="width:20%;">
                    <%--<asp:Label runat="server" CssClass="clstxt" ID="lbllinkskype"></asp:Label>--%>
                    <asp:Label runat="server" ID="lbllinkemail"></asp:Label>
                </td>
            </tr>
            <tr>
                <td   class="fieldTitle">
                    Q Q</td>
                <td  style="width:20%;">
                    <asp:Label runat="server"  ID="lbllinkmsn"></asp:Label>
                </td>
                <td  class="fieldTitle">
                    Skype </td>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbllinkskype"></asp:Label>
                </td>
            </tr>
       <%--     </table>
        </div>
        <div class="content">
        <table class="dataBox lineTable">--%>
          <tr>
                <td style="text-align: center;background: #F0F0F0;"" colspan="6">
                    <span style="font-weight: bold; font-size: 14px;">银行信息</span>
                </td>
            </tr>
            <%--<caption>主要银行 </caption>--%>
            <tr>
                <td class="fieldTitle">
                    开户银行
                </td>
                <td   style="width:20%;">
                    <asp:Label runat="server"  ID="lblbank"></asp:Label>
                </td>
                <td class="fieldTitle" >
                    银行帐号
                </td>
                <td  style="width:20%;">
                    <asp:Label runat="server"  ID="lblbankcard"></asp:Label>
                </td>
                 <td class="fieldTitle">
                    开户户名
                </td>
                <td  style="width:20%;">
                    <asp:Label runat="server" ID="lblbankman"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="fieldTitle">
                    备注
                </td>
                <td colspan="5">
                    <asp:Label runat="server" ID="lblremark" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="fieldTitle">
                    制单员
                </td>
                <td >
                    <asp:Label runat="server" ID="lblMadeFrom" ></asp:Label>
                </td>
                <td class="fieldTitle">
                    制单时间
                </td>
                <td colspan="3">
                    <asp:Label runat="server" ID="lblMadeTime" ></asp:Label>
                </td>
            </tr>
        </table></div>
        <div>
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center;">
                    <span style="font-weight: bold; font-size: 14px;">其他联系人</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px;">
                    <table id="tablelink" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg">
                                名称
                            </td>
                            <td class="clstitleimg">
                                职务
                            </td>
                            <td class="clstitleimg">
                                电话
                            </td>
                            <td class="clstitleimg">
                                传真
                            </td>
                            <td class="clstitleimg">
                                手机
                            </td>
                            <td class="clstitleimg">
                                电子邮件
                            </td>
                            <td class="clstitleimg">
                                QQ
                            </td>
                            <td class="clstitleimg">
                                Skype
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        <div>
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center;">
                    <span style="font-weight: bold; font-size: 14px;">其他银行信息</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px;">
                    <table id="tablebank" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg" style="width: 230px;">
                                开户银行
                            </td>
                            <td class="clstitleimg" style="width: 230px;">
                                银行帐号
                            </td>
                            <td class="clstitleimg" style="width: 160px;">
                                户名
                            </td>
                            <td class="clstitleimg">
                                备注
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        
    </div>
    </form>
</body>
</html>
