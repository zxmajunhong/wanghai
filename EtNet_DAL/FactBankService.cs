using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[FactBank]������ݷ�����
    /// </summary>
    public class FactBankService
    {
        /// <summary>
        ///[FactBank]����ӵķ���
        /// </summary>
        public static int addFactBank(FactBank factbank)
        {
            string sql = "insert into FactBank([factId],[bank],[accountId],[accountName],[remark]) values (@factId,@bank,@accountId,@accountName,@remark)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@factId",factbank.FactId),
        new SqlParameter("@bank",factbank.Bank),
        new SqlParameter("@accountId",factbank.AccountId),
        new SqlParameter("@accountName",factbank.AccountName),
        new SqlParameter("@remark",factbank.Remark)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[FactBank]���޸ĵķ���
        /// </summary>
        public static int updateFactBankById(FactBank factbank)
        {

            string sql = "update FactBank set factId=@factId,bank=@bank,accountId=@accountId,accountName=@accountName,remark=@remark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",factbank.Id),
        new SqlParameter("@factId",factbank.FactId),
        new SqlParameter("@bank",factbank.Bank),
        new SqlParameter("@accountId",factbank.AccountId),
        new SqlParameter("@accountName",factbank.AccountName),
        new SqlParameter("@remark",factbank.Remark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[FactBank]��ɾ���ķ���
        /// </summary>
        public static int deleteFactBankById(int id)
        {

            string sql = "delete from FactBank where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[FactBank]���ѯʵ��ķ���
        /// </summary>
        public static FactBank getFactBankById(int id)
        {
            FactBank factbank = null;

            string sql = "select * from FactBank where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                factbank = new FactBank();
                foreach (DataRow dr in dt.Rows)
                {
                    factbank.Id = Convert.ToInt32(dr["id"]);
                    factbank.FactId = Convert.ToInt32(dr["factId"]);
                    factbank.Bank = Convert.ToString(dr["bank"]);
                    factbank.AccountId = Convert.ToString(dr["accountId"]);
                    factbank.AccountName = Convert.ToString(dr["accountName"]);
                    factbank.Remark = Convert.ToString(dr["remark"]);
                }
            }

            return factbank;
        }

        /// <summary>
        ///[FactBank]���ѯ���еķ���
        /// </summary>
        public static IList<FactBank> getFactBankAll()
        {
            string sql = "select * from FactBank";
            return getFactBanksBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<FactBank> getFactBanksBySql(string sql)
        {
            IList<FactBank> list = new List<FactBank>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FactBank factbank = new FactBank();
                    factbank.Id = Convert.ToInt32(dr["id"]);
                    factbank.FactId = Convert.ToInt32(dr["factId"]);
                    factbank.Bank = Convert.ToString(dr["bank"]);
                    factbank.AccountId = Convert.ToString(dr["accountId"]);
                    factbank.AccountName = Convert.ToString(dr["accountName"]);
                    factbank.Remark = Convert.ToString(dr["remark"]);
                    list.Add(factbank);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static FactBank getFactBankBySql(string sql)
        {
            FactBank factbank = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                factbank = new FactBank();
                foreach (DataRow dr in dt.Rows)
                {
                    factbank.Id = Convert.ToInt32(dr["id"]);
                    factbank.FactId = Convert.ToInt32(dr["factId"]);
                    factbank.Bank = Convert.ToString(dr["bank"]);
                    factbank.AccountId = Convert.ToString(dr["accountId"]);
                    factbank.AccountName = Convert.ToString(dr["accountName"]);
                    factbank.Remark = Convert.ToString(dr["remark"]);
                }
            }
            return factbank;
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from FactBank where factId = " + id;
            return DBHelper.GetDataSet(sql);
        }

        public static int deleteFactBankByfactId(int id)
        {
            string sql = "delete from FactBank where factId=@id";
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@id",id)
            };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        public static IList<FactBank> getFactBankByFacrId(int factId)
        {
            string sql = "select * from FactBank where factId =" + factId;
            return getFactBanksBySql(sql);
        }
    }
}
