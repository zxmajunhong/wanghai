using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CusBank
  {
   //CusBank���Ĭ�Ϲ��췽��
   public CusBank ()
   {

   }
   private int id;
   /// <summary>
   ///[CusBank]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int customerId;
   /// <summary>
   ///[CusBank]�� [customerId]��
   /// </summary>
   public int CustomerId
   {
     get{ return customerId; }
     set{ this.customerId=value;}
   }
   private string bank;
   /// <summary>
   ///[CusBank]�� [bank]��
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string cardId;
   /// <summary>
   ///[CusBank]�� [cardId]��
   /// </summary>
   public string CardId
   {
     get{ return cardId; }
     set{ this.cardId=value;}
   }
   private string cardName;
   /// <summary>
   ///[CusBank]�� [cardName]��
   /// </summary>
   public string CardName
   {
     get{ return cardName; }
     set{ this.cardName=value;}
   }
   private string remark;
   /// <summary>
   ///[CusBank]�� [remark]��
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
