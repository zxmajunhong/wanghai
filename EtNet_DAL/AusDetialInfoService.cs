using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EtNet_DAL
{
    public class AusDetialInfoService
    {
        public AusDetialInfoService()
		{}
		#region  Method

	

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AusDetialInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);
            try
            {
                if (rad.Read())
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                rad.Close();
            }

		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static int  getAusDetialInfoByAusType(string austype)
        {
            string strSql = "select count(*) from AusDetialInfo where austype='" + austype + "'";
            
            return DBHelper.ExecuteScalar(strSql);
   

        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.AusDetialInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AusDetialInfo(");
            strSql.Append("ausname,ausmoney,remark,jobflowid,happendate,billnum,belongsort,Salesman)");
			strSql.Append(" values (");
            strSql.Append("@ausname,@ausmoney,@remark,@jobflowid,@happendate,@billnum,@belongsort,@Salesman)");

            SqlParameter[] parameters = {
					new SqlParameter("@ausname", SqlDbType.VarChar,20),
					new SqlParameter("@ausmoney", SqlDbType.Money,8),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@jobflowid", SqlDbType.Int,4),
                    new SqlParameter("@happendate",SqlDbType.DateTime),
                    new SqlParameter("@billnum",SqlDbType.Int,4),
                    new SqlParameter("@belongsort", SqlDbType.VarChar,20),
                      new SqlParameter("@Salesman", SqlDbType.VarChar,20)};
                                        
			parameters[0].Value = model.ausname;
			parameters[1].Value = model.ausmoney;
			parameters[2].Value = model.remark;
            parameters[3].Value = model.jobflowid;
            parameters[4].Value = model.happendate;
            parameters[5].Value = model.billnum;
            parameters[6].Value = model.belongsort;
            parameters[7].Value = model.Salesman;

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
		/// 更新一条数据
		/// </summary>
		public static bool Update( EtNet_Models.AusDetialInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AusDetialInfo set ");
			strSql.Append("ausname=@ausname,");
			strSql.Append("ausmoney=@ausmoney,");
			strSql.Append("remark=@remark,");
            strSql.Append("jobflowid=@jobflowid,");
            strSql.Append("happendate=@happendate,");
            strSql.Append("billnum=@billnum");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@ausname", SqlDbType.VarChar,20),
					new SqlParameter("@ausmoney", SqlDbType.Money,8),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@jobflowid", SqlDbType.Int,4),
                    new SqlParameter("@happendate",SqlDbType.DateTime),
                    new SqlParameter("@billnum",SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.ausname;
			parameters[1].Value = model.ausmoney;
			parameters[2].Value = model.remark;
            parameters[3].Value = model.jobflowid;
            parameters[4].Value = model.happendate;
            parameters[5].Value = model.billnum;
			parameters[6].Value = model.id;

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

        public static bool Updatebx(int id, int jobid, string financetype)
        {
            string sql = "update AusDetialInfo set financetype=@financetype where id=@id and jobflowid=@jobflowid";
            SqlParameter[] parameters = 
            {
                new SqlParameter("@id",SqlDbType.Int,4),
                new SqlParameter("@jobflowid",SqlDbType.Int,4),
                new SqlParameter("@financetype",SqlDbType.VarChar,20)
            };
            parameters[0].Value = id;
            parameters[1].Value = jobid;
            parameters[2].Value = financetype;

            int result = DBHelper.ExecuteCommand(sql, parameters);
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
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusDetialInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
        /// 根据报销单关联的工作流的id值删除数据
        /// </summary>
        /// <param name="ausid">工作流的id值</param>

        public static bool Del(int jobflowid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusDetialInfo ");
            strSql.Append(" where jobflowid=@jobflowid");
            SqlParameter[] parameters = {
					new SqlParameter("@jobflowid", SqlDbType.Int,4)};
            parameters[0].Value = jobflowid;

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
		public static bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AusDetialInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.AusDetialInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select * from AusDetialInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.AusDetialInfo model = null;
            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);

			if(rad.Read())
			{
                model = new EtNet_Models.AusDetialInfo();
                model.id = rad.GetInt32(0);
                model.ausname = rad.GetString(1);
                model.ausmoney = rad.GetDecimal(2);
                model.remark = rad.GetString(3);
                model.jobflowid= rad.GetInt32(4);
                model.happendate = rad.GetDateTime(5);
                model.billnum = rad.GetInt32(6);

                return model;

			}
			else
			{
				return null;
			}
		}

		/// <summary>
        /// 根据指定的jobflowid获得数据列表
		/// </summary>
        public static DataTable GetLists(string jobflowid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select * ");
			strSql.Append(" FROM AusDetialInfo  ");
            strSql.Append(" where jobflowid =" + jobflowid);
            DataTable tbl = DBHelper.GetDataSet(strSql.ToString());
            return tbl;
			
		}

		/// <summary>
		/// 获得前几行数据,指定需要的行数
		/// </summary>
		public static  DataTable GetList( int Top)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" top "+Top.ToString());
            strSql.Append(" * ");
			strSql.Append(" FROM AusDetialInfo ");
            DataTable tbl = DBHelper.GetDataSet(strSql.ToString());
            return tbl;
		
		}

    



		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "AusDetialInfo";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// 得到指定条件某一列的值
        /// </summary>
        /// <param name="colname">列名</param>
        /// <param name="depart">部门</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static object GetOne(string colname, string depart, string year, string month)
        {
            string sql = "select " + colname + " from View_AusMonthMoney where belongsort = '" + depart + "' and year=" + year + " and month=" + month;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][colname];
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 得到部门月度金额累计表
        /// </summary>
        /// <param name="loginID">当前登陆人id</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DataTable GetMonthCount(int loginID, string year)
        {

            string sql = "select dataIds from LoginDataLimit where loginId=" + loginID;//查询用户数据查看权限表中的可查看id字段
            string dataIds = DBHelper.GetDataSet(sql).Rows[0]["dataIds"].ToString();
            string departcount = "";
            double depart_Month = 0; //一个部门十二个月的累计
            double month_Depart = 0; //一个月多个部门的累计
            if (dataIds != "")
                dataIds += "," + loginID.ToString();//将所登陆角色的id加入可查看权限列中
            else
                dataIds += loginID.ToString();

            string sqldepart = "select distinct departtxt from ViewLoginInfo where id in (" + dataIds + ")";
            DataTable dt = DBHelper.GetDataSet(sqldepart);


            for (int i = 0; i < dt.Rows.Count; i++) //由部门数得到行数
            {
                depart_Month = 0;
                for (int j = 1; j < 14; j++) //一到十二个月  第十三个为部门的月累计金额
                {
                    if (i == 0)
                    {
                        dt.Columns.Add(j.ToString(), typeof(object)); //增加十二个列
                    }
                    object o = GetOne("jezh", dt.Rows[i]["departtxt"].ToString(), year, j.ToString());
                    decimal d = o.ToString() == "" ? 0 : decimal.Parse(o.ToString());
                    depart_Month = Convert.ToDouble((decimal.Parse(depart_Month.ToString()) + d));

                    if (j == 13)
                    {
                        dt.Rows[i][j] = depart_Month.ToString() + "," + dt.Rows[i]["departtxt"].ToString() + "," + year + ",";//部门月累计的那列的月份数据为空
                    }
                    else
                    {
                        dt.Rows[i][j] = o.ToString() + "," + dt.Rows[i]["departtxt"].ToString() + "," + year + "," + j.ToString(); //金额，部门，年，月
                    }
                }
                departcount += "'" + dt.Rows[i]["departtxt"].ToString() + "'|";
            }

            DataRow dr = dt.NewRow();
            dr[0] = "月_部门合计";

            for (int m = 1; m < dt.Columns.Count -1; m++)
            {
                month_Depart = 0;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    double d = dt.Rows[n][m].ToString().Split(',')[0] == "" ? 0 : Convert.ToDouble(dt.Rows[n][m].ToString().Split(',')[0]);
                    month_Depart += d;
                }
                dr[m] = month_Depart.ToString() + "," + departcount + "," + year + "," + m.ToString();
            }
            dt.Rows.Add(dr);

            return dt;
        }



		#endregion  Method


    }
}
