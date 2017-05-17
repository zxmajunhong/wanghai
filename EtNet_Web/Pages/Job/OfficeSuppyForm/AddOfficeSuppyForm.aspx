<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOfficeSuppyForm.aspx.cs" Inherits="PJOAUI.View.Job.OfficeSuppyForm.AddOfficeSuppyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>添加办公用品申请</title>
   <link href="../../../Styles/easyui.css" rel="stylesheet" type="text/css" />
   <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
      .clsdata{ width:100%; border:1px solid #CDC9C9;}
      .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsdatalist{ width:200px;}     
      .clstxt{ display:inline-block; width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      img{ cursor:pointer;}
      #supplydetail{ background-color:#E5E5E5;}
      #supplydetail tr td{ background-color:White;}
      .buttonStyle{ background:url('../../../Images/Job/buticon.gif'); height:22px; width:64px; border:0; }
   </style>
   <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
   <script src="../../../Scripts/Jquery/jquery.easyui.min.js" type="text/javascript"></script>
   <script type="text/javascript">

       $(function () {


           //动态新增文件上传控件
           var num = 1;
           $("#imgadd").click(function () {
               var str = '<tr><td><input type="file" name="addfile" /></td>'
               str += '<td><img class="imgaddfile" alt="删除" src="../../../Images/Job/delete.gif" /></td></tr>'
               if (num == 5) {
                   alert('最多上传五个文件!');
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


           $("#ddlauditsort,#ddlapprovalrole").change(function () {
               $("#iptremark").val(encodeURIComponent($("#iptremark").val()));

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


           //隐藏对话框
           $("#box").hide();

           //点击打开办公明细添加对话框
           $(".imgdetail").click(function () {
               $("#box").show();
               $("#box").window({
                   modal: true,
                   title: '申请办公用品明细',
                   width: 300,
                   height: 120,
                   collapsible: false,
                   minimizable: false,
                   maximizable: false,
                   resizable: false
               })
           })


           //确定添加明细
           $("#btnsure").click(function () {

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
               $("#box").window("close");
           })

           //取消添加明细
           $("#btncanel").click(function () {
               $("#box").window("close");
           })



           //删除办公用品明细
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
                   str += "审核类型未选!\n";
               }
               if ($("#ddlapprovalrole").val() == "0") {
                   str += "审批规则未选！";
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




           // 保存草稿提示
           $("#ibtnSave").click(function () {
               $("#iptremark").val(encodeURIComponent($("#iptremark").val()));
               return true;
           });





           //清空数据
           $("#ibtnReset").click(function () {
               $("#iptdetial").val("");
               $("#iptremark").val("");
           })






       })

   </script>

</head>
<body>
  <form id="form1" runat="server">
  <input type="hidden" id="iptdetial" runat="server" />
  <div class="clstop">
    <div style=" background-image:url('../../../Images/Job/title_hover.png'); background-repeat:no-repeat; height:25px;">
         <span style=" color:White; font-size:12px; font-weight:bold; position:relative;top:5px;">物品申请单添加</span>
     </div>
     <div style=" background:#4CB0D5; height:5px;"></div>          
   </div>
   <div class="clsbottom">
      <div style="text-align:right">
        <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/Images/home/btn_submit.jpg" onclick="ibtnSubmit_Click" />  
        <asp:ImageButton ID="ibtnSave" runat="server"   ImageUrl="~/Images/home/btn_save.jpg" onclick="ibtnSave_Click" />
        <asp:ImageButton ID="ibtnReset" runat="server"  ImageUrl="~/Images/home/btn_reset.jpg" onclick="ibtnReset_Click" />             
      </div>
      <table class="clsdata">
        <tr>
           <td style="width:100px; height:20px;">物品申请单号:</td>
           <td><asp:Label runat="server" CssClass="clstxt" ID="lblnumbers"></asp:Label><span style=" color:Red">(自动生成)</span></td>
           <td style="width:100px;"></td>
           <td style="width:100px;"><span style=" letter-spacing:20px;"> 部门</span>:</td>
           <td><asp:Label runat="server" CssClass="clstxt" ID="lbldepart"></asp:Label></td>     
        </tr>
        <tr>
         <td style=" height:20px;">申请人:</td>
         <td><asp:Label runat="server" CssClass="clstxt" ID="lblcanme"></asp:Label></td>
         <td></td>
         <td>申请日期:</td>
         <td><asp:Label runat="server" CssClass="clstxt" ID="lblapplydate"></asp:Label></td>
        </tr>
        <tr>
          <td colspan="5">
            <table id="supplydetail" style=" width:40%;">
              <tr>
                <td colspan="3" style=" font-weight:bold;">办公用品申请明细</td>
              </tr>
              <tr>
                <td style=" width:50%;background-color:#C6E2FF;">名称</td>
                <td style=" width:20%;background-color:#C6E2FF;">数量</td>
                <td style=" width:30%;background-color:#C6E2FF;">
                  <span>添加明细</span>
                  <img class="imgdetail" alt="添加" src="../../../Images/Job/bulletadd.png" />
                </td>
              </tr>
            </table>
          </td>
        </tr>
       <tr>
          <td colspan="5">申请原因及用途说明:</td>
        </tr>
        <tr>
         <td colspan="5" style=" padding-right:5px;">
           <textarea runat="server" id="iptremark" style="height:100px; resize:none; width:100%" ></textarea>      
         </td>
        </tr>
        <tr>
           <td>附件:</td>
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
              <asp:DropDownList ID="ddlauditsort" runat="server" CssClass="clsdatalist" AutoPostBack="True"
                  onselectedindexchanged="ddlauditsort_SelectedIndexChanged" ></asp:DropDownList>
           </td>
         </tr>
         <tr>
           <td>审核规则:</td>
           <td colspan="4">
              <asp:DropDownList ID="ddlapprovalrole" runat="server" CssClass="clsdatalist" AutoPostBack="True" 
                 onselectedindexchanged="ddlapprovalrole_SelectedIndexChanged"></asp:DropDownList>          
           </td>
         </tr>
         <tr>
           <td colspan="8">
             <div id="auditpic" style="border:2px solid #C6E2FF;" runat="server"></div>   
           </td>
         </tr>
      </table>
    </div>

    <!-- 办公用品填写 -->
    <div id="box">
      <table style="width:100%; height:100%;">
        <tr>
          <td>办公用品:</td>
          <td><select id="selsupply" style=" width:200px;" runat="server"></select></td>
        </tr>
        <tr>
          <td>数量:</td>
          <td><input id="iptnum"  class="clsunderline" type="text" /></td>
        </tr>
        <tr>
          <td colspan="2" style=" text-align:right;">
            <input type="button" value="确定" id="btnsure" class="buttonStyle" />
            <input type="button" value="取消" id="btncanel" class="buttonStyle" />
          </td>
        </tr>
      </table>
    </div>

  </form>
</body>
</html>
