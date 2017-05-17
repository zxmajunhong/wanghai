<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOfficeSuppyForm.aspx.cs" Inherits="PJOAUI.View.Job.OfficeSuppyForm.ShowOfficeSuppyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看办公用品申请单</title>
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/page.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
       
       .titlebtncls{ position:absolute; right:40px;}
       .editpage, .siftdata, .addapplylink,.datago{ font-size:12px; font-weight:bold; margin-right:10px; color:#718ABE; cursor:pointer;}
       .datago{ margin-left:0px;}
       .titlebtncls input,.titlebtncls img{ width:12px; height:12px;}
        img{ border:0px solid #111; }
     
        
    </style>




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




              $(window).load(function () {
                  //最新一条数据添加颜色
                  $("#table1 tr").eq(1).children().css("background-color", "#EEE685");

              });





              //提交时判断编号的输入是否符合要求
              $("#ibtnsearchjob,#ibtnjobreset").click(function () {
                  var rg = /[^\w]/g;
                  if ($("#tbxnumber").val() && rg.test($("#tbxnumber").val())) {
                      jNotify('单据编号只包含数字与字母!', { autoHide: true,
                          clickOverlay: true,
                          TimeShown: 3000,
                          HorizontalPosition: 'center',
                          VerticalPosition: 'center'
                      });
                      $("#tbxnumber").val("");
                      return false;
                  }
                  else {
                      return true;
                  }

              });


              $("form").keypress(function (e) {
                  if (e.keyCode == "13") {

                      var rg = /[^\w]/g;
                      if ($("#tbxnumber").val() && rg.test($("#tbxnumber").val())) {
                          $("#tbxnumber").val("");
                      }

                      return true;

                  }

              });


              //数据导出
              $(".datago").click(function () {
                  $("#imgbtndata").trigger("click");

              })


              $(".editpage").click(function () {
                  var strmodal = "dialogHeight=140px;dialogWidth=200px;resizable=no;";
                  strmodal += "status=no";

                  window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=010&dt=" + new Date().toString(), window.self, strmodal);
              })


              //按照条件判断是否显示筛选栏
              function fist() {
                  if ($("#hidsift").val() == "0") {
                      $("#tablesift").hide();
                  }
                  else {
                      $("#tablesift").show();
                  }
              }

              fist();


              //展开或影藏筛选栏
              $(".siftdata").click(function () {
                  if ($("#hidsift").val() == "0") {
                      $(this).children("img").attr("src", "../../../Images/Job/collapse.gif");
                      $("#tablesift").show();
                      $("#hidsift").val("1");
                  }
                  else {
                      $(this).children("img").attr("src", "../../../Images/Job/expand.gif");
                      $("#tablesift").hide();
                      $("#hidsift").val("0");
                  }

              })





          });
      </script>

</head>


<body>
    
   <form id="form1" runat="server">
    <input type="hidden" id="hidsift" runat="server"/>
    <div>
       <table id="tabledata" style="width:100%;">
       <tr>
         <td colspan="8" style="background-image: url('../../../Images/Job/win_top.png'); background-repeat:repeat-x; height:24px;"> 
             <span style=" font-size:13px; font-weight:bold; margin-top:5px; margin-left:10px;">
               <img style="vertical-align:middle" src="../../../Images/Common/chartorg.png" alt="导航" />
               工作流管理—>办公用品申请单查看
             </span> 
             <span class="titlebtncls">
               <a href="#" class="editpage">
                 <img src="../../../Images/Common/layoutedit.png" alt="设置" />
                    页面设置
               </a>
               <a href="#" class="siftdata">
                  <img src="../../../Images/Job/expand.gif" alt="展开筛选栏" />
                  数据筛选
               </a>
               <a class="addapplylink" href="AddOfficeSuppyForm.aspx">
                  <img src="../../../Images/Job/addapply.gif" alt="添加申请" />
                  添加申请
               </a>   

              <asp:ImageButton runat="server"  ID="imgbtndata"  
                  ImageUrl="~/Images/Job/tablesave.png" onclick="imgbtndata_Click" />
              <span class="datago">数据导出</span>    
           </span>
         </td>
       </tr>  

       <tr>
        <td colspan="8">
           <table id="tablesift" style="width:100%;">
               <tr>
                 <th colspan="8" class="siftcol">
                    <img src="../../../Images/Common/attach.PNG" alt="筛选" />筛选条件
                 </th>
               </tr>
               <tr>
                 <td>单据编号</td>
                 <td><asp:TextBox runat="server" ID="tbxnumber" ></asp:TextBox></td>          
                 <td>保存状态</td>
                 <td>
                   <asp:DropDownList ID="ddlsavestatus" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlsavestatus_SelectedIndexChanged">
                   <asp:ListItem Selected="True" Value="0" Text="——请选中——"></asp:ListItem>
                     <asp:ListItem Value="草稿" Text="草稿"></asp:ListItem>
                     <asp:ListItem Value="已提交" Text="已提交"></asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td>审核状态</td>
               <td><asp:DropDownList ID="ddlauditstatus" runat="server" AutoPostBack="true" 
                     onselectedindexchanged="ddlauditstatus_SelectedIndexChanged"></asp:DropDownList></td> 
              <td>申请时间</td>
              <td><input type="text" runat="server" id="iptstartdate" readonly="readonly" />
                  <span>至</span> 
                  <input type="text" runat="server" id="iptenddate" readonly="readonly" />
             </td>  
            </tr>
            <tr>
              <td colspan="8" align="right">
                <asp:ImageButton ID="ibtnsearchjob" runat="server" 
                    ImageUrl="~/Images/home/btn_search.jpg" onclick="ibtnsearchjob_Click" />
                <asp:ImageButton ID="ibtnjobreset" runat="server" 
                   ImageUrl="~/Images/home/btn_reset.jpg" onclick="ImageButton2_Click" />
              </td>
           </tr>
          </table>
        </td>
       </tr>  
       <tr>
         <td colspan="8">
            <table style=" width:100%" id="table1" class="sortable">
             <thead>
               <tr align="center" style=" font-weight:bold;">
                  <th><h3>单据编号</h3></th>
                  <th><h3>申请时间</h3></th>
                  <th><h3>申请人  </h3></th>
                  <th><h3>审核状态</h3></th>
                  <th class="nosort">保存状态 </th>   
                  <th class="nosort">操作     </th>
              </tr>
            </thead>
            <tbody>
               <asp:Repeater ID="rptsupplyform" runat="server" 
                    onitemcommand="rptsupplyform_ItemCommand">    
                  <ItemTemplate>
                    <tr>
                      <td> <%# Eval("cname")%>                                         </td>
                      <td> <%# Eval("applydate").ToString().Substring(0, 10)%>         </td>
                      <td> <%# Eval("logincname") + "(" + Eval("departcname") + ")"%>  </td>
                      <td> <%# StatusColor(Eval("auditstutastxt").ToString()) %>       </td>
                      <td> <%# Eval("savestatus") %> <asp:ImageButton runat="server" Enabled='<%# Eval("savestatus").ToString() == "草稿"?false: true  %>'  CommandName="refresh" CommandArgument='<%# Eval("jobflowid") %>' ImageUrl="~/Images/Job/formfresh.png" AlternateText="刷新"/> </td>
                      <td>
                        <asp:ImageButton  runat="server" CssClass="imgbtnedit"   CommandName="edit" CommandArgument='<%# Eval("jobflowid") %>'   ImageUrl="~/Images/Job/edit.gif" AlternateText="编辑"/> 
                        <asp:ImageButton  runat="server" CssClass="imgbtnsearch" Enabled='<%# Eval("savestatus").ToString() == "草稿"?false: true  %>'  CommandName="search" CommandArgument='<%# Eval("jobflowid") %>' ImageUrl="~/Images/Job/person.gif" AlternateText="详细"/>
                        <asp:ImageButton  runat="server" CssClass="imgbtndel"    Enabled='<%# Eval("auditstatus").ToString() =="01"? true :false  %>'   CommandName="del" CommandArgument='<%# Eval("jobflowid") %>'    ImageUrl="~/Images/Job/delete.gif" AlternateText="删除"/>
                      </td>
                    </tr>
                  </ItemTemplate>
               </asp:Repeater>
            </tbody>
           </table>
         </td>
       </tr>
      </table>

        <div id="pages" runat="server"></div>
     
        <script src="../../../Scripts/Common/script.js" type="text/javascript"></script>

        <script type="text/javascript">
            var sorter = new TINY.table.sorter("sorter");
            sorter.head = "head";
            sorter.asc = "asc";
            sorter.desc = "desc";
            sorter.even = "evenrow";
            sorter.odd = "oddrow";
            sorter.evensel = "evenselected";
            sorter.oddsel = "oddselected";
            sorter.paginate = true;
            sorter.currentid = "currentpage";
            sorter.limitid = "pagelimit";
            sorter.init("table1", 0);
        </script>
     
      
    </div>


    </form>

</body>
</html>
