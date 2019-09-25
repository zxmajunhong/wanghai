using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[CompanyProd]表的数据访问类
    /// </summary>
    public class CompanyProdService
    {
        /// <summary>
        ///[CompanyProd]表添加的方法
        /// </summary>
        public static int addCompanyProd(CompanyProd companyprod)
        {
            string sql = "insert into CompanyProd([companyId],[prodTypeId]) values (@companyId,@prodTypeId)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@companyId",companyprod.CompanyId),
        new SqlParameter("@prodTypeId",companyprod.ProdTypeId)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[CompanyProd]表修改的方法
        /// </summary>
        public static int updateCompanyProdById(CompanyProd companyprod)
        {

            string sql = "update CompanyProd set companyId=@companyId,prodTypeId=@prodTypeId where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",companyprod.Id),
        new SqlParameter("@companyId",companyprod.CompanyId),
        new SqlParameter("@prodTypeId",companyprod.ProdTypeId)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[CompanyProd]表删除的方法
        /// </summary>
        public static int deleteCompanyProdById(int id)
        {

            string sql = "delete from CompanyProd where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[CompanyProd]表查询实体的方法
        /// </summary>
        public static CompanyProd getCompanyProdById(int id)
        {
            CompanyProd companyprod = null;

            string sql = "select * from CompanyProd where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                companyprod = new CompanyProd();
                foreach (DataRow dr in dt.Rows)
                {
                    companyprod.Id = Convert.ToInt32(dr["id"]);
                    companyprod.CompanyId = Convert.ToInt32(dr["companyId"]);
                    companyprod.ProdTypeId = Convert.ToString(dr["prodTypeId"]);
                }
            }

            return companyprod;
        }

        /// <summary>
        ///[CompanyProd]表查询所有的方法
        /// </summary>
        public static IList<CompanyProd> getCompanyProdAll()
        {
            string sql = "select * from CompanyProd";
            return getCompanyProdsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<CompanyProd> getCompanyProdsBySql(string sql)
        {
            IList<CompanyProd> list = new List<CompanyProd>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CompanyProd companyprod = new CompanyProd();
                    companyprod.Id = Convert.ToInt32(dr["id"]);
                    companyprod.CompanyId = Convert.ToInt32(dr["companyId"]);
                    companyprod.ProdTypeId = Convert.ToString(dr["prodTypeId"]);
                    list.Add(companyprod);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static CompanyProd getCompanyProdBySql(string sql)
        {
            CompanyProd companyprod = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                companyprod = new CompanyProd();
                foreach (DataRow dr in dt.Rows)
                {
                    companyprod.Id = Convert.ToInt32(dr["id"]);
                    companyprod.CompanyId = Convert.ToInt32(dr["companyId"]);
                    companyprod.ProdTypeId = Convert.ToString(dr["prodTypeId"]);
                }
            }
            return companyprod;
        }

        public static CompanyProd getCompanyProdByComId(int id)
        {
            CompanyProd companyprod = null;

            string sql = "select * from CompanyProd where companyid=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                companyprod = new CompanyProd();
                foreach (DataRow dr in dt.Rows)
                {
                    companyprod.Id = Convert.ToInt32(dr["id"]);
                    companyprod.CompanyId = Convert.ToInt32(dr["companyId"]);
                    companyprod.ProdTypeId = Convert.ToString(dr["prodTypeId"]);
                }
            }

            return companyprod;
        }

        public static int deleteCompanyProByComId(int id)
        {
            string sql = "delete from CompanyProd where Companyid=@id";

            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);
        }

    }
}
