<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddAuditRole.aspx.cs" Inherits="Pages.SysSet.AuditRole.AddAuditRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加审批流程</title>
    <link href="../../../CSS/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
            border: 1px solid #CDC9C9;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .clstxt
        {
            display: inline-block;
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clspicbtn
        {
            width: 0px;
            height: 0px;
        }
        .clsimg
        {
            width: 60px;
            height: 20px;
            line-height: 20px;
            text-align: center;
            cursor: pointer;
            font-size: 12px;
            border: 1px solid #CAE1FF;
        }
        #supplydetail
        {
            background-color: #E5E5E5;
        }
        #teratxt
        {
            width: 350px;
            font-size: 13px;
            border: 1px solid #C6E2FF;
            resize: none;
            height: 60px;
        }
       .buttonStyle{ background:url('../../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
      
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/zDialogTwo.js" type="text/javascript"></script>
    <script src="../../../Scripts/zDrag.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            //保存时判断数据是否填写正确
            $("#ibtnsave").click(function () {
                var str = "";
                var rg = /[^\u4e00-\u9fa5\w-—()]/g;
                if (!$("#iptcname").val().replace(/\s/g, "")) {
                    str += "流程名不能为空!\n";
                }
                else if ($("#iptcname").val() && rg.test($("#iptcname").val())) {
                    str += "名称只能由中文,字母,数字与-—()组成!\n";
                }
                else {
                }
                if ($("#seljobflowsort").val() == "00") {
                    str += "类型未选!\n";
                }
                if ($("#hiddepartlist").val() == "") {
                    str += "部门未选\n";
                }
                if (!$("#auditpic").text().replace(/\s/g, "")) {
                    str += "请创建审核流程图!\n";
                }

                if (str) {
                    alert(str);
                    return false;
                }
                else {
                    //保存审核流程图
                    var str = $("#auditpic").html()
                    str = window.escape(str);
                    $("#hidaudit").val(str);
                    $("#teratxt").val(encodeURIComponent($("#teratxt").val()));
                    return true;
                }

            });


            $("#picrefresh").click(function () {
                $("#imgrefresh").click();
            })

            $("#picright").click(function () {
                $("#imgright").click();
            })

            $("#picleft").click(function () {
                $("#imgleft").click();
            })

            $("#picup").click(function () {
                $("#imgup").click();
            })

            $("#picdown").click(function () {
                $("#imgdown").click();
            })


            //改变规则分类时清空流程图
            $("#selauditsort").change(function () {
                $("#imgrefresh").trigger("click");
            });


            $("#imgrefresh,#imgright,#imgleft,#imgup,#imgdown,#ibtnreset").click(function () {
                $("#teratxt").val(encodeURIComponent($("#teratxt").val()));

            });


            $(window).load(function () {
                if ($("#hidtxtlist").val() != "") {
                    var strlist = "," + $("#hidtxtlist").val() + ",";
                    var txtlist = strlist.split(',');

                    strlist = "," + $("#hidlist").val() + ",";
                    var list = strlist.split(',');

                    for (var i = 1; i < txtlist.length - 1; i++) {
                        $("#replace" + i).html(txtlist[i]);
                        $("#replace" + i).attr("class", "cls" + list[i]);
                    }
                }

            })


            $("#iptdepartlist").click(function () {
                seldepart();
            })

            //选部门
            $("#imgdepart").click(seldepart);
            function seldepart() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 355;
                diag.Title = "选部门";
                diag.URL = "../SearchDepart.aspx?dlist=" + $("#hiddepartlist").val();
                diag.OKEvent = function () {
                    $("#hiddepartlist").val(diag.innerFrame.contentWindow.document.getElementById('hidseldepart').value);
                    $("#iptdepartlist").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtdepart').value);
                    diag.close();
                };
                diag.show();
            }





        }) 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidaudit" runat="server" />
    <input type="hidden" id="hidlist" runat="server" />
    <input type="hidden" id="hidtxtlist" runat="server"  />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        添加审批流程
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right">
        <asp:ImageButton ID="ibtnSaveAdd" runat="server" OnClick="ibtnSaveAdd_Click" ImageUrl="../../../Images/Button/btn_saveadd.jpg" />
            <asp:ImageButton ID="ibtnsave" runat="server" ImageUrl="../../../Images/Button/btn_save.jpg"
                OnClick="ibtnsave_Click" />
            <asp:ImageButton ID="ibtnreset" runat="server" ImageUrl="../../../Images/Button/btn_reset.jpg"
                OnClick="ibtnreset_Click" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="../../../Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td style="width: 70px; height: 30px;">
                    流程名称:
                </td>
                <td style="width: 300px;">
                    <input type="text" runat="server" class="clsunderline" id="iptcname" />
                    <span style="color: Red;">*</span>
                </td>
                <td rowspan="6" style="width: 10px; text-align: center;">
                    <div style="border: 0; border-left: 1px solid #CDC9C9; height: 200px; width: 1px">
                    </div>
                </td>
                <td rowspan="6">
                    <div>
                        审核人员设置</div>
                    <div>
                        <table style="position: relative; left: 5px; border: 1px solid #F2F2F2; background-color: #F0F8FF;">
                            <tr>
                                <td colspan="2">
                                    可选的审核人员
                                </td>
                                <td>
                                    选定的审核人员
                                </td>
                                <td>
                                    <div class="clsimg" id="picrefresh" style="background-image: url(../../../Images/AuditRole/btn.png)">
                                        清空</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="lbuntake" runat="server" Height="150px" Width="100px" SelectionMode="Multiple">
                                    </asp:ListBox>
                                </td>
                                <td>
                                    <div class="clsimg" id="picright" style="margin-bottom: 20px; background-image: url(../../../Images/AuditRole/btn.png)">
                                        右移&gt;&gt;</div>
                                    <div class="clsimg" id="picleft" style="background-image: url(../../../Images/AuditRole/btn.png)">
                                        左移&lt;&lt;</div>
                                </td>
                                <td>
                                    <asp:ListBox ID="lbtake" runat="server" Height="150px" Width="100px" SelectionMode="Multiple">
                                    </asp:ListBox>
                                </td>
                                <td>
                                    <div class="clsimg" id="picup" style="margin-bottom: 20px; background-image: url(../../../Images/AuditRole/btn.png)">
                                        上移&#8593;</div>
                                    <div class="clsimg" id="picdown" style="background-image: url(../../../Images/AuditRole/btn.png)">
                                        下移&#8595;</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    审核分类:
                </td>
                <td>
                    <select id="selauditsort" class=" clsdatalist" runat="server">
                        <option value="单审">单审</option>
                        <option value="选审">选审</option>
                        <option value="会审">会审</option>
                    </select>
                    <span style="color: Red;">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    关联工作流:
                </td>
                <td>
                    <select id="seljobflowsort" class=" clsdatalist" runat="server">
                    </select>
                    <span style="color: Red;">*</span>
                </td>
            </tr>


            <tr>
              <td>所属部门:</td>
              <td>
                 <input type="text" runat="server" id="iptdepartlist" class="clsunderline" />
                 <img id="imgdepart" title="选取部门" src="../../../Images/Public/group.gif"  alt="选取部门" />        
                 <input type="hidden" runat="server" id="hiddepartlist" />
                 <span style="color: Red;">*</span>
              </td>
            </tr>
            <tr>
            <td>
            流程图显示
            </td>
            <td>
             <select id="selhide" class=" clsdatalist" runat="server" onserverchange="hide_serverchange">
                        <option value="1">岗位</option>
                        <option value="2" selected="selected">人名+岗位</option>
                        <option value="3">人名</option>
                    </select>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    审核流程的描述:
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-right: 5px;">
                    <textarea id="teratxt" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="color: blue;">
                    审核流程图(目前系统只支持5级审批):
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="auditpic" style="border: 2px solid #C6E2FF;" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <!--审核图按钮 -->
    <div>
        <asp:ImageButton ID="imgrefresh" CssClass="clspicbtn" runat="server" ImageUrl="../../../Images/Button/btn_update.jpg"
            OnClick="imgrefresh_Click" />
        <asp:ImageButton ID="imgright" CssClass="clspicbtn" runat="server" ImageUrl="../../../Images/Button/btn_update.jpg"
            OnClick="imgright_Click" />
        <asp:ImageButton ID="imgleft" CssClass="clspicbtn" runat="server" ImageUrl="../../../Images/Button/btn_update.jpg"
            OnClick="imgleft_Click" />
        <asp:ImageButton ID="imgup" CssClass="clspicbtn" runat="server" ImageUrl="../../../Images/Button/btn_update.jpg"
            OnClick="imgup_Click" />
        <asp:ImageButton ID="imgdown" CssClass="clspicbtn" runat="server" ImageUrl="../../../Images/Button/btn_update.jpg"
            OnClick="imgdown_Click" />
    </div>
    </form>
</body>
</html>
