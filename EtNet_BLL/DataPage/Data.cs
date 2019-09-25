using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using DbAccess;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EtNet_DAL;

namespace EtNet_BLL.DataPage
{
    public partial class Data
    {
        private static string connectionString = DbHelperSQLChatting.connectionString;
        /// <summary>
        /// 存储过程分页查询
        /// </summary>
        /// <param name="TableName">表名称</param>
        /// <param name="PrimaryKey">主键名称</param>
        /// <param name="Fields">显示的字段（*代表全部）</param>
        /// <param name="Sql_where">查询条件（and开头）</param>
        /// <param name="OrderItem">排序字段</param>
        /// <param name="Order">升序或降序（true降序 false升序）</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="PageItems">分页控件显示个数</param>
        /// <param name="PageId">分页控件Id</param>
        /// <param name="OutSelectSql">输出sql语句（调试用）</param>
        /// <returns>返回dataset</returns>
        public DataSet DataPage(string TableName, string PrimaryKey, string Fields, string Sql_where, string OrderItem, bool Order, int PageSize, int PageItems, System.Web.UI.HtmlControls.HtmlGenericControl PageId, System.Web.UI.HtmlControls.HtmlGenericControl nullarea = null, string OutSelectSql = "")
        {
            return DbAccess.DataByPage.DataPage(connectionString, TableName, PrimaryKey, Fields, Sql_where, OrderItem, Order, PageSize, PageItems, PageId, nullarea, OutSelectSql);
        }
        public DataSet Query(string Sql_Str)
        {
            return DBUtility.DbHelperSQLChatting.Query(Sql_Str);
        }

        /// <summary>
        /// aspnetpage 存储过程分页查询
        /// </summary>
        /// <param name="tblName">表名称</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="strOrderType">升序或降序asc/desc</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="PageIndex">第几页</param>
        /// <param name="strwhere">sql语句不要加and</param>
        /// <returns></returns>
        public DataTable GetList(string tblName, string strOrder, string strOrderType, int PageSize, int PageIndex, string strwhere)
        {
            DataTable dt = new DataTable();
            string cmdText =  "proc_SplitPage"; //定义存储过程名称
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@tblName",tblName),
                new SqlParameter("@strOrder",strOrder),
                new SqlParameter("@strOrderType",strOrderType),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@strWhere",strwhere)
            };

            dt = DBHelper.GetDataSet(cmdText, paras, CommandType.StoredProcedure);
            return dt;
        }

        /// <summary>
        /// 0512  存储过程多排序字段显示分页
        /// </summary>
        /// <param name="tblName"></param>
        /// <param name="strOrder"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetpageList(string tblName, string strOrder, int PageSize, int PageIndex, string strwhere)
        {
            DataTable dt = new DataTable();
            string cmdText = "proc_PageSplit";//定义存储过程名称
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@tblName",tblName),
                new SqlParameter("@strOrder",strOrder),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@strWhere",strwhere)
            };

            dt = DBHelper.GetDataSet(cmdText, paras, CommandType.StoredProcedure);
            return dt;
        }

        /// <summary>
        /// 得到记录总数
        /// </summary>
        /// <param name="tblname"></param>
        /// <param name="strwhere">加where</param>
        /// <returns></returns>
        public int GetCount(string tblname, string strwhere)
        {
            int count;
            string sql = "select count(1) from " + tblname;
            if (strwhere != "")
            {
                sql += " where (1>0) " + strwhere;
            }

            count = DBHelper.ExecuteScalar(sql);
            return count;
        }

        /// <summary>
        /// 得到报表金额合计
        /// </summary>
        /// <param name="sqlSelect">所要查询的sql语句</param>
        /// <param name="tblname">表名</param>
        /// <param name="sqlWhere">where条件</param>
        /// <returns></returns>
        public DataTable GetSumMoney(string sqlSelect, string tblname, string sqlWhere)
        {
            string sql = sqlSelect + " from " + tblname;
            if (sqlWhere != "")
            {
                sql += " where (1>0) " + sqlWhere;
            }
            DataTable dt = DBHelper.GetDataSet(sql);
            return dt;
        }
    }
}
