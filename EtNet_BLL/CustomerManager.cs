using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class CustomerManager
    {
        public static int addCustomer(Customer customer)
        {
            return CustomerService.addCustomer(customer);
        }

        public static int updateCustomer(Customer customer)
        {
            return CustomerService.updateCustomerById(customer);
        }

        /// <summary>
        /// 更新客户等级。（新客户，老客户）
        /// </summary>
        /// <param name="cusID"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static int updateCustomenPro(string cusID, string pro)
        {
            return CustomerService.updateCustomenPro(cusID, pro);
        }

        public static int deleteCustomer(int id)
        {
            return CustomerService.deleteCustomerById(id);
        }

        public static Customer getCustomerById(int id)
        {
            return CustomerService.getCustomerById(id);
        }

        public static IList<Customer> getCustomerAll()
        {
            return CustomerService.getCustomerAll();
        }

        public static Customer getLastOneID()
        {
            return CustomerService.getLastOneID();
        }

        public static IList<Customer> getCustomerType(int id)
        {
            return CustomerService.getCustomerType(id);
        }


        public static int getCountBy3(string cusCode, string cusshortname, string cusCName, int num)
        {
            return CustomerService.getCount3(cusCode, cusshortname, cusCName, num);
        }

        public static bool getCode(string cusCode, int num)
        {
            return CustomerService.getCode(cusCode, num);
        }

        public static bool getSName(string cusshortname, int num)
        {
            return CustomerService.getSName(cusshortname, num);
        }

        public static bool getCName(string cusCName, int num)
        {
            return CustomerService.getCName(cusCName, num);
        }

        public static DataTable GetList(string strWhere)
        {
            return CustomerService.GetList(strWhere);
        }


        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return CustomerService.GetList(Top, strWhere, filedOrder);
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
            return CustomerService.GetListByPage(strWhere, startIndex, endIndex);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string where)
        {
            return CustomerService.GetTotalCount(where);
        }


        public static int Clear()
        {
            return CustomerService.Clear();
        }
    }
}
