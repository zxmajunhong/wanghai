using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class ComLinkman
  {
   //ComLinkman���Ĭ�Ϲ��췽��
   public ComLinkman ()
   {

   }
   private int id;
   /// <summary>
   ///[ComLinkman]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int companyId;
   /// <summary>
   ///[ComLinkman]�� [companyId]��
   /// </summary>
   public int CompanyId
   {
     get{ return companyId; }
     set{ this.companyId=value;}
   }
   private string linkName;
   /// <summary>
   ///[ComLinkman]�� [linkName]��
   /// </summary>
   public string LinkName
   {
     get{ return linkName; }
     set{ this.linkName=value;}
   }
   private string post;
   /// <summary>
   ///[ComLinkman]�� [post]��
   /// </summary>
   public string Post
   {
     get{ return post; }
     set{ this.post=value;}
   }
   private string telephone;
   /// <summary>
   ///[ComLinkman]�� [telephone]��
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[ComLinkman]�� [fax]��
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[ComLinkman]�� [mobile]��
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[ComLinkman]�� [email]��
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string msn;
   /// <summary>
   ///[ComLinkman]�� [msn]��
   /// </summary>
   public string Msn
   {
     get{ return msn; }
     set{ this.msn=value;}
   }
   private string skype;
   /// <summary>
   ///[ComLinkman]�� [skype]��
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
  }
}
