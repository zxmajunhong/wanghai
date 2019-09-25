using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace EtNet_BLL
{

    public class JobFlowManager
    {

        public JobFlowManager()
        { }

        #region  Method


        /// <summary>
        /// 查询id值最大的数据
        /// </summary>
        public static int Maxid()
        {
            return EtNet_DAL.JobFlowService.Maxid();
        }





        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int id)
        {
            return EtNet_DAL.JobFlowService.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(EtNet_Models.JobFlow model)
        {
            return EtNet_DAL.JobFlowService.Add(model);
        }

       

        public static int AddAndGetId(EtNet_Models.JobFlow model)
        {
            return EtNet_DAL.JobFlowService.AddAndGetId(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(EtNet_Models.JobFlow model)
        {
            return EtNet_DAL.JobFlowService.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int id)
        {
            return EtNet_DAL.JobFlowService.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.JobFlow GetModel(int id)
        {
            return EtNet_DAL.JobFlowService.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
           return EtNet_DAL.JobFlowService.GetList(strWhere);
        }

         /// <summary>
        /// 删除指定条件的数据
        /// </summary>
        public static bool DeleteList(string strWhere)
        {
            return EtNet_DAL.JobFlowService.DeleteList(strWhere);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return EtNet_DAL.JobFlowService.GetList(Top, strWhere, filedOrder);
        }

        public static bool UpdateBySerialNum(EtNet_Models.JobFlow jobflow)
        {
            return EtNet_DAL.JobFlowService.UpdateBySerialNum(jobflow);
        }

        #endregion


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public static int GetMaxId()
        {
            return EtNet_DAL.JobFlowService.GetMaxId();
        }
    }
}