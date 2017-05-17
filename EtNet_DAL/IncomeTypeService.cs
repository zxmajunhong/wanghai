using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_DAL
{
    public class IncomeTypeService
    {

        public static bool Add(IncomeType type)
        {
            string sql = "insert into IncomeType(typename) values (@typename)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@typename",type.TypeName)
            };
            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }

        public static IncomeType GetModelByName(string name)
        {
            string sql = "select * from IncomeType where typename = @typename";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@typename",name)
            };
            IncomeType model = null;
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                model = new IncomeType();
                model.id = Convert.ToInt32(dt.Rows[0]["id"]);
                model.TypeName = dt.Rows[0]["typename"].ToString();
            }
            return model;
        }

        public static IncomeType GetModel(int id)
        {
            string sql = "select * from IncomeType where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id)
            };
            IncomeType model = null;
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                model = new IncomeType();
                model.id = Convert.ToInt32(dt.Rows[0]["id"]);
                model.TypeName = dt.Rows[0]["typename"].ToString();
            }
            return model;
        }

        public static bool Update(IncomeType model)
        {
            string sql = "update IncomeType set typename = @typename  where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",model.id),
                new SqlParameter("@typename",model.TypeName)
            };
            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }

        public static bool Delete(int id)
        {
            string sql = "delete from IncomeType where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id)
            };
            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }

        public static DataTable GetList(string strWhere)
        {
            string sql = "select * from IncomeType ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }
    }
}
