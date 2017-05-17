UpdateNotice = ({

    init: function () {


     $(function () {
            var dates = $("#iptbegintime, #iptendtime").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 2,
                showAnim: "clip",
                dateFormat: 'yy-mm-dd',
                showButtonPanel: true, //是否显示按钮面板  
                closeText: "关闭", //关闭选择框的按钮名称 
                currentText: "今天",
                onSelect: function (selectedDate) {
                    var option = this.id == "iptbegintime" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);

                }
            });

     $.datepicker.setDefaults($.datepicker.regional['zh-CN']);



    $("#btnlook").click(function () {
        var str = $("#iptaccesfile").val();
        $("#divaccesfile").text(str);
        $("#divaccesfile").dialog({ title: "原有附件路径", modal: false });

    });

    //有对话框打开的话，关闭该对话框
    $("#btnfix").mouseenter(function () {
        $("#divaccesfile").dialog("close");

    });

    //判断数据是否为空或选中项是否无效
    $("#btnfix").click(function () {
        var value;
        var str = "";
        value = $("#selifpublic").val();
        if (value == "-1") {
            str += "* 公告范围未选" + "<br/>";
        }

        value = $("#selattr").val();
        if (value == "-1") {
            str += "* 属性未选" + "<br/>";
        }

        value = $("#selsort").val();
        if (value == "-1") {
            str += "* 分类未选" + "<br/>";
        }

        value = $("#ipthead").val();
        if (value.length == 0) {
            str += "* 公告标题不能为空" + "<br/>";
        }

        value = $("#iptbegintime").val();
        if (value.length == 0) {
            str += "* 发布时间不能为空" + "<br/>";
        }

        value = $("#iptendtime").val();
        if (value.length == 0) {
            str += "* 结束时间不能为空" + "<br/>";
        }

        if (str.length != 0) {
            $("#divaccesfile").html(str);
            $("#divaccesfile").dialog({ title: "错误提示", modal: true });
            return false;
        }
        else {
            return true;
        }

    });

    }

});