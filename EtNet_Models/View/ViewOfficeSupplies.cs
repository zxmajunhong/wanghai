using System;
namespace EtNet_Models
{
    /// <summary>
    /// OfficeSupplies:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ViewOfficeSupplies
    {
        public ViewOfficeSupplies()
        { }
        #region Model
        private int _id;
        private string _cname;
        private string _standard;
        private string _prickle;
        private string _warnstatus;
        private int _warnnum;
        private int _sort;
        private int _inventory;
        private string _num;
        private string _remrak;
        private string _sortcname;

        /// <summary>
        /// 唯一键
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 办公用品的名称
        /// </summary>
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string standard
        {
            set { _standard = value; }
            get { return _standard; }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string prickle
        {
            set { _prickle = value; }
            get { return _prickle; }
        }
        /// <summary>
        /// 警示状态
        /// </summary>
        public string warnstatus
        {
            set { _warnstatus = value; }
            get { return _warnstatus; }
        }
        /// <summary>
        /// 警示数量
        /// </summary>
        public int warnnum
        {
            set { _warnnum = value; }
            get { return _warnnum; }
        }
        /// <summary>
        /// 分类
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int inventory
        {
            set { _inventory = value; }
            get { return _inventory; }
        }


        /// <summary>
        /// 分类的编号
        /// </summary>
        public string num
        {
            set { _num = value; }
            get { return _num; }
        }


        /// <summary>
        /// 分类的描述
        /// </summary>
        public string remark
        {
            set { _remrak = value; }
            get { return _remrak; }
        }


        /// <summary>
        /// 分类的名称
        /// </summary>
        public string sortcname
        {
            set { _sortcname = value; }
            get { return _sortcname; }
        }

        #endregion Model

    }
}

