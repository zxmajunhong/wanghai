using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[ComBank]表的数据访问类
    /// </summary>
    public class ComBankService
    {
        /// <summary>
        ///[ComBank]表添加的方法
        /// </summary>
        public static int addComBank(ComBank combank)
        {
            string sql = "insert into ComBank([companyId],[bank],[cardId],[cardName],[remark]) values (@companyId,@bank,@cardId,@cardName,@remark)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@companyId",combank.CompanyId),
        new SqlParameter("@bank",combank.Bank),
        new SqlParameter("@cardId",combank.CardId),
        new SqlParameter("@cardName",combank.CardName),
        new SqlParameter("@remark",combank.Remark)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[ComBank]表修改的方法
        /// </summary>
        public static int updateComBankById(ComBank combank)
        {

            string sql = "update ComBank set companyId=@companyId,bank=@bank,cardId=@cardId,cardName=@cardName,remark=@remark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",combank.Id),
        new SqlParameter("@companyId",combank.CompanyId),
        new SqlParameter("@bank",combank.Bank),
        new SqlParameter("@cardId",combank.CardId),
        new SqlParameter("@cardName",combank.CardName),
        new SqlParameter("@remark",combank.Remark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[ComBank]表删除的方法
        /// </summary>
        public static int deleteComBankById(int id)
        {

            string sql = "delete from ComBank where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[ComBank]表查询实体的方法
        /// </summary>
        public static ComBank getComBankById(int id)
        {
            ComBank combank = null;

            string sql = "select * from ComBank where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                combank = new ComBank();
                foreach (DataRow dr in dt.Rows)
                {
                    combank.Id = Convert.ToInt32(dr["id"]);
                    combank.CompanyId = Convert.ToInt32(dr["companyId"]);
                    combank.Bank = Convert.ToString(dr["bank"]);
                    combank.CardId = Convert.ToString(dr["cardId"]);
                    combank.CardName = Convert.ToString(dr["cardName"]);
                    combank.Remark = Convert.ToString(dr["remark"]);
                }
            }

            return combank;
        }

        /// <summary>
        ///[ComBank]表查询所有的方法
        /// </summary>
        public static IList<ComBank> getComBankAll()
        {
            string sql = "select * from ComBank";
            return getComBanksBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<ComBank> getComBanksBySql(string sql)
        {
            IList<ComBank> list = new List<ComBank>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComBank combank = new ComBank();
                    combank.Id = Convert.ToInt32(dr["id"]);
                    combank.CompanyId = Convert.ToInt32(dr["companyId"]);
                    combank.Bank = Convert.ToString(dr["bank"]);
                    combank.CardId = Convert.ToString(dr["cardId"]);
                    combank.CardName = Convert.ToString(dr["cardName"]);
                    combank.Remark = Convert.ToString(dr["remark"]);
                    list.Add(combank);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static ComBank getComBankBySql(string sql)
        {
            ComBank combank = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                combank = new ComBank();
                foreach (DataRow dr in dt.Rows)
                {
                    combank.Id = Convert.ToInt32(dr["id"]);
                    combank.CompanyId = Convert.ToInt32(dr["companyId"]);
                    combank.Bank = Convert.ToString(dr["bank"]);
                    combank.CardId = Convert.ToString(dr["cardId"]);
                    combank.CardName = Convert.ToString(dr["cardName"]);
                    combank.Remark = Convert.ToString(dr["remark"]);
                }
            }
            return combank;
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from ComBank where companyId = " + id;
            return DBHelper.GetDataSet(sql);
        }

        public static int deleteComBankByCusId(int id)
        {
            string sql = "delete from ComBank where companyId=@id";
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@id",id)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }
    }
}
