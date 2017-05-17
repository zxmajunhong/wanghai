<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementAddFirm.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementAddFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增公司公告</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
      .clsdata{ width:100%;border:1px solid #CDC9C9;}
      .clsdata tr td{ height:24px;}
      .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsdatalist{ width:200px;}
      .clsmtxt{  width:200px; border:0; border-bottom:1px solid #C6E2FF; display:inline-block;}
      .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
      img{border:0; cursor:pointer;}
      .datebox{ border:0;}
      .combo-text{width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsauditpic{border:1px solid #63B8FF;}
      #showpicture{border:1px solid #C6E2FF;width:200px; text-align:center;}
      #showpicture img{ max-width:80px; max-height:80px;}
      #tmimg,#tmseal{ border:1px solid #CDC9C9;}
      .ke-icon-insertimg {
         background-image: url('../../Images/public/insertimg.gif') !important;
         width:16px;
         height: 16px;
       }
    .buttonStyle{ background:url('../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
    .imgbtnstyle{ background:url('../../Images/Common/buticon.gif'); 
                    height:22px;
                    width:64px;               
                    float:right; 
                    margin-right:5px;
                    text-align:center;
                    line-height:22px;
                    cursor:pointer;
                    border:0; 
                    display:inline-block;
                }
                  
                   
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../kindeditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            var objframe = {
                "name": ""
            }


            KindEditor.lang({
                insertimg: '插入图片'
            });


            var editoption = {
                items: ['undo', 'redo', '|', 'preview', 'cut', 'copy', 'paste',
                         'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                         'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                         'superscript', 'clearhtml', 'selectall', '/',
                         'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                         'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|',
                         'hr', 'insertimg', 'pagebreak', 'link', 'unlink', 'table'],
                fullscreenShortcut: true,
                allowImageUpload: false,
                allowFileManager: false
            }



            //插入图片
            KindEditor.plugin('insertimg', function (K) {
                var editor = this, name = 'insertimg';
                // 点击图标时执行
                editor.clickToolbar(name, function () {
                    objframe.name = "obj" + (new Date().getTime());
                    var str = "<iframe id='imgshow' name='" + objframe.name + "' frameborder='0' src='../Picture/PictureSearch.aspx'";
                    // var str = "<iframe id='imgshow' name='imgshow' frameborder='0' src='../Picture/PictureSearch.aspx'";
                    str += " style='width:100%; height:340px;' ></iframe>";
                    $("#tmimg").append(str);
                    $("#shareimg").show();
                    $("#shareimg").dialog({
                        width: 400,
                        height: 410,
                        resizable: false,
                        closable: false,
                        title: "插入图片",
                        modal: true
                    });
                });
            });


            //确定插入图片
            $("#btnimgs").click(function () {
                var strpath = window.frames[objframe.name].document.getElementById("hidimgpath").value;
                // var strpath = window.frames["imgshow"].document.getElementById("hidimgpath").value;
                if (strpath != "") {
                    strpath = '<img src="' + strpath.substring(3) + '" />';
                    editor.insertHtml(strpath);
                }
                $("#tmimg").html("");
                $("#shareimg").dialog("close");
            })


            //取消插入图片
            $("#btnimgc").click(function () {
                $("#tmimg").html("");
                $("#shareimg").dialog("close");
            })

            var editor = KindEditor.create('#tracontent', editoption);
            editor.html($("#hidtxt").val());




            //选部门
            $("#imgcarboncopy,#iptcarboncopy").click(seldepart);
            function seldepart() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 355;
                diag.Title = "选部门";
                diag.URL = "../SysSet/SearchDepart.aspx?dlist=" + $("#hidcarboncopy").val();
                diag.OKEvent = function () {
                    $("#hidcarboncopy").val(diag.innerFrame.contentWindow.document.getElementById('hidseldepart').value);
                    $("#iptcarboncopy").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtdepart').value);
                    diag.close();
                };
                diag.show();
            }



            //选公章
            $("#imgseal,#iptimgseal").click(function () {
                objframe.name = "obj" + (new Date().getTime());
                var str = "<iframe id='imgshow' name='" + objframe.name + "' frameborder='0' src='../Picture/PictureSearch.aspx'";
                // var str = "<iframe id='imgshow' name='imgshow' frameborder='0' src='../Picture/PictureSearch.aspx'";

                str += " style='width:100%; height:340px;' ></iframe>";
                $("#tmseal").append(str);
                $("#tsealimg").show();
                $("#tsealimg").dialog({
                    width: 400,
                    height: 410,
                    resizable: false,
                    closable: false,
                    title: "选择公章图片",
                    modal: true
                });
            })




            //确定插入公章图片
            $("#seals").click(function () {
                var str = window.frames[objframe.name].document.getElementById("iptcname").value;
                var strpath = window.frames[objframe.name].document.getElementById("hidimgpath").value;
                var strid = window.frames[objframe.name].document.getElementById("hidimgid").value;

                // var str = window.frames["imgshow"].document.getElementById("iptcname").value;
                // var strpath = window.frames["imgshow"].document.getElementById("hidimgpath").value;
                // var strid = window.frames["imgshow"].document.getElementById("hidimgid").value;

                if (strpath != "" && str != "" && strid != "") {

                    strpath = strpath.substring(3);
                    $("#showpicture").parent("td").parent("tr").show();
                    $("#showpicture img").remove();
                    $("<img src='" + strpath + "' />").appendTo($("#showpicture"))
                    $("#hidimgseal").val(strid);
                    $("#iptimgseal").val(str);

                }
                else {
                    $("#showpicture").parent("td").parent("tr").hide();
                    $("#showpicrure").html("");
                    $("#hidimgseal").val("");
                    $("#iptimgseal").val("");
                }
                $("#tmseal").html("");
                $("#tsealimg").dialog("close");

            })


            //取消插入公章图片
            $("#sealc").click(function () {
                $("#tmseal").html("");
                $("#tsealimg").dialog("close");
            })


            //显示审核规则
            $("#ddlrule").change(function () {
                $.get("../Job/JobFlowHandler.ashx", { sort: 1, flag: $("#ddlrule").val() }, function (data) {
                    $("#auditpic").html(data);
                    $("#auditpic div").each(function () {
                        var vpath = $(this).css("background-image");
                        if (vpath.lastIndexOf('.') != -1) {
                            var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                            $(this).css({ "background-image": str });
                        }
                    })
                });
            })


            //设定开始时间
            $("#iptstart").datebox({ onSelect: function () {
                $("#iptstart").val($("#iptstart").datebox("getValue"))
            }
            });


            //点击时间文本框展开时间面板
            $(".combo-text").click(function () {
                $(".combo-arrow").click();
            });



            $("#imgbtnsave,#imgbtnaudit").click(function () {
                var str = "";
                var rg = /[<,>]/;
                var digit = /^[1-9][0-9]*$/;

                if ($.trim($("#ipttitle").val()) == "") {
                    str += "公告标题不能为空\n";
                    $("#ipttitle").val("");
                }
                if (rg.test($("#ipttitle").val())) {
                    str += "公告标题不能包含括号中的字符（<,>）\n";
                }
                if ($("#ddlfirm").val() == "-1") {
                    str += "所属公司不能为空\n";
                }
                if ($.trim($("#iptorder").val()) == "") {
                    str += "公告序号不能为空\n"
                    $("#iptorder").val("");
                }
                if ($.trim($("#iptword").val()) == "") {
                    str += "主题词不能为空\n";
                    $("#iptword").val("");
                }
                if (rg.test($("#iptword").val())) {
                    str += "主题词不能包含括号中的字符（<,>）\n";
                }
                if ($("#iptstart").val() == "") { 
                    str += "开始时间不能为空\n"
                }
                if ($.trim($("#iptperiod").val()) == "" || !digit.test($("#iptperiod").val())) {
                    str += "有效期限不为空,且应该为数字\n"
                    $("#iptperiod").val("");
                }
                if ($("#hidcarboncopy").val() == "") {
                    str += "抄送部门不能为空\n";
                }
                if ($("#hidimgseal").val() == "") {
                    str += "公章不能为空\n"
                }
                if ($("#ddlrule").val() == "-1" || $("#auditpic").html() == "") {
                    str += "请选审批流程\n"
                }
                if (str) {
                    alert(str);
                    return false;
                }
                else {
                    $("#hidtxt").val(window.encodeURI(editor.html()));
                    return true;
                }
            })


            //返回
            $("#imgbtnback").click(function () {
                $("#hidtxt").val("");
            })


            //动态新增文件上传控件
            var num = 1;
            $("#imgadd").click(function () {
                var str = '<tr><td><input type="file" name="addfile" /></td>'
                str += '<td><img class="imgdel" alt="删除附件" src="../../Images/public/delete.gif" /></td></tr>'
                if (num == 5) {
                    alert('最多上传五个文件');
                }
                else {
                    $("#addfile").append(str);
                    num++;
                }
            })



            //删除新增的上传控件
            $(".imgdel").live("click", function () {
                $(this).parent().parent().remove();
                num--;

            });



        })
    </script>

</head>
<body>
  <form id="form1" runat="server">
     <div class="clstop">
       <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <table style=" width:100%; height:100%;">
            <tr>
              <td class="toptitletxt">新增公司公告</td>                
            </tr>
          </table>
       </div>
       <div style=" background:#4CB0D5; height:5px;"></div>
     </div>
     <div class="clsbottom">
       <div style="text-align:right;">
          <asp:ImageButton runat="server" ID="imgbtnsave"  
               ImageUrl="~/Images/Button/btn_save.jpg" onclick="imgbtnsave_Click"  />
          <asp:ImageButton runat="server" ID="imgbtnaudit" 
               ImageUrl="~/Images/Button/btn_audisend.jpg" onclick="imgbtnaudit_Click" />
          <asp:ImageButton runat="server" ID="imgbtnback"  
               ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click"  />          
       </div>
       <table class="clsdata">
        
         <tr>
           <td style=" width:80px;">公告标题:</td>
           <td>
             <input type="text" runat="server" id="ipttitle" class="clsunderline" />
             <span style="color:Red;">*</span>
           </td>
           <td style="width:80px;">所属公司:</td>
           <td>
            <asp:DropDownList runat="server" ID="ddlfirm" CssClass="clsdatalist"></asp:DropDownList> 
            <span style="color:Red;">*</span>
           </td>
         </tr>

         <tr>
          <td  style=" width:80px;">主题词语:</td>
          <td> 
             <input type="text" runat="server" id="iptword" class="clsunderline" />
             <span style="color:Red;">*</span>
          </td>
          <td style=" width:80px;">公告序号:</td>
          <td> 
             <input type="text" runat="server" id="iptorder" class="clsunderline" />
             <span style="color:Red;">*</span>
          </td>    
         </tr>
                 
         <tr>
           <td>开始时间:</td>
           <td>
             <input type="text" id="iptstart" runat="server" class="clsunderline" />
             <span style="color:Red;">*</span>
           </td>
           <td>有效期限:</td>
           <td>
             <input type="text" id="iptperiod" runat="server" class="clsunderline" />(天数)
             <span style="color:Red;">*</span>
           </td>
         </tr>

         <tr>
          <td>抄送部门:</td>
          <td>
           <input type="text" runat="server" id="iptcarboncopy" class="clsunderline" />
           <input type="hidden" runat="server" id="hidcarboncopy" />
           <img id="imgcarboncopy" title="选取抄送部门" src="../../Images/Public/group.gif"  alt="选取部门" />
           <span style="color:Red;">*</span>
          </td>
          <td>选择公章:</td>
          <td>
            <input type="text" runat="server" id="iptimgseal" class="clsunderline" />
            <input type="hidden"  runat="server" id="hidimgseal" />
            <img id="imgseal" style=" margin-bottom:-5px;" title="选取公章" src="../../Images/Public/picture.png"  alt="选取公章" />
            <span style="color:Red;">(建议尺寸大小170 x 170像素)*</span>     
          </td>
         </tr>

         <tr style="display:none;">
           <td colspan="3"></td>
           <td>
             <div id="showpicture"></div>
           </td>
         </tr>
         <tr>
          <td colspan="4">公告内容:</td>
         </tr>
         <tr>
          <td colspan="4">
             <textarea  id="tracontent"  style="width:100%; height:400px;"></textarea>
              <input type="hidden" runat="server" id="hidtxt" />
          </td>
         </tr>
         <tr>
           <td>附件上传:</td>
           <td colspan="3">
             <table id="addfile">
               <tr>
                 <td><asp:FileUpload runat="server" ID="fpattachment" /></td>
                 <td><img id="imgadd" alt="新增附件" src="../../Images/Public/fileadd.gif"  /></td>    
                </tr>
             </table>
           </td>
          </tr>

         <tr>
          <td>拟稿人员:</td>
          <td>
           <input id="iptcreater" type="text" runat="server"  class="clsunderline" />
          </td>
          <td>印发日期:</td>
          <td>
           <input id="iptprintime" type="text" runat="server"  class="clsunderline" />
          </td>   
         </tr>


         <tr>
           <td>审批流程:</td>
           <td colspan="3">
              <asp:DropDownList ID="ddlrule" runat="server" CssClass="clsdatalist"></asp:DropDownList>        
           </td>
         </tr>
         <tr>
           <td colspan="4">
             <div id="auditpic" class="clsauditpic" runat="server"></div>
           </td>
         </tr>      
       </table>
     </div>

     <!-- 选图片 -->
     <div id="shareimg" style="display:none;">
      <div id="tmimg"></div>
      <div style=" text-align:right;padding-top:5px;">
        <span id="btnimgc" class="imgbtnstyle">取消</span>
            <span id="btnimgs" class="imgbtnstyle">确定</span>  
      </div>
     </div>

     <!-- 选公章 -->
     <div id="tsealimg" style="display:none;">
      <div id="tmseal"></div>
      <div style=" text-align:right;padding-top:5px;">
        <span id="sealc" class="imgbtnstyle">取消</span>
            <span id="seals" class="imgbtnstyle">确定</span>  
      </div>
     </div>


  </form>
</body>
</html>
