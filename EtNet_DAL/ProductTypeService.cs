using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:ProductTypeService
	/// </summary>
	public partial class ProductTypeService
	{
		public ProductTypeService()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EtNet_Models.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductType(");
			strSql.Append("ProdTypeNo,ProdTypeName,ParentId,ProdClass,TargetTypeId)");
			strSql.Append(" values (");
			strSql.Append("@ProdTypeNo,@ProdTypeName,@ParentId,@ProdClass,@TargetTypeId)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdTypeNo", SqlDbType.VarChar,30),
					new SqlParameter("@ProdTypeName", SqlDbType.NVarChar,60),
					new SqlParameter("@ParentId", SqlDbType.VarChar,30),
					new SqlParameter("@ProdClass", SqlDbType.VarChar,4),
					new SqlParameter("@TargetTypeId", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdTypeNo;
			parameters[1].Value = model.ProdTypeName;
			parameters[2].Value = model.ParentId;
			parameters[3].Value = model.ProdClass;
			parameters[4].Value = model.TargetTypeId;

			int rows=DBHelper.ExecuteCommand(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EtNet_Models.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductType set ");
			strSql.Append("ProdTypeName=@ProdTypeName,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("ProdClass=@ProdClass,");
			strSql.Append("TargetTypeId=@TargetTypeId");
			strSql.Append(" where ProdTypeNo=@ProdTypeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdTypeName", SqlDbType.NVarChar,60),
					new SqlParameter("@ParentId", SqlDbType.VarChar,30),
					new SqlParameter("@ProdClass", SqlDbType.VarChar,4),
					new SqlParameter("@TargetTypeId", SqlDbType.Int,4),
					new SqlParameter("@ProdTypeNo", SqlDbType.VarChar,30)};
			parameters[0].Value = model.ProdTypeName;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.ProdClass;
			parameters[3].Value = model.TargetTypeId;
			parameters[4].Value = model.ProdTypeNo;

			int rows=DBHelper.ExecuteCommand(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdTypeNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
			strSql.Append(" where ProdTypeNo=@ProdTypeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdTypeNo", SqlDbType.VarChar,30)			};
			parameters[0].Value = ProdTypeNo;

			int rows=DBHelper.ExecuteCommand(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ProdTypeNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
			strSql.Append(" where ProdTypeNo in ("+ProdTypeNolist + ")  ");
			int rows=DBHelper.ExecuteCommand(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EtNet_Models.ProductType GetModel(string ProdTypeNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdTypeNo,ProdTypeName,ParentId,ProdClass,TargetTypeId from ProductType ");
			strSql.Append(" where ProdTypeNo=@ProdTypeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdTypeNo", SqlDbType.VarChar,30)			};
			parameters[0].Value = ProdTypeNo;

			EtNet_Models.ProductType model=new EtNet_Models.ProductType();
			DataTable ds=DBHelper.GetDataSet(strSql.ToString(),parameters);
			if(ds.Rows.Count>0)
			{
				if(ds.Rows[0]["ProdTypeNo"]!=null && ds.Rows[0]["ProdTypeNo"].ToString()!="")
				{
					model.ProdTypeNo=ds.Rows[0]["ProdTypeNo"].ToString();
				}
				if(ds.Rows[0]["ProdTypeName"]!=null && ds.Rows[0]["ProdTypeName"].ToString()!="")
				{
					model.ProdTypeName=ds.Rows[0]["ProdTypeName"].ToString();
				}
				if(ds.Rows[0]["ParentId"]!=null && ds.Rows[0]["ParentId"].ToString()!="")
				{
					model.ParentId=ds.Rows[0]["ParentId"].ToString();
				}
				if(ds.Rows[0]["ProdClass"]!=null && ds.Rows[0]["ProdClass"].ToString()!="")
				{
					model.ProdClass=ds.Rows[0]["ProdClass"].ToString();
				}
				if(ds.Rows[0]["TargetTypeId"]!=null && ds.Rows[0]["TargetTypeId"].ToString()!="")
				{
					model.TargetTypeId=int.Parse(ds.Rows[0]["TargetTypeId"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProdTypeNo,ProdTypeName,ParentId,ProdClass,TargetTypeId ");
			strSql.Append(" FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}

            return DBHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ProdTypeNo,ProdTypeName,ParentId,ProdClass,TargetTypeId ");
			strSql.Append(" FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelper.ExecuteScalar(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ProdTypeNo desc");
			}
			strSql.Append(")AS Row, T.*  from ProductType T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelper.GetDataSet(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ProductType";
			parameters[1].Value = "ProdTypeNo";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

