using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
using System.Collections;
namespace EtNet_BLL
{


    public class To_PolicyManager
    {
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="to_policy"></param>
        /// <returns></returns>
        public static int addTo_Policy(To_Policy to_policy)
        {
            return To_PolicyService.addTo_Policy(to_policy);
        }

        public static int updateTo_Policy(To_Policy to_policy)
        {
            return To_PolicyService.updateTo_PolicyById(to_policy);
        }

        /// <summary>
        /// To_Policy 表的业务员列Salesman修改方法
        /// </summary>
        /// <param name="salesman">业务员</param>
        /// <param name="prid">id</param>
        /// <returns></returns>
        public static int updateTo_PolicySalesman(string salesman, int id)
        {
            return To_PolicyService.updateTo_PolicySalesman(salesman, id);
        }

        public static int deleteTo_Policy(int id)
        {
            return To_PolicyService.deleteTo_PolicyById(id);
        }

        public static To_Policy getTo_PolicyById(int id)
        {
            return To_PolicyService.getTo_PolicyById(id);
        }

        public static IList<To_Policy> getTo_PolicyAll()
        {
            return To_PolicyService.getTo_PolicyAll();
        }

        public static DataTable GetList(int? id)
        {
            return To_PolicyService.GetList(id);
        }

        public static DataTable GetListByPage(int? id, int loginId, string orderby, string strWhere, int startIndex, int endIndex)
        {
            return To_PolicyService.GetListByPage(id, loginId, orderby, strWhere, startIndex, endIndex);
        }

        public static Nullable<int> GetCount(string where, int loginId)
        {
            return To_PolicyService.GetCount(where, loginId);
        }

        public static Nullable<int> GetCount()
        {
            return To_PolicyService.GetCount();
        }

        public static int getTo_PolicyCountByCoutomerID(string id)
        {
            return To_PolicyService.getCountByCustomerID(id);
        }

        public static int getTo_PolicyCountByCompanyID(string id)
        {
            return To_PolicyService.getCountByCompanyID(id);
        }
        public static DataTable GetLists(string strWhere)
        {
            return To_PolicyService.GetLists(strWhere);
        }

        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return To_PolicyService.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据提供的字段验证是否存在相同记录
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public static bool ExitsRecordByField(string fieldName, string fieldValue, object ID)
        {
            return To_PolicyService.ExitsRecordByField(fieldName, fieldValue, ID);
        }

        public static int Clear()
        {
            IList<To_Policy> idlist = To_PolicyService.getTo_PolicyAll();

            if (idlist.Count > 0)
            {
                for (int i = 0; i < idlist.Count; i++)
                {

                    To_Policy policy = To_PolicyManager.getTo_PolicyById(Convert.ToInt32(idlist[i].Id));
                    if (policy != null)
                    {
                        int jobflowid = policy.IsVerify;
                        JobFlow model = JobFlowManager.GetModel(jobflowid);
                        string strdel = " jobflowid=" + jobflowid;
                        AuditJobFlowManager.Delete(strdel);
                        JobFlowManager.Delete(jobflowid);
                    }
                }
            }

            return To_PolicyService.Clear();
        }
    }
}
