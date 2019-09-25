using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class InvoiceRecordManager
    {
        /// <summary>
        /// 新增一条记录并返回新增的id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(InvoiceRecord model)
        {
            return InvoiceRecordService.Add(model);
        }

        /// <summary>
        /// 根据id得到对象实例
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static InvoiceRecord GetModel(int Id)
        {
            return InvoiceRecordService.GetModel(Id);
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(InvoiceRecord model)
        {
            return InvoiceRecordService.Update(model);
        }

        /// <summary>
        /// 根据id删除一条记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool Del(string Id)
        {
            return InvoiceRecordService.Del(Id);
        }
    }
}
