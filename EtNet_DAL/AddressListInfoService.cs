using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:AddressListInfoService
	/// </summary>
	public  class AddressListInfoService
	{
		public AddressListInfoService()
		{}
		#region  Method

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AddressListInfo");
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
		public static bool Add(EtNet_Models.AddressListInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AddressListInfo(");
            strSql.Append("cname,ename,sex,phone,cellphone,mailbox,positiontxt,departid,linkstaff,staffid,founder,createtime,remark,scellphone)");
			strSql.Append(" values (");
            strSql.Append("@cname,@ename,@sex,@phone,@cellphone,@mailbox,@positiontxt,@departid,@linkstaff,@staffid,@founder,@createtime,@remark,@scellphone)");
		
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@ename", SqlDbType.VarChar,40),
					new SqlParameter("@sex", SqlDbType.VarChar,10),
					new SqlParameter("@phone", SqlDbType.VarChar,40),
					new SqlParameter("@cellphone", SqlDbType.VarChar,40),
					new SqlParameter("@mailbox", SqlDbType.VarChar,100),
					new SqlParameter("@positiontxt", SqlDbType.VarChar,40),
					new SqlParameter("@departid", SqlDbType.Int,4),
					new SqlParameter("@linkstaff", SqlDbType.Int,4),
					new SqlParameter("@staffid", SqlDbType.Int,4),
					new SqlParameter("@founder", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@scellphone",SqlDbType.VarChar,40)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ename;
			parameters[2].Value = model.sex;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.cellphone;
			parameters[5].Value = model.mailbox;
			parameters[6].Value = model.positiontxt;
			parameters[7].Value = model.departid;
            parameters[8].Value = model.linkstaff;
            parameters[9].Value = model.staffid;
			parameters[10].Value = model.founder;
			parameters[11].Value = model.createtime;
			parameters[12].Value = model.remark;
            parameters[13].Value = model.scellphone;

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
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AddressListInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AddressListInfo set ");
			strSql.Append("cname=@cname,");
			strSql.Append("ename=@ename,");
			strSql.Append("sex=@sex,");
			strSql.Append("phone=@phone,");
			strSql.Append("cellphone=@cellphone,");
			strSql.Append("mailbox=@mailbox,");
			strSql.Append("positiontxt=@positiontxt,");
			strSql.Append("departid=@departid,");
            strSql.Append("linkstaff=@linkstaff,");
            strSql.Append("staffid=@staffid,");
			strSql.Append("founder=@founder,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("remark=@remark,");
            strSql.Append("scellphone=@scellphone");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@ename", SqlDbType.VarChar,40),
					new SqlParameter("@sex", SqlDbType.VarChar,10),
					new SqlParameter("@phone", SqlDbType.VarChar,40),
					new SqlParameter("@cellphone", SqlDbType.VarChar,40),
					new SqlParameter("@mailbox", SqlDbType.VarChar,100),
					new SqlParameter("@positiontxt", SqlDbType.VarChar,40),
					new SqlParameter("@departid", SqlDbType.Int,4),
					new SqlParameter("@linkstaff", SqlDbType.Int,4),
					new SqlParameter("@staffid", SqlDbType.Int,4),
					new SqlParameter("@founder", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@scellphone",SqlDbType.VarChar,40),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ename;
			parameters[2].Value = model.sex;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.cellphone;
			parameters[5].Value = model.mailbox;
			parameters[6].Value = model.positiontxt;
			parameters[7].Value = model.departid;
            parameters[8].Value = model.linkstaff;
            parameters[9].Value = model.staffid;
			parameters[10].Value = model.founder;
			parameters[11].Value = model.createtime;
			parameters[12].Value = model.remark;
            parameters[13].Value = model.scellphone;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from AddressListInfo ");
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
        /// 依据条件,批量删除数据
        /// </summary>
        public static bool Del(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AddressListInfo ");
            if(strwhere !="")
            { 
                strSql.Append(" where " + strwhere );
            }    
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
		/// 批量删除数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AddressListInfo ");
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
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.AddressListInfo GetModel(int id)
		{		
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from AddressListInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.AddressListInfo model = new EtNet_Models.AddressListInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.ename = tbl.Rows[0]["ename"].ToString();
                model.sex = tbl.Rows[0]["sex"].ToString();
                model.phone = tbl.Rows[0]["phone"].ToString();
                model.cellphone = tbl.Rows[0]["cellphone"].ToString();
                model.mailbox = tbl.Rows[0]["mailbox"].ToString();
                model.positiontxt = tbl.Rows[0]["positiontxt"].ToString();
                model.departid = int.Parse(tbl.Rows[0]["departid"].ToString());
                model.linkstaff = int.Parse(tbl.Rows[0]["linkstaff"].ToString());
                model.staffid = int.Parse(tbl.Rows[0]["staffid"].ToString());
                model.founder = int.Parse(tbl.Rows[0]["founder"].ToString());
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.remark = tbl.Rows[0]["remark"].ToString();
                model.scellphone = tbl.Rows[0]["scellphone"].ToString();
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
			strSql.Append(" FROM AddressListInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" FROM AddressListInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

		
		#endregion  Method

        public static int Clear()
        {
            string sql = "truncate table AddressListInfo;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}

