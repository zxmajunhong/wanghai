using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
    /// <summary>
    /// 数据访问类:FirmInfoService
    /// </summary>
    public class FirmInfoService
    {
        public FirmInfoService()
        { }
        #region  Method



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from FirmInfo");
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
        /// 增加一条数据,取得id值
        /// </summary>
        public static int Add(EtNet_Models.FirmInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("ProcFirm");
            SqlParameter[] parameters = {
					new SqlParameter("@firmcode", SqlDbType.VarChar,20),
					new SqlParameter("@sname", SqlDbType.VarChar,40),
					new SqlParameter("@cname", SqlDbType.VarChar,100),
					new SqlParameter("@ename", SqlDbType.VarChar,100),
					new SqlParameter("@caddress", SqlDbType.VarChar,200),
					new SqlParameter("@eaddress", SqlDbType.VarChar,200),
					new SqlParameter("@telephone", SqlDbType.VarChar,40),
					new SqlParameter("@fax", SqlDbType.VarChar,40),
					new SqlParameter("@mailbox", SqlDbType.VarChar,40),
					new SqlParameter("@postalcode", SqlDbType.VarChar,40),
					new SqlParameter("@website", SqlDbType.VarChar,100),
					new SqlParameter("@taxnum", SqlDbType.VarChar,40),
					new SqlParameter("@orgcode", SqlDbType.VarChar,40),
					new SqlParameter("@imgpath", SqlDbType.VarChar,200),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                    new SqlParameter("@id",SqlDbType.Int,4)};
            parameters[0].Value = model.firmcode;
            parameters[1].Value = model.sname;
            parameters[2].Value = model.cname;
            parameters[3].Value = model.ename;
            parameters[4].Value = model.caddress;
            parameters[5].Value = model.eaddress;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.fax;
            parameters[8].Value = model.mailbox;
            parameters[9].Value = model.postalcode;
            parameters[10].Value = model.website;
            parameters[11].Value = model.taxnum;
            parameters[12].Value = model.orgcode;
            parameters[13].Value = model.imgpath;
            parameters[14].Value = model.remark;
            parameters[15].Direction = ParameterDirection.Output;
            EtNet_DAL.DBHelper.ExecuteCommandPoc(strSql.ToString(), parameters);
            int id = int.Parse(parameters[15].Value.ToString());
            return id;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(EtNet_Models.FirmInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FirmInfo set ");
            strSql.Append("firmcode=@firmcode,");
            strSql.Append("sname=@sname,");
            strSql.Append("cname=@cname,");
            strSql.Append("ename=@ename,");
            strSql.Append("caddress=@caddress,");
            strSql.Append("eaddress=@eaddress,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("fax=@fax,");
            strSql.Append("mailbox=@mailbox,");
            strSql.Append("postalcode=@postalcode,");
            strSql.Append("website=@website,");
            strSql.Append("taxnum=@taxnum,");
            strSql.Append("orgcode=@orgcode,");
            strSql.Append("imgpath=@imgpath,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@firmcode", SqlDbType.VarChar,20),
					new SqlParameter("@sname", SqlDbType.VarChar,40),
					new SqlParameter("@cname", SqlDbType.VarChar,100),
					new SqlParameter("@ename", SqlDbType.VarChar,100),
					new SqlParameter("@caddress", SqlDbType.VarChar,200),
					new SqlParameter("@eaddress", SqlDbType.VarChar,200),
					new SqlParameter("@telephone", SqlDbType.VarChar,40),
					new SqlParameter("@fax", SqlDbType.VarChar,40),
					new SqlParameter("@mailbox", SqlDbType.VarChar,40),
					new SqlParameter("@postalcode", SqlDbType.VarChar,40),
					new SqlParameter("@website", SqlDbType.VarChar,100),
					new SqlParameter("@taxnum", SqlDbType.VarChar,40),
					new SqlParameter("@orgcode", SqlDbType.VarChar,40),
					new SqlParameter("@imgpath", SqlDbType.VarChar,200),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.firmcode;
            parameters[1].Value = model.sname;
            parameters[2].Value = model.cname;
            parameters[3].Value = model.ename;
            parameters[4].Value = model.caddress;
            parameters[5].Value = model.eaddress;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.fax;
            parameters[8].Value = model.mailbox;
            parameters[9].Value = model.postalcode;
            parameters[10].Value = model.website;
            parameters[11].Value = model.taxnum;
            parameters[12].Value = model.orgcode;
            parameters[13].Value = model.imgpath;
            parameters[14].Value = model.remark;
            parameters[15].Value = model.id;

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
            strSql.Append("delete from FirmInfo ");
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
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FirmInfo ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public static EtNet_Models.FirmInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,firmcode,sname,cname,ename,caddress,eaddress,telephone,fax,mailbox,postalcode,website,taxnum,orgcode,imgpath,remark from FirmInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            EtNet_Models.FirmInfo model = new EtNet_Models.FirmInfo();
            DataTable ds = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                model.id = int.Parse(ds.Rows[0]["id"].ToString());
                model.firmcode = ds.Rows[0]["firmcode"].ToString();
                model.sname = ds.Rows[0]["sname"].ToString();
                model.cname = ds.Rows[0]["cname"].ToString();
                model.ename = ds.Rows[0]["ename"].ToString();
                model.caddress = ds.Rows[0]["caddress"].ToString();
                model.eaddress = ds.Rows[0]["eaddress"].ToString();
                model.telephone = ds.Rows[0]["telephone"].ToString();
                model.fax = ds.Rows[0]["fax"].ToString();
                model.mailbox = ds.Rows[0]["mailbox"].ToString();
                model.postalcode = ds.Rows[0]["postalcode"].ToString();
                model.website = ds.Rows[0]["website"].ToString();
                model.taxnum = ds.Rows[0]["taxnum"].ToString();
                model.orgcode = ds.Rows[0]["orgcode"].ToString();
                model.imgpath = ds.Rows[0]["imgpath"].ToString();
                model.remark = ds.Rows[0]["remark"].ToString();

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
            strSql.Append(" FROM FirmInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" FROM FirmInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }
        #endregion  Method
    }
}

