using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FactBank
  {
   //FactBank���Ĭ�Ϲ��췽��
   public FactBank ()
   {

   }
   private int id;
   /// <summary>
   ///[FactBank]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int factId;
   /// <summary>
   ///[FactBank]�� [factId]��
   /// </summary>
   public int FactId
   {
     get{ return factId; }
     set{ this.factId=value;}
   }
   private string bank;
   /// <summary>
   ///[FactBank]�� [bank]��
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string accountId;
   /// <summary>
   ///[FactBank]�� [accountId]��
   /// </summary>
   public string AccountId
   {
     get{ return accountId; }
     set{ this.accountId=value;}
   }
   private string accountName;
   /// <summary>
   ///[FactBank]�� [accountName]��
   /// </summary>
   public string AccountName
   {
     get{ return accountName; }
     set{ this.accountName=value;}
   }
   private string remark;
   /// <summary>
   ///[FactBank]�� [remark]��
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
