using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class To_Outcome
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime OutComeDate { get; set; }

        /// <summary>
        /// 付款类别
        /// </summary>
        public string OutComeItem { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public string OutComeStatus { get; set; }

        /// <summary>
        /// 收款单位
        /// </summary>
        public string ComeUnit { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public double OutComeMoney { get; set; }

        /// <summary>
        /// 付款银行
        /// </summary>
        public string OutComeBankName { get; set; }

        /// <summary>
        /// 付款银行id
        /// </summary>
        public int OutComeBankId { get; set; }

        /// <summary>
        /// 付款银行帐号
        /// </summary>
        public string OutComeBankAccount { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string OutComeDepart { get; set; }

        /// <summary>
        /// 所属部门id
        /// </summary>
        public int OutComeDepartId { get; set; }

        /// <summary>
        /// 制单员
        /// </summary>
        public string MakeName { get; set; }

        /// <summary>
        /// 制单员id
        /// </summary>
        public int MakeId { get; set; }

        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime MakeDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public int OutComeItemId { get; set; }
    }
}
