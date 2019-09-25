using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_OrderReimDetial
  {
   //To_OrderReimDetial表的默认构造方法
   public To_OrderReimDetial ()
   {

   }
   private int id;
   /// <summary>
   ///[To_OrderReimDetial]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int orderid;
   /// <summary>
   ///[To_OrderReimDetial]表 [orderid]列
   /// </summary>
   public int Orderid
   {
     get{ return orderid; }
     set{ this.orderid=value;}
   }
   private string reimNum;
   /// <summary>
   ///[To_OrderReimDetial]表 [reimNum]列
   /// </summary>
   public string ReimNum
   {
     get{ return reimNum; }
     set{ this.reimNum=value;}
   }
   private string reimContent;
   /// <summary>
   ///[To_OrderReimDetial]表 [reimContent]列
   /// </summary>
   public string ReimContent
   {
     get{ return reimContent; }
     set{ this.reimContent=value;}
   }
   private double reimMoney;
   /// <summary>
   ///[To_OrderReimDetial]表 [reimMoney]列
   /// </summary>
   public double ReimMoney
   {
     get{ return reimMoney; }
     set{ this.reimMoney=value;}
   }
   private double reimAmount;
   /// <summary>
   ///[To_OrderReimDetial]表 [reimAmount]列
   /// </summary>
   public double ReimAmount
   {
     get{ return reimAmount; }
     set{ this.reimAmount=value;}
   }
   private string reimConfirm;
   /// <summary>
   ///[To_OrderReimDetial]表 [reimConfirm]列
   /// </summary>
   public string ReimConfirm
   {
     get{ return reimConfirm; }
     set{ this.reimConfirm=value;}
   }
  }
}
