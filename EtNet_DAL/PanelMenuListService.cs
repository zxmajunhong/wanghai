using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_DAL  
{
    //PanelMenuListService
    public class PanelMenuListService
	{
   		     
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from PanelMenuList");
			strSql.Append(" where ");
		    strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.ExecuteReader(strSql.ToString(),parameters);
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
		public static bool Add(EtNet_Models.PanelMenuList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PanelMenuList(");			
            strSql.Append("num,cname,imageload");
			strSql.Append(") values (");
            strSql.Append("@num,@cname,@imageload");            
            strSql.Append(") ");            
            
			SqlParameter[] parameters = {
			            new SqlParameter("@num", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@cname", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@imageload", SqlDbType.VarChar,200)             
            };
			            
            parameters[0].Value = model.num;                        
            parameters[1].Value = model.cname;                        
            parameters[2].Value = model.imageload;

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
		public static bool Update(EtNet_Models.PanelMenuList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PanelMenuList set ");                                         
            strSql.Append(" num = @num , ");                                    
            strSql.Append(" cname = @cname , ");                                    
            strSql.Append(" imageload = @imageload  ");            			
			strSql.Append(" where id=@id ");
						
           SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@num", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@cname", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@imageload", SqlDbType.VarChar,200) 
            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.num;                        
            parameters[2].Value = model.cname;                        
            parameters[3].Value = model.imageload;

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
			strSql.Append("delete from PanelMenuList ");
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
			strSql.Append("delete from PanelMenuList ");
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
		public static EtNet_Models.PanelMenuList GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, num, cname, imageload  ");			
			strSql.Append("  from PanelMenuList ");
			strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					    new SqlParameter("@id", SqlDbType.Int,4)};
		    parameters[0].Value = id;

			
			EtNet_Models.PanelMenuList model=new EtNet_Models.PanelMenuList();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
               model.id = int.Parse(tbl.Rows[0]["id"].ToString());
               model.num = tbl.Rows[0]["num"].ToString();
               model.cname = tbl.Rows[0]["cname"].ToString();
               model.imageload = tbl.Rows[0]["imageload"].ToString();																						
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
			strSql.Append(" FROM PanelMenuList ");
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
			strSql.Append(" FROM PanelMenuList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}



   
	}
}

