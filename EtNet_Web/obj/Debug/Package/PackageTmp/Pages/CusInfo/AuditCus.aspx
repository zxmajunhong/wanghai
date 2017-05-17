<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditCus.aspx.cs" Inherits="EtNet_Web.Pages.CusInfo.AuditCus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户审批</title>
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
        .style4
        {
            height: 19px;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
            margin-top: 5px;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
        .content
        {
            width:100%
            padding: 5px;
        }
        .content caption
        {
            background-color: #fff;
            border: 0px;
        }
        table.dataBox
        {
            width: 100%;
        }
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            min-width: 100px;
        }
        table.dataBox td
        {
            padding: 5px;
        }
        table.dataBox td.fieldTitle
        {
            font-family: 宋体;
            font-weight: normal;
            color: #333;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: center;
            padding: 6px 6px 6px 16px;
            font-weight: bold;
            height: 20px;
        }
        .lineTable td
        {
            border: 1px solid #C1DAD7;
            padding-left: 5px;
        }
        .lineTable tr
        {
            height: 20px;
            line-height: 20px;
        }
        .lineTable
        {
            border: 1px solid #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #000000;
        }
        
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .dataBox
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        #mytable2
        {
            border-collapse: collapse;
            width: 100%;
        }
        #mytable2 tr
        {
            background-color: #FFFFFF;
        }
        #mytable2 th
        {
            border: 1px solid #DED6DC;
        }
        #mytable2 tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        #mytable2 tr .sum-title
        {
            text-align: right;
        }
        .invoiceCol
        {
            display: none;
        }
       #iptcomment{border:1px solid #C6E2FF; width:400px; height:60px; font-size:13px;resize:none;}
    </style>

    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            //审核通过
            $("#ibtnPass").click(function () {
//                if ($.trim($("#iptcomment").val()) == "") {
//                    alert('请填写审批意见!');
//                    return false;
//                }
                if (confirm("确定审批通过!")) {
                    $("#iptcomment").val(encodeURIComponent($("#iptcomment").val()));
                }
                else {
                    return false;
                }
            })



            //审核拒绝
            $("#ibtnRefuse").click(function () {
//                if ($.trim($("#iptcomment").val()) == "") {
//                    alert('请填写审批意见!');
//                    return false;
//                }
                if (confirm("确定拒绝该申请!")) {
                    $("#iptcomment").val(encodeURIComponent($("#iptcomment").val()));
                    return true;
                }
                else {
                    return false;
                }
            })


        })
    </script>


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
                            font-weight: bold;">客户审批</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
          <asp:ImageButton ID="ibtnPass" runat="server" ImageUrl="~/Images/Button/btn_pass.jpg" OnClick="ibtnPass_Click" /> 
          <asp:ImageButton ID="ibtnRefuse" runat="server" ImageUrl="~/Images/Button/btn_refuse.jpg" OnClick="ibtnRefuse_Click" />
          <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="../../Images/Button/btn_back.jpg" OnClick="imgbtnback_Click" />         
        </div>
        <!--版本号:20130319-->
        <div class="content">
            <table class="dataBox lineTable">
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        客户代码
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblcuscode"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        客户分类
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblcustype"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        是否启用
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblused"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        客户简称
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblshortname"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        客户全称
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblcname"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        客户属性
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblcuspro"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        省份城市
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbladdress"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        中文地址
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblcaddress"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        公司网址
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblcompanyurl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">联系方式</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        联系人名
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbllinkname"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        所属职务
                    </td>
                    <td style="width: 20%;">
                        <asp:Label runat="server" ID="lbllinkpost"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        手机号码
                    </td>
                    <td class="style4">
                        <asp:Label runat="server" ID="lbllinkmobile"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        联系电话
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbllinktel"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        联系传真
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbllinkfax"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        邮箱地址
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbllinkemail"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        Q Q
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbllinkmsn"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        Skype
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lbllinkskype"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">银行信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        开户银行
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblbank"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        银行帐号
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblbankcard"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        开户户名
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblbankman"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        备注
                    </td>
                    <td class="style2" colspan="5">
                        <asp:Label runat="server" ID="lblremark" Width="600px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        制单员
                    </td>
                    <td>
                        <asp:Label Width="200" ID="lblMadeFrom" runat="server"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        制单时间
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblMadeTime" Width="200" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
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
                                联系人
                            </td>
                            <td class="clstitleimg">
                                职务
                            </td>
                            <td class="clstitleimg">
                                联系电话
                            </td>
                            <td class="clstitleimg">
                                联系传真
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
                            <td class="clstitleimg" style="width: 150px;">
                                开户银行
                            </td>
                            <td class="clstitleimg" style="width: 150px;">
                                银行帐号
                            </td>
                            <td class="clstitleimg" style="width: 80px;">
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
        <!--历史版本-->
     <%--   <table class="clsdata" style="padding-left: 30px;">
            <tr>
               <td colspan="6" style="text-align: center;background: #F0F0F0;">
                 <span style="font-weight: bold; font-size: 14px;">基本信息</span>
               </td>
            </tr>
            <tr>
               <td colspan="4" style="text-align:right; padding-right:20px;">&nbsp;&nbsp;</td>        
               <td style="text-align:right; padding-right:20px;">&nbsp;</td>
               <td style="text-align:right; padding-right:20px;"> &nbsp;</td>        
            </tr>
            <tr>
              <td style="width: 80px; height: 20px;">客户代码:</td>     
              <td>
                 <asp:Label runat="server" CssClass="clstxt" ID="lblcuscode"></asp:Label>
              </td>
              <td>是否启用:</td> 
              <td>
                <asp:Label runat="server" CssClass="clstxt" ID="lblused"></asp:Label>
              </td>
              <td>客户属性:</td>              
              <td>
                <asp:Label runat="server" CssClass="clstxt" ID="lblcuspro"></asp:Label>
              </td>
            </tr>
            <tr>
             <td style="width: 80px; height: 20px;">客户简称:</td>      
             <td>
               <asp:Label runat="server" CssClass="clstxt" ID="lblshortname"></asp:Label>
             </td>
             <td>客户名称:</td>                  
             <td>
               <asp:Label runat="server" CssClass="clstxt" ID="lblcname"></asp:Label>
             </td>
             <td>公司网址:</td>                  
             <td>
               <asp:Label runat="server" CssClass="clstxt" ID="lblcompanyurl"></asp:Label>
             </td>
            </tr>
            <tr>
             <td style="width: 80px; height: 20px;">中文地址:</td>          
             <td>
               <asp:Label runat="server" CssClass="clstxt" ID="lblcaddress"></asp:Label>
             </td>
             <td>客户分类:</td>                                  
             <td>
               <asp:Label runat="server" CssClass="clstxt" ID="lblcustype"></asp:Label>
             </td>
             <td>省份城市:</td>             
             <td>
               <asp:Label runat="server" CssClass="clstxt" ID="lbladdress"></asp:Label>
             </td>
            </tr>
            <tr>
              <td style="width: 80px;"></td>             
              <td>&nbsp;</td>            
              <td>制单员:</td>            
              <td>
                <asp:Label Width="200" ID="lblMadeFrom"  CssClass="clstxt" runat="server" ></asp:Label>
              </td>
              <td>制单时间:</td>                   
              <td>
                <asp:Label ID="lblMadeTime" Width="200" CssClass="clstxt"  runat="server"></asp:Label>
              </td>
            </tr>
            <tr>
              <td>&nbsp;</td>                  
              <td>&nbsp;</td>                 
              <td>&nbsp;</td>        
              <td>&nbsp;</td>         
              <td>&nbsp;</td>              
              <td>&nbsp;</td>          
            </tr>
        </table>
        <table class="clsdata" style="margin-top: 5px; ">
            <tr>
                <td colspan="6" style="text-align: center;background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">主要联系人</span>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: center;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3">
                    联系人名:
                </td>
                <td class="style4">
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkname"></asp:Label>
                </td>
                <td class="style4">
                    所属职务:
                </td>
                <td class="style4">
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkpost"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 80px; height: 20px;">
                    联系电话:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinktel"></asp:Label>
                </td>
                <td>
                    手机号码:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkmobile"></asp:Label>
                </td>
                <td style="width: 80px;">
                    Q Q&nbsp;&nbsp; :
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkmsn"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 80px; height: 20px;">
                    联系传真:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkfax"></asp:Label>
                </td>
                <td>
                    邮箱地址:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkemail"></asp:Label>
                </td>
                <td style="width: 80px;">
                    Skype &nbsp;:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lbllinkskype"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 80px; height: 20px;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 80px;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table class="clsdata" style="margin-top: 5px; padding-left: 30px;">
            <tr>
                <td colspan="4" style="text-align: center;background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">主要银行</span>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 80px; height: 20px;">
                    开户银行:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lblbank"></asp:Label>
                </td>
                <td style="width: 80px;">
                    银行帐号:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lblbankcard"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 80px; height: 20px;">
                    开户户名:
                </td>
                <td>
                    <asp:Label runat="server" CssClass="clstxt" ID="lblbankman"></asp:Label>
                </td>
                <td style="width: 80px;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    备&nbsp;&nbsp;&nbsp;&nbsp;注:
                </td>
                <td class="style2" colspan="3">
                    <asp:Label runat="server" CssClass="clstxt" ID="lblremark" Width="600px"></asp:Label>
                </td>
            </tr>
        </table>
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
                                联系人
                            </td>
                            <td class="clstitleimg">
                                职务
                            </td>
                            <td class="clstitleimg">
                                联系电话
                            </td>
                            <td class="clstitleimg">
                                联系传真
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
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center;">
                    <span style="font-weight: bold; font-size: 14px;">其他银行信息息</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px;">
                    <table id="tablebank" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg" style="width: 150px;">
                                开户银行
                            </td>
                            <td class="clstitleimg" style="width: 150px;">
                                银行帐号
                            </td>
                            <td class="clstitleimg" style="width: 80px;">
                                户名
                            </td>
                            <td class="clstitleimg">
                                备注
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>
        
        <table width="100%">
            <tr>
            <td style="font-weight:bold">审批意见:</td>   
          </tr>
          <tr>
            <td>
              <textarea id="iptcomment" runat="server" style="width:100%" ></textarea>
            </td>
          </tr>
        </table>
         
    </div>
    </form>
</body>
</html>
