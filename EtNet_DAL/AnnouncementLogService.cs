using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_DAL
{
	//AnnouncementLog
	public partial class AnnouncementLogService
	{
   		     
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AnnouncementLog");
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
		public static bool Add(EtNet_Models.AnnouncementLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AnnouncementLog(");			
            strSql.Append("announcementid,ipaddress,operatecode,operatetxt,createtime,founderid");
			strSql.Append(") values (");
            strSql.Append("@announcementid,@ipaddress,@operatecode,@operatetxt,@createtime,@founderid");            
            strSql.Append(") ");            
           	
			SqlParameter[] parameters = {
			            new SqlParameter("@announcementid", SqlDbType.Int,4) ,            
                        new SqlParameter("@ipaddress", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@operatecode", SqlDbType.Int,4) ,            
                        new SqlParameter("@operatetxt", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@createtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4)};        
            parameters[0].Value = model.announcementid;                        
            parameters[1].Value = model.ipaddress;                        
            parameters[2].Value = model.operatecode;                        
            parameters[3].Value = model.operatetxt;                        
            parameters[4].Value = model.createtime;                        
            parameters[5].Value = model.founderid;
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
		public static bool Update(EtNet_Models.AnnouncementLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AnnouncementLog set ");		                                                
            strSql.Append(" announcementid = @announcementid , ");                                    
            strSql.Append(" ipaddress = @ipaddress , ");                                    
            strSql.Append(" operatecode = @operatecode , ");                                    
            strSql.Append(" operatetxt = @operatetxt , ");                                    
            strSql.Append(" createtime = @createtime , ");                                    
            strSql.Append(" founderid = @founderid  ");            			
			strSql.Append(" where id=@id ");
						
            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@announcementid", SqlDbType.Int,4) ,            
                        new SqlParameter("@ipaddress", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@operatecode", SqlDbType.Int,4) ,            
                        new SqlParameter("@operatetxt", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@createtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4)  
            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.announcementid;                        
            parameters[2].Value = model.ipaddress;                        
            parameters[3].Value = model.operatecode;                        
            parameters[4].Value = model.operatetxt;                        
            parameters[5].Value = model.createtime;                        
            parameters[6].Value = model.founderid;
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
			strSql.Append("delete from AnnouncementLog ");
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
			strSql.Append("delete from AnnouncementLog ");
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
        /// 删除多条数据
        /// </summary>
        public static bool Del(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AnnouncementLog ");
            if (strwhere != "")
            {
                strSql.Append(" where " + strwhere);
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
		public static EtNet_Models.AnnouncementLog GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select *  ");			
			strSql.Append("  from AnnouncementLog ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.AnnouncementLog model = new EtNet_Models.AnnouncementLog();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.announcementid = int.Parse(tbl.Rows[0]["announcementid"].ToString());
                model.ipaddress = tbl.Rows[0]["ipaddress"].ToString();
                model.operatecode = int.Parse(tbl.Rows[0]["operatecode"].ToString());
                model.operatetxt = tbl.Rows[0]["operatetxt"].ToString();
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());																										
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
			strSql.Append(" FROM AnnouncementLog ");
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
			strSql.Append(" FROM AnnouncementLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

   
	}
}

