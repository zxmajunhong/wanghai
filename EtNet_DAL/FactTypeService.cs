using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
using EtNet_DAL;
namespace EtNet_DAL
{

    /// <summary>
    ///[FactType]表的数据访问类
    /// </summary>
    public class FactTypeService
    {
        /// <summary>
        ///[FactType]表添加的方法
        /// </summary>
        public static int addFactType(FactType facttype)
        {
            string sql = "insert into FactType([typeName],[typeremark]) values (@typeName,@typeremark)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@typeName",facttype.TypeName),
        new SqlParameter("@typeremark",facttype.Typeremark)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[FactType]表修改的方法
        /// </summary>
        public static int updateFactTypeById(FactType facttype)
        {

            string sql = "update FactType set typeName=@typeName,typeremark=@typeremark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",facttype.Id),
        new SqlParameter("@typeName",facttype.TypeName),
        new SqlParameter("@typeremark",facttype.Typeremark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[FactType]表删除的方法
        /// </summary>
        public static int deleteFactTypeById(int id)
        {

            string sql = "delete from FactType where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[FactType]表查询实体的方法
        /// </summary>
        public static FactType getFactTypeById(int id)
        {
            FactType facttype = null;

            string sql = "select * from FactType where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                facttype = new FactType();
                foreach (DataRow dr in dt.Rows)
                {
                    facttype.Id = Convert.ToInt32(dr["id"]);
                    facttype.TypeName = Convert.ToString(dr["typeName"]);
                    facttype.Typeremark = Convert.ToString(dr["typeremark"]);
                }
            }

            return facttype;
        }

        /// <summary>
        ///[FactType]表查询所有的方法
        /// </summary>
        public static IList<FactType> getFactTypeAll()
        {
            string sql = "select * from FactType";
            return getFactTypesBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<FactType> getFactTypesBySql(string sql)
        {
            IList<FactType> list = new List<FactType>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FactType facttype = new FactType();
                    facttype.Id = Convert.ToInt32(dr["id"]);
                    facttype.TypeName = Convert.ToString(dr["typeName"]);
                    facttype.Typeremark = Convert.ToString(dr["typeremark"]);
                    list.Add(facttype);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static FactType getFactTypeBySql(string sql)
        {
            FactType facttype = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                facttype = new FactType();
                foreach (DataRow dr in dt.Rows)
                {
                    facttype.Id = Convert.ToInt32(dr["id"]);
                    facttype.TypeName = Convert.ToString(dr["typeName"]);
                    facttype.Typeremark = Convert.ToString(dr["typeremark"]);
                }
            }
            return facttype;
        }

        public static int getFactTypeBytypename(string typename)
        {
            string sql = "select count(*) from FactType where typeName='" + typename + "'";
            return DBHelper.ExecuteScalar(sql);
        }
    }
}
