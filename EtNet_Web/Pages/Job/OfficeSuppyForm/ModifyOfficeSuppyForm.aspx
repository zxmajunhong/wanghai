<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyOfficeSuppyForm.aspx.cs"
    Inherits="PJOAUI.View.Job.OfficeSuppyForm.ModifyOfficeSuppyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改办公用品申请</title>
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jNotify.jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {



            $("img").css({ cursor: "pointer" });


            //动态新增文件上传控件
            var num = 1;
            $("#imgadd").click(function () {
                var str = '<tr><td><input type="file" name="addfile" /></td>'
                str += '<td><img class="imgaddfile" alt="删除" src="../../../Images/Job/delete.gif" /></td></tr>'
                if (num == (5 - $("#iptflienum").val())) {
                    jNotify("最多上传5个附件！", { autoHide: true,
                        clickOverlay: true,
                        TimeShown: 3000,
                        HorizontalPosition: 'center',
                        VerticalPosition: 'center'
                    });
                }
                else {
                    $("#addfile").append(str);
                    num++;
                }

            })



            //删除新增的上传控件
            $(".imgaddfile").live("click", function () {
                $(this).parent().parent().remove();
                num--;

            });





            //图片的路径改变
            $(window).load(function () {
                $(".make1").each(function () {
                    $(this).children().attr("src", "../../../Images/AuditRole/right.gif");
                });

                $(".make2").each(function () {
                    $(this).children().attr("src", "../../../Images/AuditRole/down.gif");
                });

                $(".make3").each(function () {
                    $(this).children().attr("src", "../../../Images/AuditRole/up.gif");
                });

            });



            jQuery.extend({ "changeaddstr": function (str) {
                var newstr = "";
                var rgl = /</g;
                var rgr = />/g;
                newstr = str.replace(rgl, "< ");
                newstr = newstr.replace(rgr, " >");
                return newstr;

            }
            });




            jQuery.extend({ "changereducestr": function (str) {
                var newstr = "";
                var rgl = /< /g;
                var rgr = / >/g;
                newstr = str.replace(rgl, "<");
                newstr = newstr.replace(rgr, ">");
                return newstr;

            }
            });





            $("#ddlauditsort,#ddlapprovalrole").change(function () {
                $("#iptremark").val(jQuery.changeaddstr($("#iptremark").val()));

            });



            //加载已有的办公用品的明细的数据
            $(window).load(function () {
                if ($("#iptdetial").val()) {
                    var list = $("#iptdetial").val().split(',');
                    var str = "";
                    for (var i = 0; i < list.length; i++) {
                        str += "<tr><td>" + list[i].split('_')[2] + "</td><td>" + list[i].split('_')[0] + " </td><td><img  class='imgdel' ";
                        str += " alt='删除' ";
                        str += "src='../../../Images/Job/bulletdel.png' /></td></tr>";

                    }

                    $("#supplydetail").append(str);
                }

            })



            //影藏对话框
            $("#box").hide();


            //添加办公明细
            $(".imgdetail").click(function () {
                $("#box").dialog({
                    modal: true,
                    title: '申请办公用品明细',
                    width: 240,
                    height: 170,
                    resizable: false,
                    buttons: { '确定': function () {
                        var rg = new RegExp("^(0|[1-9][0-9]*|(0\.[0-9]+)|([1-9][0-9]*\.[0-9]+))$");
                        rg.global = true;
                        if (!$("#box td").children("#iptnum").val() || !rg.test($("#box td").children("#iptnum").val())) {
                            $("#box td").children("#iptnum").val("");
                        }
                        else {
                            var cname = $("#box td #selsupply").children("option:selected").text();
                            var val = $("#box td #selsupply").children("option:selected").val();
                            var num = $("#box td").children("#iptnum").val();

                            var str = "<tr><td>" + cname + "</td><td>" + num + " </td><td><img class='imgdel' alt='删除' ";
                            str += "src='../../../Images/Job/bulletdel.png' /></td></tr>";
                            $("#supplydetail").append(str);

                            if ($("#iptdetial").val() == "") {
                                $("#iptdetial").val($("#iptdetial").val() + num + "_" + val + "_" + cname);
                            }
                            else {
                                $("#iptdetial").val($("#iptdetial").val() + "," + num + "_" + val + "_" + cname);
                            }
                        }

                        $(this).dialog("close");

                    }, '取消': function () { $(this).dialog("close") }
                    }

                });

            })





            $(".imgdel").live("click", function () {
                //当前要删除的行在表格中的索引值
                var i = $(this).parent("td").parent("tr").prevAll("tr").length - 2;
                var list = $("#iptdetial").val().split(',');
                list.splice(i, 1);
                $("#iptdetial").val(list.join(','));

                $(this).parent("td").parent("tr").remove();

            });





            //提交申请的提示
            $("#ibtnSubmit").click(function () {
                var str = "";
                if ($("#ddlauditsort").val().length > 4) {
                    str += "审核类型未选！<br/>";
                }
                if ($("#ddlapprovalrole").val() == "0") {
                    str += "审批规则未选！";
                }
                if (str.length != "") {
                    jNotify(str, { autoHide: true,
                        clickOverlay: true,
                        TimeShown: 3000,
                        HorizontalPosition: 'center',
                        VerticalPosition: 'center'
                    });
                    return false;
                }
                else {

                    $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
                    return true;

                }

            });




            // 保存草稿提示
            $("#ibtnSave").click(function () {
                $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
                return true;
            });





            //重置数据
            $("#ibtnReset").click(function () {
                $("#iptremark").val("");
            })



            $("#originalfile input:image").click(function () {
                $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
            })



        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="iptdetial" runat="server" />
    <input type="hidden" id="iptflienum" runat="server" />
    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <th colspan="8" align="center">
                    <h3>
                        办公用品申请单修改</h3>
                </th>
            </tr>
            <tr>
                <td colspan="8" style="background-image: url('../../../Images/Job/win_top.png');
                    height: 10px; background-repeat: repeat-x;">
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    办公申请单号
                </td>
                <td style="width: 15%">
                    <asp:Label runat="server" ID="lblnumbers"></asp:Label>
                </td>
                <td style="width: 10%">
                    部门
                </td>
                <td style="width: 15%">
                    <asp:Label runat="server" ID="lbldepart"></asp:Label>
                </td>
                <td style="width: 10%">
                    申请人
                </td>
                <td style="width: 15%">
                    <asp:Label runat="server" ID="lblcanme"></asp:Label>
                </td>
                <td style="width: 10%">
                    申请日期
                </td>
                <td style="width: 15%">
                    <asp:Label runat="server" ID="lblapplydate"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <table id="supplydetail" style="width: 40%;">
                        <tr>
                            <td colspan="3" style="font-weight: bold;">
                                办公用品申请明细
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%;">
                                名称
                            </td>
                            <td style="width: 20%;">
                                数量
                            </td>
                            <td style="width: 30%;">
                                <span>添加明细</span><img class="imgdetail" alt="添加" src="../../../Images/Job/bulletadd.png" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    申请原因及用途说明
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <textarea runat="server" id="iptremark" style="height: 100px; width: 100%"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    审核设置
                </td>
            </tr>
            <tr>
                <td>
                    审核类型
                </td>
                <td colspan="7">
                    <asp:DropDownList ID="ddlauditsort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlauditsort_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    审核规则
                </td>
                <td colspan="7">
                    <asp:DropDownList ID="ddlapprovalrole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlapprovalrole_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <div id="auditpic" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    附件
                </td>
                <td colspan="7">
                    <div>
                        <table id="addfile">
                            <tr>
                                <td>
                                    <asp:FileUpload runat="server" ID="fpattachment" />
                                </td>
                                <td>
                                    <img id="imgadd" alt="新增" src="../../../Images/Job/fileadd.gif" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    原有附件
                </td>
                <td colspan="7">
                    <div>
                        <table id="originalfile" runat="server">
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="8">
                    <hr />
                    <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/Images/home/btn_submit.jpg"
                        OnClick="ibtnSubmit_Click" />
                    &nbsp;
                    <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="~/Images/home/btn_save.jpg"
                        OnClick="ibtnSave_Click" />
                    &nbsp;
                    <asp:ImageButton ID="ibtnReset" runat="server" ImageUrl="~/Images/home/btn_reset.jpg"
                        OnClick="ibtnReset_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="box">
        <table style="width: 100%; height: 100%;">
            <tr>
                <td>
                    办公用品
                </td>
                <td>
                    <select id="selsupply" runat="server">
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    数量
                </td>
                <td>
                    <input id="iptnum" type="text" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
