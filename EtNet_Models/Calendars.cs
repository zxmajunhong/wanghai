using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Calendars
  {
   //Calendars���Ĭ�Ϲ��췽��
   public Calendars ()
   {

   }
   private int id;
   /// <summary>
   ///[Calendars]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string subject;
   /// <summary>
   ///[Calendars]�� [Subject]��
   /// </summary>
   public string Subject
   {
     get{ return subject; }
     set{ this.subject=value;}
   }
   private string location;
   /// <summary>
   ///[Calendars]�� [Location]��
   /// </summary>
   public string Location
   {
     get{ return location; }
     set{ this.location=value;}
   }
   private int masterId;
   /// <summary>
   ///[Calendars]�� [MasterId]��
   /// </summary>
   public int MasterId
   {
     get{ return masterId; }
     set{ this.masterId=value;}
   }
   private string description;
   /// <summary>
   ///[Calendars]�� [Description]��
   /// </summary>
   public string Description
   {
     get{ return description; }
     set{ this.description=value;}
   }
   private int calendarType;
   /// <summary>
   ///[Calendars]�� [CalendarType]��
   /// </summary>
   public int CalendarType
   {
     get{ return calendarType; }
     set{ this.calendarType=value;}
   }
   private DateTime startTime;
   /// <summary>
   ///[Calendars]�� [StartTime]��
   /// </summary>
   public DateTime StartTime
   {
     get{ return startTime; }
     set{ this.startTime=value;}
   }
   private DateTime endTime;
   /// <summary>
   ///[Calendars]�� [EndTime]��
   /// </summary>
   public DateTime EndTime
   {
     get{ return endTime; }
     set{ this.endTime=value;}
   }
   private int isAllDayEvent;
   /// <summary>
   ///[Calendars]�� [IsAllDayEvent]��
   /// </summary>
   public int IsAllDayEvent
   {
     get{ return isAllDayEvent; }
     set{ this.isAllDayEvent=value;}
   }
   private int hasAttachment;
   /// <summary>
   ///[Calendars]�� [HasAttachment]��
   /// </summary>
   public int HasAttachment
   {
     get{ return hasAttachment; }
     set{ this.hasAttachment=value;}
   }
   private string category;
   /// <summary>
   ///[Calendars]�� [Category]��
   /// </summary>
   public string Category
   {
     get{ return category; }
     set{ this.category=value;}
   }
   private int instanceType;
   /// <summary>
   ///[Calendars]�� [InstanceType]��
   /// </summary>
   public int InstanceType
   {
     get{ return instanceType; }
     set{ this.instanceType=value;}
   }
   private string attendees;
   /// <summary>
   ///[Calendars]�� [Attendees]��
   /// </summary>
   public string Attendees
   {
     get{ return attendees; }
     set{ this.attendees=value;}
   }
   private string attendeeNames;
   /// <summary>
   ///[Calendars]�� [AttendeeNames]��
   /// </summary>
   public string AttendeeNames
   {
     get{ return attendeeNames; }
     set{ this.attendeeNames=value;}
   }
   private string otherAttendee;
   /// <summary>
   ///[Calendars]�� [OtherAttendee]��
   /// </summary>
   public string OtherAttendee
   {
     get{ return otherAttendee; }
     set{ this.otherAttendee=value;}
   }
   private string uPAccount;
   /// <summary>
   ///[Calendars]�� [UPAccount]��
   /// </summary>
   public string UPAccount
   {
     get{ return uPAccount; }
     set{ this.uPAccount=value;}
   }
   private string uPName;
   /// <summary>
   ///[Calendars]�� [UPName]��
   /// </summary>
   public string UPName
   {
     get{ return uPName; }
     set{ this.uPName=value;}
   }
   private DateTime uPTime;
   /// <summary>
   ///[Calendars]�� [UPTime]��
   /// </summary>
   public DateTime UPTime
   {
     get{ return uPTime; }
     set{ this.uPTime=value;}
   }
   private string recurringRule;
   /// <summary>
   ///[Calendars]�� [RecurringRule]��
   /// </summary>
   public string RecurringRule
   {
     get{ return recurringRule; }
     set{ this.recurringRule=value;}
   }
  }
}
