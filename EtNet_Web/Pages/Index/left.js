menulist = ({
    init: function () {
        Ext.Ajax.request({
            url: '../../Handler/left.ashx',
            method: "post",
            params: {},
            success: function (data) {
                data = eval("(" + data.responseText + ")");
                var panel = document.getElementById('panel');
                var template = document.getElementById('subPanel').innerHTML;
                var smTemplate = '<li><a href="../../[#Url]" target="mainFrame">[#Name]</a></li>';
                for (var i = 0; i < data.length; i++) {
                    var fName = data[i].name, fIcon = data[i].icon, fUrl = data[i].url, fSubMenu = '';
                    for (var j = 0; j < data[i].childsMenu.length; j++) {
                        fSubMenu += smTemplate.replace('[#Name]', data[i].childsMenu[j].name).replace('[#Url]', data[i].childsMenu[j].url);
                    }
                    var fnEntity = template.replace('display: none;', '').replace('[#Name]', fName).replace('Icon', fIcon).replace('[#SubMenu]', fSubMenu);
                    panel.innerHTML += fnEntity;
                }
                (function () {
                    var contents = document.getElementsByClassName('content');
                    var toggles = document.getElementsByClassName('type');
                    var myAccordion = new fx.Accordion(toggles, contents, { opacity: true, duration: 400 });
                    myAccordion.showThisHideOpen(contents[0]);
                })();
            }
        });
    }
});