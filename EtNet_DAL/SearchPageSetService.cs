using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[SearchPageSet]������ݷ�����
    /// </summary>
    public class SearchPageSetService
    {
        /// <summary>
        ///[SearchPageSet]����ӵķ���
        /// </summary>
        public static int addSearchPageSet(SearchPageSet searchpageset)
        {
            string sql = "insert into SearchPageSet([ownersid],[pagenum],[pageitem],[pagecount]) values (@ownersid,@pagenum,@pageitem,@pagecount)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@ownersid",searchpageset.Ownersid),
        new SqlParameter("@pagenum",searchpageset.Pagenum),
        new SqlParameter("@pageitem",searchpageset.Pageitem),
        new SqlParameter("@pagecount",searchpageset.Pagecount)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[SearchPageSet]���޸ĵķ���
        /// </summary>
        public static int updateSearchPageSetById(SearchPageSet searchpageset)
        {

            string sql = "update SearchPageSet set ownersid=@ownersid,pagenum=@pagenum,pageitem=@pageitem,pagecount=@pagecount where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",searchpageset.Id),
        new SqlParameter("@ownersid",searchpageset.Ownersid),
        new SqlParameter("@pagenum",searchpageset.Pagenum),
        new SqlParameter("@pageitem",searchpageset.Pageitem),
        new SqlParameter("@pagecount",searchpageset.Pagecount)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[SearchPageSet]��ɾ���ķ���
        /// </summary>
        public static int deleteSearchPageSetById(int id)
        {

            string sql = "delete from SearchPageSet where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[SearchPageSet]���ѯʵ��ķ���
        /// </summary>
        public static SearchPageSet getSearchPageSetById(int id)
        {
            SearchPageSet searchpageset = null;

            string sql = "select * from SearchPageSet where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                searchpageset = new SearchPageSet();
                foreach (DataRow dr in dt.Rows)
                {
                    searchpageset.Id = Convert.ToInt32(dr["id"]);
                    searchpageset.Ownersid = Convert.ToInt32(dr["ownersid"]);
                    searchpageset.Pagenum = Convert.ToString(dr["pagenum"]);
                    searchpageset.Pageitem = Convert.ToInt32(dr["pageitem"]);
                    searchpageset.Pagecount = Convert.ToInt32(dr["pagecount"]);
                }
            }

            return searchpageset;
        }

        /// <summary>
        ///[SearchPageSet]���ѯ���еķ���
        /// </summary>
        public static IList<SearchPageSet> getSearchPageSetAll()
        {
            string sql = "select * from SearchPageSet";
            return getSearchPageSetsBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<SearchPageSet> getSearchPageSetsBySql(string sql)
        {
            IList<SearchPageSet> list = new List<SearchPageSet>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SearchPageSet searchpageset = new SearchPageSet();
                    searchpageset.Id = Convert.ToInt32(dr["id"]);
                    searchpageset.Ownersid = Convert.ToInt32(dr["ownersid"]);
                    searchpageset.Pagenum = Convert.ToString(dr["pagenum"]);
                    searchpageset.Pageitem = Convert.ToInt32(dr["pageitem"]);
                    searchpageset.Pagecount = Convert.ToInt32(dr["pagecount"]);
                    list.Add(searchpageset);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static SearchPageSet getSearchPageSetBySql(string sql)
        {
            SearchPageSet searchpageset = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                searchpageset = new SearchPageSet();
                foreach (DataRow dr in dt.Rows)
                {
                    searchpageset.Id = Convert.ToInt32(dr["id"]);
                    searchpageset.Ownersid = Convert.ToInt32(dr["ownersid"]);
                    searchpageset.Pagenum = Convert.ToString(dr["pagenum"]);
                    searchpageset.Pageitem = Convert.ToInt32(dr["pageitem"]);
                    searchpageset.Pagecount = Convert.ToInt32(dr["pagecount"]);
                }
            }
            return searchpageset;
        }

        public static SearchPageSet getSearchPageSetByLoginId(int id, int pagenum)
        {
            string sql = "select * from SearchPageSet where ownersid = " + id + " and pagenum =" + pagenum;
            return getSearchPageSetBySql(sql);
        }



        /// <summary>
        /// ��������б�
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ownersid,pagenum,pageitem,pagecount ");
            strSql.Append(" FROM SearchPageSet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public static SearchPageSet GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ownersid,pagenum,pageitem,pagecount from SearchPageSet ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            SearchPageSet model = new SearchPageSet();
            DataTable tbl = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
            {
                model.Id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.Ownersid = int.Parse(tbl.Rows[0]["ownersid"].ToString());
                model.Pagenum = tbl.Rows[0]["pagenum"].ToString();
                model.Pageitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
                model.Pagecount = int.Parse(tbl.Rows[0]["pagecount"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
