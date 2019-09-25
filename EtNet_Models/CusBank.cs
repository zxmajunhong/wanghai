using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CusBank
  {
   //CusBank表的默认构造方法
   public CusBank ()
   {

   }
   private int id;
   /// <summary>
   ///[CusBank]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int customerId;
   /// <summary>
   ///[CusBank]表 [customerId]列
   /// </summary>
   public int CustomerId
   {
     get{ return customerId; }
     set{ this.customerId=value;}
   }
   private string bank;
   /// <summary>
   ///[CusBank]表 [bank]列
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string cardId;
   /// <summary>
   ///[CusBank]表 [cardId]列
   /// </summary>
   public string CardId
   {
     get{ return cardId; }
     set{ this.cardId=value;}
   }
   private string cardName;
   /// <summary>
   ///[CusBank]表 [cardName]列
   /// </summary>
   public string CardName
   {
     get{ return cardName; }
     set{ this.cardName=value;}
   }
   private string remark;
   /// <summary>
   ///[CusBank]表 [remark]列
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
