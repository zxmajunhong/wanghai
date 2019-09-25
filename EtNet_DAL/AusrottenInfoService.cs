using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:AusRottenInfo
	/// </summary>
	public  class AusRottenInfoService
	{
		public AusRottenInfoService()
		{}
		#region  Method

	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AusRottenInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.ExecuteReader(strSql.ToString(), parameters);
            if (rad.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
			
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add( EtNet_Models.AusRottenInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AusRottenInfo(");
            strSql.Append("applydate,applycantid,totalmoney,remark,txt,jobflowid,billstate,itemtype,person,banker,bankname,banknum)");
			strSql.Append(" values (");
            strSql.Append("@applydate,@applycantid,@totalmoney,@remark,@txt,@jobflowid,@billstate,@itemtype,@person,@banker,@bankname,@banknum)");
			
			SqlParameter[] parameters = {
					new SqlParameter("@applydate", SqlDbType.Date,3),
					new SqlParameter("@applycantid", SqlDbType.Int,4),
					new SqlParameter("@totalmoney", SqlDbType.Money,8),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@txt", SqlDbType.VarChar,200),
                    new SqlParameter("@jobflowid",SqlDbType.Int,4),
                    new SqlParameter("@itemtype",SqlDbType.VarChar,100),
                    new SqlParameter("@billstate",SqlDbType.Int,4),
                    new SqlParameter("@person",SqlDbType.VarChar,100),
                    new SqlParameter("@banker",SqlDbType.VarChar,50),
                    new SqlParameter("@bankname",SqlDbType.VarChar,100),
                    new SqlParameter("@banknum",SqlDbType.VarChar,100)
                                        };
			parameters[0].Value = model.applydate;
			parameters[1].Value = model.applycantid;
			parameters[2].Value = model.totalmoney;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.txt;
            parameters[5].Value = model.jobflowid;
            parameters[6].Value = model.itemtype;
            parameters[7].Value = model.billstate;
            parameters[8].Value = model.person;
            parameters[9].Value = model.Banker;
            parameters[10].Value = model.BankName;
            parameters[11].Value = model.bankNum;

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(),parameters);
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
		public static bool Update(EtNet_Models.AusRottenInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AusRottenInfo set ");
			strSql.Append("applydate=@applydate,");
			strSql.Append("applycantid=@applycantid,");
			strSql.Append("totalmoney=@totalmoney,");
			strSql.Append("remark=@remark,");
			strSql.Append("txt=@txt,");
            strSql.Append("jobflowid=@jobflowid,");
            strSql.Append("billstate=@billstate,");
            strSql.Append("itemtype=@itemtype,");
            strSql.Append("person=@person,");
            strSql.Append("banker=@banker,");
            strSql.Append("bankname=@bankname,");
            strSql.Append("banknum=@banknum");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@applydate", SqlDbType.Date,3),
					new SqlParameter("@applycantid", SqlDbType.Int,4),
					new SqlParameter("@totalmoney", SqlDbType.Money,8),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@txt", SqlDbType.VarChar,200),
                    new SqlParameter("@jobflowid",SqlDbType.Int,4),
                    new SqlParameter("@billstate",SqlDbType.Int,4),
                    new SqlParameter("@itemtype",SqlDbType.VarChar,100),
                    new SqlParameter("@person",SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@banker",SqlDbType.VarChar,50),
                    new SqlParameter("@bankname",SqlDbType.VarChar,100),
                    new SqlParameter("@banknum",SqlDbType.VarChar,100)
                                        };
                

			parameters[0].Value = model.applydate;
			parameters[1].Value = model.applycantid;
			parameters[2].Value = model.totalmoney;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.txt;
            parameters[5].Value = model.jobflowid;
            parameters[6].Value = model.billstate;
            parameters[7].Value = model.itemtype;
            parameters[8].Value = model.person;
            parameters[9].Value = model.id;
            parameters[10].Value = model.Banker;
            parameters[11].Value = model.BankName;
            parameters[12].Value = model.bankNum;
          
            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AusRottenInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
			strSql.Append("delete from AusRottenInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString());
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
        /// 依据指定的条件删除数据
        /// </summary>
        public static bool Del(string strWhere)
        {
          
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusRottenInfo ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            else
            { }
            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString());
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
		public static EtNet_Models.AusRottenInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AusRottenInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.AusRottenInfo model = new EtNet_Models.AusRottenInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
			    model.id=int.Parse(tbl.Rows[0]["id"].ToString());
			    model.applydate=DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
			    model.applycantid=int.Parse(tbl.Rows[0]["applycantid"].ToString());
				model.totalmoney=decimal.Parse(tbl.Rows[0]["totalmoney"].ToString());
			    model.remark=tbl.Rows[0]["remark"].ToString();
			    model.txt=tbl.Rows[0]["txt"].ToString();
                model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                model.billstate = int.Parse(tbl.Rows[0]["billstate"].ToString());
                model.itemtype = tbl.Rows[0]["itemtype"].ToString();
                model.person = tbl.Rows[0]["person"].ToString();
                model.Banker = tbl.Rows[0]["banker"].ToString();
                model.BankName = tbl.Rows[0]["bankname"].ToString();
                model.bankNum = tbl.Rows[0]["banknum"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 根据工作流id得到对象实体
        /// </summary>
        /// <param name="jobflowid"></param>
        /// <returns></returns>
        public static EtNet_Models.AusRottenInfo GetModelByjob(int jobflowid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusRottenInfo ");
            strSql.Append(" where jobflowid=@jobflowid");
            SqlParameter[] parameters = {
					new SqlParameter("@jobflowid", SqlDbType.Int,4)};
            parameters[0].Value = jobflowid;

            EtNet_Models.AusRottenInfo model = new EtNet_Models.AusRottenInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
            {
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
                model.applycantid = int.Parse(tbl.Rows[0]["applycantid"].ToString());
                model.totalmoney = decimal.Parse(tbl.Rows[0]["totalmoney"].ToString());
                model.remark = tbl.Rows[0]["remark"].ToString();
                model.txt = tbl.Rows[0]["txt"].ToString();
                model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                model.billstate = int.Parse(tbl.Rows[0]["billstate"].ToString());
                model.itemtype = tbl.Rows[0]["itemtype"].ToString();
                model.person = tbl.Rows[0]["person"].ToString();
                model.Banker = tbl.Rows[0]["banker"].ToString();
                model.BankName = tbl.Rows[0]["bankname"].ToString();
                model.bankNum = tbl.Rows[0]["banknum"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public static DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
            strSql.Append(" FROM AusRottenInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetViewList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AusOrderView ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM AusRottenInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
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
			parameters[0].Value = "AusRottenInfo";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        public static int Clear()
        {
            string sql = "truncate table AusRottenInfo;truncate table AusDetialInfo;truncate table RegReimbursement;truncate table ReimbursementInvoice";
            return DBHelper.ExecuteCommand(sql);
                
        }
    }
}

