using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class DepartmentInfoManager
    {
        public static int addDepartmentInfo(DepartmentInfo departmentinfo)
        {
            return DepartmentInfoService.addDepartmentInfo(departmentinfo);
        }

        public static int updateDepartmentInfo(DepartmentInfo departmentinfo)
        {
            return DepartmentInfoService.updateDepartmentInfoById(departmentinfo);
        }

        public static int deleteDepartmentInfo(int departid)
        {
            return DepartmentInfoService.deleteDepartmentInfoById(departid);
        }

        public static DepartmentInfo getDepartmentInfoById(int departid)
        {
            return DepartmentInfoService.getDepartmentInfoById(departid);
        }

        public static DepartmentInfo getDepartmentInfoBydepartcname(string departcname)
        {
            return DepartmentInfoService.getDepartmentInfoBydepartcname(departcname);
        }

        /// <summary>
        /// 根据名称集合得到对象实体
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IList<DepartmentInfo> getDepartmentInfoBynames(string names)
        {
            return DepartmentInfoService.getDepartmentBynames(names);
        }

        public static IList<DepartmentInfo> getDepartmentInfoAll()
        {
            return DepartmentInfoService.getDepartmentInfoAll();
        }

        public static IList<DepartmentInfo> getDepartmentAll()
        {
            return DepartmentInfoService.getDepartmentAll("");
        }

        public static DataTable GetList(string strWhere)
        {
            return EtNet_DAL.DepartmentInfoService.GetList(strWhere);
        }
        public static DataTable GetTypeList(string strWhere)
        {
            return EtNet_DAL.DepartmentInfoService.GetTypeList(strWhere);
        }
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return EtNet_DAL.DepartmentInfoService.GetList(Top, strWhere, filedOrder);
        }

        public static string getPostname(int postid)
        {
            return EtNet_DAL.DepartmentInfoService.getPostname(postid);
        }

        public static int getPostid(string postname)
        {
            return EtNet_DAL.DepartmentInfoService.getpostid(postname);
        }
    }
}
