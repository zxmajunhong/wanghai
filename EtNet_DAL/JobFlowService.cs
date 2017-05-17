using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;


namespace EtNet_DAL
{

    public class JobFlowService
    {

        /// <summary>
        /// 查询id值最大的数据
        /// </summary>
        public static int Maxid()
        {
            string strid = " select * from JobFlow order by id desc";
            return EtNet_DAL.DBHelper.ExecuteScalar(strid);

        }

        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from JobFlow");
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
        public static bool Add(EtNet_Models.JobFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JobFlow(");
            strSql.Append("cname,sort,createtime,endtime,founderid,auditsort,auditstatus,savestatus,attachment,txt,ruleid");
            strSql.Append(") values (");
            strSql.Append("@cname,@sort,@createtime,@endtime,@founderid,@auditsort,@auditstatus,@savestatus,@attachment,@txt,@ruleid");
            strSql.Append(") ;");

            SqlParameter[] parameters = {     
                        new SqlParameter("@cname", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@sort", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@auditsort", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@auditstatus", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@savestatus", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@attachment", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,200),
                        new SqlParameter("@ruleid",SqlDbType.Int,4)};

            parameters[0].Value = model.cname;
            parameters[1].Value = model.sort;
            parameters[2].Value = model.createtime;
            parameters[3].Value = model.endtime;
            parameters[4].Value = model.founderid;
            parameters[5].Value = model.auditsort;
            parameters[6].Value = model.auditstatus;
            parameters[7].Value = model.savestatus;
            parameters[8].Value = model.attachment;
            parameters[9].Value = model.txt;
            parameters[10].Value = model.ruleid;

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




        public static int AddAndGetId(EtNet_Models.JobFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("ProcJobFlow");

            SqlParameter[] parameters = {     
                        new SqlParameter("@cname", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@sort", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@auditsort", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@auditstatus", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@savestatus", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@attachment", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,200),
                        new SqlParameter("@ruleid",SqlDbType.Int,4),
                        new SqlParameter("@id",SqlDbType.Int,4)};


            parameters[0].Value = model.cname;
            parameters[1].Value = model.sort;
            parameters[2].Value = model.createtime;
            parameters[3].Value = model.endtime;
            parameters[4].Value = model.founderid;
            parameters[5].Value = model.auditsort;
            parameters[6].Value = model.auditstatus;
            parameters[7].Value = model.savestatus;
            parameters[8].Value = model.attachment;
            parameters[9].Value = model.txt;
            parameters[10].Value = model.ruleid;
            parameters[11].Direction = ParameterDirection.Output;

            EtNet_DAL.DBHelper.ExecuteCommandPoc(strSql.ToString(), parameters);
            int result = int.Parse(parameters[11].Value.ToString());
            return result;

        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(EtNet_Models.JobFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JobFlow set ");
            strSql.Append(" cname = @cname , ");
            strSql.Append(" sort = @sort , ");
            strSql.Append(" createtime = @createtime , ");
            strSql.Append(" endtime = @endtime , ");
            strSql.Append(" founderid = @founderid , ");
            strSql.Append(" auditsort = @auditsort , ");
            strSql.Append(" auditstatus = @auditstatus , ");
            strSql.Append(" savestatus = @savestatus , ");
            strSql.Append(" attachment = @attachment , ");
            strSql.Append(" txt = @txt ,  ");
            strSql.Append(" ruleid = @ruleid");
            strSql.Append(" where id=@id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@cname", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@sort", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@auditsort", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@auditstatus", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@savestatus", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@attachment", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,200),
                        new SqlParameter("@ruleid",SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.cname;
            parameters[2].Value = model.sort;
            parameters[3].Value = model.createtime;
            parameters[4].Value = model.endtime;
            parameters[5].Value = model.founderid;
            parameters[6].Value = model.auditsort;
            parameters[7].Value = model.auditstatus;
            parameters[8].Value = model.savestatus;
            parameters[9].Value = model.attachment;
            parameters[10].Value = model.txt;
            parameters[11].Value = model.ruleid;

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
        public static bool UpdateBySerialNum(EtNet_Models.JobFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JobFlow set ");
            strSql.Append(" sort = @sort , ");
            strSql.Append(" createtime = @createtime , ");
            strSql.Append(" endtime = @endtime , ");
            strSql.Append(" founderid = @founderid , ");
            strSql.Append(" auditsort = @auditsort , ");
            strSql.Append(" auditstatus = @auditstatus , ");
            strSql.Append(" savestatus = @savestatus , ");
            strSql.Append(" attachment = @attachment , ");
            strSql.Append(" txt = @txt ,  ");
            strSql.Append(" ruleid = @ruleid");
            strSql.Append(" where cname=@cname  ");

            SqlParameter[] parameters = { 
                        new SqlParameter("@cname",SqlDbType.VarChar,100),
                        new SqlParameter("@sort", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@auditsort", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@auditstatus", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@savestatus", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@attachment", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,200),
                        new SqlParameter("@ruleid",SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.cname;
            parameters[1].Value = model.sort;
            parameters[2].Value = model.createtime;
            parameters[3].Value = model.endtime;
            parameters[4].Value = model.founderid;
            parameters[5].Value = model.auditsort;
            parameters[6].Value = model.auditstatus;
            parameters[7].Value = model.savestatus;
            parameters[8].Value = model.attachment;
            parameters[9].Value = model.txt;
            parameters[10].Value = model.ruleid;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobFlow ");
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
        public static bool DeleteList(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobFlow ");
            if (strWhere != "")
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
        public static EtNet_Models.JobFlow GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, cname, sort, createtime, endtime, founderid, auditsort, auditstatus, savestatus, attachment, txt,ruleid ");
            strSql.Append("  from JobFlow ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            EtNet_Models.JobFlow model = new EtNet_Models.JobFlow();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.sort = tbl.Rows[0]["sort"].ToString();
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.endtime = DateTime.Parse(tbl.Rows[0]["endtime"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                model.auditsort = tbl.Rows[0]["auditsort"].ToString();
                model.auditstatus = tbl.Rows[0]["auditstatus"].ToString();
                model.savestatus = tbl.Rows[0]["savestatus"].ToString();
                model.attachment = tbl.Rows[0]["attachment"].ToString();
                model.txt = tbl.Rows[0]["txt"].ToString();
                model.ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());

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
            strSql.Append(" FROM JobFlow ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " order by id desc");
            }
            else
            {
                strSql.Append(" order by id desc");
            }
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM JobFlow ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }



        public static int GetMaxId()
        {
            string strSql = "select top 1 id from JobFlow order by id desc";
            return EtNet_DAL.DBHelper.ExecuteScalar(strSql);
        }
    }
}

