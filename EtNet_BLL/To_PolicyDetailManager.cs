using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class To_PolicyDetailManager
    {
        public static int addTo_PolicyDetail(To_PolicyDetail to_policydetail)
        {
            return To_PolicyDetailService.addTo_PolicyDetail(to_policydetail);
        }

        public static int updateTo_PolicyDetail(To_PolicyDetail to_policydetail)
        {
            return To_PolicyDetailService.updateTo_PolicyDetailById(to_policydetail);
        }

        public static int deleteTo_PolicyDetail(int id)
        {
            return To_PolicyDetailService.deleteTo_PolicyDetailById(id);
        }

        public static To_PolicyDetail getTo_PolicyDetailById(int id)
        {
            return To_PolicyDetailService.getTo_PolicyDetailById(id);
        }

        public static IList<To_PolicyDetail> getTo_PolicyDetailAll()
        {
            return To_PolicyDetailService.getTo_PolicyDetailAll();
        }

        public static DataTable GetListByPolicy(int id)
        {
            return To_PolicyDetailService.GetListByPolicy(id);
        }

        public static int DeleteByPolicy(int policyId)
        {
            return To_PolicyDetailService.DeleteByPolicy(policyId);
        }

        /// <summary>
        /// 编辑保单中读取保单明细中的数据
        /// </summary>
        /// <param name="policyid">保单id</param>
        /// <returns></returns>
        public static DataTable GetListByPolicyid(int policyid)
        {
            return To_PolicyDetailService.GetListByPolicyId(policyid);
        }
    }
}
