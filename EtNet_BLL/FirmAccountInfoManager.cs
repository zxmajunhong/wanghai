using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
    /// <summary>
    /// FirmAccountInfoManager
    /// </summary>
    public class FirmAccountInfoManager
    {

        public FirmAccountInfoManager()
        { }
        #region  Method



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int id)
        {
            return EtNet_DAL.FirmAccountInfoService.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(EtNet_Models.FirmAccountInfo model)
        {
            return EtNet_DAL.FirmAccountInfoService.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(EtNet_Models.FirmAccountInfo model)
        {
            return EtNet_DAL.FirmAccountInfoService.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int id)
        {
            return EtNet_DAL.FirmAccountInfoService.Delete(id);
        }


        /// <summary>
        /// 依据条件删除数据
        /// </summary>
        public static bool Del(string strwhere)
        {
            return EtNet_DAL.FirmAccountInfoService.Del(strwhere);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteList(string idlist)
        {
            return EtNet_DAL.FirmAccountInfoService.DeleteList(idlist);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.FirmAccountInfo GetModel(int id)
        {
            return EtNet_DAL.FirmAccountInfoService.GetModel(id);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            return EtNet_DAL.FirmAccountInfoService.GetList(strWhere);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return EtNet_DAL.FirmAccountInfoService.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 得到收支合计
        /// </summary>
        /// <param name="id">银行对应id</param>
        /// <param name="moent">是收入还是付出（0，付出；1，收入）</param>
        /// <returns></returns>
        public static decimal GetMoneySum(string id, string moent,string ysdate)
        {
            return EtNet_DAL.FirmAccountInfoService.GetMoneySum(id, moent,ysdate);
        }

        /// <summary>
        /// 得到对应账户的明细数据
        /// </summary>
        /// <param name="strWhere">sql条件需要and</param>
        /// <param name="orderby">排序字段（A desc or A asc）</param>
        /// <returns></returns>
        public static DataTable GetExpense(string strWhere, string orderby)
        {
            return EtNet_DAL.FirmAccountInfoService.GetExpense(strWhere, orderby);
        }

        #endregion  Method


    }
}

