using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Ratio]表的数据访问类
    /// </summary>
    public class RatioService
    {
        /// <summary>
        ///[Ratio]表添加的方法
        /// </summary>
        public static int addRatio(Ratio ratio)
        {
            string sql = "insert into Ratio([rationame],[ratio1],[ratio2],[ratio3],[ratio4],[ratio5],[ratio6],[ratio7],[ratio8],[ratio9],[ratio10]) values (@rationame,@ratio1,@ratio2,@ratio3,@ratio4,@ratio5,@ratio6,@ratio7,@ratio8,@ratio9,@ratio10)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@rationame",ratio.Rationame),
        new SqlParameter("@ratio1",ratio.Ratio1),
        new SqlParameter("@ratio2",ratio.Ratio2),
        new SqlParameter("@ratio3",ratio.Ratio3),
        new SqlParameter("@ratio4",ratio.Ratio4),
        new SqlParameter("@ratio5",ratio.Ratio5),
        new SqlParameter("@ratio6",ratio.Ratio6),
        new SqlParameter("@ratio7",ratio.Ratio7),
        new SqlParameter("@ratio8",ratio.Ratio8),
        new SqlParameter("@ratio9",ratio.Ratio9),
        new SqlParameter("@ratio10",ratio.Ratio10)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Ratio]表修改的方法
        /// </summary>
        public static int updateRatioById(Ratio ratio)
        {

            string sql = "update Ratio set rationame=@rationame,ratio1=@ratio1,ratio2=@ratio2,ratio3=@ratio3,ratio4=@ratio4,ratio5=@ratio5,ratio6=@ratio6,ratio7=@ratio7,ratio8=@ratio8,ratio9=@ratio9,ratio10=@ratio10 where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",ratio.Id),
        new SqlParameter("@rationame",ratio.Rationame),
        new SqlParameter("@ratio1",ratio.Ratio1),
        new SqlParameter("@ratio2",ratio.Ratio2),
        new SqlParameter("@ratio3",ratio.Ratio3),
        new SqlParameter("@ratio4",ratio.Ratio4),
        new SqlParameter("@ratio5",ratio.Ratio5),
        new SqlParameter("@ratio6",ratio.Ratio6),
        new SqlParameter("@ratio7",ratio.Ratio7),
        new SqlParameter("@ratio8",ratio.Ratio8),
        new SqlParameter("@ratio9",ratio.Ratio9),
        new SqlParameter("@ratio10",ratio.Ratio10)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Ratio]表删除的方法
        /// </summary>
        public static int deleteRatioById(int id)
        {

            string sql = "delete from Ratio where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Ratio]表查询实体的方法
        /// </summary>
        public static Ratio getRatioById(int id)
        {
            Ratio ratio = null;

            string sql = "select * from Ratio where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                ratio = new Ratio();
                foreach (DataRow dr in dt.Rows)
                {
                    ratio.Id = Convert.ToInt32(dr["id"]);
                    ratio.Rationame = Convert.ToString(dr["rationame"]);
                    ratio.Ratio1 = Convert.ToString(dr["ratio1"]);
                    ratio.Ratio2 = Convert.ToString(dr["ratio2"]);
                    ratio.Ratio3 = Convert.ToString(dr["ratio3"]);
                    ratio.Ratio4 = Convert.ToString(dr["ratio4"]);
                    ratio.Ratio5 = Convert.ToString(dr["ratio5"]);
                    ratio.Ratio6 = Convert.ToString(dr["ratio6"]);
                    ratio.Ratio7 = Convert.ToString(dr["ratio7"]);
                    ratio.Ratio8 = Convert.ToString(dr["ratio8"]);
                    ratio.Ratio9 = Convert.ToString(dr["ratio9"]);
                    ratio.Ratio10 = Convert.ToString(dr["ratio10"]);
                }
            }

            return ratio;
        }

        /// <summary>
        ///[Ratio]表查询所有的方法
        /// </summary>
        public static IList<Ratio> getRatioAll()
        {
            string sql = "select * from Ratio";
            return getRatiosBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Ratio> getRatiosBySql(string sql)
        {
            IList<Ratio> list = new List<Ratio>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Ratio ratio = new Ratio();
                    ratio.Id = Convert.ToInt32(dr["id"]);
                    ratio.Rationame = Convert.ToString(dr["rationame"]);
                    ratio.Ratio1 = Convert.ToString(dr["ratio1"]);
                    ratio.Ratio2 = Convert.ToString(dr["ratio2"]);
                    ratio.Ratio3 = Convert.ToString(dr["ratio3"]);
                    ratio.Ratio4 = Convert.ToString(dr["ratio4"]);
                    ratio.Ratio5 = Convert.ToString(dr["ratio5"]);
                    ratio.Ratio6 = Convert.ToString(dr["ratio6"]);
                    ratio.Ratio7 = Convert.ToString(dr["ratio7"]);
                    ratio.Ratio8 = Convert.ToString(dr["ratio8"]);
                    ratio.Ratio9 = Convert.ToString(dr["ratio9"]);
                    ratio.Ratio10 = Convert.ToString(dr["ratio10"]);
                    list.Add(ratio);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Ratio getRatioBySql(string sql)
        {
            Ratio ratio = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                ratio = new Ratio();
                foreach (DataRow dr in dt.Rows)
                {
                    ratio.Id = Convert.ToInt32(dr["id"]);
                    ratio.Rationame = Convert.ToString(dr["rationame"]);
                    ratio.Ratio1 = Convert.ToString(dr["ratio1"]);
                    ratio.Ratio2 = Convert.ToString(dr["ratio2"]);
                    ratio.Ratio3 = Convert.ToString(dr["ratio3"]);
                    ratio.Ratio4 = Convert.ToString(dr["ratio4"]);
                    ratio.Ratio5 = Convert.ToString(dr["ratio5"]);
                    ratio.Ratio6 = Convert.ToString(dr["ratio6"]);
                    ratio.Ratio7 = Convert.ToString(dr["ratio7"]);
                    ratio.Ratio8 = Convert.ToString(dr["ratio8"]);
                    ratio.Ratio9 = Convert.ToString(dr["ratio9"]);
                    ratio.Ratio10 = Convert.ToString(dr["ratio10"]);
                }
            }
            return ratio;
        }

        public static IList<Ratio> getTop1()
        {
            string sql = "select top 1 * from Ratio";
            return getRatiosBySql(sql);
        }
    }
}
