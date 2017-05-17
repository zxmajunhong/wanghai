using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_InvoiceDetial
  {
   //To_InvoiceDetial表的默认构造方法
   public To_InvoiceDetial ()
   {

   }
   private int id;
   /// <summary>
   ///[to_InvoiceDetial]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int invoiceID;
   /// <summary>
   ///[to_InvoiceDetial]表 [invoiceID]列
   /// </summary>
   public int InvoiceID
   {
     get{ return invoiceID; }
     set{ this.invoiceID=value;}
   }
   private string policyID;
   /// <summary>
   ///[to_InvoiceDetial]表 [policyID]列
   /// </summary>
   public string PolicyID
   {
     get{ return policyID; }
     set{ this.policyID=value;}
   }
   private string cusName;
   /// <summary>
   ///[to_InvoiceDetial]表 [cusName]列
   /// </summary>
   public string CusName
   {
     get{ return cusName; }
     set{ this.cusName=value;}
   }
   private double cost;
   /// <summary>
   ///[to_InvoiceDetial]表 [cost]列
   /// </summary>
   public double Cost
   {
     get{ return cost; }
     set{ this.cost=value;}
   }
   private string detialReamrk;
   /// <summary>
   ///[to_InvoiceDetial]表 [detialReamrk]列
   /// </summary>
   public string DetialReamrk
   {
     get{ return detialReamrk; }
     set{ this.detialReamrk=value;}
   }
  }
}
