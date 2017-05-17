using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Factory
  {
   //Factory���Ĭ�Ϲ��췽��
   public Factory ()
   {

   }
   private int id;
   /// <summary>
   ///[Factory]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string factCode;
   /// <summary>
   ///[Factory]�� [factCode]��
   /// </summary>
   public string FactCode
   {
     get{ return factCode; }
     set{ this.factCode=value;}
   }
   private int factType;
   /// <summary>
   ///[Factory]�� [factType]��
   /// </summary>
   public int FactType
   {
     get{ return factType; }
     set{ this.factType=value;}
   }
   private string factshortName;
   /// <summary>
   ///[Factory]�� [factshortName]��
   /// </summary>
   public string FactshortName
   {
     get{ return factshortName; }
     set{ this.factshortName=value;}
   }
   private string factCName;
   /// <summary>
   ///[Factory]�� [factCName]��
   /// </summary>
   public string FactCName
   {
     get{ return factCName; }
     set{ this.factCName=value;}
   }
   private string factCAddress;
   /// <summary>
   ///[Factory]�� [factCAddress]��
   /// </summary>
   public string FactCAddress
   {
     get{ return factCAddress; }
     set{ this.factCAddress=value;}
   }
   private string province;
   /// <summary>
   ///[Factory]�� [province]��
   /// </summary>
   public string Province
   {
     get{ return province; }
     set{ this.province=value;}
   }
   private string city;
   /// <summary>
   ///[Factory]�� [city]��
   /// </summary>
   public string City
   {
     get{ return city; }
     set{ this.city=value;}
   }
   private int used;
   /// <summary>
   ///[Factory]�� [used]��
   /// </summary>
   public int Used
   {
     get{ return used; }
     set{ this.used=value;}
   }
   private string linkeName;
   /// <summary>
   ///[Factory]�� [linkeName]��
   /// </summary>
   public string LinkeName
   {
     get{ return linkeName; }
     set{ this.linkeName=value;}
   }
   private string duty;
   /// <summary>
   ///[Factory]�� [duty]��
   /// </summary>
   public string Duty
   {
     get{ return duty; }
     set{ this.duty=value;}
   }
   private string telephone;
   /// <summary>
   ///[Factory]�� [telephone]��
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[Factory]�� [fax]��
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[Factory]�� [mobile]��
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[Factory]�� [email]��
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string qQ;
   /// <summary>
   ///[Factory]�� [QQ]��
   /// </summary>
   public string QQ
   {
     get{ return qQ; }
     set{ this.qQ=value;}
   }
   private string skype;
   /// <summary>
   ///[Factory]�� [skype]��
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
   private string bank;
   /// <summary>
   ///[Factory]�� [bank]��
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string accountID;
   /// <summary>
   ///[Factory]�� [accountID]��
   /// </summary>
   public string AccountID
   {
     get{ return accountID; }
     set{ this.accountID=value;}
   }
   private string accountName;
   /// <summary>
   ///[Factory]�� [accountName]��
   /// </summary>
   public string AccountName
   {
     get{ return accountName; }
     set{ this.accountName=value;}
   }
   private string remark;
   /// <summary>
   ///[Factory]�� [remark]��
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
   private string ordernum;
   /// <summary>
   ///[Factory]�� [ordernum]��
   /// </summary>
   public string Ordernum
   {
     get{ return ordernum; }
     set{ this.ordernum=value;}
   }
   private string codeformat;
   /// <summary>
   ///[Factory]�� [codeformat]��
   /// </summary>
   public string Codeformat
   {
     get{ return codeformat; }
     set{ this.codeformat=value;}
   }
   private int inputname;
   /// <summary>
   ///[Factory]�� [inputname]��
   /// </summary>
   public int Inputname
   {
     get{ return inputname; }
     set{ this.inputname=value;}
   }
   private DateTime inputdate;
   /// <summary>
   ///[Factory]�� [inputdate]��
   /// </summary>
   public DateTime Inputdate
   {
     get{ return inputdate; }
     set{ this.inputdate=value;}
   }
      /// <summary>
      /// ����޸���Ա
      /// </summary>
   public string LastEditMan { get; set; }
      /// <summary>
      /// ����޸�����
      /// </summary>
   public DateTime LastEditDate { get; set; }
  }
}
