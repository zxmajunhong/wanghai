using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class DepartmentInfo
    {
        //DepartmentInfo���Ĭ�Ϲ��췽��
        public DepartmentInfo()
        {

        }
        private int departid;
        /// <summary>
        ///[DepartmentInfo]������
        /// </summary>
        public int Departid
        {
            get { return departid; }
            set { this.departid = value; }
        }
        private string departcname;
        /// <summary>
        ///[DepartmentInfo]�� [departcname]��
        /// </summary>
        public string Departcname
        {
            get { return departcname; }
            set { this.departcname = value; }
        }
        private string departename;
        /// <summary>
        ///[DepartmentInfo]�� [departename]��
        /// </summary>
        public string Departename
        {
            get { return departename; }
            set { this.departename = value; }
        }

        /// <summary>
        /// �Զ������ʶ��
        /// </summary>
        public string AutoCode
        { set; get; }
    }
}
