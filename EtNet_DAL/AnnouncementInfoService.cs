using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_DAL
{
	 	//AnnouncementInfo
	public partial class AnnouncementInfoService
	{
   		     
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AnnouncementInfo");
			strSql.Append(" where ");
	        strSql.Append(" id = @id  ");
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
		public static int Add(EtNet_Models.AnnouncementInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AnnouncementInfo(");
            strSql.Append("title,statusid,sortid,period,starttime,endtime,visiblecode,visibletxt,txt,departlist,peoplelist,createtime,createrid,departtxtlist,");
            strSql.Append("firmid,yearnow,filenum,filetime,themeword,carboncopy,carboncopytxt,imgid,printtime,checkpid,signpid,jobflowid,opiniontxt");
			strSql.Append(") values (");
            strSql.Append("@title,@statusid,@sortid,@period,@starttime,@endtime,@visiblecode,@visibletxt,@txt,@departlist,@peoplelist,@createtime,@createrid,@departtxtlist,");
            strSql.Append("@firmid,@yearnow,@filenum,@filetime,@themeword,@carboncopy,@carboncopytxt,@imgid,@printtime,@checkpid,@signpid,@jobflowid,@opiniontxt");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY() ");
			SqlParameter[] parameters = {
			            new SqlParameter("@title", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@statusid", SqlDbType.Int,4) ,            
                        new SqlParameter("@sortid", SqlDbType.Int,4) ,            
                        new SqlParameter("@period", SqlDbType.Int,4) ,            
                        new SqlParameter("@starttime", SqlDbType.DateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@visiblecode", SqlDbType.Int,4) ,            
                        new SqlParameter("@visibletxt", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@txt", SqlDbType.Text) ,            
                        new SqlParameter("@departlist", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@peoplelist", SqlDbType.VarChar,400) ,            
                        new SqlParameter("@createtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@createrid", SqlDbType.Int,4),
                        new SqlParameter("@departtxtlist",SqlDbType.VarChar,200),
                        new SqlParameter("@firmid",SqlDbType.Int,4),
                        new SqlParameter("@yearnow",SqlDbType.VarChar,20),
                        new SqlParameter("@filenum",SqlDbType.VarChar,40),
                        new SqlParameter("@filetime",SqlDbType.DateTime),
                        new SqlParameter("@themeword",SqlDbType.VarChar,100),
                        new SqlParameter("@carboncopy",SqlDbType.VarChar,400),
                        new SqlParameter("@carboncopytxt",SqlDbType.VarChar,1000),
                        new SqlParameter("@imgid",SqlDbType.Int,4),
                        new SqlParameter("@printtime",SqlDbType.DateTime),
                        new SqlParameter("@checkpid",SqlDbType.Int,4),
                        new SqlParameter("@signpid",SqlDbType.Int,4),
                        new SqlParameter("@jobflowid",SqlDbType.Int,4),
                        new SqlParameter("@opiniontxt",SqlDbType.VarChar,200)


            };
			            
            parameters[0].Value = model.title;                        
            parameters[1].Value = model.statusid;                        
            parameters[2].Value = model.sortid;                        
            parameters[3].Value = model.period;                        
            parameters[4].Value = model.starttime;                        
            parameters[5].Value = model.endtime;                        
            parameters[6].Value = model.visiblecode;                        
            parameters[7].Value = model.visibletxt;                        
            parameters[8].Value = model.txt;                        
            parameters[9].Value = model.departlist;                        
            parameters[10].Value = model.peoplelist;                  
            parameters[11].Value = model.createtime;                        
            parameters[12].Value = model.createrid;
            parameters[13].Value = model.departtxtlist;
            parameters[14].Value = model.firmid;
            parameters[15].Value = model.yearnow;
            parameters[16].Value = model.filenum;
            parameters[17].Value = model.filetime;
            parameters[18].Value = model.themeword;
            parameters[19].Value = model.carboncopy;
            parameters[20].Value = model.carboncopytxt;
            parameters[21].Value = model.imgid;
            parameters[22].Value = model.printtime;
            parameters[23].Value = model.checkpid;
            parameters[24].Value = model.signpid;
            parameters[25].Value = model.jobflowid;
            parameters[26].Value = model.opiniontxt;

            int result = 0;
            SqlDataReader rad = EtNet_DAL.DBHelper.ExecuteReader(strSql.ToString(), parameters);
            if (rad.Read())
            {
                result = Convert.ToInt32(rad[0]);
                rad.Close();
            }

            return result;
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AnnouncementInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AnnouncementInfo set ");                                                
            strSql.Append(" title = @title , ");                                    
            strSql.Append(" statusid = @statusid , ");                                    
            strSql.Append(" sortid = @sortid , ");                                    
            strSql.Append(" period = @period , ");                                    
            strSql.Append(" starttime = @starttime , ");                                    
            strSql.Append(" endtime = @endtime , ");                                    
            strSql.Append(" visiblecode = @visiblecode , ");                                    
            strSql.Append(" visibletxt = @visibletxt , ");                                    
            strSql.Append(" txt = @txt , ");                                    
            strSql.Append(" departlist = @departlist , ");                                    
            strSql.Append(" peoplelist = @peoplelist , ");                                    
            strSql.Append(" createtime = @createtime , ");                                    
            strSql.Append(" createrid = @createrid , ");
            strSql.Append(" departtxtlist = @departtxtlist , ");
            strSql.Append(" firmid = @firmid,");
            strSql.Append(" yearnow=@yearnow,");
            strSql.Append(" filenum=@filenum,");
            strSql.Append(" filetime=@filetime,");
            strSql.Append(" themeword=@themeword,");
            strSql.Append(" carboncopy=@carboncopy,");
            strSql.Append(" carboncopytxt=@carboncopytxt,");
            strSql.Append(" imgid= @imgid,");
            strSql.Append(" printtime= @printtime,");
            strSql.Append(" checkpid=@checkpid,");
            strSql.Append(" signpid=@signpid,");
            strSql.Append(" jobflowid=@jobflowid,");
            strSql.Append(" opiniontxt=@opiniontxt");
			strSql.Append(" where id=@id ");
						
            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@title", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@statusid", SqlDbType.Int,4) ,            
                        new SqlParameter("@sortid", SqlDbType.Int,4) ,            
                        new SqlParameter("@period", SqlDbType.Int,4) ,            
                        new SqlParameter("@starttime", SqlDbType.DateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@visiblecode", SqlDbType.Int,4) ,            
                        new SqlParameter("@visibletxt", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@txt", SqlDbType.Text) ,            
                        new SqlParameter("@departlist", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@peoplelist", SqlDbType.VarChar,400) ,            
                        new SqlParameter("@createtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@createrid", SqlDbType.Int,4),
                        new SqlParameter("@departtxtlist",SqlDbType.VarChar,200),
                        new SqlParameter("@firmid",SqlDbType.Int,4),
                        new SqlParameter("@yearnow",SqlDbType.VarChar,20),
                        new SqlParameter("@filenum",SqlDbType.VarChar,40),
                        new SqlParameter("@filetime",SqlDbType.DateTime),
                        new SqlParameter("@themeword",SqlDbType.VarChar,100),
                        new SqlParameter("@carboncopy",SqlDbType.VarChar,400),
                        new SqlParameter("@carboncopytxt",SqlDbType.VarChar,1000),
                        new SqlParameter("@imgid",SqlDbType.Int,4),
                        new SqlParameter("@printtime",SqlDbType.DateTime),
                        new SqlParameter("@checkpid",SqlDbType.Int,4),
                        new SqlParameter("@signpid",SqlDbType.Int,4),
                        new SqlParameter("@jobflowid",SqlDbType.Int,4),
                        new SqlParameter("@opiniontxt",SqlDbType.VarChar,200)

            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.title;                        
            parameters[2].Value = model.statusid;                        
            parameters[3].Value = model.sortid;                        
            parameters[4].Value = model.period;                        
            parameters[5].Value = model.starttime;                        
            parameters[6].Value = model.endtime;                        
            parameters[7].Value = model.visiblecode;                        
            parameters[8].Value = model.visibletxt;                        
            parameters[9].Value = model.txt;                        
            parameters[10].Value = model.departlist;                        
            parameters[11].Value = model.peoplelist;                        
            parameters[12].Value = model.createtime;                        
            parameters[13].Value = model.createrid;
            parameters[14].Value = model.departtxtlist;
            parameters[15].Value = model.firmid;
            parameters[16].Value = model.yearnow;
            parameters[17].Value = model.filenum;
            parameters[18].Value = model.filetime;
            parameters[19].Value = model.themeword;
            parameters[20].Value = model.carboncopy;
            parameters[21].Value = model.carboncopytxt;
            parameters[22].Value = model.imgid;
            parameters[23].Value = model.printtime;
            parameters[24].Value = model.checkpid;
            parameters[25].Value = model.signpid;
            parameters[26].Value = model.jobflowid;
            parameters[27].Value = model.opiniontxt;
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
			strSql.Append("delete from AnnouncementInfo ");
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
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AnnouncementInfo ");
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
		public static  EtNet_Models.AnnouncementInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select *  ");			
			strSql.Append("  from AnnouncementInfo ");
			strSql.Append(" where id=@id");
		    SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;


            EtNet_Models.AnnouncementInfo model = new EtNet_Models.AnnouncementInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.title = tbl.Rows[0]["title"].ToString();
                model.statusid = int.Parse(tbl.Rows[0]["statusid"].ToString());
                model.sortid = int.Parse(tbl.Rows[0]["sortid"].ToString());
                model.period = int.Parse(tbl.Rows[0]["period"].ToString());
                model.starttime = DateTime.Parse(tbl.Rows[0]["starttime"].ToString());
                model.endtime = DateTime.Parse(tbl.Rows[0]["endtime"].ToString());
                model.visiblecode = int.Parse(tbl.Rows[0]["visiblecode"].ToString());
                model.visibletxt = tbl.Rows[0]["visibletxt"].ToString();
                model.txt = tbl.Rows[0]["txt"].ToString();
                model.departlist = tbl.Rows[0]["departlist"].ToString();
                model.departtxtlist = tbl.Rows[0]["departtxtlist"].ToString();
                model.peoplelist = tbl.Rows[0]["peoplelist"].ToString();
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.createrid = int.Parse(tbl.Rows[0]["createrid"].ToString());
                model.firmid = int.Parse(tbl.Rows[0]["firmid"].ToString());
                model.yearnow = tbl.Rows[0]["yearnow"].ToString();
                model.filenum = tbl.Rows[0]["filenum"].ToString();
                model.filetime = DateTime.Parse(tbl.Rows[0]["filetime"].ToString());
                model.themeword = tbl.Rows[0]["themeword"].ToString();
                model.carboncopy = tbl.Rows[0]["carboncopy"].ToString();
                model.carboncopytxt = tbl.Rows[0]["carboncopytxt"].ToString();
                model.imgid = int.Parse(tbl.Rows[0]["imgid"].ToString());
                model.printtime = DateTime.Parse(tbl.Rows[0]["printtime"].ToString());
                model.checkpid = int.Parse(tbl.Rows[0]["checkpid"].ToString());
                model.signpid = int.Parse(tbl.Rows[0]["signpid"].ToString());
                model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                model.opiniontxt = tbl.Rows[0]["opiniontxt"].ToString();													
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AnnouncementInfo ");
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
			strSql.Append(" FROM AnnouncementInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}



        public static int Clear()
        {
            string sql = "truncate table AnnouncementInfo; truncate table AnnouncementFiles; truncate table AnnouncementLog;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}

