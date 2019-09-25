using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_PolicyDetail]表的数据访问类
    /// </summary>
    public class To_PolicyDetailService
    {
        /// <summary>
        ///[To_PolicyDetail]表添加的方法
        /// </summary>
        public static int addTo_PolicyDetail(To_PolicyDetail to_policydetail)
        {
            string sql = "insert into To_PolicyDetail([policyId],[salesman],[departname],[numrate],[fmone],[rich],[mark]) values (@policyId,@salesman,@departname,@numrate,@fmone,@rich,@mark)";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@policyId",to_policydetail.PolicyId),
                new SqlParameter("@salesman",to_policydetail.Salesman),
                new SqlParameter("@departname",to_policydetail.DepartName),
                new SqlParameter("@numrate",to_policydetail.NumRate),
                new SqlParameter("@fmone",to_policydetail.Fmone),
                new SqlParameter("@rich",to_policydetail.Rich),
                new SqlParameter("@mark",to_policydetail.Mark)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_PolicyDetail]表修改的方法
        /// </summary>
        public static int updateTo_PolicyDetailById(To_PolicyDetail to_policydetail)
        {

            string sql = "update To_PolicyDetail set policyId=@policyId,saleaman=@salesman,departname=@departname,numrate=@numrate,fmone=@fmone,rich=@rich,mark=@mark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@id",to_policydetail.Id),
                new SqlParameter("@policyId",to_policydetail.PolicyId),
                new SqlParameter("@salesman",to_policydetail.Salesman),
                new SqlParameter("@departname",to_policydetail.DepartName),
                new SqlParameter("@numrate",to_policydetail.NumRate),
                new SqlParameter("@fmone",to_policydetail.Fmone),
                new SqlParameter("@rich",to_policydetail.Rich),
                new SqlParameter("@mark",to_policydetail.Mark)
            };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_PolicyDetail]表删除的方法
        /// </summary>
        public static int deleteTo_PolicyDetailById(int id)
        {

            string sql = "delete from To_PolicyDetail where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        public static int DeleteByPolicy(int policyId)
        {
            string sql = string.Format("delete from To_PolicyDetail where policyId={0}", policyId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        ///[To_PolicyDetail]表查询实体的方法
        /// </summary>
        public static To_PolicyDetail getTo_PolicyDetailById(int id)
        {
            To_PolicyDetail to_policydetail = null;

            string sql = "select * from To_PolicyDetail where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_policydetail = new To_PolicyDetail();
                foreach (DataRow dr in dt.Rows)
                {
                    to_policydetail.Id = Convert.ToInt32(dr["id"]);
                    to_policydetail.PolicyId = Convert.ToInt32(dr["policyId"]);
                    to_policydetail.Salesman = Convert.ToString(dr["salesman"]);
                    to_policydetail.DepartName = Convert.ToString(dr["departname"]);
                    to_policydetail.NumRate = Convert.ToDecimal(dr["numrate"]);
                    to_policydetail.Fmone = Convert.ToDecimal(dr["fmone"]);
                    to_policydetail.Rich = Convert.ToDecimal(dr["rich"]);
                    to_policydetail.Mark = dr["mark"].ToString();
                }
            }

            return to_policydetail;
        }

        /// <summary>
        ///[To_PolicyDetail]表查询所有的方法
        /// </summary>
        public static IList<To_PolicyDetail> getTo_PolicyDetailAll()
        {
            string sql = "select * from To_PolicyDetail";
            return getTo_PolicyDetailsBySql(sql);
        }

        public static DataTable GetListByPolicy(int id)
        {
            string sql = string.Format("select * from To_PolicyDetail as pd join Product as p on pd.productId=p.ProdID where policyId={0}", id);
            return DBHelper.GetDataSet(sql);
        }

        /// <summary>
        /// 编辑保单中读取保单明细中的数据
        /// </summary>
        /// <param name="policyid">保单id</param>
        /// <returns></returns>
        public static DataTable GetListByPolicyId(int policyid)
        {
            string sql = string.Format("select * from To_PolicyDetail where policyId={0}", policyid);
            return DBHelper.GetDataSet(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_PolicyDetail> getTo_PolicyDetailsBySql(string sql)
        {
            IList<To_PolicyDetail> list = new List<To_PolicyDetail>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_PolicyDetail to_policydetail = new To_PolicyDetail();
                    to_policydetail.Id = Convert.ToInt32(dr["id"]);
                    to_policydetail.PolicyId = Convert.ToInt32(dr["policyId"]);
                    to_policydetail.Salesman = Convert.ToString(dr["salesman"]);
                    to_policydetail.DepartName = Convert.ToString(dr["departname"]);
                    to_policydetail.NumRate = Convert.ToDecimal(dr["numrate"]);
                    to_policydetail.Fmone = Convert.ToDecimal(dr["fmone"]);
                    to_policydetail.Rich = Convert.ToDecimal(dr["rich"]);
                    to_policydetail.Mark = dr["mark"].ToString();
                    list.Add(to_policydetail);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_PolicyDetail getTo_PolicyDetailBySql(string sql)
        {
            To_PolicyDetail to_policydetail = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_policydetail = new To_PolicyDetail();
                foreach (DataRow dr in dt.Rows)
                {
                    to_policydetail.Id = Convert.ToInt32(dr["id"]);
                    to_policydetail.PolicyId = Convert.ToInt32(dr["policyId"]);
                    to_policydetail.Salesman = Convert.ToString(dr["salesman"]);
                    to_policydetail.DepartName = Convert.ToString(dr["departname"]);
                    to_policydetail.NumRate = Convert.ToDecimal(dr["numrate"]);
                    to_policydetail.Fmone = Convert.ToDecimal(dr["fmone"]);
                    to_policydetail.Rich = Convert.ToDecimal(dr["rich"]);
                    to_policydetail.Mark = dr["mark"].ToString();
                }
            }
            return to_policydetail;
        }
    }
}
