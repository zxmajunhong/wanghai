using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Company]表的数据访问类
    /// </summary>
    public class CompanyService
    {
        /// <summary>
        ///[Company]表添加的方法
        /// </summary>
        public static int addCompany(Company company)
        {
            string sql = "insert into Company([comCode],[comType],[comPro],[comShortName],[comCname],[comCAddress],[province],[city],[comUrl],[used],[linkName],[post],[telephone],[fax],[mobile],[email],[msn],[skype],[bank],[cardId],[cardName],[remark],[ordernum],[codeformat],[madefrom],[madeTime]) values (@comCode,@comType,@comPro,@comShortName,@comCname,@comCAddress,@province,@city,@comUrl,@used,@linkName,@post,@telephone,@fax,@mobile,@email,@msn,@skype,@bank,@cardId,@cardName,@remark,@ordernum,@codeformat,@madefrom,@madeTime)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@comCode",company.ComCode),
        new SqlParameter("@comType",company.ComType),
        new SqlParameter("@comPro",company.ComPro),
        new SqlParameter("@comShortName",company.ComShortName),
        new SqlParameter("@comCname",company.ComCname),
        new SqlParameter("@comCAddress",company.ComCAddress),
        new SqlParameter("@province",company.Province),
        new SqlParameter("@city",company.City),
        new SqlParameter("@comUrl",company.ComUrl),
        new SqlParameter("@used",company.Used),
        new SqlParameter("@linkName",company.LinkName),
        new SqlParameter("@post",company.Post),
        new SqlParameter("@telephone",company.Telephone),
        new SqlParameter("@fax",company.Fax),
        new SqlParameter("@mobile",company.Mobile),
        new SqlParameter("@email",company.Email),
        new SqlParameter("@msn",company.Msn),
        new SqlParameter("@skype",company.Skype),
        new SqlParameter("@bank",company.Bank),
        new SqlParameter("@cardId",company.CardId),
        new SqlParameter("@cardName",company.CardName),
        new SqlParameter("@remark",company.Remark),
        new SqlParameter("@ordernum",company.Ordernum),
        new SqlParameter("@codeformat",company.Codeformat),
        new SqlParameter("@madefrom",company.Madefrom),
        new SqlParameter("@madeTime",company.MadeTime)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Company]表修改的方法
        /// </summary>
        public static int updateCompanyById(Company company)
        {

            string sql = "update Company set comCode=@comCode,comType=@comType,comPro=@comPro,comShortName=@comShortName,comCname=@comCname,comCAddress=@comCAddress,province=@province,city=@city,comUrl=@comUrl,used=@used,linkName=@linkName,post=@post,telephone=@telephone,fax=@fax,mobile=@mobile,email=@email,msn=@msn,skype=@skype,bank=@bank,cardId=@cardId,cardName=@cardName,remark=@remark,ordernum=@ordernum,codeformat=@codeformat,madefrom=@madefrom,madeTime=@madeTime where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",company.Id),
        new SqlParameter("@comCode",company.ComCode),
        new SqlParameter("@comType",company.ComType),
        new SqlParameter("@comPro",company.ComPro),
        new SqlParameter("@comShortName",company.ComShortName),
        new SqlParameter("@comCname",company.ComCname),
        new SqlParameter("@comCAddress",company.ComCAddress),
        new SqlParameter("@province",company.Province),
        new SqlParameter("@city",company.City),
        new SqlParameter("@comUrl",company.ComUrl),
        new SqlParameter("@used",company.Used),
        new SqlParameter("@linkName",company.LinkName),
        new SqlParameter("@post",company.Post),
        new SqlParameter("@telephone",company.Telephone),
        new SqlParameter("@fax",company.Fax),
        new SqlParameter("@mobile",company.Mobile),
        new SqlParameter("@email",company.Email),
        new SqlParameter("@msn",company.Msn),
        new SqlParameter("@skype",company.Skype),
        new SqlParameter("@bank",company.Bank),
        new SqlParameter("@cardId",company.CardId),
        new SqlParameter("@cardName",company.CardName),
        new SqlParameter("@remark",company.Remark),
        new SqlParameter("@ordernum",company.Ordernum),
        new SqlParameter("@codeformat",company.Codeformat),
        new SqlParameter("@madefrom",company.Madefrom),
        new SqlParameter("@madeTime",company.MadeTime)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Company]表删除的方法
        /// </summary>
        public static int deleteCompanyById(int id)
        {

            string sql = "delete from Company where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Company]表查询实体的方法
        /// </summary>
        public static Company getCompanyById(int id)
        {
            Company company = null;

            string sql = "select * from Company where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                company = new Company();
                foreach (DataRow dr in dt.Rows)
                {
                    company.Id = Convert.ToInt32(dr["id"]);
                    company.ComCode = Convert.ToString(dr["comCode"]);
                    company.ComType = Convert.ToInt32(dr["comType"]);
                    company.ComPro = Convert.ToInt32(dr["comPro"]);
                    company.ComShortName = Convert.ToString(dr["comShortName"]);
                    company.ComCname = Convert.ToString(dr["comCname"]);
                    company.ComCAddress = Convert.ToString(dr["comCAddress"]);
                    company.Province = Convert.ToString(dr["province"]);
                    company.City = Convert.ToString(dr["city"]);
                    company.ComUrl = Convert.ToString(dr["comUrl"]);
                    company.Used = Convert.ToInt32(dr["used"]);
                    company.LinkName = Convert.ToString(dr["linkName"]);
                    company.Post = Convert.ToString(dr["post"]);
                    company.Telephone = Convert.ToString(dr["telephone"]);
                    company.Fax = Convert.ToString(dr["fax"]);
                    company.Mobile = Convert.ToString(dr["mobile"]);
                    company.Email = Convert.ToString(dr["email"]);
                    company.Msn = Convert.ToString(dr["msn"]);
                    company.Skype = Convert.ToString(dr["skype"]);
                    company.Bank = Convert.ToString(dr["bank"]);
                    company.CardId = Convert.ToString(dr["cardId"]);
                    company.CardName = Convert.ToString(dr["cardName"]);
                    company.Remark = Convert.ToString(dr["remark"]);
                    company.Ordernum = Convert.ToString(dr["ordernum"]);
                    company.Codeformat = Convert.ToString(dr["codeformat"]);
                    company.Madefrom = Convert.ToInt32(dr["madefrom"]);
                    company.MadeTime = Convert.ToDateTime(dr["madeTime"]);
                }
            }

            return company;
        }

        /// <summary>
        ///[Company]表查询所有的方法
        /// </summary>
        public static IList<Company> getCompanyAll()
        {
            string sql = "select * from Company";
            return getCompanysBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Company> getCompanysBySql(string sql)
        {
            IList<Company> list = new List<Company>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Company company = new Company();
                    company.Id = Convert.ToInt32(dr["id"]);
                    company.ComCode = Convert.ToString(dr["comCode"]);
                    company.ComType = Convert.ToInt32(dr["comType"]);
                    company.ComPro = Convert.ToInt32(dr["comPro"]);
                    company.ComShortName = Convert.ToString(dr["comShortName"]);
                    company.ComCname = Convert.ToString(dr["comCname"]);
                    company.ComCAddress = Convert.ToString(dr["comCAddress"]);
                    company.Province = Convert.ToString(dr["province"]);
                    company.City = Convert.ToString(dr["city"]);
                    company.ComUrl = Convert.ToString(dr["comUrl"]);
                    company.Used = Convert.ToInt32(dr["used"]);
                    company.LinkName = Convert.ToString(dr["linkName"]);
                    company.Post = Convert.ToString(dr["post"]);
                    company.Telephone = Convert.ToString(dr["telephone"]);
                    company.Fax = Convert.ToString(dr["fax"]);
                    company.Mobile = Convert.ToString(dr["mobile"]);
                    company.Email = Convert.ToString(dr["email"]);
                    company.Msn = Convert.ToString(dr["msn"]);
                    company.Skype = Convert.ToString(dr["skype"]);
                    company.Bank = Convert.ToString(dr["bank"]);
                    company.CardId = Convert.ToString(dr["cardId"]);
                    company.CardName = Convert.ToString(dr["cardName"]);
                    company.Remark = Convert.ToString(dr["remark"]);
                    company.Ordernum = Convert.ToString(dr["ordernum"]);
                    company.Codeformat = Convert.ToString(dr["codeformat"]);
                    company.Madefrom = Convert.ToInt32(dr["madefrom"]);
                    company.MadeTime = Convert.ToDateTime(dr["madeTime"]);
                    list.Add(company);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Company getCompanyBySql(string sql)
        {
            Company company = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                company = new Company();
                foreach (DataRow dr in dt.Rows)
                {
                    company.Id = Convert.ToInt32(dr["id"]);
                    company.ComCode = Convert.ToString(dr["comCode"]);
                    company.ComType = Convert.ToInt32(dr["comType"]);
                    company.ComPro = Convert.ToInt32(dr["comPro"]);
                    company.ComShortName = Convert.ToString(dr["comShortName"]);
                    company.ComCname = Convert.ToString(dr["comCname"]);
                    company.ComCAddress = Convert.ToString(dr["comCAddress"]);
                    company.Province = Convert.ToString(dr["province"]);
                    company.City = Convert.ToString(dr["city"]);
                    company.ComUrl = Convert.ToString(dr["comUrl"]);
                    company.Used = Convert.ToInt32(dr["used"]);
                    company.LinkName = Convert.ToString(dr["linkName"]);
                    company.Post = Convert.ToString(dr["post"]);
                    company.Telephone = Convert.ToString(dr["telephone"]);
                    company.Fax = Convert.ToString(dr["fax"]);
                    company.Mobile = Convert.ToString(dr["mobile"]);
                    company.Email = Convert.ToString(dr["email"]);
                    company.Msn = Convert.ToString(dr["msn"]);
                    company.Skype = Convert.ToString(dr["skype"]);
                    company.Bank = Convert.ToString(dr["bank"]);
                    company.CardId = Convert.ToString(dr["cardId"]);
                    company.CardName = Convert.ToString(dr["cardName"]);
                    company.Remark = Convert.ToString(dr["remark"]);
                    company.Ordernum = Convert.ToString(dr["ordernum"]);
                    company.Codeformat = Convert.ToString(dr["codeformat"]);
                    company.Madefrom = Convert.ToInt32(dr["madefrom"]);
                    company.MadeTime = Convert.ToDateTime(dr["madeTime"]);
                }
            }
            return company;
        }



        public static Company getLastOneID()
        {
            string sql = "select Top 1 * from Company order by id  desc ";
            return getCompanyBySql(sql);
        }



        public static IList<Company> getCompanyType(int id)
        {
            string sql = "select * from Company where ComType = " + id;
            return getCompanysBySql(sql);
        }

        public static int getCount3(string comCode, string comShortName, string comCname)
        {
            string sql = "select count(*) from Company where comCode ='" + comCode + "' or comShortName = '" + comShortName + "' or comCname ='" + comCname + "'";
            return DBHelper.ExecuteScalar(sql);
        }

        public static bool getCode(string comcode)
        {
            string sql = "select count(comCode) from Company where comCode = '" + comcode + "'";
            int count = DBHelper.ExecuteScalar(sql);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否有相同名字和id的公司信息
        /// </summary>
        /// <param name="comShortName">公司简称</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool getSName(string comShortName, int id)
        {
            string sql = "select count(comShortName) from Company where comShortName = '" + comShortName + "' and ID <> " + id;
            int count = DBHelper.ExecuteScalar(sql);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool getCName(string comCname, int id)
        {
            string sql = "select count(comCname) from Company where comCname = '" + comCname + "' and ID <> " + id;
            int count = DBHelper.ExecuteScalar(sql);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Company ");
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
            strSql.Append(" FROM Company ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static DataTable GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.ID desc ");
            strSql.Append(")AS Row, T.*  from Company T ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append("WHERE ");
                strSql.Append(strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string where)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT COUNT(*) FROM Company ");

            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append("WHERE ");
                sqlBuilder.Append(where);
            }

            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlBuilder.ToString(), conn);
                object result = sqlCmd.ExecuteScalar();
                return result == null ? 0 : int.Parse(result.ToString());
            }
        }


        public static int Clear()
        {
            string sql = "truncate table Company;truncate table ComBank; truncate table ComLinkman; truncate table ComType; truncate table CompanyProd;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}
