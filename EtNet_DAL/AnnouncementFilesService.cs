using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_DAL
{
	//AnnouncementFiles
	public  class AnnouncementFilesService
	{
   		     
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AnnouncementFiles");
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
		public static bool Add(EtNet_Models.AnnouncementFiles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AnnouncementFiles(");			
            strSql.Append("announcementid,cname,path,uptime,founderid,remark");
			strSql.Append(") values (");
            strSql.Append("@announcementid,@cname,@path,@uptime,@founderid,@remark");            
            strSql.Append(") ");            
           	
			SqlParameter[] parameters = {
			            new SqlParameter("@announcementid", SqlDbType.Int,4) ,            
                        new SqlParameter("@cname", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@path", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@uptime", SqlDbType.DateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@remark", SqlDbType.VarChar,200)  
            };
			            
            parameters[0].Value = model.announcementid;                        
            parameters[1].Value = model.cname;                        
            parameters[2].Value = model.path;                        
            parameters[3].Value = model.uptime;                        
            parameters[4].Value = model.founderid;                        
            parameters[5].Value = model.remark;

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
		public static bool Update ( EtNet_Models.AnnouncementFiles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AnnouncementFiles set ");	                                                
            strSql.Append(" announcementid = @announcementid , ");                                    
            strSql.Append(" cname = @cname , ");                                    
            strSql.Append(" path = @path , ");                                    
            strSql.Append(" uptime = @uptime , ");                                    
            strSql.Append(" founderid = @founderid , ");                                    
            strSql.Append(" remark = @remark  ");            			
			strSql.Append(" where id=@id ");			
            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@announcementid", SqlDbType.Int,4) ,            
                        new SqlParameter("@cname", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@path", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@uptime", SqlDbType.DateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@remark", SqlDbType.VarChar,200) };            
           		            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.announcementid;                        
            parameters[2].Value = model.cname;                        
            parameters[3].Value = model.path;                        
            parameters[4].Value = model.uptime;                        
            parameters[5].Value = model.founderid;                        
            parameters[6].Value = model.remark;
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
			strSql.Append("delete from AnnouncementFiles ");
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
			strSql.Append("delete from AnnouncementFiles ");
			strSql.Append(" where ID in ("+idlist + ")  ");
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
		public static  EtNet_Models.AnnouncementFiles GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");			
			strSql.Append("  from AnnouncementFiles ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;


            EtNet_Models.AnnouncementFiles model = new EtNet_Models.AnnouncementFiles();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.announcementid = int.Parse(tbl.Rows[0]["announcementid"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.path = tbl.Rows[0]["path"].ToString();
                model.uptime = DateTime.Parse(tbl.Rows[0]["uptime"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                model.remark = tbl.Rows[0]["remark"].ToString();																						
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
			strSql.Append(" FROM AnnouncementFiles ");
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
			strSql.Append(" FROM AnnouncementFiles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

   
	}
}

