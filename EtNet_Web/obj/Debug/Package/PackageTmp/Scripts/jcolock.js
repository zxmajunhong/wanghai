;
(function ($) {

    $.extend($.fn, {
        colock: function (options) {
            var option = { day: ['星期七', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'] };
            option = $.extend(option, options);
            var clock = this;
            clock.append("<div class='clock_top'></div><div class='clock_bottom'></div>" + "<br/>");


            window.setInterval(function () {
                var dtime = new Date();
                $(".clock_top").html(dtime.getFullYear() + "年" + (dtime.getMonth() + 1) + "月" + dtime.getDate() + "号" + option.day[dtime.getDay()]);
                $(".clock_bottom").html(dtime.toLocaleTimeString("HH:mm:ss"));

            }, 1000);
        }

    });
})(jQuery)