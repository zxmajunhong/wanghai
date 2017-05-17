<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitializeSet.aspx.cs" Inherits="Pages.SysSet.SetInitialize.InitializeSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统参数设置</title>
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; border:1px solid #CDC9C9; margin-bottom:5px;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{width:200px;}
       .clsrequired{ color:Red;}
       .btnimg{width:0px;height:0px;}
       .clsbtn,.clsubtn,.clsuserbtn{ background-image:url('../../../Images/Public/btn.png'); 
               width:80px;
               border:1px solid #BCBCBC; 
               height:20px;
               line-height:20px;
               cursor:pointer;
               text-align:center;
               margin-left:10px;
               margin-right:10px;
               margin-bottom:5px;}
      .buttonStyle{ background:url('../../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; } 
      #imgedit{ cursor:pointer;}
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/zDialogTwo.js" type="text/javascript"></script>
    <script src="../../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#imgbtnsave").click(function () {
                var str = "";
                if ($("#ddlpagecount option:selected").val() == "-1") {
                    str += "显示页数未设置\n";
                }
                if ($("#ddlpageitem option:selected").val() == "-1") {
                    str += "每页数据未设置\n";
                }
                if ($("#ddlnewinforemind option:selected").val() == "-1") {
                    str += "新消息提醒未设置\n";
                }
                if (!testinfocycle()) {
                    str += "消息循环周期格式不正确\n";
                }
                if ($("#hidpanellist").val() == "") {
                    str += "主页显示面板不能为空\n";
                }
                if ($("#hidupanellist").val() == "") {
                    str += "可添加面板不能为空\n";
                }
                if ($("#ddlpanelcols option:selected").val() == "-1") {
                    str += "主页面板的显示方式未选\n";
                }
                if ($("#ddlpanelcount option:selected").val() == "-1") {
                    str += "主页面板的数据条数未选";
                }

                if (str != "") {
                    alert(str);
                    return false;
                }
                else {
                    return true;
                }

            })

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

            //主页默认显示面板
            $(".clsbtn").click(function () {
                var sort = $(this).attr("id");
                switch (sort) {
                    case "addbtn":
                        if ($("#listleft option:selected").length == 0) {
                            alert('未选中添加项')
                            return;
                        }
                        $("#listleft option:selected").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listright").append(str);
                            $(this).remove();
                        })

                        break;

                    case "delbtn":
                        if ($("#listright option:selected").length == 0) {
                            alert('未选中删除项')
                            return;
                        }
                        $("#listright option:selected").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listleft").append(str);
                            $(this).remove();
                        })

                        break;

                    case "addallbtn":
                        if ($("#listleft option").length == 0) {
                            return;
                        }
                        $("#listleft option").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listright").append(str);
                            $(this).remove();
                        })

                        break;

                    case "selallbtn":
                        if ($("#listright option").length == 0) {
                            return;
                        }
                        $("#listright option").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listleft").append(str);
                            $(this).remove();
                        })
                        break;
                }

                if ($("#listright option").length == 0) {
                    $("#hidpanellist").val("");
                }
                else {
                    var list = "";
                    $("#listright option").each(function () {
                        if (list == "") {
                            list = $(this).val();
                        }
                        else {
                            list += "," + $(this).val();
                        }
                    })

                    $("#hidpanellist").val(list);
                }

            })


            //主页默认可添加的面板
            $(".clsubtn").click(function () {
                var sort = $(this).attr("id");
                switch (sort) {
                    case "addubtn":
                        if ($("#listuleft option:selected").length == 0) {
                            alert('未选中添加项')
                            return;
                        }
                        $("#listuleft option:selected").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listuright").append(str);
                            $(this).remove();
                        })

                        break;

                    case "delubtn":
                        if ($("#listuright option:selected").length == 0) {
                            alert('未选中删除项')
                            return;
                        }
                        $("#listuright option:selected").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listuleft").append(str);
                            $(this).remove();
                        })

                        break;

                    case "addallubtn":
                        if ($("#listuleft option").length == 0) {
                            return;
                        }
                        $("#listuleft option").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listuright").append(str);
                            $(this).remove();
                        })

                        break;

                    case "selallubtn":
                        if ($("#listuright option").length == 0) {
                            return;
                        }
                        $("#listuright option").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listuleft").append(str);
                            $(this).remove();
                        })
                        break;

                }


                if ($("#listuright option").length == 0) {
                    $("#hidupanellist").val("");
                }
                else {
                    var list = "";
                    $("#listuright option").each(function () {
                        if (list == "") {
                            list = $(this).val();
                        }
                        else {
                            list += "," + $(this).val();
                        }
                    })

                    $("#hidupanellist").val(list);
                }
            })



            //显示选人对话框
            function diloginfo() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 356;
                diag.Title = "选人员";
                diag.URL = "../../Personnel/SearchPersonnel.aspx?plist=" + $("#hiduserlist").val();
                diag.OKEvent = function () {
                    $("#hiduserlist").val(diag.innerFrame.contentWindow.document.getElementById('hidselpeople').value);
                    $("#iptuserlist").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtpeople').value);
                    diag.close();
                };
                diag.show();
            }

            //打开消息对话框
            $("#imgedit").click(diloginfo);
            $("#iptuserlist").focus(diloginfo)



            //重置用户
            $(".clsuserbtn").click(function () {
                if ($("#hiduserlist").val() == "") {
                    alert('未选中用户!');
                    return false;
                }
                if (confirm('确定重置指定用户的参数')) {
                    $("#imgbtnuser").click();
                }
                else {
                    return falsel;
                }

            })







        })
    
    </script>


</head>
<body>
  <form id="form1" runat="server">
   <input type="hidden" runat="server" id="hidval" />
   <div class="clstop">
      <div style=" background-image:url('../../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
         <span style=" color:White; font-size:12px; font-weight:bold; position:relative; top:5px; left:5px;">系统参数设置</span>
      </div>
        <div style=" background:#4CB0D5; height:5px;"></div>          
     </div>
     <div class="clsbottom">
       <div style=" float:right; padding-bottom:5px;">
         <asp:ImageButton runat="server" ID="imgbtnsave" 
               ImageUrl="~/Images/Button/btn_save.jpg" onclick="imgbtnsave_Click" />
       </div>

        <table class="clsdata">
         <tr>
           <td colspan="2" style=" color:Blue;font-size:13px;">数据列表页面显示配置</td>
         </tr>
         <tr>
          <td style=" width:80px;">显示页数:</td>
          <td>
            <asp:DropDownList runat="server" ID="ddlpagecount" CssClass="clsdatalist">
              <asp:ListItem Text="——请选中——" Value="-1"></asp:ListItem>
              <asp:ListItem Text="1页" Value="1"></asp:ListItem>
              <asp:ListItem Text="5页" Value="5"></asp:ListItem>
              <asp:ListItem Text="10页" Value="10"></asp:ListItem>
            </asp:DropDownList>
            <span class="clsrequired">*</span>
          </td>
         </tr>
         <tr>
          <td>每页数据:</td>
          <td>
            <asp:DropDownList runat="server" ID="ddlpageitem" CssClass="clsdatalist">
              <asp:ListItem Text="——请选中——" Value="-1"></asp:ListItem>
              <asp:ListItem Text="5条" Value="5"></asp:ListItem>
              <asp:ListItem Text="10条" Value="10"></asp:ListItem>
              <asp:ListItem Text="15条" Value="15"></asp:ListItem>
              <asp:ListItem Text="20条" Value="20"></asp:ListItem>
              <asp:ListItem Text="40条" Value="40"></asp:ListItem>
              <asp:ListItem Text="50条" Value="50"></asp:ListItem>
            </asp:DropDownList>
            <span class="clsrequired">*</span>
          </td>
         </tr>
        </table>

        <table class="clsdata">
         <tr>
          <td colspan="2" style=" color:Blue; font-size:13px;">消息显示设置</td>
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
           <td colspan="2" style=" color:Blue; font-size:13px;">主页默认显示面板</td>
          </tr>
          <tr>
           <td>
             <table>
                <tr>
                 <td>待分配面板</td>
                 <td></td>
                 <td>已分配面板<span class="clsrequired">*</span></td>
                </tr>
                <tr>
                   <td>
                     <asp:ListBox ID="listleft" SelectionMode="Multiple" runat="server" Width="160" Height="240"></asp:ListBox>
                     <input id="hidpanellist" type="hidden" runat="server" />
                   </td>    
                   <td style=" width:60px">
                     <div id="addbtn" class="clsbtn"> 添加—></div>
                     <div id="delbtn" class="clsbtn"> 删除<—</div>
                     <div id="addallbtn" class="clsbtn"> 全部添加</div>
                     <div id="selallbtn" class="clsbtn"> 全部删除</div>        
                   </td>
                   <td><asp:ListBox ID="listright" SelectionMode="Multiple" runat="server" Width="160" Height="240"></asp:ListBox></td>     
                 </tr>
                 <tr>    
                   <td>可用于自定义添加的面板</td>
                   <td></td>
                   <td>已用于自定义添加的面板<span class="clsrequired">*</span></td>
                 </tr>
                 <tr>
                   <td>
                     <asp:ListBox ID="listuleft" SelectionMode="Multiple" runat="server" Width="160" Height="240"></asp:ListBox>
                     <input id="hidupanellist" type="hidden" runat="server" />
                   </td> 
                   <td style=" width:60px">
                     <div id="addubtn" class="clsubtn"> 添加—></div>
                     <div id="delubtn" class="clsubtn"> 删除<—</div>
                     <div id="addallubtn" class="clsubtn"> 全部添加</div>
                     <div id="selallubtn" class="clsubtn"> 全部删除</div>        
                   </td>
                   <td><asp:ListBox ID="listuright" SelectionMode="Multiple" runat="server" Width="160" Height="240"></asp:ListBox></td>
                 </tr>
                 <tr>
                  <td colspan="3">
                    <table>
                       <tr>
                        <td>默认数据条数:</td>
                        <td>
                         <asp:DropDownList runat="server" ID="ddlpanelcount"  CssClass="clsdatalist">
                          <asp:ListItem Text="——请选中——" Value="-1"></asp:ListItem>
                          <asp:ListItem Text="5条" Value="5"></asp:ListItem>
                          <asp:ListItem Text="10条" Value="10"></asp:ListItem>
                          <asp:ListItem Text="15条" Value="15"></asp:ListItem>                          
                        </asp:DropDownList>
                        <span class="clsrequired">*</span>
                       </td>
                      </tr>
                      <tr>
                       <td>面板排列方式:</td>
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
                    </table>
                  </td>
                </tr>
             </table>
           </td>
          </tr>
        </table>

        <table>
          <tr>
           <td>待重置用户:</td>
           <td>
             <input type="text" runat="server" id="iptuserlist" class="clsunderline" />
             <img  id="imgedit" src="../../../Images/Public/adedit.gif" alt="编辑用户" />
             <span class="clsuserbtn" style=" display:inline-block; border:1px solid #4CB0D5;">重置用户参数</span>
             <input type="hidden" runat="server" id="hiduserlist" />
             <asp:ImageButton  runat="server" ID="imgbtnuser" CssClass="btnimg"
                   ImageUrl="~/Images/Public/btn.png" onclick="imgbtnuser_Click" />
           </td>
          </tr>
        </table>

      </div>
  </form>
</body>
</html>
