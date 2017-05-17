using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class CompanyProdManager
    {
        public static int addCompanyProd(CompanyProd companyprod)
        {
            return CompanyProdService.addCompanyProd(companyprod);
        }

        public static int updateCompanyProd(CompanyProd companyprod)
        {
            return CompanyProdService.updateCompanyProdById(companyprod);
        }

        public static int deleteCompanyProd(int id)
        {
            return CompanyProdService.deleteCompanyProdById(id);
        }

        public static CompanyProd getCompanyProdById(int id)
        {
            return CompanyProdService.getCompanyProdById(id);
        }

        public static IList<CompanyProd> getCompanyProdAll()
        {
            return CompanyProdService.getCompanyProdAll();
        }

        public static CompanyProd getCompanyProdByComId(int id)
        {
            return CompanyProdService.getCompanyProdByComId(id);
        }

        public static IList<CompanyProd> GetListByPro(int id)
        {
            return CompanyProdService.getCompanyProdsBySql(string.Format("select id,companyId,prodTypeId from CompanyProd where companyId={0}", id));
        }

        public static int deleteCompanyProdByComId(int id)
        {
            return CompanyProdService.deleteCompanyProByComId(id);
        }
    }
}
