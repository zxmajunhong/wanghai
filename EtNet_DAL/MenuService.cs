using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Menu]������ݷ�����
    /// </summary>
    public class MenuService
    {
        /// <summary>
        ///[Menu]����ӵķ���
        /// </summary>
        public static int addMenu(Menu menu)
        {
            string sql = "insert into Menu([name],[url],[nodesort],[parentnodeid]) values (@name,@url,@nodesort,@parentnodeid)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@name",menu.Name),
        new SqlParameter("@url",menu.Url),
        new SqlParameter("@nodesort",menu.Nodesort),
        new SqlParameter("@parentnodeid",menu.Parentnodeid)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Menu]���޸ĵķ���
        /// </summary>
        public static int updateMenuById(Menu menu)
        {

            string sql = "update Menu set name=@name,url=@url,nodesort=@nodesort,parentnodeid=@parentnodeid where nodeid=@nodeid";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@nodeid",menu.Nodeid),
        new SqlParameter("@name",menu.Name),
        new SqlParameter("@url",menu.Url),
        new SqlParameter("@nodesort",menu.Nodesort),
        new SqlParameter("@parentnodeid",menu.Parentnodeid)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Menu]��ɾ���ķ���
        /// </summary>
        public static int deleteMenuById(int nodeid)
        {

            string sql = "delete from Menu where nodeid=@nodeid";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@nodeid",nodeid)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Menu]���ѯʵ��ķ���
        /// </summary>
        public static Menu getMenuById(int nodeid)
        {
            Menu menu = null;

            string sql = "select * from Menu where nodeid=@nodeid";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@nodeid",nodeid)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                menu = new Menu();
                foreach (DataRow dr in dt.Rows)
                {
                    menu.Nodeid = Convert.ToInt32(dr["nodeid"]);
                    menu.Name = Convert.ToString(dr["name"]);
                    menu.Url = Convert.ToString(dr["url"]);
                    menu.Nodesort = Convert.ToInt32(dr["nodesort"]);
                    menu.Parentnodeid = Convert.ToInt32(dr["parentnodeid"]);
                }
            }

            return menu;
        }

        /// <summary>
        ///[Menu]���ѯ���еķ���
        /// </summary>
        public static IList<Menu> getMenuAll()
        {
            string sql = "select * from Menu order by nodesort";
            return getMenusBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<Menu> getMenusBySql(string sql)
        {
            IList<Menu> list = new List<Menu>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Menu menu = new Menu();
                    menu.Nodeid = Convert.ToInt32(dr["nodeid"]);
                    menu.Name = Convert.ToString(dr["name"]);
                    menu.Url = Convert.ToString(dr["url"]);
                    menu.Nodesort = Convert.ToInt32(dr["nodesort"]);
                    menu.Parentnodeid = Convert.ToInt32(dr["parentnodeid"]);
                    list.Add(menu);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static Menu getMenuBySql(string sql)
        {
            Menu menu = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                menu = new Menu();
                foreach (DataRow dr in dt.Rows)
                {
                    menu.Nodeid = Convert.ToInt32(dr["nodeid"]);
                    menu.Name = Convert.ToString(dr["name"]);
                    menu.Url = Convert.ToString(dr["url"]);
                    menu.Nodesort = Convert.ToInt32(dr["nodesort"]);
                    menu.Parentnodeid = Convert.ToInt32(dr["parentnodeid"]);
                }
            }
            return menu;
        }

        public static IList<Menu> getMenuAllByID(int loginId)
        {
            string sql = "select * from Menu order by nodesort";
            return getMenusBySql(sql);
        }
    }
}
