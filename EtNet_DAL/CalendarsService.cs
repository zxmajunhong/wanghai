using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Calendars]表的数据访问类
    /// </summary>
    public class CalendarsService
    {
        /// <summary>
        ///[Calendars]表添加的方法
        /// </summary>
        public static int addCalendars(Calendars calendars)
        {
            string sql = "insert into Calendars([Subject],[Location],[MasterId],[Description],[CalendarType],[StartTime],[EndTime],[IsAllDayEvent],[HasAttachment],[Category],[InstanceType],[Attendees],[AttendeeNames],[OtherAttendee],[UPAccount],[UPName],[UPTime],[RecurringRule]) values (@Subject,@Location,@MasterId,@Description,@CalendarType,@StartTime,@EndTime,@IsAllDayEvent,@HasAttachment,@Category,@InstanceType,@Attendees,@AttendeeNames,@OtherAttendee,@UPAccount,@UPName,@UPTime,@RecurringRule)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@Subject",calendars.Subject),
        new SqlParameter("@Location",calendars.Location),
        new SqlParameter("@MasterId",calendars.MasterId),
        new SqlParameter("@Description",calendars.Description),
        new SqlParameter("@CalendarType",calendars.CalendarType),
        new SqlParameter("@StartTime",calendars.StartTime),
        new SqlParameter("@EndTime",calendars.EndTime),
        new SqlParameter("@IsAllDayEvent",calendars.IsAllDayEvent),
        new SqlParameter("@HasAttachment",calendars.HasAttachment),
        new SqlParameter("@Category",calendars.Category),
        new SqlParameter("@InstanceType",calendars.InstanceType),
        new SqlParameter("@Attendees",calendars.Attendees),
        new SqlParameter("@AttendeeNames",calendars.AttendeeNames),
        new SqlParameter("@OtherAttendee",calendars.OtherAttendee),
        new SqlParameter("@UPAccount",calendars.UPAccount),
        new SqlParameter("@UPName",calendars.UPName),
        new SqlParameter("@UPTime",calendars.UPTime),
        new SqlParameter("@RecurringRule",calendars.RecurringRule)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Calendars]表修改的方法
        /// </summary>
        public static int updateCalendarsById(Calendars calendars)
        {

            string sql = "update Calendars set Subject=@Subject,Location=@Location,MasterId=@MasterId,Description=@Description,CalendarType=@CalendarType,StartTime=@StartTime,EndTime=@EndTime,IsAllDayEvent=@IsAllDayEvent,HasAttachment=@HasAttachment,Category=@Category,InstanceType=@InstanceType,Attendees=@Attendees,AttendeeNames=@AttendeeNames,OtherAttendee=@OtherAttendee,UPAccount=@UPAccount,UPName=@UPName,UPTime=@UPTime,RecurringRule=@RecurringRule where Id=@Id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@Id",calendars.Id),
        new SqlParameter("@Subject",calendars.Subject),
        new SqlParameter("@Location",calendars.Location),
        new SqlParameter("@MasterId",calendars.MasterId),
        new SqlParameter("@Description",calendars.Description),
        new SqlParameter("@CalendarType",calendars.CalendarType),
        new SqlParameter("@StartTime",calendars.StartTime),
        new SqlParameter("@EndTime",calendars.EndTime),
        new SqlParameter("@IsAllDayEvent",calendars.IsAllDayEvent),
        new SqlParameter("@HasAttachment",calendars.HasAttachment),
        new SqlParameter("@Category",calendars.Category),
        new SqlParameter("@InstanceType",calendars.InstanceType),
        new SqlParameter("@Attendees",calendars.Attendees),
        new SqlParameter("@AttendeeNames",calendars.AttendeeNames),
        new SqlParameter("@OtherAttendee",calendars.OtherAttendee),
        new SqlParameter("@UPAccount",calendars.UPAccount),
        new SqlParameter("@UPName",calendars.UPName),
        new SqlParameter("@UPTime",calendars.UPTime),
        new SqlParameter("@RecurringRule",calendars.RecurringRule)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Calendars]表删除的方法
        /// </summary>
        public static int deleteCalendarsById(int Id)
        {

            string sql = "delete from Calendars where Id=@Id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@Id",Id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Calendars]表查询实体的方法
        /// </summary>
        public static Calendars getCalendarsById(int Id)
        {
            Calendars calendars = null;

            string sql = "select * from Calendars where Id=@Id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@Id",Id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                calendars = new Calendars();
                foreach (DataRow dr in dt.Rows)
                {
                    calendars.Id = Convert.ToInt32(dr["Id"]);
                    calendars.Subject = Convert.ToString(dr["Subject"]);
                    calendars.Location = Convert.ToString(dr["Location"]);
                    calendars.MasterId = Convert.ToInt32(dr["MasterId"]);
                    calendars.Description = Convert.ToString(dr["Description"]);
                    calendars.CalendarType = Convert.ToInt32(dr["CalendarType"]);
                    calendars.StartTime = Convert.ToDateTime(dr["StartTime"]);
                    calendars.EndTime = Convert.ToDateTime(dr["EndTime"]);
                    calendars.IsAllDayEvent = Convert.ToInt32(dr["IsAllDayEvent"]);
                    calendars.HasAttachment = Convert.ToInt32(dr["HasAttachment"]);
                    calendars.Category = Convert.ToString(dr["Category"]);
                    calendars.InstanceType = Convert.ToInt32(dr["InstanceType"]);
                    calendars.Attendees = Convert.ToString(dr["Attendees"]);
                    calendars.AttendeeNames = Convert.ToString(dr["AttendeeNames"]);
                    calendars.OtherAttendee = Convert.ToString(dr["OtherAttendee"]);
                    calendars.UPAccount = Convert.ToString(dr["UPAccount"]);
                    calendars.UPName = Convert.ToString(dr["UPName"]);
                    calendars.UPTime = Convert.ToDateTime(dr["UPTime"]);
                    calendars.RecurringRule = Convert.ToString(dr["RecurringRule"]);
                }
            }

            return calendars;
        }

        /// <summary>
        ///[Calendars]表查询所有的方法
        /// </summary>
        public static IList<Calendars> getCalendarsAll()
        {
            string sql = "select * from Calendars";
            return getCalendarssBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Calendars> getCalendarssBySql(string sql)
        {
            IList<Calendars> list = new List<Calendars>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Calendars calendars = new Calendars();
                    calendars.Id = Convert.ToInt32(dr["Id"]);
                    calendars.Subject = Convert.ToString(dr["Subject"]);
                    calendars.Location = Convert.ToString(dr["Location"]);
                    calendars.MasterId = Convert.ToInt32(dr["MasterId"]);
                    calendars.Description = Convert.ToString(dr["Description"]);
                    calendars.CalendarType = Convert.ToInt32(dr["CalendarType"]);
                    calendars.StartTime = Convert.ToDateTime(dr["StartTime"]);
                    calendars.EndTime = Convert.ToDateTime(dr["EndTime"]);
                    calendars.IsAllDayEvent = Convert.ToInt32(dr["IsAllDayEvent"]);
                    calendars.HasAttachment = Convert.ToInt32(dr["HasAttachment"]);
                    calendars.Category = Convert.ToString(dr["Category"]);
                    calendars.InstanceType = Convert.ToInt32(dr["InstanceType"]);
                    calendars.Attendees = Convert.ToString(dr["Attendees"]);
                    calendars.AttendeeNames = Convert.ToString(dr["AttendeeNames"]);
                    calendars.OtherAttendee = Convert.ToString(dr["OtherAttendee"]);
                    calendars.UPAccount = Convert.ToString(dr["UPAccount"]);
                    calendars.UPName = Convert.ToString(dr["UPName"]);
                    calendars.UPTime = Convert.ToDateTime(dr["UPTime"]);
                    calendars.RecurringRule = Convert.ToString(dr["RecurringRule"]);
                    list.Add(calendars);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Calendars getCalendarsBySql(string sql)
        {
            Calendars calendars = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                calendars = new Calendars();
                foreach (DataRow dr in dt.Rows)
                {
                    calendars.Id = Convert.ToInt32(dr["Id"]);
                    calendars.Subject = Convert.ToString(dr["Subject"]);
                    calendars.Location = Convert.ToString(dr["Location"]);
                    calendars.MasterId = Convert.ToInt32(dr["MasterId"]);
                    calendars.Description = Convert.ToString(dr["Description"]);
                    calendars.CalendarType = Convert.ToInt32(dr["CalendarType"]);
                    calendars.StartTime = Convert.ToDateTime(dr["StartTime"]);
                    calendars.EndTime = Convert.ToDateTime(dr["EndTime"]);
                    calendars.IsAllDayEvent = Convert.ToInt32(dr["IsAllDayEvent"]);
                    calendars.HasAttachment = Convert.ToInt32(dr["HasAttachment"]);
                    calendars.Category = Convert.ToString(dr["Category"]);
                    calendars.InstanceType = Convert.ToInt32(dr["InstanceType"]);
                    calendars.Attendees = Convert.ToString(dr["Attendees"]);
                    calendars.AttendeeNames = Convert.ToString(dr["AttendeeNames"]);
                    calendars.OtherAttendee = Convert.ToString(dr["OtherAttendee"]);
                    calendars.UPAccount = Convert.ToString(dr["UPAccount"]);
                    calendars.UPName = Convert.ToString(dr["UPName"]);
                    calendars.UPTime = Convert.ToDateTime(dr["UPTime"]);
                    calendars.RecurringRule = Convert.ToString(dr["RecurringRule"]);
                }
            }
            return calendars;
        }

        public static int Clear()
        {
            string sql = "truncate table Calendars";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}
