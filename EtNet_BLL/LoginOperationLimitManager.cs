using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class LoginOperationLimitManager
    {
        public static int addLoginOperationLimit(LoginOperationLimit loginoperationlimit)
        {
            return LoginOperationLimitService.addLoginOperationLimit(loginoperationlimit);
        }

        public static int updateLoginOperationLimit(LoginOperationLimit loginoperationlimit)
        {
            return LoginOperationLimitService.updateLoginOperationLimitById(loginoperationlimit);
        }

        public static int deleteLoginOperationLimit(int id)
        {
            return LoginOperationLimitService.deleteLoginOperationLimitById(id);
        }

        public static LoginOperationLimit getLoginOperationLimitById(int id)
        {
            return LoginOperationLimitService.getLoginOperationLimitById(id);
        }

        public static IList<LoginOperationLimit> getLoginOperationLimitAll()
        {
            return LoginOperationLimitService.getLoginOperationLimitAll();
        }

        /// <summary>
        /// 根据权限类别得到实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static LoginOperationLimit getLoginOperationLimitByType(string type)
        {
            return LoginOperationLimitService.getLoginOperationLimitByType(type);
        }
    }
}
