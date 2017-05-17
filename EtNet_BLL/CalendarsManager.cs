using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class CalendarsManager
  {
     public static int addCalendars(Calendars calendars)
     {
       return CalendarsService.addCalendars(calendars);
     }

     public static int updateCalendars(Calendars calendars)
     {
      return CalendarsService.updateCalendarsById(calendars);
     }

     public static int deleteCalendars(int Id)
     {
       return CalendarsService.deleteCalendarsById(Id);
     }

     public static Calendars getCalendarsById(int Id)
     {
       return CalendarsService.getCalendarsById(Id);
     }

     public static IList<Calendars> getCalendarsAll()
     {
       return CalendarsService.getCalendarsAll();
     }

     public static int Clear()
     {
         return CalendarsService.Clear();
     }
  }
}
