using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class ComBank
  {
   //ComBank���Ĭ�Ϲ��췽��
   public ComBank ()
   {

   }
   private int id;
   /// <summary>
   ///[ComBank]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int companyId;
   /// <summary>
   ///[ComBank]�� [companyId]��
   /// </summary>
   public int CompanyId
   {
     get{ return companyId; }
     set{ this.companyId=value;}
   }
   private string bank;
   /// <summary>
   ///[ComBank]�� [bank]��
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string cardId;
   /// <summary>
   ///[ComBank]�� [cardId]��
   /// </summary>
   public string CardId
   {
     get{ return cardId; }
     set{ this.cardId=value;}
   }
   private string cardName;
   /// <summary>
   ///[ComBank]�� [cardName]��
   /// </summary>
   public string CardName
   {
     get{ return cardName; }
     set{ this.cardName=value;}
   }
   private string remark;
   /// <summary>
   ///[ComBank]�� [remark]��
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
