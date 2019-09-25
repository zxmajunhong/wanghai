using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[ComType]������ݷ�����
    /// </summary>
    public class ComTypeService
    {
        /// <summary>
        ///[ComType]����ӵķ���
        /// </summary>
        public static int addComType(ComType comtype)
        {
            string sql = "insert into ComType([typeName],[typeremark]) values (@typeName,@typeremark)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@typeName",comtype.TypeName),
        new SqlParameter("@typeremark",comtype.Typeremark)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[ComType]���޸ĵķ���
        /// </summary>
        public static int updateComTypeById(ComType comtype)
        {

            string sql = "update ComType set typeName=@typeName,typeremark=@typeremark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",comtype.Id),
        new SqlParameter("@typeName",comtype.TypeName),
        new SqlParameter("@typeremark",comtype.Typeremark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[ComType]��ɾ���ķ���
        /// </summary>
        public static int deleteComTypeById(int id)
        {

            string sql = "delete from ComType where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }
        /// <summary>
        ///[ComTypeName]���ѯʵ��ķ���
        /// </summary>
        public static int getComTypeByTypename(string typename)
        {
            string sql = "select count(*) from ComType where typeName = '" + typename + "'";
            return DBHelper.ExecuteScalar(sql); ;
        }

        /// <summary>
        ///[ComType]���ѯʵ��ķ���
        /// </summary>
        public static ComType getComTypeById(int id)
        {
            ComType comtype = null;

            string sql = "select * from ComType where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                comtype = new ComType();
                foreach (DataRow dr in dt.Rows)
                {
                    comtype.Id = Convert.ToInt32(dr["id"]);
                    comtype.TypeName = Convert.ToString(dr["typeName"]);
                    comtype.Typeremark = Convert.ToString(dr["typeremark"]);
                }
            }

            return comtype;
        }

        /// <summary>
        ///[ComType]���ѯ���еķ���
        /// </summary>
        public static IList<ComType> getComTypeAll()
        {
            string sql = "select * from ComType";
            return getComTypesBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<ComType> getComTypesBySql(string sql)
        {
            IList<ComType> list = new List<ComType>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComType comtype = new ComType();
                    comtype.Id = Convert.ToInt32(dr["id"]);
                    comtype.TypeName = Convert.ToString(dr["typeName"]);
                    comtype.Typeremark = Convert.ToString(dr["typeremark"]);
                    list.Add(comtype);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static ComType getComTypeBySql(string sql)
        {
            ComType comtype = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                comtype = new ComType();
                foreach (DataRow dr in dt.Rows)
                {
                    comtype.Id = Convert.ToInt32(dr["id"]);
                    comtype.TypeName = Convert.ToString(dr["typeName"]);
                    comtype.Typeremark = Convert.ToString(dr["typeremark"]);
                }
            }
            return comtype;
        }
    }
}
