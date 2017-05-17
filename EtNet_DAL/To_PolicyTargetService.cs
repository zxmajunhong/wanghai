using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_PolicyTarget]表的数据访问类
    /// </summary>
    public class To_PolicyTargetService
    {
        /// <summary>
        ///[To_PolicyTarget]表添加的方法
        /// </summary>
        public static int addTo_PolicyTarget(To_PolicyTarget To_PolicyTarget)
        {
            string sql = "insert into To_PolicyTarget([policyID],[propertyName],[propertyValue],[propertyTypeID],[propertyID],[datatype]) values (@policyID,@propertyName,@propertyValue,@propertyTypeID,@propertyID,@datatype)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@policyID",To_PolicyTarget.PolicyID),
        new SqlParameter("@propertyName",To_PolicyTarget.PropertyName),
        new SqlParameter("@propertyValue",To_PolicyTarget.PropertyValue),
        new SqlParameter("@propertyTypeID",To_PolicyTarget.PropertyTypeID),
        new SqlParameter("@propertyID",To_PolicyTarget.PropertyID),
        new SqlParameter("@datatype",To_PolicyTarget.Datatype)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_PolicyTarget]表修改的方法
        /// </summary>
        public static int updateTo_PolicyTargetById(To_PolicyTarget To_PolicyTarget)
        {

            string sql = "update To_PolicyTarget set policyID=@policyID,propertyName=@propertyName,propertyValue=@propertyValue,propertyTypeID=@propertyTypeID,propertyID=@propertyID,datatype=@datatype where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",To_PolicyTarget.Id),
        new SqlParameter("@policyID",To_PolicyTarget.PolicyID),
        new SqlParameter("@propertyName",To_PolicyTarget.PropertyName),
        new SqlParameter("@propertyValue",To_PolicyTarget.PropertyValue),
        new SqlParameter("@propertyTypeID",To_PolicyTarget.PropertyTypeID),
        new SqlParameter("@propertyID",To_PolicyTarget.PropertyID),
        new SqlParameter("@datatype",To_PolicyTarget.Datatype)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_PolicyTarget]表删除的方法
        /// </summary>
        public static int deleteTo_PolicyTargetById(int id)
        {

            string sql = "delete from To_PolicyTarget where id=@id";
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

            string sql = "delete from To_PolicyTarget where policyID=@policyID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@policyID",policyID)
            };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_PolicyTarget]表查询实体的方法
        /// </summary>
        public static To_PolicyTarget getTo_PolicyTargetById(int id)
        {
            To_PolicyTarget To_PolicyTarget = null;

            string sql = "select * from To_PolicyTarget where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                To_PolicyTarget = new To_PolicyTarget();
                foreach (DataRow dr in dt.Rows)
                {
                    To_PolicyTarget.Id = Convert.ToInt32(dr["id"]);
                    To_PolicyTarget.PolicyID = Convert.ToInt32(dr["policyID"]);
                    To_PolicyTarget.PropertyName = Convert.ToString(dr["propertyName"]);
                    To_PolicyTarget.PropertyValue = Convert.ToString(dr["propertyValue"]);
                    To_PolicyTarget.PropertyTypeID = Convert.ToInt32(dr["propertyTypeID"]);
                    To_PolicyTarget.PropertyID = Convert.ToInt32(dr["propertyID"]);
                    To_PolicyTarget.Datatype = Convert.ToInt32(dr["datatype"]);
                }
            }

            return To_PolicyTarget;
        }

        /// <summary>
        ///[To_PolicyTarget]表查询所有的方法
        /// </summary>
        public static IList<To_PolicyTarget> getTo_PolicyTargetAll()
        {
            string sql = "select * from To_PolicyTarget";
            return getTo_PolicyTargetsBySql(sql);
        }

        public static IList<To_PolicyTarget> GetListByPolicy(int policyID)
        {
            string sql = string.Format("select * from To_PolicyTarget where policyID={0}", policyID);
            return getTo_PolicyTargetsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_PolicyTarget> getTo_PolicyTargetsBySql(string sql)
        {
            IList<To_PolicyTarget> list = new List<To_PolicyTarget>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_PolicyTarget To_PolicyTarget = new To_PolicyTarget();
                    To_PolicyTarget.Id = Convert.ToInt32(dr["id"]);
                    To_PolicyTarget.PolicyID = Convert.ToInt32(dr["policyID"]);
                    To_PolicyTarget.PropertyName = Convert.ToString(dr["propertyName"]);
                    To_PolicyTarget.PropertyValue = Convert.ToString(dr["propertyValue"]);
                    To_PolicyTarget.PropertyTypeID = Convert.ToInt32(dr["propertyTypeID"]);
                    To_PolicyTarget.PropertyID = Convert.ToInt32(dr["propertyID"]);
                    To_PolicyTarget.Datatype = Convert.ToInt32(dr["datatype"]);
                    list.Add(To_PolicyTarget);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_PolicyTarget getTo_PolicyTargetBySql(string sql)
        {
            To_PolicyTarget To_PolicyTarget = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                To_PolicyTarget = new To_PolicyTarget();
                foreach (DataRow dr in dt.Rows)
                {
                    To_PolicyTarget.Id = Convert.ToInt32(dr["id"]);
                    To_PolicyTarget.PolicyID = Convert.ToInt32(dr["policyID"]);
                    To_PolicyTarget.PropertyName = Convert.ToString(dr["propertyName"]);
                    To_PolicyTarget.PropertyValue = Convert.ToString(dr["propertyValue"]);
                    To_PolicyTarget.PropertyTypeID = Convert.ToInt32(dr["propertyTypeID"]);
                    To_PolicyTarget.PropertyID = Convert.ToInt32(dr["propertyID"]);
                    To_PolicyTarget.Datatype = Convert.ToInt32(dr["datatype"]);
                }
            }
            return To_PolicyTarget;
        }
    }
}
