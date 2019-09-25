using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[CusLinkman]������ݷ�����
    /// </summary>
    public class CusLinkmanService
    {
        /// <summary>
        ///[CusLinkman]����ӵķ���
        /// </summary>
        public static int addCusLinkman(CusLinkman cuslinkman)
        {
            string sql = "insert into CusLinkman([customerId],[linkName],[departName],[telephone],[fax],[mobile],[email],[msn],[skype]) values (@customerId,@linkName,@departName,@telephone,@fax,@mobile,@email,@msn,@skype)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@customerId",cuslinkman.CustomerId),
        new SqlParameter("@linkName",cuslinkman.LinkName),
        new SqlParameter("@departName",cuslinkman.DepartName),
        new SqlParameter("@telephone",cuslinkman.Telephone),
        new SqlParameter("@fax",cuslinkman.Fax),
        new SqlParameter("@mobile",cuslinkman.Mobile),
        new SqlParameter("@email",cuslinkman.Email),
        new SqlParameter("@msn",cuslinkman.Msn),
        new SqlParameter("@skype",cuslinkman.Skype)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[CusLinkman]���޸ĵķ���
        /// </summary>
        public static int updateCusLinkmanById(CusLinkman cuslinkman)
        {

            string sql = "update CusLinkman set customerId=@customerId,linkName=@linkName,departName=@departName,telephone=@telephone,fax=@fax,mobile=@mobile,email=@email,msn=@msn,skype=@skype where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",cuslinkman.Id),
        new SqlParameter("@customerId",cuslinkman.CustomerId),
        new SqlParameter("@linkName",cuslinkman.LinkName),
        new SqlParameter("@departName",cuslinkman.DepartName),
        new SqlParameter("@telephone",cuslinkman.Telephone),
        new SqlParameter("@fax",cuslinkman.Fax),
        new SqlParameter("@mobile",cuslinkman.Mobile),
        new SqlParameter("@email",cuslinkman.Email),
        new SqlParameter("@msn",cuslinkman.Msn),
        new SqlParameter("@skype",cuslinkman.Skype)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[CusLinkman]��ɾ���ķ���
        /// </summary>
        public static int deleteCusLinkmanById(int id)
        {

            string sql = "delete from CusLinkman where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[CusLinkman]���ѯʵ��ķ���
        /// </summary>
        public static CusLinkman getCusLinkmanById(int id)
        {
            CusLinkman cuslinkman = null;

            string sql = "select * from CusLinkman where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                cuslinkman = new CusLinkman();
                foreach (DataRow dr in dt.Rows)
                {
                    cuslinkman.Id = Convert.ToInt32(dr["id"]);
                    cuslinkman.CustomerId = Convert.ToInt32(dr["customerId"]);
                    cuslinkman.LinkName = Convert.ToString(dr["linkName"]);
                    cuslinkman.DepartName = Convert.ToString(dr["departName"]);
                    cuslinkman.Telephone = Convert.ToString(dr["telephone"]);
                    cuslinkman.Fax = Convert.ToString(dr["fax"]);
                    cuslinkman.Mobile = Convert.ToString(dr["mobile"]);
                    cuslinkman.Email = Convert.ToString(dr["email"]);
                    cuslinkman.Msn = Convert.ToString(dr["msn"]);
                    cuslinkman.Skype = Convert.ToString(dr["skype"]);
                }
            }

            return cuslinkman;
        }

        /// <summary>
        ///[CusLinkman]���ѯ���еķ���
        /// </summary>
        public static IList<CusLinkman> getCusLinkmanAll()
        {
            string sql = "select * from CusLinkman";
            return getCusLinkmansBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<CusLinkman> getCusLinkmansBySql(string sql)
        {
            IList<CusLinkman> list = new List<CusLinkman>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CusLinkman cuslinkman = new CusLinkman();
                    cuslinkman.Id = Convert.ToInt32(dr["id"]);
                    cuslinkman.CustomerId = Convert.ToInt32(dr["customerId"]);
                    cuslinkman.LinkName = Convert.ToString(dr["linkName"]);
                    cuslinkman.DepartName = Convert.ToString(dr["departName"]);
                    cuslinkman.Telephone = Convert.ToString(dr["telephone"]);
                    cuslinkman.Fax = Convert.ToString(dr["fax"]);
                    cuslinkman.Mobile = Convert.ToString(dr["mobile"]);
                    cuslinkman.Email = Convert.ToString(dr["email"]);
                    cuslinkman.Msn = Convert.ToString(dr["msn"]);
                    cuslinkman.Skype = Convert.ToString(dr["skype"]);
                    list.Add(cuslinkman);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static CusLinkman getCusLinkmanBySql(string sql)
        {
            CusLinkman cuslinkman = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                cuslinkman = new CusLinkman();
                foreach (DataRow dr in dt.Rows)
                {
                    cuslinkman.Id = Convert.ToInt32(dr["id"]);
                    cuslinkman.CustomerId = Convert.ToInt32(dr["customerId"]);
                    cuslinkman.LinkName = Convert.ToString(dr["linkName"]);
                    cuslinkman.DepartName = Convert.ToString(dr["departName"]);
                    cuslinkman.Telephone = Convert.ToString(dr["telephone"]);
                    cuslinkman.Fax = Convert.ToString(dr["fax"]);
                    cuslinkman.Mobile = Convert.ToString(dr["mobile"]);
                    cuslinkman.Email = Convert.ToString(dr["email"]);
                    cuslinkman.Msn = Convert.ToString(dr["msn"]);
                    cuslinkman.Skype = Convert.ToString(dr["skype"]);
                }
            }
            return cuslinkman;
        }

        public static IList<CusLinkman> getCusLinkmanByCusId(int cusId)
        {
            string sql = "select * from CusLinkman where customerId = " + cusId;
            return getCusLinkmansBySql(sql);
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from CusLinkman where customerId = " + id;
            return DBHelper.GetDataSet(sql);

        }

        public static int deleteCusLinkmanByCusId(int id)
        {
            string sql = "delete from CusLinkman where customerId=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        /// ����sql���ɾ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteCusLinkmanBySql(string sql)
        {
            string sqlwhere = "delete from CusLinkman where " + sql;
            return DBHelper.ExecuteCommand(sqlwhere);
        }
    }
}
