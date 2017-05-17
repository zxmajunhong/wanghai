using System;
using System.Collections.Generic;
using System.Text;

namespace EtNet_Models
{
    public class AusTypeInfo
    {
        public AusTypeInfo()
        { }
        #region Model
        private int _id;
        private string _typename;
        private string _iscy;
        /// <summary>
        /// 主键，自动增长
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string typename
        {
            set { _typename = value; }
            get { return _typename; }
        }

        /// <summary>
        /// 是否常用
        /// </summary>
        public string iscy
        {
            set { _iscy = value; }
            get { return _iscy; }
        }
        #endregion Model


    }
}
