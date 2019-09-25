using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Parameter
  {
   //Parameter表的默认构造方法
   public Parameter ()
   {

   }
   private int id;
   /// <summary>
   ///[Parameter]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string rate;
   /// <summary>
   ///[Parameter]表 [rate]列
   /// </summary>
   public string Rate
   {
     get{ return rate; }
     set{ this.rate=value;}
   }
   private int freeDay;
   /// <summary>
   ///[Parameter]表 [freeDay]列
   /// </summary>
   public int FreeDay
   {
     get{ return freeDay; }
     set{ this.freeDay=value;}
   }
   private string conRatio;
   /// <summary>
   ///[Parameter]表 [conRatio]列
   /// </summary>
   public string ConRatio
   {
     get{ return conRatio; }
     set{ this.conRatio=value;}
   }
   private string brokeRatio;
   /// <summary>
   ///[Parameter]表 [brokeRatio]列
   /// </summary>
   public string BrokeRatio
   {
     get{ return brokeRatio; }
     set{ this.brokeRatio=value;}
   }
   private string brokeTaxRatio;
   /// <summary>
   ///[Parameter]表 [brokeTaxRatio]列
   /// </summary>
   public string BrokeTaxRatio
   {
     get{ return brokeTaxRatio; }
     set{ this.brokeTaxRatio=value;}
   }
   private string serviceRatio;
   /// <summary>
   ///[Parameter]表 [serviceRatio]列
   /// </summary>
   public string ServiceRatio
   {
     get{ return serviceRatio; }
     set{ this.serviceRatio=value;}
   }
   private string otherRatio;
   /// <summary>
   ///[Parameter]表 [otherRatio]列
   /// </summary>
   public string OtherRatio
   {
     get{ return otherRatio; }
     set{ this.otherRatio=value;}
   }
   private int commission;
   /// <summary>
   ///[Parameter]表 [commission]列
   /// </summary>
   public int Commission
   {
     get{ return commission; }
     set{ this.commission=value;}
   }

   public string ServiceTaxRatio
   {
       get;
       set;
   }
  }
}
