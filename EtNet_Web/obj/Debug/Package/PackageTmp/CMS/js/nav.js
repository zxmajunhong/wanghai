// 导航栏配置文件
var outlookbar = new outlook();
var t;
t = outlookbar.addtitle('基本设置', '系统设置', 1)
outlookbar.additem('登录设置', t, 'SysSet/AppConfig.aspx')
outlookbar.additem('技术支持', t, 'SysSet/Support.aspx')
outlookbar.additem('数据显示', t, 'SysSet/PageSets.aspx')

//t=outlookbar.addtitle('广告设置','系统设置',1)
//outlookbar.additem('登录文学论坛',t,'')
//outlookbar.additem('发出电子邮件',t,'mailto:476344704@qq.com')

//t=outlookbar.addtitle('新闻设置','系统设置',1)
//outlookbar.additem('尚未通过文章',t,'un_pass.php')
//outlookbar.additem('已经通过文章',t,'al_pass.php')
//outlookbar.additem('修改现有文章',t,'modify.php')
//outlookbar.additem('撰写最新文章',t,'sub_new.php')
//outlookbar.additem('投稿给文学报',t,'#')

t = outlookbar.addtitle('数据列表', '数据管理', 1)
outlookbar.additem('付款单位', t, 'Data/CompanysManager.aspx')
outlookbar.additem('收款单位', t, 'Data/CustomersManager.aspx')
//outlookbar.additem('发票管理', t, 'Data/InsurancesManager.aspx')
outlookbar.additem('订单管理', t, 'Data/PolicyManager.aspx')
outlookbar.additem('报销管理', t, 'Data/ReimburseManager.aspx')
outlookbar.additem('收款管理', t, 'Data/CollectingsManager.aspx')
outlookbar.additem('全部数据', t, 'Manager/ChearTable.aspx')
outlookbar.additem()


//t = outlookbar.addtitle('退出系统', '管理首页', 1)
//outlookbar.additem('点击退出登录', t, 'loginout.php')

//t = outlookbar.addtitle('系统信息', '管理首页', 1)
//outlookbar.additem('点击刷新系统', t, 'loginout.php')



