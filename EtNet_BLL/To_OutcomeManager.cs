using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;

namespace EtNet_BLL
{
    public class To_OutcomeManager
    {
        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="outcome"></param>
        /// <returns></returns>
        public static int Add(To_Outcome outcome)
        {
            return To_OutcomeService.Add(outcome);
        }

        public static int Delete(int id)
        {
            return To_OutcomeService.Delete(id);
        }

        public static To_Outcome GetModel(string id)
        {
            return To_OutcomeService.GetModel(id);
        }

        public static int Update(To_Outcome outcome)
        {
            return To_OutcomeService.Update(outcome);
        }

        /// <summary>
        /// 更改支付状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateStatus(string Id, string status)
        {
            return To_OutcomeService.UpdateStatus(Id, status);
        }

        public static double GetMoneyAmount(string sqlstr)
        {
          return To_OutcomeService.GetMoneyAmount(sqlstr);
        }

        public static System.Data.DataTable GetList(string sqlstr)
        {
          return To_OutcomeService.GetList(sqlstr);
        }
    }
}
