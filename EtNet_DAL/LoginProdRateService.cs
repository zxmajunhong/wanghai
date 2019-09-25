using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_DAL
{
    public class LoginProdRateService
    {
        public LoginProdRateService()
        { }
        #region
        /// <summary>
        /// 检查是否存在该记录
        /// </summary>
        /// <param name="prodname">险种名称</param>
        /// <param name="username">人员名称</param>
        /// <returns></returns>
        public static bool Exists(string prodname, string username)
        {
            string sql = "select * from LoginProdRate where prodname=@prodname and username=@username";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@prodname",prodname),
                new SqlParameter("@username",username)
            };

            DataTable dt = DBHelper.GetDataSet(sql, sp);
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
        public static bool Add(LoginProdRate model)
        {
            string sql = "insert into LoginProdRate([prodname],[prodid],[username],[userid],[rate]) values(@prodname,@prodid,@username,@userid,@rate)";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@prodname",model.ProdName),
                new SqlParameter("@prodid",model.ProdId),
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@userid",model.UserId),
                new SqlParameter("@rate",model.Rate)
            };

            int result = DBHelper.ExecuteCommand(sql, sp);
            if (result > 0)
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
        public static bool Update(LoginProdRate model)
        {
            string sql = "update LoginProdRate set prodname=@prodname,prodid=@prodid,username=@username,userid=@userid,rate=@rate where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",model.ID),
                new SqlParameter("@prodname",model.ProdName),
                new SqlParameter("@prodid",model.ProdId),
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@userid",model.UserId),
                new SqlParameter("@rate",model.Rate)
            };

            int result = DBHelper.ExecuteCommand(sql, sp);
            if (result > 0)
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
            string sql = "delete from LoginProdRate where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id)
            };

            int result = DBHelper.ExecuteCommand(sql, sp);
            if (result > 0)
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
        public static LoginProdRate GetModel(int id)
        {
            LoginProdRate model = null;
            string sql = "select * from LoginProdRate where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id)
            };

            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                model = new LoginProdRate();
                foreach (DataRow dr in dt.Rows)
                {
                    model.ID = Convert.ToInt32(dr["id"]);
                    model.ProdName = Convert.ToString(dr["prodname"]);
                    model.ProdId = Convert.ToString(dr["prodid"]);
                    model.UserName = Convert.ToString(dr["username"]);
                    model.UserId = Convert.ToString(dr["userid"]);
                    model.Rate = Convert.IsDBNull(dr["rate"]) ? 0.0 : Convert.ToDouble(dr["rate"]);
                }
            }

            return model;
        }

        /// <summary>
        /// 根据险种名称和人员名称得到一个对象实体
        /// </summary>
        /// <param name="prodname">险种名称</param>
        /// <param name="username">人员名称</param>
        /// <returns></returns>
        public static LoginProdRate GetModelByProdnameUsername(string prodname, string username)
        {
            LoginProdRate model = null;
            string sql = "select * from LoginProdRate where prodname=@prodname and username=@username";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@prodname",prodname),
                new SqlParameter("@username",username)
            };

            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                model = new LoginProdRate();
                foreach (DataRow dr in dt.Rows)
                {
                    model.ID = Convert.ToInt32(dr["id"]);
                    model.ProdName = Convert.ToString(dr["prodname"]);
                    model.ProdId = Convert.ToString(dr["prodid"]);
                    model.UserName = Convert.ToString(dr["username"]);
                    model.UserId = Convert.ToString(dr["userid"]);
                    model.Rate = Convert.IsDBNull(dr["rate"]) ? 0.0 : Convert.ToDouble(dr["rate"]);
                }
            }

            return model;
        }

        /// <summary>
        /// 根据险种名称得到对象集合
        /// </summary>
        /// <param name="prodname"></param>
        /// <returns></returns>
        public static IList<LoginProdRate> GetModelsByProdname(string prodname)
        {
            string sql = "select * from LoginProdRate where prodname='" + prodname + "'";
            return GetModelsBySql(sql);
        }

        /// <summary>
        /// 根据人员名称得到对象集合
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static IList<LoginProdRate> GetModelsByUsername(string username)
        {
            string sql = "select * from LoginProdRate where username='" + username + "'";
            return GetModelsBySql(sql);
        }

        /// <summary>
        /// 根据sql语句得到对象集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static IList<LoginProdRate> GetModelsBySql(string sql)
        {
            IList<LoginProdRate> list = new List<LoginProdRate>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LoginProdRate model = new LoginProdRate();
                    model.ID = Convert.ToInt32(dr["id"]);
                    model.ProdName = Convert.ToString(dr["prodname"]);
                    model.ProdId = Convert.ToString(dr["prodid"]);
                    model.UserName = Convert.ToString(dr["username"]);
                    model.UserId = Convert.ToString(dr["userid"]);
                    model.Rate = Convert.IsDBNull(dr["rate"]) ? 0.0 : Convert.ToDouble(dr["rate"]);
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion
    }
}
