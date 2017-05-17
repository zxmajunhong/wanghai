using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CommissionList
  {
   //CommissionList表的默认构造方法
   public CommissionList ()
   {

   }
   private int id;
   /// <summary>
   ///[commissionList]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string task;
   /// <summary>
   ///[commissionList]表 [task]列
   /// </summary>
   public string Task
   {
     get{ return task; }
     set{ this.task=value;}
   }
   private string commission;
   /// <summary>
   ///[commissionList]表 [commission]列
   /// </summary>
   public string Commission
   {
     get{ return commission; }
     set{ this.commission=value;}
   }
  }
}
