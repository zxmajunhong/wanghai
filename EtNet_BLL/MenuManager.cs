using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class MenuManager
    {
        public static int addMenu(Menu menu)
        {
            return MenuService.addMenu(menu);
        }

        public static int updateMenu(Menu menu)
        {
            return MenuService.updateMenuById(menu);
        }

        public static int deleteMenu(int nodeid)
        {
            return MenuService.deleteMenuById(nodeid);
        }

        public static Menu getMenuById(int nodeid)
        {
            return MenuService.getMenuById(nodeid);
        }

        public static IList<Menu> getMenuAll()
        {
            return MenuService.getMenuAll();
        }
        /// <summary>
        /// 根据用户信息获取父节点信息
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static IList<Menu> getMenuAllByLoginId(int loginid)
        {
            string sql = "select * from View_Menu_ByLogin where parentnodeid = '0' and loginid = '" + loginid + "' order by nodesort";
            return MenuService.getMenusBySql(sql);
        }

        /// <summary>
        /// 根据登录信息得到权限
        /// </summary>
        /// <param name="parentidnodeid"></param>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static IList<Menu> getMenuByParentNodeLoginId(int parentidnodeid, int loginid)
        {
            string sql = "select * from View_Menu_ByLogin where parentnodeid = '" + parentidnodeid + "' and LoginId = '" + loginid + "' order by nodesort";
            return MenuService.getMenusBySql(sql);
        }
        /// <summary>
        /// 根据父节点得到子节点
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static IList<Menu> getMenuByParentId(int parentNodeId)
        {
            string sql = "select * from Menu where ParentNodeId = " + parentNodeId + " order by nodesort";
            return MenuService.getMenusBySql(sql);
        }

        /// <summary>
        /// 获得所有父节点
        /// </summary>
        /// <returns></returns>
        public static IList<Menu> getAllParentNode()
        {
            string sql = "select * from Menu where ParentNodeId = '0' order by nodesort";
            return MenuService.getMenusBySql(sql);
        }

        public static IList<Menu> getMenuAllbyID(int loginId)
        {
            return MenuService.getMenuAllByID(loginId);
        }
    }
}
