using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using System.Data;

namespace EtNet_BLL
{
    public class ViewBudgetIncomeManager
    {
        ViewBudgetIncomeService dal = new ViewBudgetIncomeService();

        public DataTable GetList(string where)
        {
            return dal.GetList(where);    
        }

        public DataTable GetListByPage(string where)
        {
            return dal.GetListByPage(where);
        }
    }
}
