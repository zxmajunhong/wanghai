using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;

namespace EtNet_BLL
{
    public class LoginDataLimitManager
    {
        public static string GetLimit(int loginID)
        {
            return LoginDataLimitServices.GetLimit(loginID);
        }

        public static string GetRoleId(int loginID)
        {
            return LoginDataLimitServices.GetRoleId(loginID);
        }

        public static bool Setlimit(LoginDataLimit ldl)
        {
            return LoginDataLimitServices.SetLimit(ldl);
        }

        public static string GetUsersByRole(int roleID)
        {
            return LoginDataLimitServices.GetUsersByRole(roleID);
        }
    }
}
