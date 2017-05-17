using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class AusFinInfo
    {
        public AusFinInfo()
        { }
        #region Model
        private int _id;
        private string _itemname;

        /// <summary>
        /// 主键，自动增长
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string itemname
        {
            set { _itemname = value; }
            get { return _itemname; }
        }
        #endregion
    }
}
