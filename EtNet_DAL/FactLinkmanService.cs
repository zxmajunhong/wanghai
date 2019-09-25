using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[FactLinkman]表的数据访问类
    /// </summary>
    public class FactLinkmanService
    {
        /// <summary>
        ///[FactLinkman]表添加的方法
        /// </summary>
        public static int addFactLinkman(FactLinkman factlinkman)
        {
            string sql = "insert into FactLinkman([factId],[linkName],[duty],[telephone],[fax],[mobile],[email],[QQ],[skype]) values (@factId,@linkName,@duty,@telephone,@fax,@mobile,@email,@QQ,@skype)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@factId",factlinkman.FactId),
        new SqlParameter("@linkName",factlinkman.LinkName),
        new SqlParameter("@duty",factlinkman.Duty),
        new SqlParameter("@telephone",factlinkman.Telephone),
        new SqlParameter("@fax",factlinkman.Fax),
        new SqlParameter("@mobile",factlinkman.Mobile),
        new SqlParameter("@email",factlinkman.Email),
        new SqlParameter("@QQ",factlinkman.QQ),
        new SqlParameter("@skype",factlinkman.Skype)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[FactLinkman]表修改的方法
        /// </summary>
        public static int updateFactLinkmanById(FactLinkman factlinkman)
        {

            string sql = "update FactLinkman set factId=@factId,linkName=@linkName,duty=@duty,telephone=@telephone,fax=@fax,mobile=@mobile,email=@email,QQ=@QQ,skype=@skype where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",factlinkman.Id),
        new SqlParameter("@factId",factlinkman.FactId),
        new SqlParameter("@linkName",factlinkman.LinkName),
        new SqlParameter("@duty",factlinkman.Duty),
        new SqlParameter("@telephone",factlinkman.Telephone),
        new SqlParameter("@fax",factlinkman.Fax),
        new SqlParameter("@mobile",factlinkman.Mobile),
        new SqlParameter("@email",factlinkman.Email),
        new SqlParameter("@QQ",factlinkman.QQ),
        new SqlParameter("@skype",factlinkman.Skype)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[FactLinkman]表删除的方法
        /// </summary>
        public static int deleteFactLinkmanById(int id)
        {

            string sql = "delete from FactLinkman where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[FactLinkman]表查询实体的方法
        /// </summary>
        public static FactLinkman getFactLinkmanById(int id)
        {
            FactLinkman factlinkman = null;

            string sql = "select * from FactLinkman where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                factlinkman = new FactLinkman();
                foreach (DataRow dr in dt.Rows)
                {
                    factlinkman.Id = Convert.ToInt32(dr["id"]);
                    factlinkman.FactId = Convert.ToInt32(dr["factId"]);
                    factlinkman.LinkName = Convert.ToString(dr["linkName"]);
                    factlinkman.Duty = Convert.ToString(dr["duty"]);
                    factlinkman.Telephone = Convert.ToString(dr["telephone"]);
                    factlinkman.Fax = Convert.ToString(dr["fax"]);
                    factlinkman.Mobile = Convert.ToString(dr["mobile"]);
                    factlinkman.Email = Convert.ToString(dr["email"]);
                    factlinkman.QQ = Convert.ToString(dr["QQ"]);
                    factlinkman.Skype = Convert.ToString(dr["skype"]);
                }
            }

            return factlinkman;
        }

        /// <summary>
        ///[FactLinkman]表查询所有的方法
        /// </summary>
        public static IList<FactLinkman> getFactLinkmanAll()
        {
            string sql = "select * from FactLinkman";
            return getFactLinkmansBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<FactLinkman> getFactLinkmansBySql(string sql)
        {
            IList<FactLinkman> list = new List<FactLinkman>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FactLinkman factlinkman = new FactLinkman();
                    factlinkman.Id = Convert.ToInt32(dr["id"]);
                    factlinkman.FactId = Convert.ToInt32(dr["factId"]);
                    factlinkman.LinkName = Convert.ToString(dr["linkName"]);
                    factlinkman.Duty = Convert.ToString(dr["duty"]);
                    factlinkman.Telephone = Convert.ToString(dr["telephone"]);
                    factlinkman.Fax = Convert.ToString(dr["fax"]);
                    factlinkman.Mobile = Convert.ToString(dr["mobile"]);
                    factlinkman.Email = Convert.ToString(dr["email"]);
                    factlinkman.QQ = Convert.ToString(dr["QQ"]);
                    factlinkman.Skype = Convert.ToString(dr["skype"]);
                    list.Add(factlinkman);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static FactLinkman getFactLinkmanBySql(string sql)
        {
            FactLinkman factlinkman = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                factlinkman = new FactLinkman();
                foreach (DataRow dr in dt.Rows)
                {
                    factlinkman.Id = Convert.ToInt32(dr["id"]);
                    factlinkman.FactId = Convert.ToInt32(dr["factId"]);
                    factlinkman.LinkName = Convert.ToString(dr["linkName"]);
                    factlinkman.Duty = Convert.ToString(dr["duty"]);
                    factlinkman.Telephone = Convert.ToString(dr["telephone"]);
                    factlinkman.Fax = Convert.ToString(dr["fax"]);
                    factlinkman.Mobile = Convert.ToString(dr["mobile"]);
                    factlinkman.Email = Convert.ToString(dr["email"]);
                    factlinkman.QQ = Convert.ToString(dr["QQ"]);
                    factlinkman.Skype = Convert.ToString(dr["skype"]);
                }
            }
            return factlinkman;
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from FactLinkman where factId = " + id;
            return DBHelper.GetDataSet(sql);

        }

        public static int deleteFactLinkmanByfactId(int id)
        {
            string sql = "delete from FactLinkman where factId=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        public static IList<FactLinkman> getFactLinkmanByFactId(int cusId)
        {
            string sql = "select * from CusLinkman where factId = " + cusId;
            return getFactLinkmansBySql(sql);
        }
    }
}
