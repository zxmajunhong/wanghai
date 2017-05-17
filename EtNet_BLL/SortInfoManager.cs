using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;

namespace EtNet_BLL
{


  public class SortInfoManager
  {
     public static int addSortInfo(SortInfo sortinfo)
     {
       return SortInfoService.addSortInfo(sortinfo);
     }

     public static int updateSortInfo(SortInfo sortinfo)
     {
      return SortInfoService.updateSortInfoById(sortinfo);
     }

     public static int deleteSortInfo(int sortid)
     {
       return SortInfoService.deleteSortInfoById(sortid);
     }

     public static SortInfo getSortInfoById(int sortid)
     {
       return SortInfoService.getSortInfoById(sortid);
     }

     public static IList<SortInfo> getSortInfoAll()
     {
       return SortInfoService.getSortInfoAll();
     }

     /// <summary>
     /// 查询公告类型的数据,如果id为空，查询全部的数据
     /// </summary>
     public static DataTable SortTbl(string id)
     {
         return EtNet_DAL.SortInfoService.SortTbl(id);
     }


  }
}
