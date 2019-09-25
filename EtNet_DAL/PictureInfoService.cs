using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:PictureInfoService
	/// </summary>
	public  class PictureInfoService
	{
		public PictureInfoService()
		{}
		#region  Method

	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from PictureInfo");
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
		public static bool Add(EtNet_Models.PictureInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PictureInfo(");
			strSql.Append("cname,imgpath,size,format,createtime,modifytime,visiblecode,visibletxt,folderid,creater,sharecode,sharestxt,viewidlist,viewtxtlist,editidlist,edittxtlist,delidlist,deltxtlist)");
			strSql.Append(" values (");
			strSql.Append("@cname,@imgpath,@size,@format,@createtime,@modifytime,@visiblecode,@visibletxt,@folderid,@creater,@sharecode,@sharestxt,@viewidlist,@viewtxtlist,@editidlist,@edittxtlist,@delidlist,@deltxtlist)");
		
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@imgpath", SqlDbType.VarChar,200),
					new SqlParameter("@size", SqlDbType.Int,4),
					new SqlParameter("@format", SqlDbType.VarChar,10),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@modifytime", SqlDbType.DateTime),
					new SqlParameter("@visiblecode", SqlDbType.Int,4),
					new SqlParameter("@visibletxt", SqlDbType.VarChar,10),
					new SqlParameter("@folderid", SqlDbType.Int,4),
					new SqlParameter("@creater", SqlDbType.Int,4),
					new SqlParameter("@sharecode", SqlDbType.Int,4),
					new SqlParameter("@sharestxt", SqlDbType.VarChar,10),
					new SqlParameter("@viewidlist", SqlDbType.VarChar,100),
					new SqlParameter("@viewtxtlist", SqlDbType.VarChar,400),
					new SqlParameter("@editidlist", SqlDbType.VarChar,100),
					new SqlParameter("@edittxtlist", SqlDbType.VarChar,400),
					new SqlParameter("@delidlist", SqlDbType.VarChar,100),
					new SqlParameter("@deltxtlist", SqlDbType.VarChar,400)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.imgpath;
			parameters[2].Value = model.size;
			parameters[3].Value = model.format;
			parameters[4].Value = model.createtime;
			parameters[5].Value = model.modifytime;
			parameters[6].Value = model.visiblecode;
			parameters[7].Value = model.visibletxt;
			parameters[8].Value = model.folderid;
			parameters[9].Value = model.creater;
			parameters[10].Value = model.sharecode;
			parameters[11].Value = model.sharestxt;
			parameters[12].Value = model.viewidlist;
			parameters[13].Value = model.viewtxtlist;
			parameters[14].Value = model.editidlist;
			parameters[15].Value = model.edittxtlist;
			parameters[16].Value = model.delidlist;
			parameters[17].Value = model.deltxtlist;

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
		public static bool Update(EtNet_Models.PictureInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PictureInfo set ");
			strSql.Append("cname=@cname,");
			strSql.Append("imgpath=@imgpath,");
			strSql.Append("size=@size,");
			strSql.Append("format=@format,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("modifytime=@modifytime,");
			strSql.Append("visiblecode=@visiblecode,");
			strSql.Append("visibletxt=@visibletxt,");
			strSql.Append("folderid=@folderid,");
			strSql.Append("creater=@creater,");
			strSql.Append("sharecode=@sharecode,");
			strSql.Append("sharestxt=@sharestxt,");
			strSql.Append("viewidlist=@viewidlist,");
			strSql.Append("viewtxtlist=@viewtxtlist,");
			strSql.Append("editidlist=@editidlist,");
			strSql.Append("edittxtlist=@edittxtlist,");
			strSql.Append("delidlist=@delidlist,");
			strSql.Append("deltxtlist=@deltxtlist");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@imgpath", SqlDbType.VarChar,200),
					new SqlParameter("@size", SqlDbType.Int,4),
					new SqlParameter("@format", SqlDbType.VarChar,10),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@modifytime", SqlDbType.DateTime),
					new SqlParameter("@visiblecode", SqlDbType.Int,4),
					new SqlParameter("@visibletxt", SqlDbType.VarChar,10),
					new SqlParameter("@folderid", SqlDbType.Int,4),
					new SqlParameter("@creater", SqlDbType.Int,4),
					new SqlParameter("@sharecode", SqlDbType.Int,4),
					new SqlParameter("@sharestxt", SqlDbType.VarChar,10),
					new SqlParameter("@viewidlist", SqlDbType.VarChar,100),
					new SqlParameter("@viewtxtlist", SqlDbType.VarChar,400),
					new SqlParameter("@editidlist", SqlDbType.VarChar,100),
					new SqlParameter("@edittxtlist", SqlDbType.VarChar,400),
					new SqlParameter("@delidlist", SqlDbType.VarChar,100),
					new SqlParameter("@deltxtlist", SqlDbType.VarChar,400),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.imgpath;
			parameters[2].Value = model.size;
			parameters[3].Value = model.format;
			parameters[4].Value = model.createtime;
			parameters[5].Value = model.modifytime;
			parameters[6].Value = model.visiblecode;
			parameters[7].Value = model.visibletxt;
			parameters[8].Value = model.folderid;
			parameters[9].Value = model.creater;
			parameters[10].Value = model.sharecode;
			parameters[11].Value = model.sharestxt;
			parameters[12].Value = model.viewidlist;
			parameters[13].Value = model.viewtxtlist;
			parameters[14].Value = model.editidlist;
			parameters[15].Value = model.edittxtlist;
			parameters[16].Value = model.delidlist;
			parameters[17].Value = model.deltxtlist;
			parameters[18].Value = model.id;

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
			strSql.Append("delete from PictureInfo ");
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
			strSql.Append("delete from PictureInfo ");
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
        /// 依据条件,批量删除数据
        /// </summary>
        public static bool DelList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PictureInfo ");
            if (strwhere != "")
            {
              strSql.Append(" where" + strwhere);
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
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.PictureInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,cname,imgpath,size,format,createtime,modifytime,visiblecode,visibletxt,folderid,creater,sharecode,sharestxt,viewidlist,viewtxtlist,editidlist,edittxtlist,delidlist,deltxtlist from PictureInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.PictureInfo model = new EtNet_Models.PictureInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.imgpath = tbl.Rows[0]["imgpath"].ToString();
                model.size = int.Parse(tbl.Rows[0]["size"].ToString());
                model.format = tbl.Rows[0]["format"].ToString();
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.modifytime = DateTime.Parse(tbl.Rows[0]["modifytime"].ToString());
                model.visiblecode = int.Parse(tbl.Rows[0]["visiblecode"].ToString());
                model.visibletxt = tbl.Rows[0]["visibletxt"].ToString();
                model.folderid = int.Parse(tbl.Rows[0]["folderid"].ToString());
                model.creater = int.Parse(tbl.Rows[0]["creater"].ToString());
                model.sharecode = int.Parse(tbl.Rows[0]["sharecode"].ToString());
                model.sharestxt = tbl.Rows[0]["sharestxt"].ToString();
                model.viewidlist = tbl.Rows[0]["viewidlist"].ToString();
                model.viewtxtlist = tbl.Rows[0]["viewtxtlist"].ToString();
                model.editidlist = tbl.Rows[0]["editidlist"].ToString();
                model.edittxtlist = tbl.Rows[0]["edittxtlist"].ToString();
                model.delidlist = tbl.Rows[0]["delidlist"].ToString();
                model.deltxtlist = tbl.Rows[0]["deltxtlist"].ToString();
				
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
		public  static DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM PictureInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public  static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM PictureInfo ");
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
            string sql = "truncate table PictureInfo;truncate table PictureFolderInfo;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}

