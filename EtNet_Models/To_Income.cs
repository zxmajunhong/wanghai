using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class To_Income
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 收款日期
        /// </summary>
        public DateTime ComeDate { get; set; }

        /// <summary>
        /// 收款金额
        /// </summary>
        public double ComeMoney { get; set; }

        /// <summary>
        /// 付款单位
        /// </summary>
        public string ComeUnit { get; set; }

        /// <summary>
        /// 入账银行
        /// </summary>
        public string ComeBankName { get; set; }

        /// <summary>
        /// 入账银行id
        /// </summary>
        public int ComeBankId { get; set; }

        /// <summary>
        /// 入账银行帐号
        /// </summary>
        public string ComeBankAccount { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string ComeDepart { get; set; }

        /// <summary>
        /// 所属部门id
        /// </summary>
        public int ComeDepartId { get; set; }

        /// <summary>
        /// 制单员
        /// </summary>
        public string MakeName { get; set; }

        /// <summary>
        /// 制单员id
        /// </summary>
        public int MakeId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime MakeDate { get; set; }

        /// <summary>
        /// 收款类别对应id
        /// </summary>
        public int SKTypeId { get; set; }

        /// <summary>
        /// 收款类别
        /// </summary>
        public string SKType { get; set; }
    }
}
