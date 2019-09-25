<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyLeaveForm.aspx.cs" Inherits="PJOAUI.View.Job.LeaveForm.ModifyLeaveForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加请假申请单</title>
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jNotify.jquery.css" rel="stylesheet" type="text/css" />


    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jNotify.jquery.min.js" type="text/javascript"></script>
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




              //设置申请日期
              $("#iptapplydate").datepicker({
                  showAnim: "clip",
                  dateFormat: 'yy-mm-dd ',
                  showButtonPanel: true, //是否显示按钮面板  
                  closeText: "关闭", //关闭选择框的按钮名称 
                  currentText: "今天",
                  changeMonth: true
              });
              $.datepicker.setDefaults($.datepicker.regional['zh-CN']);



              //  保存草稿提示
              $("#ibtnSave").click(function () {

                  var straft = "";

                  if ($("#iptstartdate").val() == "") {
                      straft += "请假开始时间未填写!<br/>";
                  }
                  if ($("#iptenddate").val() == "") {
                      straft += "请假结束时间未填写!<br/>";
                  }

                  if (straft.length != "") {
                      jNotify(straft, { autoHide: true,
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




              //提交申请的提示
              $("#ibtnSubmit").click(function () {

                  var str = "";

                  if ($("#iptstartdate").val() == "") {
                      str += "请假开始时间未填写!<br/>";
                  }
                  if ($("#iptenddate").val() == "") {
                      str += "请假结束时间未填写!<br/>";
                  }

                  if ($("#ddlauditsort").val().length > 4) {
                      str += "审核类型未选！<br/>";
                  }
                  if ($("#ddlapprovalrole").val() == "0") {
                      str += "审批规范未选！";
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




              //动态新增文件上传控件
              var num = 1;
              $("#imgadd").click(function () {

                  var str = '<tr><td><input type="file" name="addfile" /></td>'
                  str += '<td><img class="imgaddfile" alt="删除" src="../../../Images/Job/delete.gif" /></td></tr>'

                  if (num == (5 - $("#iptflienum").val())) {
                      jNotify('最多上传五个文件！', { autoHide: true,
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




              $("#originalfile input:image").click(function () {
                  $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
              })




          })

        
      
      </script>
   

    <style type="text/css">
        .style1
        {
            height: 34px;
        }
        .style3
        {
            height: 122px;
        }
    </style>
   

</head>
<body>
    <form id="form1" runat="server">
   
    <input type="hidden" id="iptflienum" runat="server" />
    <div style="width:100%; height: 660px;">
      <table style="width:100%;">
         <tr>
          <th colspan="8" align="center"><h3>请假申请单修改</h3></th>
         </tr>
         <tr>
          <td colspan="8" style=" background-image: url('../../../Images/Job/win_top.png'); height:10px; background-repeat:repeat-x;"></td>
         </tr>
         <tr>
           <td style="width:10%">请假单号</td>
           <td style="width:15%"><asp:Label ID="lblnumbers" runat="server"></asp:Label></td> 
           <td style="width:10%">部门</td>
           <td style="width:15%"><asp:Label ID="lbldepart" runat="server"></asp:Label></td>
           <td style="width:10%">申请人</td>
           <td style="width:15%"><asp:Label ID="lblpeople" runat="server"></asp:Label></td>
           <td style="width:10%">申请日期</td>
           <td style="width:15%"><asp:Label ID="lblapplydate" runat="server"></asp:Label>  </td>
         </tr>
         <tr>
           <td>请选一项请假类型</td>
           <td colspan="7">
             <asp:RadioButtonList ID="radsort" RepeatDirection="Horizontal" runat="server">
                 <asp:ListItem Selected="True">其他</asp:ListItem>
                 <asp:ListItem>事假</asp:ListItem>
                 <asp:ListItem>病假</asp:ListItem>
                 <asp:ListItem>婚嫁</asp:ListItem>   
             </asp:RadioButtonList>
           </td>
         </tr>

         <tr>
           <td>请假开始时间</td>
           <td>
            <input id ="iptstartdate" type="text" runat="server" readonly="readonly" />
           
           </td>
           <td>请假结束时间</td>
           <td colspan="5">
            <input id ="iptenddate" type="text" runat="server" readonly="readonly" />
           </td>
         </tr>
       
        <tr>
          <td colspan="8">请假原因及其他事项</td>
        </tr>
        <tr>
         <td colspan="8" class="style3">
           <textarea runat="server" id="iptremark" style="height:100px; width:100%" 
                 cols="20" name="S1" rows="1"></textarea>
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
           <td colspan="7"><asp:DropDownList ID="ddlauditsort" runat="server" AutoPostBack="True" 
                   onselectedindexchanged="ddlauditsort_SelectedIndexChanged" ></asp:DropDownList></td>
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
                       <td><asp:FileUpload runat="server" ID="FileUpload1" /></td>
                       <td><img id="img1" alt="新增" src="../../../Images/Job/fileadd.gif"  /></td>    
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
                  
          </td>
        </tr>

      </table>
    </div>

    <div id="divpromptbox">
    
    </div>

    </form>
</body>
</html>
