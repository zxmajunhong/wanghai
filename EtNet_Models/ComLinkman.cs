using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class ComLinkman
  {
   //ComLinkman表的默认构造方法
   public ComLinkman ()
   {

   }
   private int id;
   /// <summary>
   ///[ComLinkman]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int companyId;
   /// <summary>
   ///[ComLinkman]表 [companyId]列
   /// </summary>
   public int CompanyId
   {
     get{ return companyId; }
     set{ this.companyId=value;}
   }
   private string linkName;
   /// <summary>
   ///[ComLinkman]表 [linkName]列
   /// </summary>
   public string LinkName
   {
     get{ return linkName; }
     set{ this.linkName=value;}
   }
   private string post;
   /// <summary>
   ///[ComLinkman]表 [post]列
   /// </summary>
   public string Post
   {
     get{ return post; }
     set{ this.post=value;}
   }
   private string telephone;
   /// <summary>
   ///[ComLinkman]表 [telephone]列
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[ComLinkman]表 [fax]列
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[ComLinkman]表 [mobile]列
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[ComLinkman]表 [email]列
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string msn;
   /// <summary>
   ///[ComLinkman]表 [msn]列
   /// </summary>
   public string Msn
   {
     get{ return msn; }
     set{ this.msn=value;}
   }
   private string skype;
   /// <summary>
   ///[ComLinkman]表 [skype]列
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
  }
}
