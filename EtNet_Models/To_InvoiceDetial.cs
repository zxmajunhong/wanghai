using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_InvoiceDetial
  {
   //To_InvoiceDetial���Ĭ�Ϲ��췽��
   public To_InvoiceDetial ()
   {

   }
   private int id;
   /// <summary>
   ///[to_InvoiceDetial]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int invoiceID;
   /// <summary>
   ///[to_InvoiceDetial]�� [invoiceID]��
   /// </summary>
   public int InvoiceID
   {
     get{ return invoiceID; }
     set{ this.invoiceID=value;}
   }
   private string policyID;
   /// <summary>
   ///[to_InvoiceDetial]�� [policyID]��
   /// </summary>
   public string PolicyID
   {
     get{ return policyID; }
     set{ this.policyID=value;}
   }
   private string cusName;
   /// <summary>
   ///[to_InvoiceDetial]�� [cusName]��
   /// </summary>
   public string CusName
   {
     get{ return cusName; }
     set{ this.cusName=value;}
   }
   private double cost;
   /// <summary>
   ///[to_InvoiceDetial]�� [cost]��
   /// </summary>
   public double Cost
   {
     get{ return cost; }
     set{ this.cost=value;}
   }
   private string detialReamrk;
   /// <summary>
   ///[to_InvoiceDetial]�� [detialReamrk]��
   /// </summary>
   public string DetialReamrk
   {
     get{ return detialReamrk; }
     set{ this.detialReamrk=value;}
   }
  }
}
