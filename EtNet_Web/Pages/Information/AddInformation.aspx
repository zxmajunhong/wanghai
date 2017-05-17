<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInformation.aspx.cs" Inherits="EtNet_Web.Pages.Information.AddInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加消息</title>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; border:1px solid #CDC9C9;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .datebox{ border:0;}
       .combo-text{width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .buttonStyle{ background:url('../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
       #tracontents{ resize:none; border:1px solid #C6E2FF;width:100%; height:100px; font-size:13px;}
    </style>


    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {


            //图片设置手的样式
            $("img").css({ cursor: "pointer" });
            $("img:[alt='删除附件'],img:[alt='新增附件']").live("mouseenter", function () {
                $(this).css({ cursor: "pointer" });
            })

            //动态新增文件上传控件
            var num = 1;
            $("#imgadd").click(function () {
                var str = '<tr><td><input type="file" name="addfile" /></td>'
                str += '<td><img class="imgaddfile" alt="删除附件" src="../../Images/public/delete.gif" /></td></tr>'
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


            //隐藏指定时间的那一行，默认设置
            $("table:not('#addfile') tr:last").hide();

            //点击显示指定时间的显示
            $(":radio:last").click(function () {
                $("table:first tr:last").show();

            })

            //点击隐藏指定时间的显示
            $(":radio:first").click(function () {
                $("#iptdate").datetimebox("setValue", "");
                $("table:first tr:last").hide();
            })


            //显示选人对话框
            function diloginfo() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 356;
                diag.Title = "选人员";
                diag.URL = "../Personnel/SearchPersonnel.aspx?plist=" + $("#ipthidrecipient").val();
                diag.OKEvent = function () {
                    $("#ipthidrecipient").val(diag.innerFrame.contentWindow.document.getElementById('hidselpeople').value);
                    $("#recipient").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtpeople').value);
                    diag.close();
                };
                diag.show();
            }

            //打开消息对话框
            $("#imgaddpeople").click(diloginfo);
            $("#recipient").focus(diloginfo)


            //显示时间
            $("#iptdate").datetimebox();

            //点击提交时判断数据格式
            $("#imgbtnsend").click(function () {
                var strtip = "";
                if ($("#ipthidrecipient").val() == "") {
                    strtip += "至少填写一个收信人!\n";
                }
                if (!$("#tracontents").val() || $("#tracontents").val().replace(/\s/g, "") == "") {
                    strtip += "内容未填写或都是空白字符!\n";
                }
                else if ($("#tracontents").val().length > 100) {
                    strtip += "内容太多!<br/>";
                }
                else
                { }
                if ($("#rbtnright").attr("checked")) {
                    if ($("#iptdate").datetimebox("getValue") == "") {
                        strtip += "日期未填!\n";
                    }
                }
                if (strtip != "") {
                    alert(strtip);
                    return false;
                }
                else {
                    $("#tracontents").val(encodeURIComponent($("#tracontents").val()));
                    return true;
                }
            });



        })
    
    </script>
    
      

</head>
<body style="height:440px;">
   <form id="form1" runat="server">
     <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
           <span style=" color:White; font-size:12px; font-weight:bold; position:relative; top:5px; left:5px;">消息添加</span>
        </div>
        <div style=" background:#4CB0D5; height:5px;"></div>          
     </div>
     <div class="clsbottom">
      <div style=" float:right; padding-bottom:5px;">
        <asp:ImageButton runat="server" ImageUrl="~/Images/Button/btn_submit.jpg" 
                   AlternateText="提交" ID="imgbtnsend" onclick="imgbtnsend_Click" />
      </div>
      <table class="clsdata"> 
        <tr>
          <td style="width:60px;">收信人:</td>
          <td><asp:TextBox runat="server" ID="recipient"  CssClass="clsunderline"></asp:TextBox>   
              <input type="hidden" runat="server" value=""  id="ipthidrecipient"/>
              <img  id="imgaddpeople"  runat="server" src="../../Images/Public/adedit.gif" alt="编辑收信人" />
              <span style="color:Red;">*</span>
          </td>
        </tr>  
        <tr>
          <td colspan="2">内容<span style="color:Red;">*</span></td>
        </tr>
        <tr>
          <td colspan="2" style="padding-right:5px;">
            <textarea id="tracontents"  runat="server"></textarea> 
          </td>
        </tr>
        <tr>
          <td>附件上传:</td>
          <td>
              <div>
                 <table id="addfile">
                    <tr>
                      <td><asp:FileUpload runat="server" ID="fpattachment" /></td>
                      <td><img id="imgadd" alt="新增附件" src="../../Images/public/fileadd.gif"  /></td>    
                    </tr>
                  </table>     
              </div>
           </td>
         </tr>
         <tr>
          <td>发送方式:</td>
          <td>
            <asp:RadioButton Text="立即发送" ID="rbtnleft"  runat="server" GroupName="sendtime"  Checked="true" />
            <asp:RadioButton Text="定时发送" ID="rbtnright" runat="server" GroupName="sendtime" />
          </td>
         </tr>
         <tr>
           <td>指定时间:</td>
           <td><input type="text" id="iptdate" runat="server" /><span style="color:Red">*</span></td>
        </tr>
       </table>
     </div>       
   </form>
</body>
</html>
