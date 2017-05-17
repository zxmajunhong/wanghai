<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchLeaveForm.aspx.cs" Inherits="PJOAUI.View.Job.LeaveForm.SearchLeaveForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看请假的审核情况</title>
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />

    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {


            //图片的路径改变以及显示的状态
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

                if ($("#iptauditstatus").val() == "01" || $("#iptauditstatus").val() == "02") {

                    var strp = String($("#iptpeople").val()).split(',');
                    var strpu = String($("#iptpeopelstatus").val()).split(',');
                    var sort = $("#iptauditsort").val();
                    if (sort == "单审") {
                        for (var i = 0; i < strpu.length; i++) {
                            if (strpu[i] == "T") {
                                $("#audit" + strp[i].toString()).css({ "color": "red" });

                            }
                            else if (strpu[i] == "P") {
                                $("#audit" + strp[i].toString()).css({ "color": "blue" });
                            }
                            else { }
                        }
                    }
                    else if (sort == "选审") {
                        for (var i = 0; i < strpu.length; i++) {
                            if (strpu[i] == "T") {
                                $("#audit" + strp[i].toString()).css({ "color": "red" });
                            }
                            else if (strpu[i] == "P") {
                                $("#audit" + strp[i].toString()).css({ "color": "blue" });
                            }
                            else { }
                        }
                    }
                    else {
                        for (var i = 0; i < strpu.length; i++) {
                            if (strpu[i] == "T") {
                                $("#audit" + strp[i].toString()).css({ "color": "red" });
                            }
                            else if (strpu[i] == "P") {
                                $("#audit" + strp[i].toString()).css({ "color": "blue" });
                            }
                            else { }
                        }
                    }

                }
                else if ($("#iptauditstatus").val() == "03" || $("#iptauditstatus").val() == "04") {
                    $("#audit1000").css({ "color": "red" });

                }
                else {

                }

            })


            //设置审核图样式
            $("#auditpic table div").each(function () {
                if (!$(this).has("img").length) {
                    // $(this).css({ "background-color": "#f8f811" })
                    $(this).css({ "font-size":"16px","border":"0"})
                }

            })



        })

    
     
    
    </script>

    <style type="text/css">
        .style1
        {
            height: 92px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="iptauditstatus" />
    <input type="hidden" runat="server" id="iptauditsort" />
    <input type="hidden" runat="server" id="iptpeople" />
    <input type="hidden" runat="server" id="iptpeopelstatus" />
    <div style=" width:100%;">
      <table style="width:100%;">
         <tr>
          <th colspan="8" align="center"><h3>请假单审核情况</h3></th>
         </tr>
         <tr>
          <td colspan="8" style="  background-image: url('../../../Images/Job/win_top.png'); height:10px; background-repeat:repeat-x;"></td>
         </tr>
         <tr>
           <td style="width:10%">请假单号</td>
           <td style="width:15%"><asp:Label ID="lblnumber" runat="server" ></asp:Label></td>        
           <td style="width:10%">部门</td>
           <td style="width:15%"><asp:Label runat="server" ID="lbldepart"></asp:Label></td>
           <td style="width:10%">申请人</td>
           <td style="width:15%"><asp:Label runat="server" ID="lblpeople"></asp:Label></td>
           <td style="width:10%">申请日期</td>
           <td style="width:15%"><asp:Label runat="server" ID="lbldate"></asp:Label></td>
         </tr>
         <tr>
           <td>请假类型</td>
           <td><asp:Label ID="lblapplyleavesort" runat="server"></asp:Label></td>
           <td>请假时间</td>
           <td colspan="5">
           <asp:Label ID="lblapplyleavetime" runat="server"></asp:Label>
           </td>
         </tr>
      
        <tr>
          <td colspan="8">请假原因及其他事项</td>
        </tr>
        <tr>
         <td colspan="8">
           <asp:Label ID="lblremark" runat="server" Height="80px" Width="100%"></asp:Label>
         </td>
        </tr>
        <tr>
           <td>附件情况</td>
           <td colspan="7">
              <div id="jobflowfile" runat="server"></div>                 
           </td>
         </tr>

        <tr>
          <td colspan="8">审核人意见</td>
        </tr>   
        <tr>
          <td colspan="8" class="style1">
              <asp:Label ID="lblaudittxt" runat="server" Height="80px" Width="100%"></asp:Label>
          </td>
        </tr>          
        <tr>
           <td colspan="8">审核流程图</td>
         </tr>
        <tr>
           <td colspan="8">
             <div id="auditpic" runat="server"></div>
           </td>
         </tr>

        <tr>
          <td align="right" colspan="8">
              <asp:ImageButton ID="ibtnback" runat="server" 
                  ImageUrl="~/Images/home/btn_back.jpg" onclick="ibtnback_Click" />
          </td>
        </tr>

      </table>
    </div>

   
    </form>
</body>
</html>
