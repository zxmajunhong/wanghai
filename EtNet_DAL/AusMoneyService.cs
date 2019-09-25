using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_DAL
{
    public class AusMoneyService
    {
        public AusMoneyService()
        { }
        #region

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool Exists(string itemname, string username,int year)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DepartMoney");
            strSql.Append(" where itemname=@itemname");
            strSql.Append(" and username=@username");
            strSql.Append(" and years=@years");
            SqlParameter[] parameters = {
                new SqlParameter("@itemname",SqlDbType.VarChar,20),
                new SqlParameter("@username",SqlDbType.VarChar,20),
                new SqlParameter("@years",SqlDbType.Int,4)
                                        };
            parameters[0].Value = itemname;
            parameters[1].Value = username;
            parameters[2].Value = year;

            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(AusMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DepartMoney(");
            strSql.Append("itemname,username,amount,years)");
            strSql.Append(" values (");
            strSql.Append("@itemname,@username,@amount,@years)");

            SqlParameter[] parameters = {
                new SqlParameter("@itemname",SqlDbType.VarChar,20),
                new SqlParameter("@username",SqlDbType.VarChar,20),
                new SqlParameter("@amount",SqlDbType.Money,8),
                new SqlParameter("@years",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.itemname;
            parameters[1].Value = model.username;
            parameters[2].Value = model.amount;
            parameters[3].Value = model.year;
            int result = DBHelper.ExecuteCommand(strSql.ToString(),parameters);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(AusMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DepartMoney set ");
            strSql.Append(" username=@username,amount=@amount");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = 
            {
                new SqlParameter("@username",SqlDbType.VarChar,20),
                new SqlParameter("@amount",SqlDbType.Money,8),
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            parameters[0].Value = model.username;
            parameters[1].Value = model.amount;
            parameters[2].Value = model.id;

            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新以支付的金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateMoney(AusMoney model)
        {
            string str = "update DepartMoney set haspay=@haspay where id=@id";
            SqlParameter[] parameters = 
            {
                new SqlParameter("@haspay",SqlDbType.Money,8),
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            parameters[0].Value = model.haspay;
            parameters[1].Value = model.id;

            int result = DBHelper.ExecuteCommand(str, parameters);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DepartMoney ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = 
            {
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DepartMoney ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int result = DBHelper.ExecuteCommand(strSql.ToString());
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象的实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AusMoney GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DepartMoney ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = 
            {
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            AusMoney model = new AusMoney();

            DataTable ds = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                model.id = Convert.ToInt32(ds.Rows[0]["ID"]);
                model.itemname = Convert.ToString(ds.Rows[0]["itemname"]);
                model.username = Convert.ToString(ds.Rows[0]["username"]);
                model.amount = Convert.IsDBNull(ds.Rows[0]["amount"]) ? 0.0 : Convert.ToDouble(ds.Rows[0]["amount"]);
                model.haspay = Convert.IsDBNull(ds.Rows[0]["haspay"]) ? 0.0 : Convert.ToDouble(ds.Rows[0]["haspay"]);
                model.year = Convert.ToInt32(ds.Rows[0]["years"]);

            }
            return model;
        }

        /// <summary>
        /// 根据项目名称,年份和人员得到实体
        /// </summary>
        /// <param name="itemname">项目名称</param>
        /// <param name="username">人员</param>
        /// <returns></returns>
        public static AusMoney GetModelbyname(string itemname, string username, int years)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DepartMoney");
            strSql.Append(" where itemname=@itemname");
            strSql.Append(" and username=@username");
            strSql.Append(" and years=@years");
            SqlParameter[] parameters = {
                new SqlParameter("@itemname",SqlDbType.VarChar,20),
                new SqlParameter("@username",SqlDbType.VarChar,20),
                new SqlParameter("@years",SqlDbType.Int,4)
                                        };
            parameters[0].Value = itemname;
            parameters[1].Value = username;
            parameters[2].Value = years;

            AusMoney model = new AusMoney();
            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model.id = Convert.ToInt32(dt.Rows[0]["ID"]);
                model.itemname = Convert.ToString(dt.Rows[0]["itemname"]);
                model.username = Convert.ToString(dt.Rows[0]["username"]);
                model.amount = Convert.IsDBNull(dt.Rows[0]["amount"]) ? 0.0 : Convert.ToDouble(dt.Rows[0]["amount"]);
                model.haspay = Convert.IsDBNull(dt.Rows[0]["haspay"]) ? 0.0 : Convert.ToDouble(dt.Rows[0]["haspay"]);
                model.year = Convert.ToInt32(dt.Rows[0]["years"]);
            }
            return model;
        }


        #endregion
    }
}
