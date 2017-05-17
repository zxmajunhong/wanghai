<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="EtNet_Web.Pages.Index.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>主页内容</title>
    <link href="../../CSS/common.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .portlet
        {
            margin: 0 4px 4px 0;
            background-image: url("../../Images/index/9_5.png");
            border: 2px solid #ECEDEF;
        }
        .portlet-header
        {
            /*margin: 0.3em; */
            padding-bottom: 4px;
            padding-left: 0.2em;
            font-size: 12px;
            height: 20px; /* background-image:url("../../Images/9_2.png"); */
            background-image: url("../../Images/index/9_21.png");
        }
        .portlet-header .ui-icon
        {
            float: right;
        }
        .portlet-header .ui-icon-del
        {
            float: right;
            background-image: url("../../Images/index/Panel_close.png");
            width: 14px;
            height: 15px;
            margin: 4px;
        }
        .portlet-header .ui-icon-collapse
        {
            float: right;
            background-image: url("../../Images/index/Panel_updown.png");
            width: 14px;
            height: 14px;
            margin: 4px;
        }
        .portlet-header .ui-icon-expand
        {
            float: right;
            background-image: url("../../Images/index/Panel_updown.png");
            width: 14px;
            height: 14px;
            margin: 4px;
        }
        .portlet-header .ui-icon-edit
        {
            float: right;
            background-image: url("../../Images/index/Panel_edit.png");
            width: 13px;
            height: 14px;
            margin: 4px;
        }
        .portlet-header .ui-icon-refresh
        {
            float: right;
            background-image: url("../../Images/index/Panel_refresh.png");
            width: 14px;
            height: 14px;
            margin: 4px;
        }
        .portlet-header .portlet-header-title
        {
            float: left;
            position: relative;
            top: 5px;
        }
        .portlet-header span#modifytil
        {
            float: left;
        }
        .portlet-content
        {
            padding: 0.4em;
            font-size: 12px;
            background-image: url("../../Images/9_5.png");
        }
        .ui-sortable-placeholder
        {
            border: 1px dotted black;
            visibility: visible !important;
            height: 50px !important;
        }
        .ui-sortable-placeholder *
        {
            visibility: hidden;
        }
        
        .column
        {
            padding-bottom: 20px;
            padding-left: 2px;
        }
        
        body
        {
            position: absolute;
            top: 0px;
            left: 0px;
            margin: 0px;
            height: 100%;
            width: 100%;
            background-image: url(../../Images/page_bg.gif);
            background-repeat: repeat;
        }
        #menutop
        {
            width: 100%;
            position: absolute;
            left: 0px;
            top: 0px;
            border-bottom: 1px solid #A4D3EE;
            background-image: url("../../images/toolbar.png");
            background-repeat: repeat-x;
            height: 25px;
        }
        
        #menutop input, #menutop img
        {
            margin: 5px;
        }
        #menutop #imgbtnsign
        {
            width: 13px;
            height: 13px;
        }
        
        #menucontent
        {
            width: 100%;
            position: absolute;
            left: 0px;
            top: 35px;
        }
        
        .covertshow
        {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 1000;
            background-color: #F8FBF9;
        }
        
        #box ul
        {
            width: 100%;
            list-style-type: none;
        }
        #box ul li
        {
            padding-left: 5px;
            padding-right: 5px;
            margin-bottom: 2px;
        }
        #box ul li span
        {
            font-size: 13px;
            font-weight: bold;
            margin-left: 8px;
            margin-right: 2px;
        }
        #box ul li img
        {
            width: 12px;
            height: 12px;
        }
        img
        {
            cursor: pointer;
            border-width: 0px;
        }
        a
        {
            text-decoration: none;
        }
        
        ul.panelul
        {
            list-style-type: none;
        }
        
        ul.panelul li
        {
            padding: 2px;
            background-image: url("../../images/panel_list.png");
        }
        
        ul.panelul li .imglistarrow
        {
            margin-right: 5px;
            margin-left: 10px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jNotify.jquery.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jcolock.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

        
            //加载菜单面板的数据列表
            $(window).load(function () {

                $("#cover").css({ opacity: "0.5" }).css("style", "").addClass("covertshow").show();
                $("#cover").children("img").offset({ top: $(window).height() / 2, left: $(window).width() / 2 });

                $(".portlet").each(function () {
                    var contents = this;
                    $.get("WelcomeHandler.ashx", { mark: "1", direction: $(this).children("div:last").attr("id"), newdate: new Date().toString() },
                     function (data) {
                         $(contents).children().eq(1).html(data);

                     });

                });

                setTimeout(function () { $("#cover").removeClass().hide() }, 500);
            });


            //隐藏遮住层
            $("#cover").hide();
            $(".column").sortable({
                connectWith: ".column",
                delay: 500,
                opacity: 0.8,
                cursor: "pointer",

                stop: function (event, ui) {
                    var str = "";
                    $(".portlet").each(function () {
                        str += $(this).attr("id") + "_";  //用于修改指定的数据
                        str += $(this).parent(".column").attr("id") + "_";  //所属列
                        str += $(this).prevAll(".portlet").length + 1;  //所属行
                        str += ",";

                    });

                    
                    $.ajax("WelcomeHandler.ashx", {
                        data: { mark: "2", datalist: str },
                        type: "GET",
                        context: $("#cover")[0],
                        beforeSend: function () {

                            $(this).css({ opacity: "0.5" }).css("style", "").addClass("covertshow").show();
                            $(this).children("img").offset({ top: $(window).height() / 2, left: $(window).width() / 2 });

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(errorThrown);
                            setTimeout(function () { $("#cover").removeClass().hide() }, 500);
                        },

                        success: function (data, textStatus) {
                            setTimeout(function () { $("#cover").removeClass().hide() }, 500);
                        }

                    });

                }

            });


            $(".portlet").addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all")
			.find(".portlet-header")
				.addClass("ui-widget-header ui-corner-all")
				.prepend("<span class='ui-icon-del'></span><span class='ui-icon ui-icon-expand'></span><span class='ui-icon-edit'></span><span class='ui-icon-refresh'></span>")
				.end()
			.find(".portlet-content");

            $(".column").disableSelection();

            //展开与隐藏菜单面板
            $(".portlet-header .ui-icon").live("click", function () {
                $(this).toggleClass("ui-icon-expand").toggleClass("ui-icon-collapse");
                $(this).parents(".portlet:first").find(".portlet-content").toggle();
            });


            //删除菜单面板
            $(".portlet-header .ui-icon-del").live("click", function () {
                var str = "";
                str = $(this).parent().parent("div.portlet").attr("id");

                $.ajax("WelcomeHandler.ashx", {
                    data: { mark: "5", menuid: str },
                    type: "GET",
                    context: $(this).parent().parent("div.portlet"),
                    beforeSend: function () {

                        $("#cover").css({ opacity: "0.5" }).css("style", "").addClass("covertshow").show();
                        $("#cover").children("img").offset({ top: $(window).height() / 2, left: $(window).width() / 2 });

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                        setTimeout(function () { $("#cover").removeClass().hide() }, 500);
                    },

                    success: function (data, textStatus) {
                        $(this).remove();
                        setTimeout(function () { $("#cover").removeClass().hide() }, 500);
                    }

                });

            });

            //刷新数据
            $(".portlet-header .ui-icon-refresh").live("click", function () {
                var str = "";
                str = $(this).parent().siblings("div.portlet-content").attr("id");

                if (str.substring(7) == "4") {
                    return;
                }
                $.ajax("WelcomeHandler.ashx", {
                    data: { mark: "6", id: str, date: new Date().toString() },
                    type: "GET",
                    context: $(this).parent().siblings("div.portlet-content"),
                    beforeSend: function () {
                        $(this).html("").append("<img src='../../Images/loading.gif' alt='加载' />");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);

                    },
                    success: function (data, textStatus) {

                        $(this).html(data);
                    }

                });

            })

            //加载菜单列表
            $("#imgbtnaddmenu").click(function () {
                $("#box").html("");
                $("#box").dialog({
                    modal: true,
                    title: "添加",
                    resizable: false,
                    width: "150px"
                });

                $.ajax("WelcomeHandler.ashx", {
                    data: { mark: "3" },
                    type: "GET",
                    context: $("#box")[0],
                    beforeSend: function () {

                        $(this).css({ background: "#F8FBF9" }).append("<img src='../../Images/loading.gif' alt='加载' />");

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);

                    },
                    success: function (data, textStatus) {
                        $(this).html(data);
                    }

                });

            })




            //新加菜单面板
            $(".addmenu").live("click", function () {
                $("#box").dialog("close");
                var addm = $(this);
                var straddmenu = "";
                $(".portlet-content").each(function () {

                    if ($(this).attr("id").substring(7) == addm.attr("alt")) {
                        straddmenu = "该菜单已存在";
                    }
                });

                if (straddmenu != "") {
                    jNotify(straddmenu, {
                        HorizontalPosition: 'center',
                        VerticalPosition: 'center'
                    });
                    return;
                }

                $.ajax("WelcomeHandler.ashx", {
                    data: { mark: "4", id: $(this).attr("alt") },
                    type: "GET",
                    context: $("#cover")[0],
                    beforeSend: function () {

                        $(this).css({ opacity: "0.5" }).css("style", "").addClass("covertshow").show();
                        $(this).children("img").offset({ top: $(window).height() / 2, left: $(window).width() / 2 });

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                        setTimeout(function () { $("#cover").removeClass().hide() }, 500);
                    },

                    success: function (data, textStatus) {

                        $("#columnleft").append(data);
                        setTimeout(function () { $("#cover").removeClass().hide() }, 500);
                    }
                });
            })

            //提交标题修改
            $(".portlet-header span#modifytil :nth-child(2)").live("click", function () {

                var str = $(this).parent().parent().parent(".portlet").attr("id");

                str += "," + $(this).siblings("input:text").val();
                $.ajax("WelcomeHandler.ashx", {
                    data: { mark: "7", id: str },
                    type: "GET",
                    context: $(this).parent("#modifytil"),
                    beforeSend: function () {
                        var rg = /[^\u4e00-\u9fa5\w]/g;
                        if (!$(this).children("input:text").val().replace(/\s/g, "")) {

                            return false;
                        }
                        else if ($(this).children("input:text").val() && rg.test($(this).children("input:text").val())) {
                            $(this).children("input").val("");
                            return false;
                        }
                        else {
                            true;
                        }
                    },

                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                        $(this).remove();
                    },

                    success: function (data, textStatus) {

                        $(this).parent().children(".portlet-header-title").text($(this).children("input:text").val());
                        $(this).remove();

                    }

                });


            });

            //取消修改标题
            $(".portlet-header span#modifytil :nth-child(3)").live("click", function () {
                $(this).parent().remove();
            });
            $(".portlet-header span#modifytil :nth-child(1)").live("mouseenter", function () {
                $(this).focus();
            });
            //修改标题
            $(".portlet-header .ui-icon-edit").live("click", function () {

                if (!$(".portlet-header").has("#modifytil").length) {
                    $(this).parent(".portlet-header").append("<span id='modifytil'><input type='text' /><span>提交</span><span>取消</span></span>");
                }
                else {
                    jNotify("已有标题修改栏打开", {
                        HorizontalPosition: 'center',
                        VerticalPosition: 'center'
                    });
                }

            });
            //阻止网页右键菜单
            window.document.oncontextmenu = function () { return false; };

            var sg = window.setInterval(function () {
                if ($("#sign").length) {
                    $("#sign").before("<div id='clock' clsss='clockbox'></div>");
                    $("#clock").colock();
                    //  $("#sign").text("");
                    window.clearInterval(sg);
                }

            }, 1000);
        });  
    </script>
</head>
<body>
    <form runat="server">
    <div id="menutop">
        <asp:ImageButton ID="imgbtnone" ImageUrl="~/Images/index/tool1.png" AlternateText="一栏布局"
            runat="server" OnClick="imgbtnone_Click" />
        <asp:ImageButton ID="imgbtntwo" ImageUrl="~/Images/index/tool2.png" AlternateText="两栏布局"
            runat="server" OnClick="imgbtntwo_Click" />
        <asp:ImageButton ID="imgbtnthree" ImageUrl="~/Images/index/tool3.png" AlternateText="三栏布局"
            runat="server" OnClick="imgbtnthree_Click" />
        <img src="../../Images/index/tool4.png" alt="新增" id="imgbtnaddmenu" />
    </div>
    <div id="menucontent" style="width: 100%;">
        <div id="columnleft" runat="server" class="column">
        </div>
        <div id="columncenter" runat="server" class="column">
        </div>
        <div id="columnright" runat="server" class="column">
        </div>
    </div>
    <span id="cover" style="display: none">
        <img src='../../Images/index/loading.gif' alt='加载' />
    </span>
    <div id="box">
    </div>
    <div id="modify">
    </div>
    </form>
</body>
</html>
