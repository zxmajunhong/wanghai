using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FactLinkman
  {
   //FactLinkman���Ĭ�Ϲ��췽��
   public FactLinkman ()
   {

   }
   private int id;
   /// <summary>
   ///[FactLinkman]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int factId;
   /// <summary>
   ///[FactLinkman]�� [factId]��
   /// </summary>
   public int FactId
   {
     get{ return factId; }
     set{ this.factId=value;}
   }
   private string linkName;
   /// <summary>
   ///[FactLinkman]�� [linkName]��
   /// </summary>
   public string LinkName
   {
     get{ return linkName; }
     set{ this.linkName=value;}
   }
   private string duty;
   /// <summary>
   ///[FactLinkman]�� [duty]��
   /// </summary>
   public string Duty
   {
     get{ return duty; }
     set{ this.duty=value;}
   }
   private string telephone;
   /// <summary>
   ///[FactLinkman]�� [telephone]��
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[FactLinkman]�� [fax]��
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[FactLinkman]�� [mobile]��
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[FactLinkman]�� [email]��
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string qQ;
   /// <summary>
   ///[FactLinkman]�� [QQ]��
   /// </summary>
   public string QQ
   {
     get{ return qQ; }
     set{ this.qQ=value;}
   }
   private string skype;
   /// <summary>
   ///[FactLinkman]�� [skype]��
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
  }
}
