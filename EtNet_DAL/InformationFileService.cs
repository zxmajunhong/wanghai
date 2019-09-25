using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_DAL
{
    //InformationFileService
    public class InformationFileService
	{
   		     
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from InformationFile");
			strSql.Append(" where ");
			strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.GetReader(strSql.ToString(), parameters);
            if (rad.Read())
            {
                rad.Close();
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
		public static bool Add( EtNet_Models.InformationFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InformationFile(");			
            strSql.Append("informationid,fileload,filename,filesize,downloadnum,createtime");
			strSql.Append(") values (");
            strSql.Append("@informationid,@fileload,@filename,@filesize,@downloadnum,@createtime");            
            strSql.Append(") ");            
           
			SqlParameter[] parameters = {
			            new SqlParameter("@informationid", SqlDbType.Int,4) ,            
                        new SqlParameter("@fileload", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@filename", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@filesize", SqlDbType.Int,4) ,            
                        new SqlParameter("@downloadnum", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime)  };
			            
            parameters[0].Value = model.informationid;                        
            parameters[1].Value = model.fileload;                        
            parameters[2].Value = model.filename;                        
            parameters[3].Value = model.filesize;                        
            parameters[4].Value = model.downloadnum;                        
            parameters[5].Value = model.createtime;

            int result =  EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
		public static bool Update(EtNet_Models.InformationFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InformationFile set ");
			                                                
            strSql.Append(" informationid = @informationid , ");                                    
            strSql.Append(" fileload = @fileload , ");                                    
            strSql.Append(" filename = @filename , ");                                    
            strSql.Append(" filesize = @filesize , ");                                    
            strSql.Append(" downloadnum = @downloadnum , ");                                    
            strSql.Append(" createtime = @createtime  ");            			
			strSql.Append(" where id=@id ");
						
            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@informationid", SqlDbType.Int,4) ,            
                        new SqlParameter("@fileload", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@filename", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@filesize", SqlDbType.Int,4) ,            
                        new SqlParameter("@downloadnum", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.informationid;                        
            parameters[2].Value = model.fileload;                        
            parameters[3].Value = model.filename;                        
            parameters[4].Value = model.filesize;                        
            parameters[5].Value = model.downloadnum;                        
            parameters[6].Value = model.createtime;

            int result =  EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
			strSql.Append("delete from InformationFile ");
			strSql.Append(" where id=@id");
		    SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
            int result =  EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
			strSql.Append("delete from InformationFile ");
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
		public static  EtNet_Models.InformationFile GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, informationid, fileload, filename, filesize, downloadnum, createtime  ");			
			strSql.Append("  from InformationFile ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;


            EtNet_Models.InformationFile model = new EtNet_Models.InformationFile();
            DataTable tbl =  EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
				
			   model.id=int.Parse(tbl.Rows[0]["id"].ToString());
			   model.informationid=int.Parse(tbl.Rows[0]["informationid"].ToString());
			   model.fileload= tbl.Rows[0]["fileload"].ToString();
			   model.filename= tbl.Rows[0]["filename"].ToString();
			   model.filesize=int.Parse(tbl.Rows[0]["filesize"].ToString());
			   model.downloadnum=int.Parse(tbl.Rows[0]["downloadnum"].ToString());
			   model.createtime=DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
																														
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
			strSql.Append(" FROM InformationFile ");
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
			strSql.Append(" FROM InformationFile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return  EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

   
	}
}

