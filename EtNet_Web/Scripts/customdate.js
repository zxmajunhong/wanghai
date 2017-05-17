;
function cdate(opt) {
    var defopt = {
        showid: "#" + opt.sid, //显示时间容器的id值，用span控件
        saveid: "#" + opt.hid  //保存时间容器的id值,用隐藏域控件

    };


    if ($("body").length == 1 || $(defopt.showid).length == 1) {
        var $box = $("body");
        var strbox = "<div id='wdt'><table><tr><td>开始时间:</td>";
        strbox += "<td><input type='text' id='showstime' /></td><td>结束时间:</td>";
        strbox += "<td><input type='text' id='showetime' /></td></tr>";
        strbox += "<tr><td colspan='4' align='right'>";
        strbox += "<input type='button' class='buttonStyle' id='btnsure' value='确定' style='margin-right:5px;' />";
        strbox += "<input type='button' class='buttonStyle' id='btncanel' value='取消' />";
        strbox += " </td></tr></table></div>";
        $box.append(strbox);

        $("#showstime").datebox();
        $("#showetime").datebox();

        //验证输入时间
        function datetest(sd, ed) {
            var rpast = "";
            if (sd != "" && ed != "") {
                if (sd > ed) {
                    rpast += "开始时间大于结束时间\n";
                }
            }
            if (sd == "" && ed == "") {
                rpast += "未选中时间\n"
            }
            return rpast;
        }

        $("#btnsure").live("click", function () {
            var dts = $("#showstime").datebox("getValue");
            var dte = $("#showetime").datebox("getValue");
            var rt = datetest(dts, dte);
            if (rt == "") {
                var savestr = "指定时间范围为:" + dts + "—" + dte;
                $(defopt.showid).text(savestr);
                savestr = dts + "," + dte;
                $(defopt.saveid).val(savestr);
                $('#wdt').window("destroy");

            }
            else {
                alert("时间选择有误\n原因可能是:" + rt);
                $('#wdt').window("destroy");
            }
        });

        $("#btncanel").live("click", function () {
            $('#wdt').window("destroy");

        })

        $('#wdt').window({
            title: '时间段范围选择',
            width: 540,
            height: 90,
            resizable: false,
            maximizable: false,
            minimizable: false,
            collapsible: false,
            closable: false,
            modal: true
        });
    }
    else {
        alert('时间对话框打开失败!')
    }
}



