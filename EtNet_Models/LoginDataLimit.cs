using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class LoginDataLimit
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public int LoginId
        {
            get;
            set;
        }

        /// <summary>
        /// 数据权限
        /// </summary>
        public string DataIds
        {
            get;
            set;
        }

        /// <summary>
        /// 权限对应角色组ID，0为自定义
        /// </summary>
        public int RoleId
        {
            get;
            set;
        }
    }
}
