using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PaymentDetail
  {
   //To_PaymentDetail表的默认构造方法
   public To_PaymentDetail ()
   {

   }
   private int id;
   /// <summary>
   ///[To_PaymentDetail]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string paymentID;
   /// <summary>
   ///[To_PaymentDetail]表 [paymentID]列
   /// </summary>
   public string PaymentID
   {
     get{ return paymentID; }
     set{ this.paymentID=value;}
   }
   private string orderNum;
   /// <summary>
   ///[To_PaymentDetail]表 [orderNum]列
   /// </summary>
   public string OrderNum
   {
     get{ return orderNum; }
     set{ this.orderNum=value;}
   }
   private int orderPayId;
   /// <summary>
   ///[To_PaymentDetail]表 [orderPayId]列
   /// </summary>
   public int OrderPayId
   {
     get{ return orderPayId; }
     set{ this.orderPayId=value;}
   }
   private double shouldPay;
   /// <summary>
   ///[To_PaymentDetail]表 [shouldPay]列
   /// </summary>
   public double ShouldPay
   {
     get{ return shouldPay; }
     set{ this.shouldPay=value;}
   }
   private double payAmount;
   /// <summary>
   ///[To_PaymentDetail]表 [payAmount]列
   /// </summary>
   public double PayAmount
   {
     get{ return payAmount; }
     set{ this.payAmount=value;}
   }
  }
}
