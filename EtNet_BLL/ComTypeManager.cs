using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class ComTypeManager
    {
        public static int addComType(ComType comtype)
        {
            return ComTypeService.addComType(comtype);
        }

        public static int updateComType(ComType comtype)
        {
            return ComTypeService.updateComTypeById(comtype);
        }

        public static int deleteComType(int id)
        {
            return ComTypeService.deleteComTypeById(id);
        }

        public static ComType getComTypeById(int id)
        {
            return ComTypeService.getComTypeById(id);
        }
        public static int getComTypeByTypename(string typename)
        {
            return ComTypeService.getComTypeByTypename(typename);
        }

        public static IList<ComType> getComTypeAll()
        {
            return ComTypeService.getComTypeAll();
        }
    }
}
