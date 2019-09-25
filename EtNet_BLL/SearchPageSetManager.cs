using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class SearchPageSetManager
    {
        public static int addSearchPageSet(SearchPageSet searchpageset)
        {
            return SearchPageSetService.addSearchPageSet(searchpageset);
        }

        public static int updateSearchPageSet(SearchPageSet searchpageset)
        {
            return SearchPageSetService.updateSearchPageSetById(searchpageset);
        }

        public static int deleteSearchPageSet(int id)
        {
            return SearchPageSetService.deleteSearchPageSetById(id);
        }

        public static SearchPageSet getSearchPageSetById(int id)
        {
            return SearchPageSetService.getSearchPageSetById(id);
        }

        public static IList<SearchPageSet> getSearchPageSetAll()
        {
            return SearchPageSetService.getSearchPageSetAll();
        }

        public static SearchPageSet getSearchPageSetByLoginId(int id, int pagenum)
        {
            return SearchPageSetService.getSearchPageSetByLoginId(id, pagenum);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            return SearchPageSetService.GetList(strWhere);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.SearchPageSet GetModel(int id)
        {
            return EtNet_DAL.SearchPageSetService.GetModel(id);
        }
    }
}
