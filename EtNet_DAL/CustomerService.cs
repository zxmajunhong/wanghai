using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Customer]表的数据访问类
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        ///[Customer]表添加的方法
        /// </summary>
        public static int addCustomer(Customer customer)
        {
            string sql = "insert into Customer([cusCode],[cusType],[cusPro],[cusshortName],[cusCName],[cusCAddress],[province],[city],[companyURL],[used],[linkName],[post],[telephone],[fax],[mobile],[email],[msn],[skype],[bank],[cardId],[cardName],[remark],[ordernum],[codeformat],[madefrom],[madeTime],[jobflowid],[txt],[viewidlist],[viewidtxt],[authidlist],[authidtxt],[newRatio],[oldRatio]) values (@cusCode,@cusType,@cusPro,@cusshortName,@cusCName,@cusCAddress,@province,@city,@companyURL,@used,@linkName,@post,@telephone,@fax,@mobile,@email,@msn,@skype,@bank,@cardId,@cardName,@remark,@ordernum,@codeformat,@madefrom,@madeTime,@jobflowid,@txt,@viewidlist,@viewidtxt,@authidlist,@authidtxt,@newRatio,@oldRatio);select @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
              {
                new SqlParameter("@cusCode",customer.CusCode),
                new SqlParameter("@cusType",customer.CusType),
                new SqlParameter("@cusPro",customer.CusPro),
                new SqlParameter("@cusshortName",customer.CusshortName),
                new SqlParameter("@cusCName",customer.CusCName),
                new SqlParameter("@cusCAddress",customer.CusCAddress),
                new SqlParameter("@province",customer.Province),
                new SqlParameter("@city",customer.City),
                new SqlParameter("@companyURL",customer.CompanyURL),
                new SqlParameter("@used",customer.Used),
                new SqlParameter("@linkName",customer.LinkName),
                new SqlParameter("@post",customer.Post),
                new SqlParameter("@telephone",customer.Telephone),
                new SqlParameter("@fax",customer.Fax),
                new SqlParameter("@mobile",customer.Mobile),
                new SqlParameter("@email",customer.Email),
                new SqlParameter("@msn",customer.Msn),
                new SqlParameter("@skype",customer.Skype),
                new SqlParameter("@bank",customer.Bank),
                new SqlParameter("@cardId",customer.CardId),
                new SqlParameter("@cardName",customer.CardName),
                new SqlParameter("@remark",customer.Remark),
                new SqlParameter("@ordernum",customer.Ordernum),
                new SqlParameter("@codeformat",customer.Codeformat),
                new SqlParameter("@madefrom",customer.Madefrom),
                new SqlParameter("@madeTime",customer.MadeTime),
                new SqlParameter("@jobflowid",customer.Jobflowid),
                new SqlParameter("@txt",customer.Txt),
                new SqlParameter("@viewidlist",customer.Viewidlist),
                new SqlParameter("@viewidtxt",customer.Viewidtxt),
                new SqlParameter("@authidlist",customer.Authidlist),
                new SqlParameter("@authidtxt",customer.Authidtxt),
                new SqlParameter("@newRatio",customer.newRatio),
                new SqlParameter("@oldRatio",customer.oldRatio)
              };
            //return DBHelper.ExecuteCommand(sql, sp);
            return DBHelper.ExecuteScalar(sql, sp);
        }

        /// <summary>
        ///[Customer]表修改的方法
        /// </summary>
        public static int updateCustomerById(Customer customer)
        {

            string sql = "update Customer set cusCode=@cusCode,cusType=@cusType,cusPro=@cusPro,cusshortName=@cusshortName,cusCName=@cusCName,cusCAddress=@cusCAddress,province=@province,city=@city,companyURL=@companyURL,used=@used,linkName=@linkName,post=@post,telephone=@telephone,fax=@fax,mobile=@mobile,email=@email,msn=@msn,skype=@skype,bank=@bank,cardId=@cardId,cardName=@cardName,remark=@remark,ordernum=@ordernum,codeformat=@codeformat,madefrom=@madefrom,madeTime=@madeTime,jobflowid=@jobflowid,txt = @txt,viewidlist =@viewidlist, viewidtxt = @viewidtxt, authidlist=@authidlist, authidtxt=@authidtxt, newRatio=@newRatio, oldRatio=@oldRatio, lasteditman=@lasteditman, lasteditdate=@lasteditdate where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
                new SqlParameter("@id",customer.Id),
                new SqlParameter("@cusCode",customer.CusCode),
                new SqlParameter("@cusType",customer.CusType),
                new SqlParameter("@cusPro",customer.CusPro),
                new SqlParameter("@cusshortName",customer.CusshortName),
                new SqlParameter("@cusCName",customer.CusCName),
                new SqlParameter("@cusCAddress",customer.CusCAddress),
                new SqlParameter("@province",customer.Province),
                new SqlParameter("@city",customer.City),
                new SqlParameter("@companyURL",customer.CompanyURL),
                new SqlParameter("@used",customer.Used),
                new SqlParameter("@linkName",customer.LinkName),
                new SqlParameter("@post",customer.Post),
                new SqlParameter("@telephone",customer.Telephone),
                new SqlParameter("@fax",customer.Fax),
                new SqlParameter("@mobile",customer.Mobile),
                new SqlParameter("@email",customer.Email),
                new SqlParameter("@msn",customer.Msn),
                new SqlParameter("@skype",customer.Skype),
                new SqlParameter("@bank",customer.Bank),
                new SqlParameter("@cardId",customer.CardId),
                new SqlParameter("@cardName",customer.CardName),
                new SqlParameter("@remark",customer.Remark),
                new SqlParameter("@ordernum",customer.Ordernum),
                new SqlParameter("@codeformat",customer.Codeformat),
                new SqlParameter("@madefrom",customer.Madefrom),
                new SqlParameter("@madeTime",customer.MadeTime),
                new SqlParameter("@jobflowid",customer.Jobflowid),
                new SqlParameter("@txt",customer.Txt),
                new SqlParameter("@viewidlist",customer.Viewidlist),
                new SqlParameter("@viewidtxt",customer.Viewidtxt),
                new SqlParameter("@authidlist",customer.Authidlist),
                new SqlParameter("@authidtxt",customer.Authidtxt),
                new SqlParameter("@newRatio",customer.newRatio),
                new SqlParameter("@oldRatio",customer.oldRatio),
                new SqlParameter("@lasteditman",customer.LastEditMan),
                new SqlParameter("@lasteditdate",customer.LastEditDate)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        /// 更新客户等级（新客户，老客户）
        /// </summary>
        /// <param name="cusID"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static int updateCustomenPro(string cusID, string pro)
        {
            string sql = " update Customer set cusPro=@cusPro where id=@id ";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",cusID),
                new SqlParameter("@cusPro",pro)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Customer]表删除的方法
        /// </summary>
        public static int deleteCustomerById(int id)
        {

            string sql = "delete from Customer where id=@id";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", id) };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Customer]表查询实体的方法
        /// </summary>
        public static Customer getCustomerById(int id)
        {
            Customer customer = null;

            string sql = "select * from Customer where id=@id";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", id) };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                customer = new Customer();
                foreach (DataRow dr in dt.Rows)
                {
                    customer.Id = Convert.ToInt32(dr["id"]);
                    customer.CusCode = Convert.ToString(dr["cusCode"]);
                    customer.CusType = Convert.ToInt32(dr["cusType"]);
                    customer.CusPro = Convert.ToInt32(dr["cusPro"]);
                    customer.CusshortName = Convert.ToString(dr["cusshortName"]);
                    customer.CusCName = Convert.ToString(dr["cusCName"]);
                    customer.CusCAddress = Convert.ToString(dr["cusCAddress"]);
                    customer.Province = Convert.ToString(dr["province"]);
                    customer.City = Convert.ToString(dr["city"]);
                    customer.CompanyURL = Convert.ToString(dr["companyURL"]);
                    customer.Used = Convert.ToInt32(dr["used"]);
                    customer.LinkName = Convert.ToString(dr["linkName"]);
                    customer.Post = Convert.ToString(dr["post"]);
                    customer.Telephone = Convert.ToString(dr["telephone"]);
                    customer.Fax = Convert.ToString(dr["fax"]);
                    customer.Mobile = Convert.ToString(dr["mobile"]);
                    customer.Email = Convert.ToString(dr["email"]);
                    customer.Msn = Convert.ToString(dr["msn"]);
                    customer.Skype = Convert.ToString(dr["skype"]);
                    customer.Bank = Convert.ToString(dr["bank"]);
                    customer.CardId = Convert.ToString(dr["cardId"]);
                    customer.CardName = Convert.ToString(dr["cardName"]);
                    customer.Remark = Convert.ToString(dr["remark"]);
                    customer.Ordernum = Convert.ToString(dr["ordernum"]);
                    customer.Codeformat = Convert.ToString(dr["codeformat"]);
                    customer.Madefrom = Convert.ToInt32(dr["madefrom"]);
                    customer.MadeTime = Convert.ToDateTime(dr["madeTime"]);
                    customer.Jobflowid = Convert.ToInt32(dr["jobflowid"]);
                    customer.Txt = Convert.ToString(dr["txt"]);
                    customer.Viewidlist = Convert.ToString(dr["viewidlist"]);
                    customer.Viewidtxt = Convert.ToString(dr["viewidtxt"]);
                    customer.Authidlist = Convert.ToString(dr["authidlist"]);
                    customer.Authidtxt = Convert.ToString(dr["authidtxt"]);
                    customer.newRatio = Convert.IsDBNull(dr["newRatio"]) ? 0.0 : Convert.ToDouble(dr["newRatio"]);
                    customer.oldRatio = Convert.IsDBNull(dr["oldRatio"]) ? 0.0 : Convert.ToDouble(dr["oldRatio"]);
                }
            }

            return customer;
        }

        /// <summary>
        ///[Customer]表查询所有的方法
        /// </summary>
        public static IList<Customer> getCustomerAll()
        {
            string sql = "select * from Customer";
            return getCustomersBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Customer> getCustomersBySql(string sql)
        {
            IList<Customer> list = new List<Customer>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(dr["id"]);
                    customer.CusCode = Convert.ToString(dr["cusCode"]);
                    customer.CusType = Convert.ToInt32(dr["cusType"]);
                    customer.CusPro = Convert.ToInt32(dr["cusPro"]);
                    customer.CusshortName = Convert.ToString(dr["cusshortName"]);
                    customer.CusCName = Convert.ToString(dr["cusCName"]);
                    customer.CusCAddress = Convert.ToString(dr["cusCAddress"]);
                    customer.Province = Convert.ToString(dr["province"]);
                    customer.City = Convert.ToString(dr["city"]);
                    customer.CompanyURL = Convert.ToString(dr["companyURL"]);
                    customer.Used = Convert.ToInt32(dr["used"]);
                    customer.LinkName = Convert.ToString(dr["linkName"]);
                    customer.Post = Convert.ToString(dr["post"]);
                    customer.Telephone = Convert.ToString(dr["telephone"]);
                    customer.Fax = Convert.ToString(dr["fax"]);
                    customer.Mobile = Convert.ToString(dr["mobile"]);
                    customer.Email = Convert.ToString(dr["email"]);
                    customer.Msn = Convert.ToString(dr["msn"]);
                    customer.Skype = Convert.ToString(dr["skype"]);
                    customer.Bank = Convert.ToString(dr["bank"]);
                    customer.CardId = Convert.ToString(dr["cardId"]);
                    customer.CardName = Convert.ToString(dr["cardName"]);
                    customer.Remark = Convert.ToString(dr["remark"]);
                    customer.Ordernum = Convert.ToString(dr["ordernum"]);
                    customer.Codeformat = Convert.ToString(dr["codeformat"]);
                    customer.Madefrom = Convert.ToInt32(dr["madefrom"]);
                    customer.MadeTime = Convert.ToDateTime(dr["madeTime"]);
                    customer.Jobflowid = Convert.ToInt32(dr["jobflowid"]);
                    customer.Txt = Convert.ToString(dr["txt"]);
                    customer.Viewidlist = Convert.ToString(dr["viewidlist"]);
                    customer.Viewidtxt = Convert.ToString(dr["viewidtxt"]);
                    customer.Authidlist = Convert.ToString(dr["authidlist"]);
                    customer.Authidtxt = Convert.ToString(dr["authidtxt"]);
                    customer.newRatio = Convert.IsDBNull(dr["newRatio"]) ? 0.0 : Convert.ToDouble(dr["newRatio"]);
                    customer.oldRatio = Convert.IsDBNull(dr["oldRatio"]) ? 0.0 : Convert.ToDouble(dr["oldRatio"]);
                    list.Add(customer);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Customer getCustomerBySql(string sql)
        {
            Customer customer = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                customer = new Customer();
                foreach (DataRow dr in dt.Rows)
                {
                    customer.Id = Convert.ToInt32(dr["id"]);
                    customer.CusCode = Convert.ToString(dr["cusCode"]);
                    customer.CusType = Convert.ToInt32(dr["cusType"]);
                    customer.CusPro = Convert.ToInt32(dr["cusPro"]);
                    customer.CusshortName = Convert.ToString(dr["cusshortName"]);
                    customer.CusCName = Convert.ToString(dr["cusCName"]);
                    customer.CusCAddress = Convert.ToString(dr["cusCAddress"]);
                    customer.Province = Convert.ToString(dr["province"]);
                    customer.City = Convert.ToString(dr["city"]);
                    customer.CompanyURL = Convert.ToString(dr["companyURL"]);
                    customer.Used = Convert.ToInt32(dr["used"]);
                    customer.LinkName = Convert.ToString(dr["linkName"]);
                    customer.Post = Convert.ToString(dr["post"]);
                    customer.Telephone = Convert.ToString(dr["telephone"]);
                    customer.Fax = Convert.ToString(dr["fax"]);
                    customer.Mobile = Convert.ToString(dr["mobile"]);
                    customer.Email = Convert.ToString(dr["email"]);
                    customer.Msn = Convert.ToString(dr["msn"]);
                    customer.Skype = Convert.ToString(dr["skype"]);
                    customer.Bank = Convert.ToString(dr["bank"]);
                    customer.CardId = Convert.ToString(dr["cardId"]);
                    customer.CardName = Convert.ToString(dr["cardName"]);
                    customer.Remark = Convert.ToString(dr["remark"]);
                    customer.Ordernum = Convert.ToString(dr["ordernum"]);
                    customer.Codeformat = Convert.ToString(dr["codeformat"]);
                    customer.Madefrom = Convert.ToInt32(dr["madefrom"]);
                    customer.MadeTime = Convert.ToDateTime(dr["madeTime"]);
                    customer.Jobflowid = Convert.ToInt32(dr["jobflowid"]);
                    customer.Txt = Convert.ToString(dr["txt"]);
                    customer.Viewidlist = Convert.ToString(dr["viewidlist"]);
                    customer.Viewidtxt = Convert.ToString(dr["viewidtxt"]);
                    customer.Authidlist = Convert.ToString(dr["authidlist"]);
                    customer.Authidtxt = Convert.ToString(dr["authidtxt"]);
                    customer.newRatio = Convert.IsDBNull(dr["newRatio"]) ? 0.0 : Convert.ToDouble(dr["newRatio"]);
                    customer.oldRatio = Convert.IsDBNull(dr["oldRatio"]) ? 0.0 : Convert.ToDouble(dr["oldRatio"]);
                }
            }
            return customer;
        }


        public static Customer getLastOneID()
        {
            string sql = "select top 1 * from Customer order by id desc";
            return getCustomerBySql(sql);
        }

        public static IList<Customer> getCustomerType(int id)
        {
            string sql = "select * from Customer where CusType = " + id;
            return getCustomersBySql(sql);
        }

        public static int getCount3(string cusCode, string cusshortname, string cusCName, int num)
        {
            string sql = "select count(*) from Customer where cusCode='" + cusCode + "' or cusShortname ='" + cusshortname + "' or cusCname ='" + cusCName + "' and ID <> " + num;
            return DBHelper.ExecuteScalar(sql);
        }

        public static bool getCode(string cusCode, int num)
        {
            string sql = "select count(cusCode) from Customer where CusCode = '" + cusCode + "' and ID <> " + num;
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

        public static bool getSName(string cusshortname, int num)
        {
            string sql = "select count(cusshortname) from Customer where cusShortname = '" + cusshortname + "' and ID <> " + num;
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

        public static bool getCName(string cusCName, int num)
        {
            string sql = "select count(cusCName) from Customer where cusCName = '" + cusCName + "' and ID <> " + num;
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
            strSql.Append(" FROM Customer ");
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
            strSql.Append(" FROM Customer ");
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
            strSql.Append(")AS Row, T.*  from Customer T ");

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
            sqlBuilder.Append("SELECT COUNT(*) FROM Customer ");

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

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public static int Clear()
        {
            string sql = "truncate table Customer;truncate table CusBank; truncate table CusLinkman; truncate table CusType;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}
