using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;


namespace EtNet_DAL
{

    public class AuditJobFlowService
	{
   		     
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AuditJobFlow");
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
		public static bool Add( EtNet_Models.AuditJobFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AuditJobFlow(");			
            strSql.Append("reviewerid,jobflowid,mainreviewer,nowreviewer,numbers,audittime,auditoperat,operatstatus,opiniontxt");
			strSql.Append(") values (");
            strSql.Append("@reviewerid,@jobflowid,@mainreviewer,@nowreviewer,@numbers,@audittime,@auditoperat,@operatstatus,@opiniontxt");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {     
                        new SqlParameter("@reviewerid", SqlDbType.Int,4) ,            
                        new SqlParameter("@jobflowid", SqlDbType.Int,4) ,            
                        new SqlParameter("@mainreviewer", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@nowreviewer", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@numbers", SqlDbType.Int,4) ,            
                        new SqlParameter("@audittime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@auditoperat", SqlDbType.VarChar,10) ,          
                        new SqlParameter("@operatstatus", SqlDbType.VarChar,10),
                        new SqlParameter("@opiniontxt",SqlDbType.VarChar,200)};
			            
                          
            parameters[0].Value = model.reviewerid;                        
            parameters[1].Value = model.jobflowid;                        
            parameters[2].Value = model.mainreviewer;                        
            parameters[3].Value = model.nowreviewer;                        
            parameters[4].Value = model.numbers;                        
            parameters[5].Value = model.audittime;                        
            parameters[6].Value = model.auditoperat;                        
            parameters[7].Value = model.operatstatus;
            parameters[8].Value = model.opiniontxt;

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
		public static bool Update(EtNet_Models.AuditJobFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AuditJobFlow set ");                                               
            strSql.Append(" reviewerid = @reviewerid , ");                                    
            strSql.Append(" jobflowid = @jobflowid , ");                                    
            strSql.Append(" mainreviewer = @mainreviewer , ");                                    
            strSql.Append(" nowreviewer = @nowreviewer , ");                                    
            strSql.Append(" numbers = @numbers , ");                                    
            strSql.Append(" audittime = @audittime , ");                                    
            strSql.Append(" auditoperat = @auditoperat , ");                                    
            strSql.Append(" operatstatus = @operatstatus,  ");
            strSql.Append(" opiniontxt= @opiniontxt");
			strSql.Append(" where id=@id  ");		
            SqlParameter[] parameters = {
			                 
                        new SqlParameter("@reviewerid", SqlDbType.Int,4) ,            
                        new SqlParameter("@jobflowid", SqlDbType.Int,4) ,            
                        new SqlParameter("@mainreviewer", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@nowreviewer", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@numbers", SqlDbType.Int,4) ,            
                        new SqlParameter("@audittime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@auditoperat", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@operatstatus", SqlDbType.VarChar,10),
                        new SqlParameter("@opiniontxt",SqlDbType.VarChar,200),
                        new SqlParameter("@id", SqlDbType.Int,4)};             
                  
            parameters[0].Value = model.reviewerid;                        
            parameters[1].Value = model.jobflowid;                        
            parameters[2].Value = model.mainreviewer;                        
            parameters[3].Value = model.nowreviewer;                        
            parameters[4].Value = model.numbers;                        
            parameters[5].Value = model.audittime;                        
            parameters[6].Value = model.auditoperat;                        
            parameters[7].Value = model.operatstatus;
            parameters[8].Value = model.opiniontxt;
            parameters[9].Value = model.id;
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
        /// 修改其他审核人员的审核信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool UpdateOther(string strWhere)
        {
            string sql = "update AuditJobFlow set auditoperat='通过',operatstatus='已审批' ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            int result = DBHelper.ExecuteCommand(sql);
            if (result >= 1)
                return true;
            else
                return false;
        }

		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AuditJobFlow ");
			strSql.Append(" where id=@id ");
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
		/// 删除指定条件的数据
		/// </summary>
        public static bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AuditJobFlow ");
            if(strWhere != "")
            {
                strSql.Append(" where " + strWhere);
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
		public static EtNet_Models.AuditJobFlow GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select *  ");			
			strSql.Append("  from AuditJobFlow ");
			strSql.Append(" where id=@id ");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.AuditJobFlow model = new EtNet_Models.AuditJobFlow();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
               
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.reviewerid = int.Parse(tbl.Rows[0]["reviewerid"].ToString());
                model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                model.mainreviewer = tbl.Rows[0]["mainreviewer"].ToString();
                model.nowreviewer = tbl.Rows[0]["nowreviewer"].ToString();
                model.numbers = int.Parse(tbl.Rows[0]["numbers"].ToString());
                model.audittime = DateTime.Parse(tbl.Rows[0]["audittime"].ToString());
                model.auditoperat = tbl.Rows[0]["auditoperat"].ToString();
                model.operatstatus = tbl.Rows[0]["operatstatus"].ToString();
                model.opiniontxt = tbl.Rows[0]["opiniontxt"].ToString();																
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.AuditJobFlow GetModelByJFID(int jfid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from AuditJobFlow ");
            strSql.Append(" where jobflowid=@jobflowid ");
            SqlParameter[] parameters = {
					new SqlParameter("@jobflowid", SqlDbType.Int,4)};
            parameters[0].Value = jfid;

            EtNet_Models.AuditJobFlow model = new EtNet_Models.AuditJobFlow();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {

                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.reviewerid = int.Parse(tbl.Rows[0]["reviewerid"].ToString());
                model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                model.mainreviewer = tbl.Rows[0]["mainreviewer"].ToString();
                model.nowreviewer = tbl.Rows[0]["nowreviewer"].ToString();
                model.numbers = int.Parse(tbl.Rows[0]["numbers"].ToString());
                model.audittime = DateTime.Parse(tbl.Rows[0]["audittime"].ToString());
                model.auditoperat = tbl.Rows[0]["auditoperat"].ToString();
                model.operatstatus = tbl.Rows[0]["operatstatus"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM AuditJobFlow ");
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
			strSql.Append(" FROM AuditJobFlow ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());

		}

    }
}

