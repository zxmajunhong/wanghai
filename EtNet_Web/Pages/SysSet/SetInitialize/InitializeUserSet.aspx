<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitializeUserSet.aspx.cs" Inherits="Pages.SysSet.SetInitialize.InitializeUserSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户参数设置</title>
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; border:1px solid #CDC9C9; margin-bottom:5px;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{width:200px;}
       .clsrequired{ color:Red;}         
       .clsubtn{ background-image:url('../../../Images/Public/btn.png'); 
               width:60px;
               border:1px solid #4CB0D5;
               height:20px;
               line-height:20px;
               cursor:pointer;
               text-align:center;
               display:inline-block;            
               margin-bottom:5px;}        
                 
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">


        $(function () {

            $("#imgbtnsave").click(function () {
                var str = "";
                var num = "";

                num = $.trim($("#iptpagecount").val());
                if (num == "" || !testnum(num)) {
                    str += "显示页数格式不正确\n";
                    $("#iptpagecount").val("");
                }

                num = $.trim($("#iptpageitem").val());
                if (num == "" || !testnum(num)) {
                    str += "每页数据格式不正确\n";
                    $("#iptpageitem").val("")
                }
                if ($("#ddlnewinforemind option:selected").val() == "-1") {
                    str += "新消息提醒未设置\n";
                }
                if (!testinfocycle()) {
                    str += "消息循环周期格式不正确\n";
                }


                if ($("#ddlpanelcols option:selected").val() == "-1") {
                    str += "面板的排列方式未选\n";
                }
                num = $.trim($("#iptpanelcount").val());
                if (num == "" || !testnum(num)) {
                    str += "面板的数据条数格式不正确";
                    $("#iptpanelcount").val("")
                }

                if (str != "") {
                    alert(str);
                    return false;
                }
                else {
                    return true;
                }

            })


            //验证数字格式
            function testnum(num) {
                var rg = /^[1-9][0-9]*$/;
                if (rg.test(num)) {
                    return true;
                }
                else {
                    return false;
                }
            }



            //验证消息循环周期格式
            function testinfocycle() {
                var rg = /[^0-9]/;
                var r = /0[1-9]+/;
                if ($.trim($("#iptinfocycle").val()) == "") {
                    return false
                }
                if (r.test($("#iptinfocycle").val())) {
                    return false;
                }
                if (rg.test($("#iptinfocycle").val())) {
                    return false
                }
                else {
                    return true;
                }
            }


            $("#seluall").click(function () {
                $("#chkdata,#chkinformation,#chkpanel").each(function () {
                    $(this).attr("checked", "checked");
                })

            })

            $("#selunall").click(function () {
                $("#chkdata,#chkinformation,#chkpanel").each(function () {
                    $(this).removeAttr("checked");
                })

            })

        })

    
    </script>

</head>
<body>
  <form id="form1" runat="server">
     <input id="hidval" type="hidden" runat="server" />
     <div class="clstop">
      <div style=" background-image:url('../../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
         <span style=" color:White; font-size:12px; font-weight:bold; position:relative; top:5px; left:5px;">用户参数设置</span>
      </div>
        <div style=" background:#4CB0D5; height:5px;"></div>          
     </div>
     <div class="clsbottom">
       <div style=" float:right; padding-bottom:5px;">
         <asp:ImageButton runat="server" ID="imgbtnsave" 
               ImageUrl="~/Images/Button/btn_save.jpg" onclick="imgbtnsave_Click"  />
       </div>
       <div>
         <span id="seluall" class="clsubtn">全选</span>
         <span id="selunall" class="clsubtn">全不选</span>
       </div>
       <table class="clsdata">
         <tr>
           <td colspan="2" style=" color:Blue;font-size:13px;">
            <asp:CheckBox runat="server" Checked="true" ID="chkdata" /> 数据列表页面显示配置
           </td>
         </tr>
         <tr>
          <td style=" width:80px;">显示页数:</td>
          <td>
            <input type="text" runat="server" id="iptpagecount" class="clsunderline" />
            <span class="clsrequired">*</span>
          </td>
         </tr>
         <tr>
          <td>每页数据:</td>
          <td>
            <input type="text" runat="server" id="iptpageitem" class="clsunderline" />
            <span class="clsrequired">*</span>
          </td>
         </tr>
        </table>
        <table class="clsdata">
         <tr>
          <td colspan="2" style=" color:Blue; font-size:13px;">
            <asp:CheckBox runat="server" Checked="true" ID="chkinformation" /> 消息显示设置
          </td>
         </tr>
         <tr>
          <td>新消息需提醒:</td>
          <td>
            <asp:DropDownList runat="server" ID="ddlnewinforemind" CssClass="clsdatalist">
              <asp:ListItem Text="——请选中——" Value="-1"></asp:ListItem>
              <asp:ListItem Text="否" Value="0"></asp:ListItem>
              <asp:ListItem Text="是" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <span class="clsrequired">*</span>
          </td>
         </tr>
         <tr>
          <td style=" width:80px;">消息循环周期:</td>
          <td>
            <input type="text" runat="server" id="iptinfocycle" class="clsunderline" />(分)
            <span class="clsrequired">*(0代表不循环获取消息)</span>
          </td>
         </tr>
        </table>

        <table class="clsdata">
          <tr>
           <td colspan="2" style=" color:Blue; font-size:13px;">
            <asp:CheckBox runat="server" Checked="true" ID="chkpanel" />主页面板配置
           </td>
          </tr>
          <tr style="display:none">
           <td style="width:80px;">面板排列方式:</td>
           <td>
             <asp:DropDownList runat="server" ID="ddlpanelcols"  CssClass="clsdatalist">
               <asp:ListItem Text="——请选中——" Value="-1"></asp:ListItem>
               <asp:ListItem Text="1列" Value="1"></asp:ListItem>
               <asp:ListItem Text="2列" Value="2"></asp:ListItem>
               <asp:ListItem Text="3列" Value="3"></asp:ListItem>                          
             </asp:DropDownList>
             <span class="clsrequired">*</span>
           </td>      
          </tr>
          <tr>
           <td style="width:80px;">默认数据条数:</td>
           <td>
            <input type="text"  runat="server" id="iptpanelcount" class="clsunderline"/>
            <span class="clsrequired">*</span>
           </td>
          </tr>   
          <tr style="display:none;">
           <td>恢复默认面板:</td>
           <td><input type="text" runat="server" id="iptlistpanel" disabled="disabled" class="clsunderline" /></td>
          </tr>
        </table>
        <div class="clsrequired">注意:选项框勾选后的模块会进行保存</div>
      </div>
  </form>
</body>
</html>
