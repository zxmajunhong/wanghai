// �����������ļ�
var outlookbar = new outlook();
var t;
t = outlookbar.addtitle('��������', 'ϵͳ����', 1)
outlookbar.additem('��¼����', t, 'SysSet/AppConfig.aspx')
outlookbar.additem('����֧��', t, 'SysSet/Support.aspx')
outlookbar.additem('������ʾ', t, 'SysSet/PageSets.aspx')

//t=outlookbar.addtitle('�������','ϵͳ����',1)
//outlookbar.additem('��¼��ѧ��̳',t,'')
//outlookbar.additem('���������ʼ�',t,'mailto:476344704@qq.com')

//t=outlookbar.addtitle('��������','ϵͳ����',1)
//outlookbar.additem('��δͨ������',t,'un_pass.php')
//outlookbar.additem('�Ѿ�ͨ������',t,'al_pass.php')
//outlookbar.additem('�޸���������',t,'modify.php')
//outlookbar.additem('׫д��������',t,'sub_new.php')
//outlookbar.additem('Ͷ�����ѧ��',t,'#')

t = outlookbar.addtitle('�����б�', '���ݹ���', 1)
outlookbar.additem('���λ', t, 'Data/CompanysManager.aspx')
outlookbar.additem('�տλ', t, 'Data/CustomersManager.aspx')
//outlookbar.additem('��Ʊ����', t, 'Data/InsurancesManager.aspx')
outlookbar.additem('��������', t, 'Data/PolicyManager.aspx')
outlookbar.additem('��������', t, 'Data/ReimburseManager.aspx')
outlookbar.additem('�տ����', t, 'Data/CollectingsManager.aspx')
outlookbar.additem('ȫ������', t, 'Manager/ChearTable.aspx')
outlookbar.additem()


//t = outlookbar.addtitle('�˳�ϵͳ', '������ҳ', 1)
//outlookbar.additem('����˳���¼', t, 'loginout.php')

//t = outlookbar.addtitle('ϵͳ��Ϣ', '������ҳ', 1)
//outlookbar.additem('���ˢ��ϵͳ', t, 'loginout.php')



