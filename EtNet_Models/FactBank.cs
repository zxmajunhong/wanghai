using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FactBank
  {
   //FactBank表的默认构造方法
   public FactBank ()
   {

   }
   private int id;
   /// <summary>
   ///[FactBank]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int factId;
   /// <summary>
   ///[FactBank]表 [factId]列
   /// </summary>
   public int FactId
   {
     get{ return factId; }
     set{ this.factId=value;}
   }
   private string bank;
   /// <summary>
   ///[FactBank]表 [bank]列
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string accountId;
   /// <summary>
   ///[FactBank]表 [accountId]列
   /// </summary>
   public string AccountId
   {
     get{ return accountId; }
     set{ this.accountId=value;}
   }
   private string accountName;
   /// <summary>
   ///[FactBank]表 [accountName]列
   /// </summary>
   public string AccountName
   {
     get{ return accountName; }
     set{ this.accountName=value;}
   }
   private string remark;
   /// <summary>
   ///[FactBank]表 [remark]列
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
