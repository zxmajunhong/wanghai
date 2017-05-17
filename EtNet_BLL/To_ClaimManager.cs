using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using EtNet_DAL;
using System.Data;

namespace EtNet_BLL
{
    //To_Claim
    public partial class To_ClaimManager
    {

        private readonly To_ClaimService dal = new To_ClaimService();
        public To_ClaimManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_Claim model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_Claim model)
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
        public To_Claim GetModel(int ID)
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
        public List<To_Claim> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<To_Claim> DataTableToList(DataTable dt)
        {
            List<To_Claim> modelList = new List<To_Claim>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                To_Claim model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new To_Claim();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["collectingID"].ToString() != "")
                    {
                        model.collectingID = int.Parse(dt.Rows[n]["collectingID"].ToString());
                    }
                    model.makerman = dt.Rows[n]["makerman"].ToString();
                    if (dt.Rows[n]["makerID"].ToString() != "")
                    {
                        model.MakerID = int.Parse(dt.Rows[n]["makerID"].ToString());
                    }
                    model.payer = dt.Rows[n]["payer"].ToString();
                    if (dt.Rows[n]["payerID"].ToString() != "")
                    {
                        model.payerID = int.Parse(dt.Rows[n]["payerID"].ToString());
                    }
                    if (dt.Rows[n]["collectAmount"].ToString() != "")
                    {
                        model.collectAmount = Convert.ToDouble(dt.Rows[n]["collectAmount"]);
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
        /// 检测收款记录是否已被认领
        /// </summary>
        /// <param name="collectingID"></param>
        /// <returns></returns>
        public bool ExitsCollecting(int collectingID)
        {
            return dal.ExitsCollecting(collectingID);
        }

        /// <summary>
        /// 根据收款记录ID获取认领表ID
        /// </summary>
        /// <param name="collectingID"></param>
        /// <returns></returns>
        public string GetID(int collectingID)
        {
            return dal.GetID(collectingID);
        }

        /// <summary>
        /// 根据收款记录ID获取所需字段值
        /// </summary>
        /// <param name="collectingID"></param>
        /// <returns></returns>
        public string GetFiledValue(int collectingID, string filed)
        {
            return dal.GetFiledValue(collectingID, filed);
        }

        /// <summary>
        /// 根据收款认领id得到收款单指定所需字段
        /// </summary>
        /// <param name="claimId"></param>
        /// <param name="filed"></param>
        /// <returns></returns>
        public string GetFiledValueByClaimId(int claimId, string filed)
        {
            return dal.GetFiledValueByClaimId(claimId, filed);
        }

        #endregion

    }
}
