using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_Invoice
  {
   //To_Invoice表的默认构造方法
   public To_Invoice ()
   {

   }
   private int id;
   /// <summary>
   ///[to_Invoice]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string invoiceID;
   /// <summary>
   ///[to_Invoice]表 [invoiceID]列
   /// </summary>
   public string InvoiceID
   {
     get{ return invoiceID; }
     set{ this.invoiceID=value;}
   }
   private DateTime invoiceDate;
   /// <summary>
   ///[to_Invoice]表 [invoiceDate]列
   /// </summary>
   public DateTime InvoiceDate
   {
     get{ return invoiceDate; }
     set{ this.invoiceDate=value;}
   }
   private int selasmane;
   /// <summary>
   ///[to_Invoice]表 [selasmane]列
   /// </summary>
   public int Selasmane
   {
     get{ return selasmane; }
     set{ this.selasmane=value;}
   }
   private double sum;
   /// <summary>
   ///[to_Invoice]表 [sum]列
   /// </summary>
   public double Sum
   {
     get{ return sum; }
     set{ this.sum=value;}
   }
   private string department;
   /// <summary>
   ///[to_Invoice]表 [department]列
   /// </summary>
   public string Department
   {
     get{ return department; }
     set{ this.department=value;}
   }
   private string invoiceUnit;
   /// <summary>
   ///[to_Invoice]表 [invoiceUnit]列
   /// </summary>
   public string InvoiceUnit
   {
     get{ return invoiceUnit; }
     set{ this.invoiceUnit=value;}
   }
   private string remark;
   /// <summary>
   ///[to_Invoice]表 [remark]列
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
   private int invoiceCMan;
   /// <summary>
   ///[to_Invoice]表 [invoiceCMan]列
   /// </summary>
   public int InvoiceCMan
   {
     get{ return invoiceCMan; }
     set{ this.invoiceCMan=value;}
   }
   private int invoiceCDepartment;
   /// <summary>
   ///[to_Invoice]表 [invoiceCDepartment]列
   /// </summary>
   public int InvoiceCDepartment
   {
     get{ return invoiceCDepartment; }
     set{ this.invoiceCDepartment=value;}
   }
   private DateTime invoiceCDate;
   /// <summary>
   ///[to_Invoice]表 [invoiceCDate]列
   /// </summary>
   public DateTime InvoiceCDate
   {
     get{ return invoiceCDate; }
     set{ this.invoiceCDate=value;}
   }
   private string upfile;
   /// <summary>
   ///[to_Invoice]表 [upfile]列
   /// </summary>
   public string Upfile
   {
     get{ return upfile; }
     set{ this.upfile=value;}
   }
   private int detialID;
   /// <summary>
   ///[to_Invoice]表 [detialID]列
   /// </summary>
   public int DetialID
   {
     get{ return detialID; }
     set{ this.detialID=value;}
   }
   private string invoiceType;
   /// <summary>
   ///[to_Invoice]表 [invoiceType]列
   /// </summary>
   public string InvoiceType
   {
     get{ return invoiceType; }
     set{ this.invoiceType=value;}
   }
   private int isSure;
   /// <summary>
   ///[to_Invoice]表 [IsSure]列
   /// </summary>
   public int IsSure
   {
     get{ return isSure; }
     set{ this.isSure=value;}
   }
  }
}
