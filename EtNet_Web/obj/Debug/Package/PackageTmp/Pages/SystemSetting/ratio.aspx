<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提成比例设置</title>
    <style>
@charset "utf-8";
/*元素初始值*/
html {background: #FFF;}
body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,form,fieldset,p,blockquote,th,td,ins,hr{margin: 0px;padding: 0px;}
p{cursor: text;}
h1,h2,h3,h4,h5,h6{font-size:100%;}
ol,ul{list-style-type: none;}
address,caption,cite,code,dfn,em,th,var{font-style:normal;font-weight:normal;}
table{border-collapse:collapse;}
fieldset,img{border:0;}
img{display:block;}
caption,th{text-align:left;}
body{position: relative;font-size:62.5%;font-family: "宋体"}
a{text-decoration: none;}
/*demo所用元素值*/
#need {margin:0 auto 0;width: auto;}
#need li {height: 26px;width: 500px;font: 12px/26px Arial, Helvetica, sans-serif;background: white;border-bottom: 1px dashed #E0E0E0;display: block;cursor: text;padding: 7px 0px 7px 10px!important;padding: 5px 0px 5px 10px;}
#need li:hover,#need li.hover {background:white;}
#need input {line-height: 14px;background: white;height: 14px;width: 30px;border: 0px solid #E0E0E0;vertical-align: middle;padding: 6px;border-bottom:1px solid #C6E2FF;}
#need label {padding-left: 30px;}
#need label.old_password {background-position: 0 -277px;}
#need label.new_password {background-position: 0 -1576px;}
#need label.rePassword {background-position: 0 -1638px;}
#need label.email {background-position: 0 -429px;}
#need dfn {display: none;}
#need li:hover dfn, #need li.hover dfn {display:inline;margin-left: 7px;color: #676767;}
</style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <link href="default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function suckerfish(type, tag, parentId) {
            if (window.attachEvent) {
                window.attachEvent("onload", function () {
                    var sfEls = (parentId == null) ? document.getElementsByTagName(tag) : document.getElementById(parentId).getElementsByTagName(tag);
                    type(sfEls);
                });
            }
        }
        hover = function (sfEls) {
            for (var i = 0; i < sfEls.length; i++) {
                sfEls[i].onmouseover = function () {
                    this.className += " hover";
                }
                sfEls[i].onmouseout = function () {
                    this.className = this.className.replace(new RegExp(" hover\\b"), "");
                }
            }
        }
        suckerfish(hover, "li");
    </script>
</head>
<body>
    <form runat="server" id="myform">
    <div>
        <ol id="need">
            <li>
                <label class="">
                    1，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt1' />%，提成<input name='' type='text'
                    runat="server" id='rt1-1'>%<dfn></dfn></li>
            <li>
                <label class="">
                    2，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt2' />%，提成<input name='' type='text'
                    runat="server" id='rt2-2' />%<dfn></dfn></li>
            <li>
                <label class="">
                    3，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt3' />%，提成<input name='' type='text'
                    runat="server" id='rt3-3' />%<dfn></dfn></li>
            <li>
                <label class="">
                    4，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt4' />%，提成<input name='' type='text'
                    runat="server" id='rt4-4' />%<dfn></dfn></li>
            <li>
                <label class="">
                    5，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt5' />%，提成<input name='' type='text'
                    runat="server" id='rt5-5' />%<dfn></dfn></li>
            <li>
                <label class="">
                    6，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt6' />%，提成<input name='' type='text'
                    runat="server" id='rt6-6' />%<dfn></dfn></li>
            <li>
                <label class="">
                    7，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt7' />%，提成<input name='' type='text'
                    runat="server" id='rt7-7' />%<dfn></dfn></li>
            <li>
                <label class="">
                    8，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt8' />%，提成<input name='' type='text'
                    runat="server" id='rt8-8' />%<dfn></dfn></li>
            <li>
                <label class="">
                    9，
                </label>
                完成销售任务<input name='' type='text' runat="server" id='rt9' />%，提成<input name='' type='text'
                    runat="server" id='rt9-9' />%<dfn></dfn></li>
            <li>
                <label class="">
                    10，</label>完成销售任务<input name='' type='text' runat="server" id='rt10' />%，提成<input
                        name='' type='text' runat="server" id='rt10-10' />%<dfn></dfn></li>
        </ol>
    </div>
    </form>
</body>
</html>
