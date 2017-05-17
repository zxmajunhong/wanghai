using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[tb_line]表的数据访问类
    /// </summary>
    public class Tb_lineService
    {
        /// <summary>
        ///[tb_line]表添加的方法
        /// </summary>
        public static int addTb_line(Tb_line tb_line)
        {
            string sql = "insert into tb_line([line],[lineRemark],[autocode]) values (@line,@lineRemark,@autocode)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@line",tb_line.Line),
        new SqlParameter("@lineRemark",tb_line.LineRemark),
        new SqlParameter("@autocode",tb_line.AutoCode)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[tb_line]表修改的方法
        /// </summary>
        public static int updateTb_lineById(Tb_line tb_line)
        {

            string sql = "update tb_line set line=@line,lineRemark=@lineRemark,autocode=@autocode where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",tb_line.Id),
        new SqlParameter("@line",tb_line.Line),
        new SqlParameter("@lineRemark",tb_line.LineRemark),
        new SqlParameter("@autocode",tb_line.AutoCode)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[tb_line]表删除的方法
        /// </summary>
        public static int deleteTb_lineById(int id)
        {

            string sql = "delete from tb_line where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[tb_line]表查询实体的方法
        /// </summary>
        public static Tb_line getTb_lineById(int id)
        {
            Tb_line tb_line = null;

            string sql = "select * from tb_line where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                tb_line = new Tb_line();
                foreach (DataRow dr in dt.Rows)
                {
                    tb_line.Id = Convert.ToInt32(dr["id"]);
                    tb_line.Line = Convert.ToString(dr["line"]);
                    tb_line.LineRemark = Convert.ToString(dr["lineRemark"]);
                    tb_line.AutoCode = Convert.ToString(dr["autocode"]);
                }
            }

            return tb_line;
        }

        /// <summary>
        ///[tb_line]表查询所有的方法
        /// </summary>
        public static IList<Tb_line> getTb_lineAll()
        {
            string sql = "select * from tb_line";
            return getTb_linesBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Tb_line> getTb_linesBySql(string sql)
        {
            IList<Tb_line> list = new List<Tb_line>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tb_line tb_line = new Tb_line();
                    tb_line.Id = Convert.ToInt32(dr["id"]);
                    tb_line.Line = Convert.ToString(dr["line"]);
                    tb_line.LineRemark = Convert.ToString(dr["lineRemark"]);
                    tb_line.AutoCode = Convert.ToString(dr["autocode"]);
                    list.Add(tb_line);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Tb_line getTb_lineBySql(string sql)
        {
            Tb_line tb_line = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                tb_line = new Tb_line();
                foreach (DataRow dr in dt.Rows)
                {
                    tb_line.Id = Convert.ToInt32(dr["id"]);
                    tb_line.Line = Convert.ToString(dr["line"]);
                    tb_line.LineRemark = Convert.ToString(dr["lineRemark"]);
                    tb_line.AutoCode = Convert.ToString(dr["autocode"]);
                }
            }
            return tb_line;
        }

        public static DataTable getList(string sqlwhere)
        {
            string str = "select * from tb_line ";
            if (sqlwhere != "")
            {
                str += " where " + sqlwhere;

            }
            else
            { }
            return DBHelper.GetDataSet(str);
        }
    }
}
