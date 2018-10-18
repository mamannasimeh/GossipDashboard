using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


public static class Utilty
{
    public static DateTime ToPersianDateTime(this DateTime? dt)
    {
        PersianCalendar pc = new PersianCalendar();
        if (dt == null)
            return pc.ToDateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0, 0);

        int year = pc.GetYear((DateTime)dt);
        int month = pc.GetMonth((DateTime)dt);
        int day = pc.GetDayOfMonth((DateTime)dt);
        int hour = pc.GetHour((DateTime)dt);
        int min = pc.GetMinute((DateTime)dt);

        return pc.ToDateTime(year, month, day, hour, min, 0, 0);
    }
}
