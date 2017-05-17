using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[ComLinkman]表的数据访问类
    /// </summary>
    public class ComLinkmanService
    {
        /// <summary>
        ///[ComLinkman]表添加的方法
        /// </summary>
        public static int addComLinkman(ComLinkman comlinkman)
        {
            string sql = "insert into ComLinkman([companyId],[linkName],[post],[telephone],[fax],[mobile],[email],[msn],[skype]) values (@companyId,@linkName,@post,@telephone,@fax,@mobile,@email,@msn,@skype)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@companyId",comlinkman.CompanyId),
        new SqlParameter("@linkName",comlinkman.LinkName),
        new SqlParameter("@post",comlinkman.Post),
        new SqlParameter("@telephone",comlinkman.Telephone),
        new SqlParameter("@fax",comlinkman.Fax),
        new SqlParameter("@mobile",comlinkman.Mobile),
        new SqlParameter("@email",comlinkman.Email),
        new SqlParameter("@msn",comlinkman.Msn),
        new SqlParameter("@skype",comlinkman.Skype)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[ComLinkman]表修改的方法
        /// </summary>
        public static int updateComLinkmanById(ComLinkman comlinkman)
        {

            string sql = "update ComLinkman set companyId=@companyId,linkName=@linkName,post=@post,telephone=@telephone,fax=@fax,mobile=@mobile,email=@email,msn=@msn,skype=@skype where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",comlinkman.Id),
        new SqlParameter("@companyId",comlinkman.CompanyId),
        new SqlParameter("@linkName",comlinkman.LinkName),
        new SqlParameter("@post",comlinkman.Post),
        new SqlParameter("@telephone",comlinkman.Telephone),
        new SqlParameter("@fax",comlinkman.Fax),
        new SqlParameter("@mobile",comlinkman.Mobile),
        new SqlParameter("@email",comlinkman.Email),
        new SqlParameter("@msn",comlinkman.Msn),
        new SqlParameter("@skype",comlinkman.Skype)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[ComLinkman]表删除的方法
        /// </summary>
        public static int deleteComLinkmanById(int id)
        {

            string sql = "delete from ComLinkman where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[ComLinkman]表查询实体的方法
        /// </summary>
        public static ComLinkman getComLinkmanById(int id)
        {
            ComLinkman comlinkman = null;

            string sql = "select * from ComLinkman where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                comlinkman = new ComLinkman();
                foreach (DataRow dr in dt.Rows)
                {
                    comlinkman.Id = Convert.ToInt32(dr["id"]);
                    comlinkman.CompanyId = Convert.ToInt32(dr["companyId"]);
                    comlinkman.LinkName = Convert.ToString(dr["linkName"]);
                    comlinkman.Post = Convert.ToString(dr["post"]);
                    comlinkman.Telephone = Convert.ToString(dr["telephone"]);
                    comlinkman.Fax = Convert.ToString(dr["fax"]);
                    comlinkman.Mobile = Convert.ToString(dr["mobile"]);
                    comlinkman.Email = Convert.ToString(dr["email"]);
                    comlinkman.Msn = Convert.ToString(dr["msn"]);
                    comlinkman.Skype = Convert.ToString(dr["skype"]);
                }
            }

            return comlinkman;
        }

        /// <summary>
        ///[ComLinkman]表查询所有的方法
        /// </summary>
        public static IList<ComLinkman> getComLinkmanAll()
        {
            string sql = "select * from ComLinkman";
            return getComLinkmansBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<ComLinkman> getComLinkmansBySql(string sql)
        {
            IList<ComLinkman> list = new List<ComLinkman>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComLinkman comlinkman = new ComLinkman();
                    comlinkman.Id = Convert.ToInt32(dr["id"]);
                    comlinkman.CompanyId = Convert.ToInt32(dr["companyId"]);
                    comlinkman.LinkName = Convert.ToString(dr["linkName"]);
                    comlinkman.Post = Convert.ToString(dr["post"]);
                    comlinkman.Telephone = Convert.ToString(dr["telephone"]);
                    comlinkman.Fax = Convert.ToString(dr["fax"]);
                    comlinkman.Mobile = Convert.ToString(dr["mobile"]);
                    comlinkman.Email = Convert.ToString(dr["email"]);
                    comlinkman.Msn = Convert.ToString(dr["msn"]);
                    comlinkman.Skype = Convert.ToString(dr["skype"]);
                    list.Add(comlinkman);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static ComLinkman getComLinkmanBySql(string sql)
        {
            ComLinkman comlinkman = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                comlinkman = new ComLinkman();
                foreach (DataRow dr in dt.Rows)
                {
                    comlinkman.Id = Convert.ToInt32(dr["id"]);
                    comlinkman.CompanyId = Convert.ToInt32(dr["companyId"]);
                    comlinkman.LinkName = Convert.ToString(dr["linkName"]);
                    comlinkman.Post = Convert.ToString(dr["post"]);
                    comlinkman.Telephone = Convert.ToString(dr["telephone"]);
                    comlinkman.Fax = Convert.ToString(dr["fax"]);
                    comlinkman.Mobile = Convert.ToString(dr["mobile"]);
                    comlinkman.Email = Convert.ToString(dr["email"]);
                    comlinkman.Msn = Convert.ToString(dr["msn"]);
                    comlinkman.Skype = Convert.ToString(dr["skype"]);
                }
            }
            return comlinkman;
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from ComLinkman where companyId = " + id;
            return DBHelper.GetDataSet(sql);
        }

        public static int deleteComLinkmanByComId(int id)
        {
            string sql = "delete from ComLinkman where companyId=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);
        }
    }
}
