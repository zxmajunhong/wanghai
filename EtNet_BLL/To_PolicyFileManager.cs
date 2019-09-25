using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    //To_PolicyFile
    public partial class To_PolicyFileManager
    {

        private readonly To_PolicyFileService dal = new To_PolicyFileService();
        public To_PolicyFileManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_PolicyFile model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_PolicyFile model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 根据保单ID删除对应的数据
        /// </summary>
        public bool Delete(int policyID)
        {

            return dal.Delete(policyID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public To_PolicyFile GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<To_PolicyFile> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<To_PolicyFile> DataTableToList(DataTable dt)
        {
            List<To_PolicyFile> modelList = new List<To_PolicyFile>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                To_PolicyFile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new To_PolicyFile();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["policyID"].ToString() != "")
                    {
                        model.policyID = int.Parse(dt.Rows[n]["policyID"].ToString());
                    }
                    model.filename = dt.Rows[n]["filename"].ToString();
                    model.filepath = dt.Rows[n]["filepath"].ToString();
                    if (dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
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
        #endregion

    }
}