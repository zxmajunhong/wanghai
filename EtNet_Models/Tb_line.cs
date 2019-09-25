using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class Tb_line
    {
        //Tb_line表的默认构造方法
        public Tb_line()
        {

        }
        private int id;
        /// <summary>
        ///[tb_line]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string line;
        /// <summary>
        ///[tb_line]表 [line]列
        /// </summary>
        public string Line
        {
            get { return line; }
            set { this.line = value; }
        }
        private string lineRemark;
        /// <summary>
        ///[tb_line]表 [lineRemark]列
        /// </summary>
        public string LineRemark
        {
            get { return lineRemark; }
            set { this.lineRemark = value; }
        }

        /// <summary>
        /// 自动编码标识符
        /// </summary>
        public string AutoCode
        { get; set; }
    }
}
