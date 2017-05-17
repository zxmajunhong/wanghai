using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EtNet_DAL;
namespace EtNet_BLL
{
    public class ViewMenuByLoginManager
    {
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        public static DataTable getList(string strwhere)
        {
            return EtNet_DAL.ViewMenuByLoginService.getList(strwhere);
        }
        public static IList<EtNet_Models.ViewMenuByLogin> getMenuOfLay(int loginid)
        {
            return EtNet_DAL.ViewMenuByLoginService.getMenuOfLay(loginid);
        }

        private static IList<EtNet_Models.ViewMenuByLogin> getMenuByParent(int id, int loginid)
        {
            return EtNet_DAL.ViewMenuByLoginService.getMenuByParent(id, loginid);
        }

        public static IList<EtNet_Models.ViewMenuByLogin> getRootMenu(int loginid)
        {
            return EtNet_DAL.ViewMenuByLoginService.getRootMenu(loginid);
        }
    }
}
