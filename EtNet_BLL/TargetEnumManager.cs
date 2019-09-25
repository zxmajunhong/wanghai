using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{
    //TargetEnum
    public partial class TargetEnumManager
    {

        private readonly EtNet_DAL.TargetEnumService dal = new EtNet_DAL.TargetEnumService();
        public TargetEnumManager()
        { }

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(EtNet_Models.TargetEnum model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EtNet_Models.TargetEnum model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int EnumTypeId, int EnumId, string EnumValue)
        {

            return dal.Delete(EnumTypeId, EnumId, EnumValue);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int EnumTypeId)
        {
            return dal.Delete(EnumTypeId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EtNet_Models.TargetEnum GetModel(int EnumTypeId, int EnumId, string EnumValue)
        {

            return dal.GetModel(EnumTypeId, EnumId, EnumValue);
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
        public List<EtNet_Models.TargetEnum> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EtNet_Models.TargetEnum> DataTableToList(DataTable dt)
        {
            List<EtNet_Models.TargetEnum> modelList = new List<EtNet_Models.TargetEnum>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EtNet_Models.TargetEnum model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new EtNet_Models.TargetEnum();
                    if (dt.Rows[n]["EnumTypeId"].ToString() != "")
                    {
                        model.EnumTypeId = int.Parse(dt.Rows[n]["EnumTypeId"].ToString());
                    }
                    if (dt.Rows[n]["EnumId"].ToString() != "")
                    {
                        model.EnumId = int.Parse(dt.Rows[n]["EnumId"].ToString());
                    }
                    model.EnumValue = dt.Rows[n]["EnumValue"].ToString();


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

        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        #endregion

    }
}