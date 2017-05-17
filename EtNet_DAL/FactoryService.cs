using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Factory]表的数据访问类
    /// </summary>
    public class FactoryService
    {
        /// <summary>
        ///[Factory]表添加的方法
        /// </summary>
        public static int addFactory(Factory factory)
        {
            string sql = "insert into Factory([factCode],[factType],[factshortName],[factCName],[factCAddress],[province],[city],[used],[linkeName],[duty],[telephone],[fax],[mobile],[email],[QQ],[skype],[bank],[accountID],[accountName],[remark],[ordernum],[codeformat],[inputname],[inputdate]) values (@factCode,@factType,@factshortName,@factCName,@factCAddress,@province,@city,@used,@linkeName,@duty,@telephone,@fax,@mobile,@email,@QQ,@skype,@bank,@accountID,@accountName,@remark,@ordernum,@codeformat,@inputname,@inputdate)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@factCode",factory.FactCode),
        new SqlParameter("@factType",factory.FactType),
        new SqlParameter("@factshortName",factory.FactshortName),
        new SqlParameter("@factCName",factory.FactCName),
        new SqlParameter("@factCAddress",factory.FactCAddress),
        new SqlParameter("@province",factory.Province),
        new SqlParameter("@city",factory.City),
        new SqlParameter("@used",factory.Used),
        new SqlParameter("@linkeName",factory.LinkeName),
        new SqlParameter("@duty",factory.Duty),
        new SqlParameter("@telephone",factory.Telephone),
        new SqlParameter("@fax",factory.Fax),
        new SqlParameter("@mobile",factory.Mobile),
        new SqlParameter("@email",factory.Email),
        new SqlParameter("@QQ",factory.QQ),
        new SqlParameter("@skype",factory.Skype),
        new SqlParameter("@bank",factory.Bank),
        new SqlParameter("@accountID",factory.AccountID),
        new SqlParameter("@accountName",factory.AccountName),
        new SqlParameter("@remark",factory.Remark),
        new SqlParameter("@ordernum",factory.Ordernum),
        new SqlParameter("@codeformat",factory.Codeformat),
        new SqlParameter("@inputname",factory.Inputname),
        new SqlParameter("@inputdate",factory.Inputdate)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Factory]表修改的方法
        /// </summary>
        public static int updateFactoryById(Factory factory)
        {

            string sql = "update Factory set factCode=@factCode,factType=@factType,factshortName=@factshortName,factCName=@factCName,factCAddress=@factCAddress,province=@province,city=@city,used=@used,linkeName=@linkeName,duty=@duty,telephone=@telephone,fax=@fax,mobile=@mobile,email=@email,QQ=@QQ,skype=@skype,bank=@bank,accountID=@accountID,accountName=@accountName,remark=@remark,ordernum=@ordernum,codeformat=@codeformat,inputname=@inputname,inputdate=@inputdate,lasteditman=@lasteditman,lasteditdate=@lasteditdate where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",factory.Id),
        new SqlParameter("@factCode",factory.FactCode),
        new SqlParameter("@factType",factory.FactType),
        new SqlParameter("@factshortName",factory.FactshortName),
        new SqlParameter("@factCName",factory.FactCName),
        new SqlParameter("@factCAddress",factory.FactCAddress),
        new SqlParameter("@province",factory.Province),
        new SqlParameter("@city",factory.City),
        new SqlParameter("@used",factory.Used),
        new SqlParameter("@linkeName",factory.LinkeName),
        new SqlParameter("@duty",factory.Duty),
        new SqlParameter("@telephone",factory.Telephone),
        new SqlParameter("@fax",factory.Fax),
        new SqlParameter("@mobile",factory.Mobile),
        new SqlParameter("@email",factory.Email),
        new SqlParameter("@QQ",factory.QQ),
        new SqlParameter("@skype",factory.Skype),
        new SqlParameter("@bank",factory.Bank),
        new SqlParameter("@accountID",factory.AccountID),
        new SqlParameter("@accountName",factory.AccountName),
        new SqlParameter("@remark",factory.Remark),
        new SqlParameter("@ordernum",factory.Ordernum),
        new SqlParameter("@codeformat",factory.Codeformat),
        new SqlParameter("@inputname",factory.Inputname),
        new SqlParameter("@inputdate",factory.Inputdate),
        new SqlParameter("@lasteditman",factory.LastEditMan),
        new SqlParameter("@lasteditdate",factory.LastEditDate)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Factory]表删除的方法
        /// </summary>
        public static int deleteFactoryById(int id)
        {

            string sql = "delete from Factory where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Factory]表查询实体的方法
        /// </summary>
        public static Factory getFactoryById(int id)
        {
            Factory factory = null;

            string sql = "select * from Factory where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                factory = new Factory();
                foreach (DataRow dr in dt.Rows)
                {
                    factory.Id = Convert.ToInt32(dr["id"]);
                    factory.FactCode = Convert.ToString(dr["factCode"]);
                    factory.FactType = Convert.ToInt32(dr["factType"]);
                    factory.FactshortName = Convert.ToString(dr["factshortName"]);
                    factory.FactCName = Convert.ToString(dr["factCName"]);
                    factory.FactCAddress = Convert.ToString(dr["factCAddress"]);
                    factory.Province = Convert.ToString(dr["province"]);
                    factory.City = Convert.ToString(dr["city"]);
                    factory.Used = Convert.ToInt32(dr["used"]);
                    factory.LinkeName = Convert.ToString(dr["linkeName"]);
                    factory.Duty = Convert.ToString(dr["duty"]);
                    factory.Telephone = Convert.ToString(dr["telephone"]);
                    factory.Fax = Convert.ToString(dr["fax"]);
                    factory.Mobile = Convert.ToString(dr["mobile"]);
                    factory.Email = Convert.ToString(dr["email"]);
                    factory.QQ = Convert.ToString(dr["QQ"]);
                    factory.Skype = Convert.ToString(dr["skype"]);
                    factory.Bank = Convert.ToString(dr["bank"]);
                    factory.AccountID = Convert.ToString(dr["accountID"]);
                    factory.AccountName = Convert.ToString(dr["accountName"]);
                    factory.Remark = Convert.ToString(dr["remark"]);
                    factory.Ordernum = Convert.ToString(dr["ordernum"]);
                    factory.Codeformat = Convert.ToString(dr["codeformat"]);
                    factory.Inputname = Convert.ToInt32(dr["inputname"]);
                    factory.Inputdate = Convert.ToDateTime(dr["inputdate"]);
                }
            }

            return factory;
        }

        /// <summary>
        ///[Factory]表查询所有的方法
        /// </summary>
        public static IList<Factory> getFactoryAll()
        {
            string sql = "select * from Factory";
            return getFactorysBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Factory> getFactorysBySql(string sql)
        {
            IList<Factory> list = new List<Factory>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Factory factory = new Factory();
                    factory.Id = Convert.ToInt32(dr["id"]);
                    factory.FactCode = Convert.ToString(dr["factCode"]);
                    factory.FactType = Convert.ToInt32(dr["factType"]);
                    factory.FactshortName = Convert.ToString(dr["factshortName"]);
                    factory.FactCName = Convert.ToString(dr["factCName"]);
                    factory.FactCAddress = Convert.ToString(dr["factCAddress"]);
                    factory.Province = Convert.ToString(dr["province"]);
                    factory.City = Convert.ToString(dr["city"]);
                    factory.Used = Convert.ToInt32(dr["used"]);
                    factory.LinkeName = Convert.ToString(dr["linkeName"]);
                    factory.Duty = Convert.ToString(dr["duty"]);
                    factory.Telephone = Convert.ToString(dr["telephone"]);
                    factory.Fax = Convert.ToString(dr["fax"]);
                    factory.Mobile = Convert.ToString(dr["mobile"]);
                    factory.Email = Convert.ToString(dr["email"]);
                    factory.QQ = Convert.ToString(dr["QQ"]);
                    factory.Skype = Convert.ToString(dr["skype"]);
                    factory.Bank = Convert.ToString(dr["bank"]);
                    factory.AccountID = Convert.ToString(dr["accountID"]);
                    factory.AccountName = Convert.ToString(dr["accountName"]);
                    factory.Remark = Convert.ToString(dr["remark"]);
                    factory.Ordernum = Convert.ToString(dr["ordernum"]);
                    factory.Codeformat = Convert.ToString(dr["codeformat"]);
                    factory.Inputname = Convert.ToInt32(dr["inputname"]);
                    factory.Inputdate = Convert.ToDateTime(dr["inputdate"]);
                    list.Add(factory);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Factory getFactoryBySql(string sql)
        {
            Factory factory = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                factory = new Factory();
                foreach (DataRow dr in dt.Rows)
                {
                    factory.Id = Convert.ToInt32(dr["id"]);
                    factory.FactCode = Convert.ToString(dr["factCode"]);
                    factory.FactType = Convert.ToInt32(dr["factType"]);
                    factory.FactshortName = Convert.ToString(dr["factshortName"]);
                    factory.FactCName = Convert.ToString(dr["factCName"]);
                    factory.FactCAddress = Convert.ToString(dr["factCAddress"]);
                    factory.Province = Convert.ToString(dr["province"]);
                    factory.City = Convert.ToString(dr["city"]);
                    factory.Used = Convert.ToInt32(dr["used"]);
                    factory.LinkeName = Convert.ToString(dr["linkeName"]);
                    factory.Duty = Convert.ToString(dr["duty"]);
                    factory.Telephone = Convert.ToString(dr["telephone"]);
                    factory.Fax = Convert.ToString(dr["fax"]);
                    factory.Mobile = Convert.ToString(dr["mobile"]);
                    factory.Email = Convert.ToString(dr["email"]);
                    factory.QQ = Convert.ToString(dr["QQ"]);
                    factory.Skype = Convert.ToString(dr["skype"]);
                    factory.Bank = Convert.ToString(dr["bank"]);
                    factory.AccountID = Convert.ToString(dr["accountID"]);
                    factory.AccountName = Convert.ToString(dr["accountName"]);
                    factory.Remark = Convert.ToString(dr["remark"]);
                    factory.Ordernum = Convert.ToString(dr["ordernum"]);
                    factory.Codeformat = Convert.ToString(dr["codeformat"]);
                    factory.Inputname = Convert.ToInt32(dr["inputname"]);
                    factory.Inputdate = Convert.ToDateTime(dr["inputdate"]);
                }
            }
            return factory;
        }

        public static DataTable GetList(string strsql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Factory ");
            if (strsql.Trim() != "")
            {
                strSql.Append(" where " + strsql);
            }
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }

        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Factory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }

        public static bool getSName(string factshortname, int num)
        {
            string sql = "select count(factshortName) from Factory where factshortName = '" + factshortname + "' and ID <> " + num;
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

        public static bool getCName(string factCName, int num)
        {
            string sql = "select count(factCName) from Factory where factCName = '" + factCName + "' and ID <> " + num;
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

        public static Factory getLastOneID()
        {
            string sql = "select top 1 * from Factory order by id desc";
            return getFactoryBySql(sql);
        }
        public static IList<Factory> getFactoryType(int id)
        {
            string sql = "select * from Factory where factType = " + id;
            return getFactorysBySql(sql);
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
            strSql.Append(")AS Row, T.*  from Factory T ");

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
            sqlBuilder.Append("SELECT COUNT(*) FROM Factory ");

            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append("WHERE ");
                sqlBuilder.Append(where);
            }

            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
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
            string sql = "truncate table Factory;truncate table FactBank;truncate table FactLinkman;truncate table FactType";
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 得到做过付款申请并且付款申请审核通过的单位信息并且是没有做过确认的单位
        /// </summary>
        /// <returns></returns>
        public static DataTable getFactoryWhichHasPayment()
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append(" select distinct Factory.* ");
            sqlstr.Append(" from Factory inner join View_PaymentList on Factory.id = View_PaymentList.payerID ");
            sqlstr.Append(" where View_PaymentList.auditstatus = '04' and isConfirm <> 1 ");
            return DBHelper.GetDataSet(sqlstr.ToString());
        }
    }
}
