using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Parameter
  {
   //Parameter���Ĭ�Ϲ��췽��
   public Parameter ()
   {

   }
   private int id;
   /// <summary>
   ///[Parameter]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string rate;
   /// <summary>
   ///[Parameter]�� [rate]��
   /// </summary>
   public string Rate
   {
     get{ return rate; }
     set{ this.rate=value;}
   }
   private int freeDay;
   /// <summary>
   ///[Parameter]�� [freeDay]��
   /// </summary>
   public int FreeDay
   {
     get{ return freeDay; }
     set{ this.freeDay=value;}
   }
   private string conRatio;
   /// <summary>
   ///[Parameter]�� [conRatio]��
   /// </summary>
   public string ConRatio
   {
     get{ return conRatio; }
     set{ this.conRatio=value;}
   }
   private string brokeRatio;
   /// <summary>
   ///[Parameter]�� [brokeRatio]��
   /// </summary>
   public string BrokeRatio
   {
     get{ return brokeRatio; }
     set{ this.brokeRatio=value;}
   }
   private string brokeTaxRatio;
   /// <summary>
   ///[Parameter]�� [brokeTaxRatio]��
   /// </summary>
   public string BrokeTaxRatio
   {
     get{ return brokeTaxRatio; }
     set{ this.brokeTaxRatio=value;}
   }
   private string serviceRatio;
   /// <summary>
   ///[Parameter]�� [serviceRatio]��
   /// </summary>
   public string ServiceRatio
   {
     get{ return serviceRatio; }
     set{ this.serviceRatio=value;}
   }
   private string otherRatio;
   /// <summary>
   ///[Parameter]�� [otherRatio]��
   /// </summary>
   public string OtherRatio
   {
     get{ return otherRatio; }
     set{ this.otherRatio=value;}
   }
   private int commission;
   /// <summary>
   ///[Parameter]�� [commission]��
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
