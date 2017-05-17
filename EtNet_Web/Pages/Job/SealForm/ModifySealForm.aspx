<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifySealForm.aspx.cs" Inherits="PJOAUI.View.Job.SealForm.ModifySealForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改公章申请</title>
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jNotify.jquery.css" rel="stylesheet" type="text/css" />

    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jNotify.jquery.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>

      <script type="text/javascript">

          $(function () {

              //设置请假开始与结束时间
              var dates = $("#iptstartdate, #iptenddate").datepicker({
                  defaultDate: "+1w",
                  changeMonth: true,
                  numberOfMonths: 2,
                  showAnim: "clip",
                  dateFormat: 'yy-mm-dd ',
                  showButtonPanel: true, //是否显示按钮面板  
                  closeText: "关闭", //关闭选择框的按钮名称 
                  currentText: "今天",
                  onSelect: function (selectedDate) {
                      var option = this.id == "iptstartdate" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                      dates.not(this).datepicker("option", option, date);
                  }
              });


              $.datepicker.setDefaults($.datepicker.regional['zh-CN']);


              //保存草稿提示
              $("#ibtnSave").click(function () {
                  var sraft = "";
                  if ($("#iptstartdate").val() == "") {
                      sraft += "借用时间未填写!<br/>";
                  }
                  if ($("#iptenddate").val() == "") {
                      sraft += "归还时间未填写!<br/>";
                  }

                  if (sraft.length != "") {
                      jNotify(sraft, { autoHide: true,
                          clickOverlay: true,
                          TimeShown: 3000,
                          HorizontalPosition: 'center',
                          VerticalPosition: 'center'
                      });
                      return false;
                  }
                  else {
                      if (confirm("确定保存草稿！")) {
                          $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
                          return true;
                      }
                      else {
                          return false;
                      }

                  }

              });







              //提交申请的提示
              $("#ibtnSubmit").click(function () {

                  var str = "";

                  if ($("#iptstartdate").val() == "") {
                      str += "借用时间未填写!<br/>";
                  }
                  if ($("#iptenddate").val() == "") {
                      str += "归还时间未填写!<br/>";
                  }

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
                      if (confirm("确定提交申请，提交后不能再进行修改！")) {
                          $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
                          return true;
                      }
                      else {
                          return false;
                      }
                  }

              });






              //动态新增文件上传控件
              var num = 1;
              $("#imgadd").click(function () {

                  var str = '<tr><td><input type="file" name="addfile" /></td>'
                  str += '<td><img class="imgaddfile" alt="删除" src="../../../Images/Job/delete.gif" /></td></tr>'

                  if (num == (5 - $("#iptflienum").val())) {
                      alert('最多上传五个文件！');
                  }
                  else {
                      $("#addfile").append(str);
                      num++;
                  }

              });

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

          })


        
      </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="iptflienum" runat="server" />
    <div style=" width:100%;">
      <table style="width:100%;">
         <tr>
          <th colspan="8" align="center"><h3>公章申请单修改</h3></th>
         </tr>
         <tr>
          <td colspan="8" style=" background-image: url('../../../Images/Job/win_top.png'); height:10px; background-repeat:repeat-x;"></td>
         </tr>
         <tr>
           <td style="width:10%">公章申请单号</td>
           <td style="width:15%"><asp:Label runat="server" ID="lblnumbers"></asp:Label></td>
           <td style="width:10%">部门</td>
           <td style="width:15%"><asp:Label runat="server" ID="lbldepart"></asp:Label></td>
           <td style="width:10%">申请人</td>
           <td style="width:15%"><asp:Label runat="server" ID="lblcanme"></asp:Label></td>
           <td style="width:10%">申请日期</td>
           <td style="width:15%"><asp:Label runat="server" ID="lblapplydate"></asp:Label>   </td>
         </tr>
         <tr>
           <td>请选公章类型</td>
           <td colspan="7">
             <asp:DropDownList runat="server" ID="ddlsealsort"></asp:DropDownList>
           </td>
         </tr>

         <tr>
           <td>公章借用时间</td>
           <td>
            <input id ="iptstartdate" type="text" runat="server" readonly="readonly" />
           
           </td>
           <td>公章归还时间</td>
           <td colspan="5">
            <input id ="iptenddate" type="text" runat="server" readonly="readonly" />
           </td>
          
         </tr>
       
        <tr>
          <td colspan="8">借用公章的原因及用途说明</td>
        </tr>
        <tr>
         <td colspan="8" class="style3">
           <textarea runat="server" id="iptremark" style="height:100px; width:100%" ></textarea>      
         </td>
        </tr>

        <tr>
          <td colspan="8"><hr /></td>
        </tr>

        <tr>
          <td colspan="8">审核设置</td>
        </tr>       
     
         <tr>
           <td>审核类型</td>
           <td colspan="7">
              <asp:DropDownList ID="ddlauditsort" runat="server" AutoPostBack="True" onselectedindexchanged="ddlauditsort_SelectedIndexChanged" ></asp:DropDownList>
           </td>
         </tr>
         <tr>
           <td>审核规则</td>
           <td colspan="7">
              <asp:DropDownList ID="ddlapprovalrole" runat="server" AutoPostBack="True" 
                   onselectedindexchanged="ddlapprovalrole_SelectedIndexChanged"></asp:DropDownList>          
           </td>
         </tr>

         <tr>
           <td colspan="8">
             <div id="auditpic" runat="server"></div>   
           </td>
         </tr>

        <tr>
           <td>附件</td>
           <td colspan="7">
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
           <td>原有附件</td>
           <td colspan="7">
              <div>  
                 <table id="originalfile" runat="server">
                   
                 </table>   
              </div>
           </td>
        </tr>
        <tr>
          <td align="right" colspan="8" class="style1">
              <asp:ImageButton ID="ibtnSubmit" runat="server" 
                  ImageUrl="~/Images/home/btn_submit.jpg" onclick="ibtnSubmit_Click" />
              &nbsp;
              <asp:ImageButton ID="ibtnSave" runat="server" 
                  ImageUrl="~/Images/home/btn_save.jpg" onclick="ibtnSave_Click" />
              &nbsp;
              <asp:ImageButton ID="ibtnReset" runat="server" 
                  ImageUrl="~/Images/home/btn_reset.jpg" onclick="ibtnReset_Click" />
           &nbsp;</td>
        </tr>

      </table>
    </div>

  
    </form>
</body>
</html>
