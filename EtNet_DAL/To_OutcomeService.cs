using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_DAL
{
    public class To_OutcomeService
    {
        public static int Add(To_Outcome outcome)
        {
            string sql = "insert into To_Outcome([outComeDate],[outComeItem],[outComeItemid],[outComeStatus],[comeUnit],[outComeMoney],[outComeBankName],[outComeBankId],[outComeBankAccount],[outComeDepart],[outComeDepartId],[makeName],[makeId],[makeDate],[remark]) values (@outComeDate,@outComeItem,@outComeItemid,@outComeStatus,@comeUnit,@outComeMoney,@outComeBankName,@outComeBankId,@outComeBankAccount,@outComeDepart,@outComeDepartId,@makeName,@makeId,@makeDate,@remark)";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@outComeDate",outcome.OutComeDate),
                new SqlParameter("@outComeItem",outcome.OutComeItem),
                new SqlParameter("@outComeItemid",outcome.OutComeItemId),
                new SqlParameter("@outComeStatus",outcome.OutComeStatus),
                new SqlParameter("@comeUnit",outcome.ComeUnit),
                new SqlParameter("@outComeMoney",outcome.OutComeMoney),
                new SqlParameter("@outComeBankName",outcome.OutComeBankName),
                new SqlParameter("@outComeBankId",outcome.OutComeBankId),
                new SqlParameter("@outComeBankAccount",outcome.OutComeBankAccount),
                new SqlParameter("@outComeDepart",outcome.OutComeDepart),
                new SqlParameter("@outComeDepartId",outcome.OutComeDepartId),
                new SqlParameter("@makeName",outcome.MakeName),
                new SqlParameter("@makeId",outcome.MakeId),
                new SqlParameter("@makeDate",outcome.MakeDate),
                new SqlParameter("@remark",outcome.Remark)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static int Update(To_Outcome outcome)
        {
            string sql = "update To_Outcome set outComeDate=@outComeDate,outComeItem=@outComeItem,outComeItemid=@outComeItemid,outComeStatus=@outComeStatus,comeUnit=@comeUnit,outComeMoney=@outComeMoney,outComeBankName=@outComeBankName,outComeBankId=@outComeBankId,outComeBankAccount=@outComeBankAccount,outComeDepart=@outComeDepart,outComeDepartId=@outComeDepartId,makeName=@makeName,makeId=@makeId,makeDate=@makeDate,remark=@remark where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",outcome.ID),
                new SqlParameter("@outComeDate",outcome.OutComeDate),
                new SqlParameter("@outComeItem",outcome.OutComeItem),
                new SqlParameter("@outComeItemid",outcome.OutComeItemId),
                new SqlParameter("@outComeStatus",outcome.OutComeStatus),
                new SqlParameter("@comeUnit",outcome.ComeUnit),
                new SqlParameter("@outComeMoney",outcome.OutComeMoney),
                new SqlParameter("@outComeBankName",outcome.OutComeBankName),
                new SqlParameter("@outComeBankId",outcome.OutComeBankId),
                new SqlParameter("@outComeBankAccount",outcome.OutComeBankAccount),
                new SqlParameter("@outComeDepart",outcome.OutComeDepart),
                new SqlParameter("@outComeDepartId",outcome.OutComeDepartId),
                new SqlParameter("@makeName",outcome.MakeName),
                new SqlParameter("@makeId",outcome.MakeId),
                new SqlParameter("@makeDate",outcome.MakeDate),
                new SqlParameter("@remark",outcome.Remark)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static int Delete(int id)
        {
            string sql = "delete To_Outcome where id=" + id;
            return DBHelper.ExecuteCommand(sql);
        }

        public static To_Outcome GetModel(string id)
        {
            string sql = "select * from To_Outcome where id=" + id;
            return getTo_OutcomeBySql(sql);
        }

        public static To_Outcome getTo_OutcomeBySql(string sql)
        {
            DataTable dt = DBHelper.GetDataSet(sql);
            To_Outcome model = null;
            if (dt.Rows.Count > 0)
            {
                model = new To_Outcome();
                foreach (DataRow dr in dt.Rows)
                {
                    model.ID = Convert.ToInt32(dr["Id"]);
                    model.OutComeDate = Convert.ToDateTime(dr["outComeDate"]);
                    model.OutComeItem = Convert.ToString(dr["outComeItem"]);
                    model.OutComeItemId = Convert.IsDBNull(dr["outComeItemid"]) ? 0 : Convert.ToInt32(dr["outComeItemid"]);
                    model.OutComeStatus = Convert.ToString(dr["outComeStatus"]);
                    model.ComeUnit = Convert.ToString(dr["comeUnit"]);
                    model.OutComeMoney = Convert.ToDouble(dr["outComeMoney"]);
                    model.OutComeBankName = Convert.ToString(dr["outComeBankName"]);
                    model.OutComeBankId = Convert.ToInt32(dr["outComeBankId"]);
                    model.OutComeBankAccount = Convert.ToString(dr["outComeBankAccount"]);
                    model.OutComeDepart = Convert.ToString(dr["outComeDepart"]);
                    model.OutComeDepartId = Convert.ToInt32(dr["outComeDepartId"]);
                    model.MakeName = Convert.ToString(dr["makeName"]);
                    model.MakeId = Convert.ToInt32(dr["makeId"]);
                    model.MakeDate = Convert.ToDateTime(dr["makeDate"]);
                    model.Remark = Convert.ToString(dr["remark"]);
                }
            }
            return model;
        }


        public static int UpdateStatus(string Id, string status)
        {
            string sql = "update To_Outcome set outComeStatus=@outComeStatus where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",Id),
                new SqlParameter("@outComeStatus",status)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }
    }
}
