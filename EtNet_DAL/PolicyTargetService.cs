using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[PolicyTarget]表的数据访问类
    /// </summary>
    public class PolicyTargetService
    {
        /// <summary>
        ///[PolicyTarget]表添加的方法
        /// </summary>
        public static int addPolicyTarget(PolicyTarget policytarget)
        {
            string sql = "insert into PolicyTarget([policyID],[propertyName],[propertyValue],[propertyTypeID],[propertyID],[datatype]) values (@policyID,@propertyName,@propertyValue,@propertyTypeID,@propertyID,@datatype)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@policyID",policytarget.PolicyID),
        new SqlParameter("@propertyName",policytarget.PropertyName),
        new SqlParameter("@propertyValue",policytarget.PropertyValue),
        new SqlParameter("@propertyTypeID",policytarget.PropertyTypeID),
        new SqlParameter("@propertyID",policytarget.PropertyID),
        new SqlParameter("@datatype",policytarget.Datatype)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[PolicyTarget]表修改的方法
        /// </summary>
        public static int updatePolicyTargetById(PolicyTarget policytarget)
        {

            string sql = "update PolicyTarget set policyID=@policyID,propertyName=@propertyName,propertyValue=@propertyValue,propertyTypeID=@propertyTypeID,propertyID=@propertyID,datatype=@datatype where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",policytarget.Id),
        new SqlParameter("@policyID",policytarget.PolicyID),
        new SqlParameter("@propertyName",policytarget.PropertyName),
        new SqlParameter("@propertyValue",policytarget.PropertyValue),
        new SqlParameter("@propertyTypeID",policytarget.PropertyTypeID),
        new SqlParameter("@propertyID",policytarget.PropertyID),
        new SqlParameter("@datatype",policytarget.Datatype)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[PolicyTarget]表删除的方法
        /// </summary>
        public static int deletePolicyTargetById(int id)
        {

            string sql = "delete from PolicyTarget where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }


        /// <summary>
        /// 根据保单对应的属性
        /// </summary>
        /// <param name="policyID"></param>
        /// <returns></returns>
        public static int DeleteByPolicy(int policyID)
        {

            string sql = "delete from PolicyTarget where policyID=@policyID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@policyID",policyID)
            };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[PolicyTarget]表查询实体的方法
        /// </summary>
        public static PolicyTarget getPolicyTargetById(int id)
        {
            PolicyTarget policytarget = null;

            string sql = "select * from PolicyTarget where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                policytarget = new PolicyTarget();
                foreach (DataRow dr in dt.Rows)
                {
                    policytarget.Id = Convert.ToInt32(dr["id"]);
                    policytarget.PolicyID = Convert.ToInt32(dr["policyID"]);
                    policytarget.PropertyName = Convert.ToString(dr["propertyName"]);
                    policytarget.PropertyValue = Convert.ToString(dr["propertyValue"]);
                    policytarget.PropertyTypeID = Convert.ToInt32(dr["propertyTypeID"]);
                    policytarget.PropertyID = Convert.ToInt32(dr["propertyID"]);
                    policytarget.Datatype = Convert.ToInt32(dr["datatype"]);
                }
            }

            return policytarget;
        }

        /// <summary>
        ///[PolicyTarget]表查询所有的方法
        /// </summary>
        public static IList<PolicyTarget> getPolicyTargetAll()
        {
            string sql = "select * from PolicyTarget";
            return getPolicyTargetsBySql(sql);
        }

        public static IList<PolicyTarget> GetListByPolicy(int policyID)
        {
            string sql = string.Format("select * from PolicyTarget where policyID={0}", policyID);
            return getPolicyTargetsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<PolicyTarget> getPolicyTargetsBySql(string sql)
        {
            IList<PolicyTarget> list = new List<PolicyTarget>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PolicyTarget policytarget = new PolicyTarget();
                    policytarget.Id = Convert.ToInt32(dr["id"]);
                    policytarget.PolicyID = Convert.ToInt32(dr["policyID"]);
                    policytarget.PropertyName = Convert.ToString(dr["propertyName"]);
                    policytarget.PropertyValue = Convert.ToString(dr["propertyValue"]);
                    policytarget.PropertyTypeID = Convert.ToInt32(dr["propertyTypeID"]);
                    policytarget.PropertyID = Convert.ToInt32(dr["propertyID"]);
                    policytarget.Datatype = Convert.ToInt32(dr["datatype"]);
                    list.Add(policytarget);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static PolicyTarget getPolicyTargetBySql(string sql)
        {
            PolicyTarget policytarget = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                policytarget = new PolicyTarget();
                foreach (DataRow dr in dt.Rows)
                {
                    policytarget.Id = Convert.ToInt32(dr["id"]);
                    policytarget.PolicyID = Convert.ToInt32(dr["policyID"]);
                    policytarget.PropertyName = Convert.ToString(dr["propertyName"]);
                    policytarget.PropertyValue = Convert.ToString(dr["propertyValue"]);
                    policytarget.PropertyTypeID = Convert.ToInt32(dr["propertyTypeID"]);
                    policytarget.PropertyID = Convert.ToInt32(dr["propertyID"]);
                    policytarget.Datatype = Convert.ToInt32(dr["datatype"]);
                }
            }
            return policytarget;
        }
    }
}
