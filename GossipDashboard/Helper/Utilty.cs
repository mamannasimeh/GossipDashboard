using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


public static class Utilty
{
    public static string ToPersianDateTime(this DateTime? dt)
    {
        if (dt == null)
            return "";

        DateTime dt1 = (DateTime)dt;
        PersianCalendar pc = new PersianCalendar();
        int year = pc.GetYear(dt1);
        int month = pc.GetMonth(dt1);
        int day = pc.GetDayOfMonth(dt1);
        int hour = pc.GetHour(dt1);
        int minute = pc.GetMinute(dt1);


        string strDay = day.ToString(), strMonth = month.ToString(), strYear = year.ToString();
        if (strDay.Length == 1)
            strDay = "0" + strDay;
        if (strMonth.Length == 1)
            strMonth = "0" + strMonth;

        return strYear + "/" + strMonth + "/" + strDay + "  " + hour + ":" + minute;
    }
}
