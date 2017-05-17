using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[CusBank]表的数据访问类
    /// </summary>
    public class CusBankService
    {
        /// <summary>
        ///[CusBank]表添加的方法
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
        ///[CusBank]表修改的方法
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
        ///[CusBank]表删除的方法
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
        ///[CusBank]表查询实体的方法
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
        ///[CusBank]表查询所有的方法
        /// </summary>
        public static IList<CusBank> getCusBankAll()
        {
            string sql = "select * from CusBank";
            return getCusBanksBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
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
        ///根据SQL语句获取实体
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
