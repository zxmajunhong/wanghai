using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PolicyTarget
  {
   //To_PolicyTarget���Ĭ�Ϲ��췽��
   public To_PolicyTarget ()
   {

   }
   private int id;
   /// <summary>
   ///[To_PolicyTarget]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int policyID;
   /// <summary>
   ///[To_PolicyTarget]�� [policyID]��
   /// </summary>
   public int PolicyID
   {
     get{ return policyID; }
     set{ this.policyID=value;}
   }
   private string propertyName;
   /// <summary>
   ///[To_PolicyTarget]�� [propertyName]��
   /// </summary>
   public string PropertyName
   {
     get{ return propertyName; }
     set{ this.propertyName=value;}
   }
   private string propertyValue;
   /// <summary>
   ///[To_PolicyTarget]�� [propertyValue]��
   /// </summary>
   public string PropertyValue
   {
     get{ return propertyValue; }
     set{ this.propertyValue=value;}
   }
   private int propertyTypeID;
   /// <summary>
   ///[To_PolicyTarget]�� [propertyTypeID]��
   /// </summary>
   public int PropertyTypeID
   {
     get{ return propertyTypeID; }
     set{ this.propertyTypeID=value;}
   }
   private int propertyID;
   /// <summary>
   ///[To_PolicyTarget]�� [propertyID]��
   /// </summary>
   public int PropertyID
   {
     get{ return propertyID; }
     set{ this.propertyID=value;}
   }
   private int datatype;
   /// <summary>
   ///[To_PolicyTarget]�� [datatype]��
   /// </summary>
   public int Datatype
   {
     get{ return datatype; }
     set{ this.datatype=value;}
   }
  }
}
