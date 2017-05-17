using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;

namespace EtNet_BLL
{
    //To_ClaimDetail
    public partial class To_ClaimDetailManager
    {

        private readonly To_ClaimDetailService dal = new To_ClaimDetailService();
        public To_ClaimDetailManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int policyID)
        {
            return dal.Exists(policyID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_ClaimDetail model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_ClaimDetail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public To_ClaimDetail GetModel(int ID)
        {

            return dal.GetModel(ID);
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
        public List<To_ClaimDetail> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<To_ClaimDetail> DataTableToList(DataTable dt)
        {
            List<To_ClaimDetail> modelList = new List<To_ClaimDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                To_ClaimDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new To_ClaimDetail();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["claimID"].ToString() != "")
                    {
                        model.claimID = int.Parse(dt.Rows[n]["claimID"].ToString());
                    }
                    model.orderNum = dt.Rows[n]["orderNum"].ToString();
                    if (dt.Rows[n]["orderCollectId"].ToString() != "")
                    {
                        model.orderCollectId = int.Parse(dt.Rows[n]["orderCollectId"].ToString());
                    }
                    if (dt.Rows[n]["orderCusId"].ToString() != "")
                    {
                        model.orderCusId = int.Parse(dt.Rows[n]["orderCusId"].ToString());
                    }
                    if (dt.Rows[n]["receiptAmount"].ToString() != "")
                    {
                        model.receiptAmount = decimal.Parse(dt.Rows[n]["receiptAmount"].ToString());
                    }
                    if (dt.Rows[n]["realAmount"].ToString() != "")
                    {
                        model.realAmount = decimal.Parse(dt.Rows[n]["realAmount"].ToString());
                    }
                    if (dt.Rows[n]["receiptStatusCode"].ToString() != "")
                    {
                        model.receiptStatusCode = int.Parse(dt.Rows[n]["receiptStatusCode"].ToString());
                    }
                    model.mark = dt.Rows[n]["mark"].ToString();


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
        /// 根据ClaimID删除一条数据
        /// </summary>
        public bool DeleteByClaim(string claimID)
        {
            return dal.DeleteByClaim(claimID);
        }

        /// <summary>
        /// 得到已经认领的明细数据
        /// </summary>
        /// <param name="claimID"></param>
        /// <returns></returns>
        public DataTable GetHasDetail(string strWhere)
        {
            return dal.GetHasDetail(strWhere);
        }

        /// <summary>
        /// 得到已经认领的金额
        /// </summary>
        /// <param name="ordercolid">订单收款信息明细id</param>
        /// <returns></returns>
        public double GetHasAmount(string ordercolid)
        {
            return dal.GetHasAmount(ordercolid);
        }

        /// <summary>
        /// 得到收款明细统计表中所需要的已经认领的明细数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCollectDetail(string strWhere)
        {
            return dal.GetCollectDetail(strWhere);
        }

        #endregion

    }
}
