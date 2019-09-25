using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
    public class ViewMenuByLoginService
    {
        public static DataTable getList(string strWhere)
        {
            string strSql = "select * from View_Menu_ByLogin ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);
        }


        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<ViewMenuByLogin> getMenusByLoginSql(string sql)
        {
            IList<ViewMenuByLogin> list = new List<ViewMenuByLogin>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ViewMenuByLogin menulist = new ViewMenuByLogin();
                    menulist.Nodeid = Convert.ToInt32(dr["nodeid"]);
                    menulist.Name = Convert.ToString(dr["name"]);
                    menulist.Url = Convert.ToString(dr["url"]);
                    menulist.Nodesort = Convert.ToInt32(dr["nodesort"]);
                    menulist.Parentnodeid = Convert.ToInt32(dr["parentnodeid"]);
                    list.Add(menulist);
                }
            }
            return list;
        }

        public static IList<EtNet_Models.ViewMenuByLogin> getMenuOfLay(int loginid)
        {
            var menuList = getRootMenu(loginid);
            foreach (var list in menuList)
            {
                list.childsMenu = (IList<EtNet_Models.ViewMenuByLogin>)getMenuByParent(list.Nodeid,loginid);
            }
            return menuList;
        }


        public static IList<EtNet_Models.ViewMenuByLogin> getMenuByParent(int id, int loginid)
        {
            string sql = string.Format("select * from ViewMenuByLogin where parentnodeid = {0} and loginid = '{1}' order by nodesort", id, loginid);
            return getMenusByLoginSql(sql);
        }

        public static IList<EtNet_Models.ViewMenuByLogin> getRootMenu(int loginid)
        {
            string sql = string.Format("select * from ViewMenuByLogin where parentnodeid = 0 and loginid = '{0}'  order by nodesort", loginid);
            return getMenusByLoginSql(sql);
        }
    }
}
