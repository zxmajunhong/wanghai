using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Factory
  {
   //Factory表的默认构造方法
   public Factory ()
   {

   }
   private int id;
   /// <summary>
   ///[Factory]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string factCode;
   /// <summary>
   ///[Factory]表 [factCode]列
   /// </summary>
   public string FactCode
   {
     get{ return factCode; }
     set{ this.factCode=value;}
   }
   private int factType;
   /// <summary>
   ///[Factory]表 [factType]列
   /// </summary>
   public int FactType
   {
     get{ return factType; }
     set{ this.factType=value;}
   }
   private string factshortName;
   /// <summary>
   ///[Factory]表 [factshortName]列
   /// </summary>
   public string FactshortName
   {
     get{ return factshortName; }
     set{ this.factshortName=value;}
   }
   private string factCName;
   /// <summary>
   ///[Factory]表 [factCName]列
   /// </summary>
   public string FactCName
   {
     get{ return factCName; }
     set{ this.factCName=value;}
   }
   private string factCAddress;
   /// <summary>
   ///[Factory]表 [factCAddress]列
   /// </summary>
   public string FactCAddress
   {
     get{ return factCAddress; }
     set{ this.factCAddress=value;}
   }
   private string province;
   /// <summary>
   ///[Factory]表 [province]列
   /// </summary>
   public string Province
   {
     get{ return province; }
     set{ this.province=value;}
   }
   private string city;
   /// <summary>
   ///[Factory]表 [city]列
   /// </summary>
   public string City
   {
     get{ return city; }
     set{ this.city=value;}
   }
   private int used;
   /// <summary>
   ///[Factory]表 [used]列
   /// </summary>
   public int Used
   {
     get{ return used; }
     set{ this.used=value;}
   }
   private string linkeName;
   /// <summary>
   ///[Factory]表 [linkeName]列
   /// </summary>
   public string LinkeName
   {
     get{ return linkeName; }
     set{ this.linkeName=value;}
   }
   private string duty;
   /// <summary>
   ///[Factory]表 [duty]列
   /// </summary>
   public string Duty
   {
     get{ return duty; }
     set{ this.duty=value;}
   }
   private string telephone;
   /// <summary>
   ///[Factory]表 [telephone]列
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[Factory]表 [fax]列
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[Factory]表 [mobile]列
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[Factory]表 [email]列
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string qQ;
   /// <summary>
   ///[Factory]表 [QQ]列
   /// </summary>
   public string QQ
   {
     get{ return qQ; }
     set{ this.qQ=value;}
   }
   private string skype;
   /// <summary>
   ///[Factory]表 [skype]列
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
   private string bank;
   /// <summary>
   ///[Factory]表 [bank]列
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string accountID;
   /// <summary>
   ///[Factory]表 [accountID]列
   /// </summary>
   public string AccountID
   {
     get{ return accountID; }
     set{ this.accountID=value;}
   }
   private string accountName;
   /// <summary>
   ///[Factory]表 [accountName]列
   /// </summary>
   public string AccountName
   {
     get{ return accountName; }
     set{ this.accountName=value;}
   }
   private string remark;
   /// <summary>
   ///[Factory]表 [remark]列
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
   private string ordernum;
   /// <summary>
   ///[Factory]表 [ordernum]列
   /// </summary>
   public string Ordernum
   {
     get{ return ordernum; }
     set{ this.ordernum=value;}
   }
   private string codeformat;
   /// <summary>
   ///[Factory]表 [codeformat]列
   /// </summary>
   public string Codeformat
   {
     get{ return codeformat; }
     set{ this.codeformat=value;}
   }
   private int inputname;
   /// <summary>
   ///[Factory]表 [inputname]列
   /// </summary>
   public int Inputname
   {
     get{ return inputname; }
     set{ this.inputname=value;}
   }
   private DateTime inputdate;
   /// <summary>
   ///[Factory]表 [inputdate]列
   /// </summary>
   public DateTime Inputdate
   {
     get{ return inputdate; }
     set{ this.inputdate=value;}
   }
      /// <summary>
      /// 最后修改人员
      /// </summary>
   public string LastEditMan { get; set; }
      /// <summary>
      /// 最后修改日期
      /// </summary>
   public DateTime LastEditDate { get; set; }
  }
}
