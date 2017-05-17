using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    /// <summary>
    /// 险种个人综合比率
    /// </summary>
    public class LoginProdRate
    {
        private int id; //ID主键
        private string prodname; //险种名称
        private string prodid; //险种id
        private string username; //人员名称
        private string userid; //人员id
        private double rate; //比率

        /// <summary>
        /// 主键id
        /// </summary>
        public int ID
        {
            set { this.id = value; }
            get { return this.id; }
        }

        /// <summary>
        /// 险种名称
        /// </summary>
        public string ProdName
        {
            set { this.prodname = value; }
            get { return this.prodname; }
        }

        /// <summary>
        /// 险种id
        /// </summary>
        public string ProdId
        {
            set { this.prodid = value; }
            get { return this.prodid; }
        }

        /// <summary>
        /// 人员名称
        /// </summary>
        public string UserName
        {
            set { this.username = value; }
            get { return this.username; }
        }

        /// <summary>
        /// 人员id
        /// </summary>
        public string UserId
        {
            set { this.userid = value; }
            get { return this.userid; }
        }

        /// <summary>
        /// 比率
        /// </summary>
        public double Rate
        {
            set { this.rate = value; }
            get { return this.rate; }
        }
    }
}
