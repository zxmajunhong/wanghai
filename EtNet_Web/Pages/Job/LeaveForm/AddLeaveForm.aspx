<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLeaveForm.aspx.cs" Inherits="PJOAUI.View.Job.LeaveForm.AddLeaveForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加请假申请单</title> 
    <link href="../../../Styles/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
      .clsdata{ width:100%; border:1px solid #CDC9C9;}
      .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsdatalist{ width:200px;}     
      .clstxt{ display:inline-block; width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      img{ cursor:pointer;}
      .combo{ border:0;}
      .combo-text{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      
    </style>
    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            //开始时间
            $("#iptstartdate").datebox({
                onSelect: function () {
                    var sdt = $("#iptstartdate").datebox('getValue');
                    $("#iptstartdate").val(sdt);
                }
            });

            //结束时间
            $("#iptenddate").datebox({
                onSelect: function () {
                    var sdt = $("#iptenddate").datebox('getValue');
                    $("#iptenddate").val(sdt);
                }
            });



            // 保存草稿提示
            $("#ibtnSave").click(function () {
                var straft = "";
                if ($("#iptstartdate").val() == "") {
                    straft += "请假开始时间未填写!\n";
                }
                if ($("#iptenddate").val() == "") {
                    straft += "请假结束时间未填写!\n";
                }
                if ($("#iptstartdate").val() != "" && $("#iptenddate").val() != "") {
                    if ($("#iptstartdate").val() > $("#iptenddate").val()) {
                        straft += "开始时间大于结束时间";
                    }
                }
                if (straft.length != "") {
                    alert(straft);
                    return false;
                }
                else {
                    $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
                    return true;
                }

            });





            //提交申请的提示
            $("#ibtnSubmit").click(function () {
                var str = "";
                if ($("#iptstartdate").val() == "") {
                    str += "请假开始时间未填写!\n";
                }
                if ($("#iptenddate").val() == "") {
                    str += "请假结束时间未填写!\n";
                }
                if ($("#ddlauditsort").val().length > 4) {
                    str += "审核类型未选！\n";
                }
                if ($("#ddlapprovalrole").val() == "0") {
                    str += "审批规范未选！\n";
                }
                if ($("#iptstartdate").val() != "" && $("#iptenddate").val() != "") {
                    if ($("#iptstartdate").val() > $("#iptenddate").val()) {
                        straft += "开始时间大于结束时间";
                    }
                }
                if (str.length != "") {
                    alert(str);
                    return false;
                }
                else {
                    $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
                    return true;
                }

            });


            //动态新增文件上传控件
            var num = 1;
            $("#imgadd").click(function () {
                var str = '<tr><td><input type="file" name="addfile" /></td>'
                str += '<td><img class="imgaddfile" alt="删除" src="../../../Images/Job/delete.gif" /></td></tr>'
                if (num == 5) {
                    alert('最多上传五个文件');
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

           //设置审核图样式
           /* $("#auditpic table div").each(function () {
                if (!$(this).has("img").length) {
                    $(this).css({ "font-size": "16px" })
                }

            }) */


            $("#ddlauditsort,#ddlapprovalrole").change(function () {
                $("#iptremark").val(encodeURIComponent($("#iptremark").val()));

            });




        })
      </script>
 
</head>

<body>
  <form id="form1" runat="server">
    <input type="hidden" id="hidattachment" runat="server" />
    <div class="clstop">
        <div style=" background-image:url('../../../Images/Job/title_hover.png'); background-repeat:no-repeat; height:25px;">
           <span style=" color:White; font-size:12px; font-weight:bold; position:relative;top:5px; left:5px;">请假单添加</span>
        </div>
        <div style=" background:#4CB0D5; height:5px;"></div>          
    </div>
    <div class="clsbottom">
      <div style="text-align:right;">
          <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/Images/home/btn_submit.jpg" onclick="ibtnSubmit_Click" />
          <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="~/Images/home/btn_save.jpg" onclick="ibtnSave_Click" />       
          <asp:ImageButton ID="ibtnReset" runat="server" ImageUrl="~/Images/home/btn_reset.jpg" onclick="ibtnReset_Click" />          
      </div>
      <table class="clsdata">
         <tr>
           <td style="width:80px; height:20px;">请假单号:</td>
           <td><asp:Label runat="server" CssClass="clstxt" ID="lblnumbers"></asp:Label><span style=" color:Red;">(自动生成)</span></td>
           <td style=" width:100px;"></td>
           <td style="width:80px;"><span style=" letter-spacing:20px;">部门</span>:</td>
           <td><asp:Label runat="server" CssClass="clstxt" ID="lbldepart"></asp:Label></td>   
         </tr>
         <tr>
           <td style="height:20px;"><span style="letter-spacing:7px;">申请人</span>:</td>
           <td><asp:Label runat="server" CssClass="clstxt" ID="lblcanme"></asp:Label></td>
           <td></td>
           <td>申请日期:</td>
           <td><asp:Label runat="server" CssClass="clstxt" ID="lblapplydate"></asp:Label></td>
         </tr>
         <tr>
           <td>开始时间:</td>
           <td><input id ="iptstartdate" type="text" runat="server" /><span style=" color:Red;">*</span></td>  
           <td></td>
           <td>结束时间:</td>
           <td><input id ="iptenddate" type="text"  runat="server" /><span style=" color:Red;">*</span></td>            
        </tr>   
        <tr>
           <td style="height:20px;">请假类型:</td>
           <td colspan="4">
             <asp:RadioButtonList ID="radsort" RepeatDirection="Horizontal" runat="server">
                 <asp:ListItem Selected="True">其他</asp:ListItem>
                 <asp:ListItem>事假</asp:ListItem>
                 <asp:ListItem>病假</asp:ListItem>
                 <asp:ListItem>婚嫁</asp:ListItem>   
             </asp:RadioButtonList>
           </td>
         </tr>
        <tr>
          <td colspan="5">请假原因及其他事项:</td>
        </tr>
        <tr>
         <td colspan="5" style=" padding-right:5px;">
           <textarea runat="server" id="iptremark" style="height:100px; resize:none; width:100%"></textarea>        
         </td>
        </tr>
        <tr>
           <td><span style=" letter-spacing:20px;">附件</span>:</td>
           <td colspan="4">
             <div> 
               <table id="addfile">
                 <tr>
                   <td><asp:FileUpload runat="server" ID="fpattachment" /></td>
                   <td><img id="imgadd" alt="新增" src="../../../Images/Job/fileadd.gif"  /></td>    
                 </tr>
               </table>             
             </div>                     
           </td>
         </tr>
        <tr>
          <td colspan="5"><hr /></td>
        </tr>
        <tr>
          <td colspan="5">审核设置</td>
        </tr>       
        <tr>
           <td>审核类型:</td>
           <td colspan="4">
              <asp:DropDownList ID="ddlauditsort" runat="server" AutoPostBack="True" CssClass="clsdatalist"
                  onselectedindexchanged="ddlauditsort_SelectedIndexChanged" ></asp:DropDownList>
           </td>
        </tr>
        <tr>
           <td>审核规则:</td>
           <td colspan="4">
              <asp:DropDownList ID="ddlapprovalrole" runat="server" AutoPostBack="True" CssClass="clsdatalist"
                 onselectedindexchanged="ddlapprovalrole_SelectedIndexChanged"></asp:DropDownList>
           </td>
        </tr>
        <tr>
           <td colspan="5"><div id="auditpic" style=" border:2px solid #C6E2FF;" runat="server"></div></td>  
        </tr>
        
             
      </table>
    </div>

 </form>
</body>
</html>
