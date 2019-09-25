using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FactLinkman
  {
   //FactLinkman表的默认构造方法
   public FactLinkman ()
   {

   }
   private int id;
   /// <summary>
   ///[FactLinkman]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int factId;
   /// <summary>
   ///[FactLinkman]表 [factId]列
   /// </summary>
   public int FactId
   {
     get{ return factId; }
     set{ this.factId=value;}
   }
   private string linkName;
   /// <summary>
   ///[FactLinkman]表 [linkName]列
   /// </summary>
   public string LinkName
   {
     get{ return linkName; }
     set{ this.linkName=value;}
   }
   private string duty;
   /// <summary>
   ///[FactLinkman]表 [duty]列
   /// </summary>
   public string Duty
   {
     get{ return duty; }
     set{ this.duty=value;}
   }
   private string telephone;
   /// <summary>
   ///[FactLinkman]表 [telephone]列
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[FactLinkman]表 [fax]列
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[FactLinkman]表 [mobile]列
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[FactLinkman]表 [email]列
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string qQ;
   /// <summary>
   ///[FactLinkman]表 [QQ]列
   /// </summary>
   public string QQ
   {
     get{ return qQ; }
     set{ this.qQ=value;}
   }
   private string skype;
   /// <summary>
   ///[FactLinkman]表 [skype]列
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
  }
}
