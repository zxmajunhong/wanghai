<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationCycle.aspx.cs" Inherits="EtNet_Web.Pages.Information.InformationCycle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息循环提醒</title>
    <base target="_self" />
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{ padding:0; margin:0px; width:600px;}
        form{ margin:5px;}
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; background-color:#B9D3EE}
       .clsdata tr td{ background-color:White; height:30px; text-align:center;}
       .clstitleimg{ background-image:url('../../Images/Public/list_tit.png'); color:White;  height:24px; font-weight:bold; text-align:center;}
       .clstitleimg:hover{ color:Black;}
       .topbtnimg{width:0px;height:0px;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold;width:100px;}
       .buttonStyle{ background:url('../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
       .clsfilehide{ display:none;}
       .clsbtntxt{ width:80px; 
                   height:20px; 
                   line-height:20px;
                   cursor:pointer;
                   float:right;
                   background:url('../../Images/Public/btn.png');
                   margin-right:5px;
                   text-align:center;              
                   border:1px solid #4CB0D5;}
       
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script> 
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


            //全选或全部选
            $("#btnchkdel").click(function () {
                if ($(".clschkb :checkbox").length == $(".clschkb :checked").length) {
                    $(".clschkb :checkbox").removeAttr("checked");
                }
                else {
                    $(".clschkb :checkbox").attr("checked", "checked");
                }
            })

            //删除选中数据项
            $("#btnalldel").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中删除项');
                }
                else {
                    if (confirm('确定删除选中项')) {
                        $("#imgdel").click();
                    }
                }
            })

            //取消提醒
            $("#btnread").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中任何项');
                }
                else {
                    if (confirm('确定对选中项取消提醒')) {
                        $("#imgread").click();
                    }
                }
            })




        })
    </script>



    <script type="text/javascript">
        
        window.onunload = function () {
            window.returnValue = window.document.getElementById("hidcycle").value;
        }
       
    </script>
</head>
<body>
  <form id="form1" runat="server">
   <input type="hidden" id="hidcycle" runat="server" />
   <div class="clstop">
       <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
         <table style=" width:100%;">
           <tr>
             <td class="toptitletxt">消息提醒</td>
           </tr>
         </table>   
       </div>
       <div style=" background:#4CB0D5; height:5px;"></div>    
    </div>
    <div class="clsbottom">          
      <table class="clsdata" cellspacing="1" cellpadding="0">
        <thead> 
          <tr>
           <td class="clstitleimg" style=" width:40px;"></td>
           <td class="clstitleimg" style=" width:100px;">发送方    </td>
           <td class="clstitleimg" style=" width:120px;">接收时间  </td>
           <td class="clstitleimg" style=" width:100px;">分类      </td>
           <td class="clstitleimg">内容      </td>
           <td class="clstitleimg" style=" width:60px;">操作 </td>
          </tr>
         </thead>
         <tbody>
            <asp:Repeater ID="rptinformation" runat="server" onitemcommand="rptinformation_ItemCommand">        
              <ItemTemplate>
                  <tr>
                    <td><asp:CheckBox  CssClass="clschkb" runat="server" /> </td>
                    <td> <%# Eval("cname") %>           </td>
                    <td> <%# Eval("sendtime") %>        </td>
                    <td> <%# Eval("txt").ToString()%>   </td>
                    <td style="text-align:left;"> <%# CommonlyUsed.Conversion.StrConversion(Eval("contents").ToString()) %> </td>            
                    <td>
                      <asp:ImageButton  runat="server" title="取消提醒,阅读状态更改为已读" CommandName="remind" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/Public/fprojects.png" />              
                      <asp:ImageButton  runat="server" title="删除" OnClientClick=" return confirm('确定删除');" CommandName="del" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/Public/delete.gif" />                 
                    </td>
                  </tr>
                </ItemTemplate>
              </asp:Repeater>
            </tbody>
            <tfoot>
              <tr>
                <td colspan="8" style=" text-align:right;">
                  <div id="btnread"   class="clsbtntxt">取消提醒</div>
                  <div id="btnalldel" class="clsbtntxt">删除选中项</div>
                  <div id="btnchkdel" class="clsbtntxt" title="全部选中时点击将取消所有选中项">全选/全不选</div>
                </td>
              </tr>
            </tfoot>
        </table>
      <div id="pages" runat="server"></div>
    </div> 

    <!-- 功能按钮隐藏区-->
    <div>
      <asp:ImageButton runat="server" ID="imgdel" Width="0" Height="0" ImageUrl="~/Images/Public/btn.png"  onclick="imgdel_Click" /> 
      <asp:ImageButton runat="server" ID="imgread" Width="0" Height="0" ImageUrl="~/Images/Public/btn.png"  onclick="imgread_Click" />      
    </div>

  </form>
</body>
</html>
