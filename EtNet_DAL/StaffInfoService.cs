using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:StaffInfoService
	/// </summary>
	public class StaffInfoService
	{
		public StaffInfoService()
		{}
		#region  Method


		/// <summary>
		/// 得到ID值
		/// </summary>
		public static int GetId(string strwhere)
		{
            string strsql = " select top 1 * from StaffInfo ";
            if (strwhere != "")
            {
                strsql += " where " + strwhere;
            }
            strsql += " order by id desc ";
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strsql);
            int result = 0;
            if (tbl.Rows.Count == 1)
            {
                result = int.Parse(tbl.Rows[0]["id"].ToString());
            }
            return result;

		}



		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from StaffInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.GetReader(strSql.ToString(), parameters);
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
		public static bool Add(EtNet_Models.StaffInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StaffInfo(");
            strSql.Append("cname,ename,paperssort,papersnum,sex,nationality,nativeplace,nationtxt,birth,age,cardaddress,marriage,politics,degree,titletxt,school,major,gdate,creater,imgpath,createdate,contactaddress,phone,cellphone,wagecard,mailbox,remark,status,departid,positiontxt)");
			strSql.Append(" values (");
            strSql.Append("@cname,@ename,@paperssort,@papersnum,@sex,@nationality,@nativeplace,@nationtxt,@birth,@age,@cardaddress,@marriage,@politics,@degree,@titletxt,@school,@major,@gdate,@creater,@imgpath,@createdate,@contactaddress,@phone,@cellphone,@wagecard,@mailbox,@remark,@status,@departid,@positiontxt)");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@ename", SqlDbType.VarChar,40),
					new SqlParameter("@paperssort", SqlDbType.Int,4),
					new SqlParameter("@papersnum", SqlDbType.VarChar,40),
					new SqlParameter("@sex", SqlDbType.VarChar,10),
					new SqlParameter("@nationality", SqlDbType.VarChar,40),
					new SqlParameter("@nativeplace", SqlDbType.VarChar,100),
					new SqlParameter("@nationtxt", SqlDbType.VarChar,40),
					new SqlParameter("@birth", SqlDbType.SmallDateTime),
					new SqlParameter("@age", SqlDbType.VarChar,10),
					new SqlParameter("@cardaddress", SqlDbType.VarChar,100),
					new SqlParameter("@marriage", SqlDbType.VarChar,10),
					new SqlParameter("@politics", SqlDbType.VarChar,40),
					new SqlParameter("@degree", SqlDbType.VarChar,40),
					new SqlParameter("@titletxt", SqlDbType.VarChar,100),
					new SqlParameter("@school", SqlDbType.VarChar,100),
					new SqlParameter("@major", SqlDbType.VarChar,40),
					new SqlParameter("@gdate", SqlDbType.SmallDateTime),
					new SqlParameter("@creater", SqlDbType.Int,4),
					new SqlParameter("@imgpath", SqlDbType.VarChar,200),
					new SqlParameter("@createdate", SqlDbType.SmallDateTime),
					new SqlParameter("@contactaddress", SqlDbType.VarChar,100),
					new SqlParameter("@phone", SqlDbType.VarChar,40),
					new SqlParameter("@cellphone", SqlDbType.VarChar,40),
					new SqlParameter("@wagecard", SqlDbType.VarChar,40),
					new SqlParameter("@mailbox", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@status",SqlDbType.VarChar,40),
                    new SqlParameter("@departid",SqlDbType.Int,4),                   
                    new SqlParameter("@positiontxt",SqlDbType.VarChar,40)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ename;
			parameters[2].Value = model.paperssort;
			parameters[3].Value = model.papersnum;
			parameters[4].Value = model.sex;
			parameters[5].Value = model.nationality;
			parameters[6].Value = model.nativeplace;
			parameters[7].Value = model.nationtxt;
			parameters[8].Value = model.birth;
			parameters[9].Value = model.age;
			parameters[10].Value = model.cardaddress;
			parameters[11].Value = model.marriage;
			parameters[12].Value = model.politics;
			parameters[13].Value = model.degree;
			parameters[14].Value = model.titletxt;
			parameters[15].Value = model.school;
			parameters[16].Value = model.major;
			parameters[17].Value = model.gdate;
			parameters[18].Value = model.creater;
			parameters[19].Value = model.imgpath;
			parameters[20].Value = model.createdate;
			parameters[21].Value = model.contactaddress;
			parameters[22].Value = model.phone;
			parameters[23].Value = model.cellphone;
			parameters[24].Value = model.wagecard;
			parameters[25].Value = model.mailbox;
			parameters[26].Value = model.remark;
            parameters[27].Value = model.status;
            parameters[28].Value = model.departid;
            parameters[29].Value = model.positiontxt;
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
		public static bool Update(EtNet_Models.StaffInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StaffInfo set ");
			strSql.Append("cname=@cname,");
			strSql.Append("ename=@ename,");
			strSql.Append("paperssort=@paperssort,");
			strSql.Append("papersnum=@papersnum,");
			strSql.Append("sex=@sex,");
			strSql.Append("nationality=@nationality,");
			strSql.Append("nativeplace=@nativeplace,");
            strSql.Append("nationtxt=@nationtxt,");
			strSql.Append("birth=@birth,");
			strSql.Append("age=@age,");
			strSql.Append("cardaddress=@cardaddress,");
			strSql.Append("marriage=@marriage,");
			strSql.Append("politics=@politics,");
			strSql.Append("degree=@degree,");
			strSql.Append("titletxt=@titletxt,");
			strSql.Append("school=@school,");
			strSql.Append("major=@major,");
			strSql.Append("gdate=@gdate,");
			strSql.Append("creater=@creater,");
			strSql.Append("imgpath=@imgpath,");
			strSql.Append("createdate=@createdate,");
			strSql.Append("contactaddress=@contactaddress,");
			strSql.Append("phone=@phone,");
			strSql.Append("cellphone=@cellphone,");
			strSql.Append("wagecard=@wagecard,");
			strSql.Append("mailbox=@mailbox,");
			strSql.Append("remark=@remark,");
            strSql.Append("status=@status,");
            strSql.Append("departid=@departid,");
            strSql.Append("positiontxt=@positiontxt");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@ename", SqlDbType.VarChar,40),
					new SqlParameter("@paperssort", SqlDbType.Int,4),
					new SqlParameter("@papersnum", SqlDbType.VarChar,40),
					new SqlParameter("@sex", SqlDbType.VarChar,10),
					new SqlParameter("@nationality", SqlDbType.VarChar,40),
					new SqlParameter("@nativeplace", SqlDbType.VarChar,100),
					new SqlParameter("@nationtxt", SqlDbType.VarChar,40),
					new SqlParameter("@birth", SqlDbType.SmallDateTime),
					new SqlParameter("@age", SqlDbType.VarChar,10),
					new SqlParameter("@cardaddress", SqlDbType.VarChar,100),
					new SqlParameter("@marriage", SqlDbType.VarChar,10),
					new SqlParameter("@politics", SqlDbType.VarChar,40),
					new SqlParameter("@degree", SqlDbType.VarChar,40),
					new SqlParameter("@titletxt", SqlDbType.VarChar,100),
					new SqlParameter("@school", SqlDbType.VarChar,100),
					new SqlParameter("@major", SqlDbType.VarChar,40),
					new SqlParameter("@gdate", SqlDbType.SmallDateTime),
					new SqlParameter("@creater", SqlDbType.Int,4),
					new SqlParameter("@imgpath", SqlDbType.VarChar,200),
					new SqlParameter("@createdate", SqlDbType.SmallDateTime),
					new SqlParameter("@contactaddress", SqlDbType.VarChar,100),
					new SqlParameter("@phone", SqlDbType.VarChar,40),
					new SqlParameter("@cellphone", SqlDbType.VarChar,40),
					new SqlParameter("@wagecard", SqlDbType.VarChar,40),
					new SqlParameter("@mailbox", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@status",SqlDbType.VarChar,40),
                    new SqlParameter("@departid",SqlDbType.Int,4),                   
                    new SqlParameter("@positiontxt",SqlDbType.VarChar,40),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ename;
			parameters[2].Value = model.paperssort;
			parameters[3].Value = model.papersnum;
			parameters[4].Value = model.sex;
			parameters[5].Value = model.nationality;
			parameters[6].Value = model.nativeplace;
			parameters[7].Value = model.nationtxt;
			parameters[8].Value = model.birth;
			parameters[9].Value = model.age;
			parameters[10].Value = model.cardaddress;
			parameters[11].Value = model.marriage;
			parameters[12].Value = model.politics;
			parameters[13].Value = model.degree;
			parameters[14].Value = model.titletxt;
			parameters[15].Value = model.school;
			parameters[16].Value = model.major;
			parameters[17].Value = model.gdate;
			parameters[18].Value = model.creater;
			parameters[19].Value = model.imgpath;
			parameters[20].Value = model.createdate;
			parameters[21].Value = model.contactaddress;
			parameters[22].Value = model.phone;
			parameters[23].Value = model.cellphone;
			parameters[24].Value = model.wagecard;
			parameters[25].Value = model.mailbox;
			parameters[26].Value = model.remark;
            parameters[27].Value = model.status;
            parameters[28].Value = model.departid;
            parameters[29].Value = model.positiontxt;
			parameters[30].Value = model.id;

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
			strSql.Append("delete from StaffInfo ");
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
			strSql.Append("delete from StaffInfo ");
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
		public static EtNet_Models.StaffInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from StaffInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.StaffInfo model = new EtNet_Models.StaffInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.ename = tbl.Rows[0]["ename"].ToString();
                model.paperssort = int.Parse(tbl.Rows[0]["paperssort"].ToString());
                model.papersnum = tbl.Rows[0]["papersnum"].ToString();
                model.sex = tbl.Rows[0]["sex"].ToString();
                model.nationality = tbl.Rows[0]["nationality"].ToString();
                model.nativeplace = tbl.Rows[0]["nativeplace"].ToString();
                model.nationtxt = tbl.Rows[0]["nationtxt"].ToString();
                model.birth = DateTime.Parse(tbl.Rows[0]["birth"].ToString());
                model.age = tbl.Rows[0]["age"].ToString();
                model.cardaddress = tbl.Rows[0]["cardaddress"].ToString();
                model.marriage = tbl.Rows[0]["marriage"].ToString();
                model.politics = tbl.Rows[0]["politics"].ToString();
                model.degree = tbl.Rows[0]["degree"].ToString();
                model.titletxt = tbl.Rows[0]["titletxt"].ToString();
                model.school = tbl.Rows[0]["school"].ToString();
                model.major = tbl.Rows[0]["major"].ToString();
                model.gdate = DateTime.Parse(tbl.Rows[0]["gdate"].ToString());
                model.creater = int.Parse(tbl.Rows[0]["creater"].ToString());
                model.imgpath = tbl.Rows[0]["imgpath"].ToString();
                model.createdate = DateTime.Parse(tbl.Rows[0]["createdate"].ToString());
                model.contactaddress = tbl.Rows[0]["contactaddress"].ToString();
                model.phone = tbl.Rows[0]["phone"].ToString();
                model.cellphone = tbl.Rows[0]["cellphone"].ToString();
                model.wagecard = tbl.Rows[0]["wagecard"].ToString();
                model.mailbox = tbl.Rows[0]["mailbox"].ToString();
                model.remark = tbl.Rows[0]["remark"].ToString();
                model.status = tbl.Rows[0]["status"].ToString();
                model.departid = int.Parse(tbl.Rows[0]["departid"].ToString());
                model.positiontxt = tbl.Rows[0]["positiontxt"].ToString();
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
			strSql.Append(" FROM StaffInfo ");
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
			strSql.Append(" FROM StaffInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

	
		#endregion  Method
	}
}

