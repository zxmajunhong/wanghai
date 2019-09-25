using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class ComBank
  {
   //ComBank表的默认构造方法
   public ComBank ()
   {

   }
   private int id;
   /// <summary>
   ///[ComBank]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int companyId;
   /// <summary>
   ///[ComBank]表 [companyId]列
   /// </summary>
   public int CompanyId
   {
     get{ return companyId; }
     set{ this.companyId=value;}
   }
   private string bank;
   /// <summary>
   ///[ComBank]表 [bank]列
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string cardId;
   /// <summary>
   ///[ComBank]表 [cardId]列
   /// </summary>
   public string CardId
   {
     get{ return cardId; }
     set{ this.cardId=value;}
   }
   private string cardName;
   /// <summary>
   ///[ComBank]表 [cardName]列
   /// </summary>
   public string CardName
   {
     get{ return cardName; }
     set{ this.cardName=value;}
   }
   private string remark;
   /// <summary>
   ///[ComBank]表 [remark]列
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
