using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[CusBank]������ݷ�����
    /// </summary>
    public class CusBankService
    {
        /// <summary>
        ///[CusBank]����ӵķ���
        /// </summary>
        public static int addCusBank(CusBank cusbank)
        {
            string sql = "insert into CusBank([customerId],[bank],[cardId],[cardName],[remark]) values (@customerId,@bank,@cardId,@cardName,@remark)";
            SqlParameter[] sp = new SqlParameter[]
          {
            new SqlParameter("@customerId",cusbank.CustomerId),
            new SqlParameter("@bank",cusbank.Bank),
            new SqlParameter("@cardId",cusbank.CardId),
            new SqlParameter("@cardName",cusbank.CardName),
            new SqlParameter("@remark",cusbank.Remark)
          };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[CusBank]���޸ĵķ���
        /// </summary>
        public static int updateCusBankById(CusBank cusbank)
        {

            string sql = "update CusBank set customerId=@customerId,bank=@bank,cardId=@cardId,cardName=@cardName,remark=@remark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",cusbank.Id),
        new SqlParameter("@customerId",cusbank.CustomerId),
        new SqlParameter("@bank",cusbank.Bank),
        new SqlParameter("@cardId",cusbank.CardId),
        new SqlParameter("@cardName",cusbank.CardName),
        new SqlParameter("@remark",cusbank.Remark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[CusBank]��ɾ���ķ���
        /// </summary>
        public static int deleteCusBankById(int id)
        {

            string sql = "delete from CusBank where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[CusBank]���ѯʵ��ķ���
        /// </summary>
        public static CusBank getCusBankById(int id)
        {
            CusBank cusbank = null;

            string sql = "select * from CusBank where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                cusbank = new CusBank();
                foreach (DataRow dr in dt.Rows)
                {
                    cusbank.Id = Convert.ToInt32(dr["id"]);
                    cusbank.CustomerId = Convert.ToInt32(dr["customerId"]);
                    cusbank.Bank = Convert.ToString(dr["bank"]);
                    cusbank.CardId = Convert.ToString(dr["cardId"]);
                    cusbank.CardName = Convert.ToString(dr["cardName"]);
                    cusbank.Remark = Convert.ToString(dr["remark"]);
                }
            }

            return cusbank;
        }

        /// <summary>
        ///[CusBank]���ѯ���еķ���
        /// </summary>
        public static IList<CusBank> getCusBankAll()
        {
            string sql = "select * from CusBank";
            return getCusBanksBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<CusBank> getCusBanksBySql(string sql)
        {
            IList<CusBank> list = new List<CusBank>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CusBank cusbank = new CusBank();
                    cusbank.Id = Convert.ToInt32(dr["id"]);
                    cusbank.CustomerId = Convert.ToInt32(dr["customerId"]);
                    cusbank.Bank = Convert.ToString(dr["bank"]);
                    cusbank.CardId = Convert.ToString(dr["cardId"]);
                    cusbank.CardName = Convert.ToString(dr["cardName"]);
                    cusbank.Remark = Convert.ToString(dr["remark"]);
                    list.Add(cusbank);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static CusBank getCusBankBySql(string sql)
        {
            CusBank cusbank = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                cusbank = new CusBank();
                foreach (DataRow dr in dt.Rows)
                {
                    cusbank.Id = Convert.ToInt32(dr["id"]);
                    cusbank.CustomerId = Convert.ToInt32(dr["customerId"]);
                    cusbank.Bank = Convert.ToString(dr["bank"]);
                    cusbank.CardId = Convert.ToString(dr["cardId"]);
                    cusbank.CardName = Convert.ToString(dr["cardName"]);
                    cusbank.Remark = Convert.ToString(dr["remark"]);
                }
            }
            return cusbank;
        }

        public static IList<CusBank> getCusBankByCusId(int cusId)
        {
            string sql = "select * from CusBank where customerId =" + cusId;
            return getCusBanksBySql(sql);
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from CusBank where customerId = " + id;
            return DBHelper.GetDataSet(sql);
        }

        public static int deleteCusBankByCusId(int id)
        {
            string sql = "delete from CusBank where customerId=@id";
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@id",id)
            };
            return DBHelper.ExecuteCommand(sql, sp);

        }
    }
}
