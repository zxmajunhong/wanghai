using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[DepartmentInfo]表的数据访问类
    /// </summary>
    public class DepartmentInfoService
    {
        /// <summary>
        ///[DepartmentInfo]表添加的方法
        /// </summary>
        public static int addDepartmentInfo(DepartmentInfo departmentinfo)
        {
            string sql = "insert into DepartmentInfo([departcname],[departename],[autocode]) values (@departcname,@departename,@autocode)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@departcname",departmentinfo.Departcname),
        new SqlParameter("@departename",departmentinfo.Departename),
        new SqlParameter("@autocode",departmentinfo.AutoCode)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[DepartmentInfo]表修改的方法
        /// </summary>
        public static int updateDepartmentInfoById(DepartmentInfo departmentinfo)
        {

            string sql = "update DepartmentInfo set departcname=@departcname,departename=@departename,autocode=@autocode where departid=@departid";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@departid",departmentinfo.Departid),
        new SqlParameter("@departcname",departmentinfo.Departcname),
        new SqlParameter("@departename",departmentinfo.Departename),
        new SqlParameter("@autocode",departmentinfo.AutoCode)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[DepartmentInfo]表删除的方法
        /// </summary>
        public static int deleteDepartmentInfoById(int departid)
        {

            string sql = "delete from DepartmentInfo where departid=@departid";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@departid",departid)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[DepartmentInfo]表查询实体的方法
        /// </summary>
        public static DepartmentInfo getDepartmentInfoById(int departid)
        {
            DepartmentInfo departmentinfo = null;

            string sql = "select * from DepartmentInfo where departid=@departid";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@departid",departid)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                departmentinfo = new DepartmentInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    departmentinfo.Departid = Convert.ToInt32(dr["departid"]);
                    departmentinfo.Departcname = Convert.ToString(dr["departcname"]);
                    departmentinfo.Departename = Convert.ToString(dr["departename"]);
                    departmentinfo.AutoCode = Convert.ToString(dr["autocode"]);
                }
            }

            return departmentinfo;
        }

        /// <summary>
        ///[DepartmentInfo]表查询实体的方法
        /// </summary>
        public static DepartmentInfo getDepartmentInfoBydepartcname(string departcname)
        {
            DepartmentInfo departmentinfo = null;

            string sql = "select * from DepartmentInfo where departcname=@departcname";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@departcname",departcname)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                departmentinfo = new DepartmentInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    departmentinfo.Departid = Convert.ToInt32(dr["departid"]);
                    departmentinfo.Departcname = Convert.ToString(dr["departcname"]);
                    departmentinfo.Departename = Convert.ToString(dr["departename"]);
                    departmentinfo.AutoCode = Convert.ToString(dr["autocode"]);
                }
            }

            return departmentinfo;
        }

        /// <summary>
        ///[DepartmentInfo]表查询所有的方法
        /// </summary>
        public static IList<DepartmentInfo> getDepartmentInfoAll()
        {
            string sql = "select * from DepartmentInfo";
            return getDepartmentInfosBySql(sql);
        }


        /// <summary>
        ///[DepartmentInfo]表查询所有的方法
        /// </summary>
        public static IList<DepartmentInfo> getDepartmentAll(string strwhere)
        {
            string sql = "select * from DepartmentInfo";
            if (strwhere != "")
            {
                sql += " where " + strwhere;
            }
            return getDepartmentInfosBySql(sql);
        }

        /// <summary>
        /// 根据名称集合得到对应的实体
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IList<DepartmentInfo> getDepartmentBynames(string names)
        {
            string sql = "select * from DepartmentInfo where departcname in (" + names + ")";
            return getDepartmentInfosBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<DepartmentInfo> getDepartmentInfosBySql(string sql)
        {
            IList<DepartmentInfo> list = new List<DepartmentInfo>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentInfo departmentinfo = new DepartmentInfo();
                    departmentinfo.Departid = Convert.ToInt32(dr["departid"]);
                    departmentinfo.Departcname = Convert.ToString(dr["departcname"]);
                    departmentinfo.Departename = Convert.ToString(dr["departename"]);
                    departmentinfo.AutoCode = Convert.ToString(dr["autocode"]);
                    list.Add(departmentinfo);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static DepartmentInfo getDepartmentInfoBySql(string sql)
        {
            DepartmentInfo departmentinfo = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                departmentinfo = new DepartmentInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    departmentinfo.Departid = Convert.ToInt32(dr["departid"]);
                    departmentinfo.Departcname = Convert.ToString(dr["departcname"]);
                    departmentinfo.Departename = Convert.ToString(dr["departename"]);
                    departmentinfo.AutoCode = Convert.ToString(dr["autocode"]);
                }
            }
            return departmentinfo;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM DepartmentInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTypeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AusTypeInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM DepartmentInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }
        /// <summary>
        /// 根据id获得postname
        /// </summary>
        public static string getPostname(int postid)
        {
            string sql = "select postname from To_Post where id='" + postid + "'";
            DataTable dt = DBHelper.GetDataSet(sql);
            string postname = Convert.ToString(dt.Rows[0].ItemArray[0]);
            return postname;
        }

        /// <summary>
        /// 根据postname获得id
        /// </summary>
        public static int getpostid(string postname)
        {
            string sql = "select id from To_Post where postname='" + postname + "'";
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows[0]["id"] == null || dt.Rows[0]["id"].ToString() == "")
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(Convert.ToInt32(dt.Rows[0]["id"]));
            }
        }
    }
}
