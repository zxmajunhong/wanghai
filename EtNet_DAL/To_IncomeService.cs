using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_DAL
{
    public class To_IncomeService
    {
        public static int Add(To_Income income)
        {
            string sql = "insert into To_Income([comeDate],[comeMoney],[comeBankName],[comeBankId],[comeBankAccount],[comeDepart],[comeDepartId],[makeName],[makeId],[remark],[makeDate],[comeUnit],[comeTypeid],[comeType]) values (@comeDate,@comeMoney,@comeBankName,@comeBankId,@comeBankAccount,@comeDepart,@comeDepartId,@makeName,@makeId,@remark,@makeDate,@comeUnit,@comeTypeid,@comeType)";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@comeDate",income.ComeDate),
                new SqlParameter("@comeMoney",income.ComeMoney),
                new SqlParameter("@comeBankName",income.ComeBankName),
                new SqlParameter("@comeBankId",income.ComeBankId),
                new SqlParameter("@comeBankAccount",income.ComeBankAccount),
                new SqlParameter("@comeDepart",income.ComeDepart),
                new SqlParameter("@comeDepartId",income.ComeDepartId),
                new SqlParameter("@makeName",income.MakeName),
                new SqlParameter("@makeId",income.MakeId),
                new SqlParameter("@remark",income.Remark),
                new SqlParameter("@makeDate",income.MakeDate),
                new SqlParameter("@comeUnit",income.ComeUnit),
                new SqlParameter("@comeTypeid",income.SKTypeId),
                new SqlParameter("@comeType",income.SKType)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static int Update(To_Income income)
        {
            string sql = "update To_Income set comeDate=@comeDate,comeMoney=@comeMoney,comeBankName=@comeBankName,comeBankId=@comeBankId,comeBankAccount=@comeBankAccount,comeDepart=@comeDepart,comeDepartId=@comeDepartId,makeName=@makeName,makeId=@makeId,remark=@remark,makeDate=@makeDate,comeUnit=@comeUnit,comeTypeid=@comeTypeid,comeType=@comeType where Id=@Id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@Id",income.ID),
                new SqlParameter("@comeDate",income.ComeDate),
                new SqlParameter("@comeMoney",income.ComeMoney),
                new SqlParameter("@comeBankName",income.ComeBankName),
                new SqlParameter("@comeBankId",income.ComeBankId),
                new SqlParameter("@comeBankAccount",income.ComeBankAccount),
                new SqlParameter("@comeDepart",income.ComeDepart),
                new SqlParameter("@comeDepartId",income.ComeDepartId),
                new SqlParameter("@makeName",income.MakeName),
                new SqlParameter("@makeId",income.MakeId),
                new SqlParameter("@remark",income.Remark),
                new SqlParameter("@makeDate",income.MakeDate),
                new SqlParameter("@comeUnit",income.ComeUnit),
                new SqlParameter("@comeTypeid",income.SKTypeId),
                new SqlParameter("@comeType",income.SKType)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static DataTable GetList(string strWhere)
        {
            string sql = "select * from To_Income ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }

        public static int Delete(int id)
        {
            string sql = " delete To_Income where Id = " + id;
            return DBHelper.ExecuteCommand(sql);
        }

        public static To_Income GetModel(string id)
        {
            string sql = "select * from To_Income where Id = " + id;
            return getTo_IncomeBySql(sql);
        }

        public static To_Income getTo_IncomeBySql(string sql)
        {
            DataTable dt = DBHelper.GetDataSet(sql);
            To_Income model = null;
            if (dt.Rows.Count > 0)
            {
                model = new To_Income();
                foreach (DataRow dr in dt.Rows)
                {
                    model.ID = Convert.ToInt32(dr["Id"]);
                    model.ComeDate = Convert.ToDateTime(dr["comeDate"]);
                    model.ComeMoney = Convert.ToDouble(dr["comeMoney"]);
                    model.ComeBankName = Convert.ToString(dr["comeBankName"]);
                    model.ComeBankId = Convert.ToInt32(dr["comeBankId"]);
                    model.ComeBankAccount = Convert.ToString(dr["comeBankAccount"]);
                    model.ComeDepart = Convert.ToString(dr["comeDepart"]);
                    model.ComeDepartId = Convert.ToInt32(dr["comeDepartId"]);
                    model.MakeName = Convert.ToString(dr["makeName"]);
                    model.MakeId = Convert.ToInt32(dr["makeId"]);
                    model.MakeDate = Convert.ToDateTime(dr["makeDate"]);
                    model.Remark = Convert.ToString(dr["remark"]);
                    model.ComeUnit = Convert.ToString(dr["comeUnit"]);
                    model.SKTypeId = Convert.ToInt32(dr["comeTypeid"]);
                    model.SKType = Convert.ToString(dr["comeType"]);
                }
            }

            return model;
        }
    }
}
