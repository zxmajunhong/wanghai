using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CompanyProd
  {
   //CompanyProd���Ĭ�Ϲ��췽��
   public CompanyProd ()
   {

   }
   private int id;
   /// <summary>
   ///[CompanyProd]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int companyId;
   /// <summary>
   ///[CompanyProd]�� [companyId]��
   /// </summary>
   public int CompanyId
   {
     get{ return companyId; }
     set{ this.companyId=value;}
   }
   private string prodTypeId;
   /// <summary>
   ///[CompanyProd]�� [prodTypeId]��
   /// </summary>
   public string ProdTypeId
   {
     get{ return prodTypeId; }
     set{ this.prodTypeId=value;}
   }
  }
}
