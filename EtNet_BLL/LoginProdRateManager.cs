using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class LoginProdRateManager
    {
        public LoginProdRateManager()
        { }

        #region
        /// <summary>
        /// 检查是否存在该记录
        /// </summary>
        /// <param name="prodname">险种名称</param>
        /// <param name="username">人员名称</param>
        /// <returns></returns>
        public static bool Exists(string prodname, string username)
        {
            return LoginProdRateService.Exists(prodname, username);
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="model">对象实体</param>
        /// <returns></returns>
        public static bool Add(LoginProdRate model)
        {
            return LoginProdRateService.Add(model);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return LoginProdRateService.Delete(id);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="model">对象实体</param>
        /// <returns></returns>
        public static bool Update(LoginProdRate model)
        {
            return LoginProdRateService.Update(model);
        }

        /// <summary>
        /// 根据主键id得到一个对象实体
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public static LoginProdRate GetModel(int id)
        {
            return LoginProdRateService.GetModel(id);
        }

        /// <summary>
        /// 根据险种名称和人员名称得到对象实体
        /// </summary>
        /// <param name="prodname">险种名称</param>
        /// <param name="username">人员名称</param>
        /// <returns></returns>
        public static LoginProdRate GetModelByProdnameUsername(string prodname, string username)
        {
            return LoginProdRateService.GetModelByProdnameUsername(prodname, username);
        }

        /// <summary>
        /// 根据险种名称得到对象集合
        /// </summary>
        /// <param name="prodname">险种名称</param>
        /// <returns></returns>
        public static IList<LoginProdRate> GetModelsByProdname(string prodname)
        {
            return LoginProdRateService.GetModelsByProdname(prodname);
        }

        /// <summary>
        /// 根据人员名称得到对象集合
        /// </summary>
        /// <param name="username">人员名称</param>
        /// <returns></returns>
        public static IList<LoginProdRate> GetModlesByUsername(string username)
        {
            return LoginProdRateService.GetModelsByUsername(username);
        }

        /// <summary>
        /// 根据sql语句得到对象集合
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static IList<LoginProdRate> GetModelsBySql(string sql)
        {
            return LoginProdRateService.GetModelsBySql(sql);
        }

        #endregion
    }
}
