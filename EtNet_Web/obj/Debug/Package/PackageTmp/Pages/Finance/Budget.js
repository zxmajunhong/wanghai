/*
    功能：盈亏测算金额计算
    日期：2012年12月7日15:50:57
*/

$(document).ready(function () {
    //设置样式
    $(".num").each(function () {
        $(this).focus(function () {
            $(this).css('text-align', 'left');
            $(this).val($(this).val().toFixed(2));
        });
        $(this).blur(function () {
            $(this).css('text-align', 'right');
        });
    });
});