using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class AusMoneyManager
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool Exists(string itemname, string username, int year)
        {
            return AusMoneyService.Exists(itemname, username, year);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(AusMoney model)
        {
            return AusMoneyService.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(AusMoney model)
        {
            return AusMoneyService.Update(model);
        }

        /// <summary>
        /// 更新已支付金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateMoney(AusMoney model)
        {
            return AusMoneyService.UpdateMoney(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return AusMoneyService.Delete(id);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public static bool DeleteList(string idlist)
        {
            return AusMoneyService.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AusMoney GetModel(int id)
        {
            return AusMoneyService.GetModel(id);
        }

        /// <summary>
        /// 根据名称得到实体
        /// </summary>
        /// <param name="itemname">项目名称</param>
        /// <param name="username">人员</param>
        /// <returns></returns>
        public static AusMoney GetModelByName(string itemname, string username, int years)
        {
            return AusMoneyService.GetModelbyname(itemname, username, years);
        }
    }
}
