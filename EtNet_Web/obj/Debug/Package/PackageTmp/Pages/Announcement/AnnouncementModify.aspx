<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementModify.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改部门公告</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
      .clsdata{ width:100%;border:1px solid #CDC9C9;}
      .clsdata tr td{ height:24px;}
      .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsdatalist{ width:200px;}
      .clsmtxt{  width:200px; border:0; border-bottom:1px solid #C6E2FF; display:inline-block;}
      .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
      .clstitleimg{ background-image:url('../../Images/public/list_tit.png');color:White; height:24px; font-weight:bold; text-align:center;}
      .clstitleimg:hover{ color:White;}    
      #originalfile{background-color:#E3E3E3;}
      #originalfile tr td{background-color:#F0F8FF;  height:20px; }   
      .clsfiledel{ background-image:url('../../Images/public/delete.gif');width:16px; height:16px;background-repeat:no-repeat;cursor:pointer;}
      img{border:0; cursor:pointer;}
      .datebox{ border:0;}
      .combo-text{width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      #tmimg{ border:1px solid #CDC9C9;}
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
                    var str = "<iframe id='imgshow' name='imgshow' frameborder='0' src='../Picture/PictureSearch.aspx'";
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
                var strpath = window.frames["imgshow"].document.getElementById("hidimgpath").value;
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

            //设定开始时间
            $("#iptstart").datebox({ onSelect: function () {
                $("#iptstart").val($("#iptstart").datebox("getValue"))
            }
            });

            //点击时间文本框展开时间面板
            $(".combo-text").click(function () {
                $(".combo-arrow").click();
            });




            //选部门
            $("#imgdepart").click(seldepart);
            function seldepart() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 355;
                diag.Title = "选部门";
                diag.URL = "../SysSet/SearchDepart.aspx?dlist=" + $("#hiddepartlist").val();
                diag.OKEvent = function () {
                    $("#hiddepartlist").val(diag.innerFrame.contentWindow.document.getElementById('hidseldepart').value);
                    $("#iptdepartlist").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtdepart').value);                   
                    diag.close();
                };
                diag.show();
            }

            $("#iptdepartlist").click(function () {
                seldepart();
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

            //删除附件
            $(".clsfiledel").live("click", function () {
                if (confirm('确定删除!')) {
                    var fid = $(this).attr("id").substring(2);
                    $.get("AnnouncementHandler.ashx", { sort: 1, fileid: fid }, function (data) {
                        var result = data.split('_');
                        if (result[1] == 1) {
                            alert(result[0])
                            $("#fd" + fid).parent("td").parent("tr").remove()
                        }
                        else {
                            alert(result[0])
                        }
                    });
                }
            })





            //保存修改
            $("#imgbtnsave").click(function () {
                var str = "";
                var rg = /[<,>]/;
                var digit = /^[1-9][0-9]*$/;
                if ($.trim($("#ipttitle").val()) == "") {
                    str = "公告标题不能为空\n";
                    $("#ipttitle").val("");
                }
                if (rg.test($("#ipttitle").val())) {
                    str = "公告标题不能包含括号中的字符（<,>）\n";
                }
                if ($("#ddlstatus option:selected").val() == "-1") {
                    str += "请选公告状态\n";
                }
                if ($("#ddlsort option:selected").val() == "-1") {
                    str += "请选公告分类\n";
                }
                if ($("#hiddepartlist").val() == "") {
                    str += "请选中部门\n";
                }
                if ($.trim($("#iptperiod").val()) == "" || !digit.test($("#iptperiod").val())) {
                    str += "有效期限不为空,且应该为数字"
                    $("#iptperiod").val("");
                }
                if (str != "") {
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

        })
    </script>
</head>
<body>
   <form id="form1" runat="server">
     <div class="clstop">
       <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <table style=" width:100%; height:100%;">
            <tr>
              <td class="toptitletxt">修改部门公告</td>
            </tr>
          </table>
       </div>
       <div style=" background:#4CB0D5; height:5px;"></div>
     </div>
     <div class="clsbottom">
        <div style="text-align:right;">
          <asp:ImageButton runat="server" ID="imgbtnsave" 
                ImageUrl="~/Images/Button/btn_save.jpg" onclick="imgbtnsave_Click"  />
          <asp:ImageButton runat="server" ID="imgbtnback" 
                ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click" />
        </div>
        <table class="clsdata">
          <tr>
           <td style="width:80px;">公告标题:</td>
           <td>
             <input type="text" runat="server" id="ipttitle" class="clsunderline" />
             <span style="color:Red;">*</span>
           </td>
           <td style="width:80px;">公告状态:</td>
           <td>
            <asp:DropDownList runat="server" ID="ddlstatus" CssClass="clsdatalist"></asp:DropDownList>
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
           <td>选取部门:</td>
           <td colspan="3">
            <input type="text" runat="server" id="iptdepartlist" class="clsunderline" />
            <img id="imgdepart" title="选取部门" src="../../Images/Public/group.gif"  alt="选取部门" />
            <span id="showdepart" style="color:Red;">*</span>
            <input type="hidden" runat="server" id="hiddepartlist" />
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
           <td colspan="4">原有附件:</td>
          </tr>
          <tr>
           <td colspan="4">
             <table id="originalfile" runat="server" cellpadding="0" cellspacing="1">
                <tr>
                 <td class="clstitleimg" style=" width:20px;"></td>
                 <td class="clstitleimg" style=" width:400px;">名称</td>
                 <td class="clstitleimg" style=" width:40px;" align="center">删除</td>
                </tr>
              </table>
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
           <td>创建人员:</td>
           <td><asp:Label runat="server" ID="lblcreater" CssClass="clsmtxt"></asp:Label></td>
           <td>创建时间:</td>
           <td><asp:Label runat="server" ID="lbldatetime" CssClass="clsmtxt"></asp:Label></td>
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

  </form>
</body>
</html>
