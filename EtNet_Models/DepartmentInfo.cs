using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class DepartmentInfo
    {
        //DepartmentInfo表的默认构造方法
        public DepartmentInfo()
        {

        }
        private int departid;
        /// <summary>
        ///[DepartmentInfo]表主键
        /// </summary>
        public int Departid
        {
            get { return departid; }
            set { this.departid = value; }
        }
        private string departcname;
        /// <summary>
        ///[DepartmentInfo]表 [departcname]列
        /// </summary>
        public string Departcname
        {
            get { return departcname; }
            set { this.departcname = value; }
        }
        private string departename;
        /// <summary>
        ///[DepartmentInfo]表 [departename]列
        /// </summary>
        public string Departename
        {
            get { return departename; }
            set { this.departename = value; }
        }

        /// <summary>
        /// 自动编码标识符
        /// </summary>
        public string AutoCode
        { set; get; }
    }
}
