using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PaymentReturn
  {
   //To_PaymentReturn表的默认构造方法
   public To_PaymentReturn ()
   {

   }
   private int id;
   /// <summary>
   ///[To_PaymentReturn]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string paymentID;
   /// <summary>
   ///[To_PaymentReturn]表 [paymentID]列
   /// </summary>
   public string PaymentID
   {
     get{ return paymentID; }
     set{ this.paymentID=value;}
   }
   private int orderretid;
   /// <summary>
   ///[To_PaymentReturn]表 [orderID]列
   /// </summary>
   public int orderRetID
   {
     get{ return orderretid; }
     set{ this.orderretid=value;}
   }
   private string orderNum;
   /// <summary>
   ///[To_PaymentReturn]表 [orderNum]列
   /// </summary>
   public string OrderNum
   {
     get{ return orderNum; }
     set{ this.orderNum=value;}
   }
   private double shouldReturn;
   /// <summary>
   ///[To_PaymentReturn]表 [shouldReturn]列
   /// </summary>
   public double ShouldReturn
   {
     get{ return shouldReturn; }
     set{ this.shouldReturn=value;}
   }
   private double returnAmount;
   /// <summary>
   ///[To_PaymentReturn]表 [returnAmount]列
   /// </summary>
   public double ReturnAmount
   {
     get{ return returnAmount; }
     set{ this.returnAmount=value;}
   }
  }
}
