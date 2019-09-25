using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CompanyProd
  {
   //CompanyProd表的默认构造方法
   public CompanyProd ()
   {

   }
   private int id;
   /// <summary>
   ///[CompanyProd]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int companyId;
   /// <summary>
   ///[CompanyProd]表 [companyId]列
   /// </summary>
   public int CompanyId
   {
     get{ return companyId; }
     set{ this.companyId=value;}
   }
   private string prodTypeId;
   /// <summary>
   ///[CompanyProd]表 [prodTypeId]列
   /// </summary>
   public string ProdTypeId
   {
     get{ return prodTypeId; }
     set{ this.prodTypeId=value;}
   }
  }
}
