using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PaymentReturn
  {
   //To_PaymentReturn���Ĭ�Ϲ��췽��
   public To_PaymentReturn ()
   {

   }
   private int id;
   /// <summary>
   ///[To_PaymentReturn]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string paymentID;
   /// <summary>
   ///[To_PaymentReturn]�� [paymentID]��
   /// </summary>
   public string PaymentID
   {
     get{ return paymentID; }
     set{ this.paymentID=value;}
   }
   private int orderretid;
   /// <summary>
   ///[To_PaymentReturn]�� [orderID]��
   /// </summary>
   public int orderRetID
   {
     get{ return orderretid; }
     set{ this.orderretid=value;}
   }
   private string orderNum;
   /// <summary>
   ///[To_PaymentReturn]�� [orderNum]��
   /// </summary>
   public string OrderNum
   {
     get{ return orderNum; }
     set{ this.orderNum=value;}
   }
   private double shouldReturn;
   /// <summary>
   ///[To_PaymentReturn]�� [shouldReturn]��
   /// </summary>
   public double ShouldReturn
   {
     get{ return shouldReturn; }
     set{ this.shouldReturn=value;}
   }
   private double returnAmount;
   /// <summary>
   ///[To_PaymentReturn]�� [returnAmount]��
   /// </summary>
   public double ReturnAmount
   {
     get{ return returnAmount; }
     set{ this.returnAmount=value;}
   }
  }
}
