using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PaymentDetail
  {
   //To_PaymentDetail���Ĭ�Ϲ��췽��
   public To_PaymentDetail ()
   {

   }
   private int id;
   /// <summary>
   ///[To_PaymentDetail]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string paymentID;
   /// <summary>
   ///[To_PaymentDetail]�� [paymentID]��
   /// </summary>
   public string PaymentID
   {
     get{ return paymentID; }
     set{ this.paymentID=value;}
   }
   private string orderNum;
   /// <summary>
   ///[To_PaymentDetail]�� [orderNum]��
   /// </summary>
   public string OrderNum
   {
     get{ return orderNum; }
     set{ this.orderNum=value;}
   }
   private int orderPayId;
   /// <summary>
   ///[To_PaymentDetail]�� [orderPayId]��
   /// </summary>
   public int OrderPayId
   {
     get{ return orderPayId; }
     set{ this.orderPayId=value;}
   }
   private double shouldPay;
   /// <summary>
   ///[To_PaymentDetail]�� [shouldPay]��
   /// </summary>
   public double ShouldPay
   {
     get{ return shouldPay; }
     set{ this.shouldPay=value;}
   }
   private double payAmount;
   /// <summary>
   ///[To_PaymentDetail]�� [payAmount]��
   /// </summary>
   public double PayAmount
   {
     get{ return payAmount; }
     set{ this.payAmount=value;}
   }
  }
}
