using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class CompanyManager
    {
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public static int addCompany(Company company)
        {
            return CompanyService.addCompany(company);
        }

        public static int updateCompany(Company company)
        {
            return CompanyService.updateCompanyById(company);
        }

        public static int deleteCompany(int id)
        {
            return CompanyService.deleteCompanyById(id);
        }

        public static Company getCompanyById(int id)
        {
            return CompanyService.getCompanyById(id);
        }

        public static IList<Company> getCompanyAll()
        {
            return CompanyService.getCompanyAll();
        }

        public static Company getLastOneID()
        {
            return CompanyService.getLastOneID();
        }



        public static IList<Company> getCompanyType(int id)
        {
            return CompanyService.getCompanyType(id);
        }

        public static int getCount3(string comCode, string comShortName, string comCname)
        {
            return CompanyService.getCount3(comCode, comShortName, comCname);
        }

        public static bool getCode(string comCode) 
        {
            return CompanyService.getCode(comCode);
        }

        /// <summary>
        /// 判断是否有相同名字和id的公司信息
        /// </summary>
        /// <param name="comShortName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool getSName(string comShortName,int id)
        {
            return CompanyService.getSName(comShortName,id);
        }
        public static bool getCName(string comCname,int id)
        {
            return CompanyService.getCName(comCname,id);
        }

        public static DataTable GetList(string strWhere)
        {
            return  CompanyService.GetList(strWhere);
        }


        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return CompanyService.GetList(Top, strWhere, filedOrder);
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static DataTable GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return CompanyService.GetListByPage(strWhere, startIndex, endIndex);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string where)
        {
            return CompanyService.GetTotalCount(where);
        }



        public static int Clear()
        {
            return CompanyService.Clear();
        }
    }


}
