using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class Tb_line
    {
        //Tb_line���Ĭ�Ϲ��췽��
        public Tb_line()
        {

        }
        private int id;
        /// <summary>
        ///[tb_line]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string line;
        /// <summary>
        ///[tb_line]�� [line]��
        /// </summary>
        public string Line
        {
            get { return line; }
            set { this.line = value; }
        }
        private string lineRemark;
        /// <summary>
        ///[tb_line]�� [lineRemark]��
        /// </summary>
        public string LineRemark
        {
            get { return lineRemark; }
            set { this.lineRemark = value; }
        }

        /// <summary>
        /// �Զ������ʶ��
        /// </summary>
        public string AutoCode
        { get; set; }
    }
}
