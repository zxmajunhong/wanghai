using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PolicyTarget
  {
   //To_PolicyTarget表的默认构造方法
   public To_PolicyTarget ()
   {

   }
   private int id;
   /// <summary>
   ///[To_PolicyTarget]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int policyID;
   /// <summary>
   ///[To_PolicyTarget]表 [policyID]列
   /// </summary>
   public int PolicyID
   {
     get{ return policyID; }
     set{ this.policyID=value;}
   }
   private string propertyName;
   /// <summary>
   ///[To_PolicyTarget]表 [propertyName]列
   /// </summary>
   public string PropertyName
   {
     get{ return propertyName; }
     set{ this.propertyName=value;}
   }
   private string propertyValue;
   /// <summary>
   ///[To_PolicyTarget]表 [propertyValue]列
   /// </summary>
   public string PropertyValue
   {
     get{ return propertyValue; }
     set{ this.propertyValue=value;}
   }
   private int propertyTypeID;
   /// <summary>
   ///[To_PolicyTarget]表 [propertyTypeID]列
   /// </summary>
   public int PropertyTypeID
   {
     get{ return propertyTypeID; }
     set{ this.propertyTypeID=value;}
   }
   private int propertyID;
   /// <summary>
   ///[To_PolicyTarget]表 [propertyID]列
   /// </summary>
   public int PropertyID
   {
     get{ return propertyID; }
     set{ this.propertyID=value;}
   }
   private int datatype;
   /// <summary>
   ///[To_PolicyTarget]表 [datatype]列
   /// </summary>
   public int Datatype
   {
     get{ return datatype; }
     set{ this.datatype=value;}
   }
  }
}
