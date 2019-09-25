using System;
using System.Data;
using System.Collections.Generic;
using EtNet_Models;
namespace EtNet_BLL
{
    /// <summary>
    /// TargetPropertyManager
    /// </summary>
    public partial class TargetPropertyManager
    {
        private readonly EtNet_DAL.TargetPropertyService dal = new EtNet_DAL.TargetPropertyService();
        public TargetPropertyManager()
        { }
        #region  Method

        public int GetMaxID(int typeID)
        {
            return dal.GetMaxID(typeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EtNet_Models.TargetProperty model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EtNet_Models.TargetProperty model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int typeID, int targetId)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete(typeID, targetId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int typeID)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete(typeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EtNet_Models.TargetProperty GetModel(int typeId, int targetId)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(typeId, targetId);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EtNet_Models.TargetProperty> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EtNet_Models.TargetProperty> DataTableToList(DataTable dt)
        {
            List<EtNet_Models.TargetProperty> modelList = new List<EtNet_Models.TargetProperty>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EtNet_Models.TargetProperty model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new EtNet_Models.TargetProperty();
                    if (dt.Rows[n]["TargetTypeId"] != null && dt.Rows[n]["TargetTypeId"].ToString() != "")
                    {
                        model.TargetTypeId = int.Parse(dt.Rows[n]["TargetTypeId"].ToString());
                    }
                    if (dt.Rows[n]["PropertyId"] != null && dt.Rows[n]["PropertyId"].ToString() != "")
                    {
                        model.PropertyId = int.Parse(dt.Rows[n]["PropertyId"].ToString());
                    }
                    if (dt.Rows[n]["PropertyNO"] != null && dt.Rows[n]["PropertyNO"].ToString() != "")
                    {
                        model.PropertyNO = dt.Rows[n]["PropertyNO"].ToString();
                    }
                    if (dt.Rows[n]["PropertyName"] != null && dt.Rows[n]["PropertyName"].ToString() != "")
                    {
                        model.PropertyName = dt.Rows[n]["PropertyName"].ToString();
                    }
                    if (dt.Rows[n]["PropertyType"] != null && dt.Rows[n]["PropertyType"].ToString() != "")
                    {
                        model.PropertyType = int.Parse(dt.Rows[n]["PropertyType"].ToString());
                    }
                    if (dt.Rows[n]["MainFlag"] != null && dt.Rows[n]["MainFlag"].ToString() != "")
                    {
                        if ((dt.Rows[n]["MainFlag"].ToString() == "1") || (dt.Rows[n]["MainFlag"].ToString().ToLower() == "true"))
                        {
                            model.MainFlag = true;
                        }
                        else
                        {
                            model.MainFlag = false;
                        }
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

