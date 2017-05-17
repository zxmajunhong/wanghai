<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateNotice.aspx.cs" Inherits="Pages.Message.UpdateNotice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/common.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jNotify.jquery.css" rel="stylesheet" type="text/css" />

    <style type="text/css">

        .style5
        {
            height: 30px;
        }
        .style1
        {
            width: 80px;
        }
        .style3
        {
            width: 100px;
        }
        .style4
        {
            width: 80px;
            height: 30px;
        }
        .style9
        {
            width: 100px;
            height: 30px;
        }
        .style10
        {
            height: 150px;
        }
    </style>
   
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jNotify.jquery.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>
    <script type="text/javascript" >
        $(function () {
            var dates = $("#iptbegintime, #iptendtime").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 2,
                showAnim: "clip",
                dateFormat: 'yy-mm-dd',
                showButtonPanel: true, //是否显示按钮面板  
                closeText: "关闭", //关闭选择框的按钮名称 
                currentText: "今天",
                onSelect: function (selectedDate) {
                    var option = this.id == "iptbegintime" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);

                }
            });

            $.datepicker.setDefaults($.datepicker.regional['zh-CN']);



            $("#btnlook").click(function () {
                var str = $("#iptaccesfile").val();
                $("#divaccesfile").text(str);
                $("#divaccesfile").dialog({ title: "原有附件路径", modal:true });

            });

            //有对话框打开的话，关闭该对话框
            $("#ibtnfix").mouseenter(function () {
                $("#divaccesfile").dialog("close");

            });

            //判断数据是否为空或选中项是否无效
            $("#ibtnfix").click(function () {
                var value;
                var str = "";
                value = $("#selifpublic").val();
                if (value == "-1") {
                    str += "公告范围未选" + "<br/>";
                }

                value = $("#selattr").val();
                if (value == "-1") {
                    str += "属性未选" + "<br/>";
                }

                value = $("#selsort").val();
                if (value == "-1") {
                    str += "分类未选" + "<br/>";
                }

                value = $("#ipthead").val();
                if (value.length == 0) {
                    str += "公告标题不能为空" + "<br/>";
                }

                value = $("#iptbegintime").val();
                if (value.length == 0) {
                    str += "发布时间不能为空" + "<br/>";
                }

                value = $("#iptendtime").val();
                if (value.length == 0) {
                    str += "结束时间不能为空" + "<br/>";
                }

                if (str.length != 0) {
                    jNotify(str, {
                        HorizontalPosition: "center",
                        VerticalPosition: "center"
                    });
                    return false;
                }
                else {
                    return true;
                }
            });

        })

    </script>


</head>
<body>
    <form id="form2" runat="server">
    <div>
     <table>
         <tr>
           <th colspan="6" align="left" class="style5">修改公告</th>
         </tr>
         <tr>
            <td class="style1">公告标题</td>
            <td><input type="text" id="ipthead" runat="server" /></td>
            <td class="style1">发布人</td>
            <td><asp:Label ID="lblfromuser" runat="server"></asp:Label></td>   
            <td class="style1">公告范围</td>
            <td class="style3"><select id="selifpublic" runat="server" name="D1"></select></td>
            
         </tr>
        <tr>
         <td class="style4">发布时间设置</td>
         <td class="style5"><input id="iptbegintime" type="text" runat="server" /></td>
         <td class="style4">结束时间设置</td>
         <td class="style5"><input id="iptendtime" type="text" runat="server" /></td>
         <td class="style4">属性</td>
         <td class="style9"><select id="selattr"  runat="server" name="D2"></select></td>     
        </tr>
        <tr>
          <td class="style4">分类</td>
          <td class="style5"><select id="selsort" runat="server" name="D3"></select></td>
          <td class="style4">附件(更新)</td>
          <td class="style5"><asp:FileUpload ID="fpaccessory" runat="server" /></td>
          <td colspan="2" class="style5"><asp:Button ID="btnUpload" runat="server" Text="上传" 
                  onclick="btnUpload_Click" /> 
          &nbsp;&nbsp;&nbsp;&nbsp; 
          <input type="button" id="btnlook" value="查看原有附件"/>
          </td>
        </tr>
        <tr>
          <td colspan="6" class="style5">内容</td>
        </tr>
        <tr>
         <td colspan="6" valign="top" class="style10">
          <textarea id="context" style="width:100%; height:140px; resize:none;"  
                 runat="server" cols="20" name="S1" rows="1"></textarea>
         </td>
        </tr>
        <tr>
          <td align="center" colspan="6">
              <asp:ImageButton ID="ibtnfix" runat="server" 
                  ImageUrl="~/Images/btn_submit.jpg" onclick="ibtnfix_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
                  ID="ibtnReset" runat="server" ImageUrl="~/Images/btn_reset.jpg" 
                  onclick="ibtnReset_Click" />
              &nbsp;&nbsp;&nbsp;
            </td>
        </tr>

     </table>
     <input id="iptaccesfile" type="hidden" runat="server" />
     <div id="divaccesfile"></div>
    </div>
    </form>
</body>
</html>
