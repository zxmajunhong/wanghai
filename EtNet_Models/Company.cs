using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Company
  {
   //Company���Ĭ�Ϲ��췽��
   public Company ()
   {

   }
   private int id;
   /// <summary>
   ///[Company]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string comCode;
   /// <summary>
   ///[Company]�� [comCode]�� ��˾����
   /// </summary>
   public string ComCode
   {
     get{ return comCode; }
     set{ this.comCode=value;}
   }
   private int comType;
   /// <summary>
   ///[Company]�� [comType]�� ��˾���
   /// </summary>
   public int ComType
   {
     get{ return comType; }
     set{ this.comType=value;}
   }
   private int comPro;
   /// <summary>
   ///[Company]�� [comPro]��
   /// </summary>
   public int ComPro
   {
     get{ return comPro; }
     set{ this.comPro=value;}
   }
   private string comShortName;
   /// <summary>
   ///[Company]�� [comShortName]�� ��˾���
   /// </summary>
   public string ComShortName
   {
     get{ return comShortName; }
     set{ this.comShortName=value;}
   }
   private string comCname;
   /// <summary>
   ///[Company]�� [comCname]�� ��˾ȫ��
   /// </summary>
   public string ComCname
   {
     get{ return comCname; }
     set{ this.comCname=value;}
   }
   private string comCAddress;
   /// <summary>
   ///[Company]�� [comCAddress]�� ��˾��ַ
   /// </summary>
   public string ComCAddress
   {
     get{ return comCAddress; }
     set{ this.comCAddress=value;}
   }
   private string province;
   /// <summary>
   ///[Company]�� [province]�� ʡ��
   /// </summary>
   public string Province
   {
     get{ return province; }
     set{ this.province=value;}
   }
   private string city;
   /// <summary>
   ///[Company]�� [city]�� ����
   /// </summary>
   public string City
   {
     get{ return city; }
     set{ this.city=value;}
   }
   private string comUrl;
   /// <summary>
   ///[Company]�� [comUrl]�� ��˾��ַ
   /// </summary>
   public string ComUrl
   {
     get{ return comUrl; }
     set{ this.comUrl=value;}
   }
   private int used;
   /// <summary>
   ///[Company]�� [used]�� �Ƿ�����
   /// </summary>
   public int Used
   {
     get{ return used; }
     set{ this.used=value;}
   }
   private string linkName;
   /// <summary>
   ///[Company]�� [linkName]�� ��ϵ����
   /// </summary>
   public string LinkName
   {
     get{ return linkName; }
     set{ this.linkName=value;}
   }
   private string post;
   /// <summary>
   ///[Company]�� [post]�� ��ϵ������ְ��
   /// </summary>
   public string Post
   {
     get{ return post; }
     set{ this.post=value;}
   }
   private string telephone;
   /// <summary>
   ///[Company]�� [telephone]�� //��ϵ����ϵ�绰
   /// </summary>
   public string Telephone
   {
     get{ return telephone; }
     set{ this.telephone=value;}
   }
   private string fax;
   /// <summary>
   ///[Company]�� [fax]�� //��ϵ�˴���
   /// </summary>
   public string Fax
   {
     get{ return fax; }
     set{ this.fax=value;}
   }
   private string mobile;
   /// <summary>
   ///[Company]�� [mobile]�� //��ϵ���ֻ�����
   /// </summary>
   public string Mobile
   {
     get{ return mobile; }
     set{ this.mobile=value;}
   }
   private string email;
   /// <summary>
   ///[Company]�� [email]�� //��ϵ�������ַ
   /// </summary>
   public string Email
   {
     get{ return email; }
     set{ this.email=value;}
   }
   private string msn;
   /// <summary>
   ///[Company]�� [msn]�� //��ϵ��QQ
   /// </summary>
   public string Msn
   {
     get{ return msn; }
     set{ this.msn=value;}
   }
   private string skype;
   /// <summary>
   ///[Company]�� [skype]�� //��ϵ��skype
   /// </summary>
   public string Skype
   {
     get{ return skype; }
     set{ this.skype=value;}
   }
   private string bank;
   /// <summary>
   ///[Company]�� [bank]�� //��������
   /// </summary>
   public string Bank
   {
     get{ return bank; }
     set{ this.bank=value;}
   }
   private string cardId;
   /// <summary>
   ///[Company]�� [cardId]�� �����˺�
   /// </summary>
   public string CardId
   {
     get{ return cardId; }
     set{ this.cardId=value;}
   }
   private string cardName;
   /// <summary>
   ///[Company]�� [cardName]�� ��������
   /// </summary>
   public string CardName
   {
     get{ return cardName; }
     set{ this.cardName=value;}
   }
   private string remark;
   /// <summary>
   ///[Company]�� [remark]�� ���б�ע
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
   private string ordernum;
   /// <summary>
   ///[Company]�� [ordernum]�� ��ˮ��
   /// </summary>
   public string Ordernum
   {
     get{ return ordernum; }
     set{ this.ordernum=value;}
   }
   private string codeformat;
   /// <summary>
   ///[Company]�� [codeformat]�� ��˾�������
   /// </summary>
   public string Codeformat
   {
     get{ return codeformat; }
     set{ this.codeformat=value;}
   }
   private int madefrom;
   /// <summary>
   ///[Company]�� [madefrom]�� �Ƶ���Աid
   /// </summary>
   public int Madefrom
   {
     get{ return madefrom; }
     set{ this.madefrom=value;}
   }
   private DateTime madeTime;
   /// <summary>
   ///[Company]�� [madeTime]�� �Ƶ�ʱ��
   /// </summary>
   public DateTime MadeTime
   {
     get{ return madeTime; }
     set{ this.madeTime=value;}
   }
  }
}
