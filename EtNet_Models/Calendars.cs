using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Calendars
  {
   //Calendars表的默认构造方法
   public Calendars ()
   {

   }
   private int id;
   /// <summary>
   ///[Calendars]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string subject;
   /// <summary>
   ///[Calendars]表 [Subject]列
   /// </summary>
   public string Subject
   {
     get{ return subject; }
     set{ this.subject=value;}
   }
   private string location;
   /// <summary>
   ///[Calendars]表 [Location]列
   /// </summary>
   public string Location
   {
     get{ return location; }
     set{ this.location=value;}
   }
   private int masterId;
   /// <summary>
   ///[Calendars]表 [MasterId]列
   /// </summary>
   public int MasterId
   {
     get{ return masterId; }
     set{ this.masterId=value;}
   }
   private string description;
   /// <summary>
   ///[Calendars]表 [Description]列
   /// </summary>
   public string Description
   {
     get{ return description; }
     set{ this.description=value;}
   }
   private int calendarType;
   /// <summary>
   ///[Calendars]表 [CalendarType]列
   /// </summary>
   public int CalendarType
   {
     get{ return calendarType; }
     set{ this.calendarType=value;}
   }
   private DateTime startTime;
   /// <summary>
   ///[Calendars]表 [StartTime]列
   /// </summary>
   public DateTime StartTime
   {
     get{ return startTime; }
     set{ this.startTime=value;}
   }
   private DateTime endTime;
   /// <summary>
   ///[Calendars]表 [EndTime]列
   /// </summary>
   public DateTime EndTime
   {
     get{ return endTime; }
     set{ this.endTime=value;}
   }
   private int isAllDayEvent;
   /// <summary>
   ///[Calendars]表 [IsAllDayEvent]列
   /// </summary>
   public int IsAllDayEvent
   {
     get{ return isAllDayEvent; }
     set{ this.isAllDayEvent=value;}
   }
   private int hasAttachment;
   /// <summary>
   ///[Calendars]表 [HasAttachment]列
   /// </summary>
   public int HasAttachment
   {
     get{ return hasAttachment; }
     set{ this.hasAttachment=value;}
   }
   private string category;
   /// <summary>
   ///[Calendars]表 [Category]列
   /// </summary>
   public string Category
   {
     get{ return category; }
     set{ this.category=value;}
   }
   private int instanceType;
   /// <summary>
   ///[Calendars]表 [InstanceType]列
   /// </summary>
   public int InstanceType
   {
     get{ return instanceType; }
     set{ this.instanceType=value;}
   }
   private string attendees;
   /// <summary>
   ///[Calendars]表 [Attendees]列
   /// </summary>
   public string Attendees
   {
     get{ return attendees; }
     set{ this.attendees=value;}
   }
   private string attendeeNames;
   /// <summary>
   ///[Calendars]表 [AttendeeNames]列
   /// </summary>
   public string AttendeeNames
   {
     get{ return attendeeNames; }
     set{ this.attendeeNames=value;}
   }
   private string otherAttendee;
   /// <summary>
   ///[Calendars]表 [OtherAttendee]列
   /// </summary>
   public string OtherAttendee
   {
     get{ return otherAttendee; }
     set{ this.otherAttendee=value;}
   }
   private string uPAccount;
   /// <summary>
   ///[Calendars]表 [UPAccount]列
   /// </summary>
   public string UPAccount
   {
     get{ return uPAccount; }
     set{ this.uPAccount=value;}
   }
   private string uPName;
   /// <summary>
   ///[Calendars]表 [UPName]列
   /// </summary>
   public string UPName
   {
     get{ return uPName; }
     set{ this.uPName=value;}
   }
   private DateTime uPTime;
   /// <summary>
   ///[Calendars]表 [UPTime]列
   /// </summary>
   public DateTime UPTime
   {
     get{ return uPTime; }
     set{ this.uPTime=value;}
   }
   private string recurringRule;
   /// <summary>
   ///[Calendars]表 [RecurringRule]列
   /// </summary>
   public string RecurringRule
   {
     get{ return recurringRule; }
     set{ this.recurringRule=value;}
   }
  }
}
