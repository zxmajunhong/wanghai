using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Company
  {
   //Company表的默认构造方法
   public Company ()
   {

   }
   private int id;
   /// <summary>
   ///[Company]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string comCode;
   /// <summary>
   ///[Company]表 [comCode]列 公司代码
   /// </summary>
   public string ComCode
   {
     get{ return comCode; }
     set{ this.comCode=value;}
   }
   private int comType;
   /// <summary>
   ///[Company]表 [comType]列 公司类别
   /// </summary>
   public int ComType
   {
     get{ return comType; }
     set{ this.comType=value;}
   }
   private int comPro;
   /// <summary>
   ///[Company]表 [comPro]列
   /// </summary>
   public int ComPro
   {
     get{ return comPro; }
     set{ this.comPro=value;}
   }
   private string comShortName;
   /// <summary>
   ///[Company]表 [comShortName]列 公司简称
   /// </summary>
   public string ComShortName
   {
     get{ return comShortName; }
     set{ this.comShortName=value;}
   }
   private string comCname;
   /// <summary>
   ///[Company]表 [comCname]列 公司全称
   /// </summary>
   public string ComCname
   {
     get{ return comCname; }
     set{ this.comCname=value;}
   }
   private string comCAddress;
   /// <summary>
   ///[Company]表 [comCAddress]列 公司地址
   /// </summary>
   public string ComCAddress
   {
     get{ return comCAddress; }
     set{ this.comCAddress=value;}
   }
   private string province;
   /// <summary>
   ///[Company]表 [province]列 省份
   /// </summary>
   public string Province
   {
     get{ return province; }
     set{ this.province=value;}
   }
   private string city;
   /// <summary>
   ///[Company]表 [city]列 城市
   /// </summary>
   public string City
   {
     get{ return city; }
     set{ this.city=value;}
   }
   private string comUrl;
   /// <summary>
   ///[Company]表 [comUrl]列 公司网址
   /// </summary>
   public string ComUrl
   {
     get{ return comUrl; }
     set{ this.comUrl=value;}
   }
   private int used;
   /// <summary>
   ///[Company]表 [used]列 是否启用
   /// </summary>
   public int Used
   {
     get{ return used; }
     set{ this.used=value;}
   }
   private string linkName;
   /// <summary>
   ///[Company]表 [linkName]列 联系人名
   /// </summary>
   public string LinkName
   {
     get{ return linkName; }
     set{ this.linkName=value;}
   }
   private string post;
   /// <summary>
   ///[Company]表 [post]列 联系人所属职务
   /// </summary>
   public string Post
   {
     get{ return post; }
     set{ this.post=value;}
   }
   private string telephone;
   /// <summary>
   ///[Company]表 [telephone]列 //联系人联系电话
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[Company]表 [fax]列 //联系人传真
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[Company]表 [mobile]列 //联系人手机号码
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[Company]表 [email]列 //联系人邮箱地址
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string msn;
   /// <summary>
   ///[Company]表 [msn]列 //联系人QQ
   /// </summary>
   public string Msn
   {
     get{ return msn; }
     set{ this.msn=value;}
   }
   private string skype;
   /// <summary>
   ///[Company]表 [skype]列 //联系人skype
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
   private string bank;
   /// <summary>
   ///[Company]表 [bank]列 //开户银行
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string cardId;
   /// <summary>
   ///[Company]表 [cardId]列 银行账号
   /// </summary>
   public string CardId
   {
     get{ return cardId; }
     set{ this.cardId=value;}
   }
   private string cardName;
   /// <summary>
   ///[Company]表 [cardName]列 开户户名
   /// </summary>
   public string CardName
   {
     get{ return cardName; }
     set{ this.cardName=value;}
   }
   private string remark;
   /// <summary>
   ///[Company]表 [remark]列 银行备注
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
   private string ordernum;
   /// <summary>
   ///[Company]表 [ordernum]列 流水号
   /// </summary>
   public string Ordernum
   {
     get{ return ordernum; }
     set{ this.ordernum=value;}
   }
   private string codeformat;
   /// <summary>
   ///[Company]表 [codeformat]列 公司代码规则
   /// </summary>
   public string Codeformat
   {
     get{ return codeformat; }
     set{ this.codeformat=value;}
   }
   private int madefrom;
   /// <summary>
   ///[Company]表 [madefrom]列 制单人员id
   /// </summary>
   public int Madefrom
   {
     get{ return madefrom; }
     set{ this.madefrom=value;}
   }
   private DateTime madeTime;
   /// <summary>
   ///[Company]表 [madeTime]列 制单时间
   /// </summary>
   public DateTime MadeTime
   {
     get{ return madeTime; }
     set{ this.madeTime=value;}
   }
  }
}
