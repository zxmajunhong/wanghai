using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CommissionList
  {
   //CommissionList���Ĭ�Ϲ��췽��
   public CommissionList ()
   {

   }
   private int id;
   /// <summary>
   ///[commissionList]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string task;
   /// <summary>
   ///[commissionList]�� [task]��
   /// </summary>
   public string Task
   {
     get{ return task; }
     set{ this.task=value;}
   }
   private string commission;
   /// <summary>
   ///[commissionList]�� [commission]��
   /// </summary>
   public string Commission
   {
     get{ return commission; }
     set{ this.commission=value;}
   }
  }
}
