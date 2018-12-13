using GossipDashboard.Models;
using GossipDashboard.Repository;
using GossipDashboard.ViewModel;
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



    /// <summary>
    /// در هر گروه، بالاترین مقادیر را یکی یکی خارج می کند و لیست جدید می سازد
    /// </summary>
    /// <param name="posts"></param>
    /// <returns></returns>
    //
    // گروه  A    B    C
    //       31   52    48
    //       29   37    49
    //       22   30    39
    // بعد از مرتب کردن
    // گروه  ListAll
    //          52
    //          49
    //          39
    //          48
    //          37
    //          30
    //          31
    //          29
    //          22
    public static List<VM_Post> SortGroupsList(List<VM_Post> posts)
    {
        PostRepository repo = new PostRepository();
        ManagementPostRepository repoManagementPost = new ManagementPostRepository();
        PubBaseRepository repoPubBase = new PubBaseRepository();


        //ایجاد تگ آرتیکل به ازای هر پست
        List<VM_Post> listAll = new List<VM_Post>();
        List<VM_Post> listPostMaxGroup = new List<VM_Post>();
        int previousGroupPostMaxID = 100000000;
        VM_Post previousGroupPost = null, maxGroup = null, postMaxGroup = null;
        int i = 0;
        var postGroup = posts.Select(p => p.SourceSiteName).Distinct().ToList();
        do
        {
            listPostMaxGroup = new List<VM_Post>();

            //پس از گروه بندی بر اساس نام سایت
            foreach (var item in postGroup)
            {
                //کمترین مقداری را که برای این گروه سایت به لیست اد کرده پیدا می کند
                previousGroupPost = listAll.OrderBy(p => p.PostID).FirstOrDefault(p => p.SourceSiteName == item);
                previousGroupPostMaxID = previousGroupPost == null ? 100000000 : previousGroupPost.PostID;

                // اکنون بالاترین مقدار را برای گروه سایت به دست می آورد 
                //با شرط اینکه از آخرین مقدار وارد شده کوچکتر باشد
                maxGroup = posts.OrderByDescending(p => p.PostID).FirstOrDefault(p => p.SourceSiteName == item && p.PostID < previousGroupPostMaxID);
                if (maxGroup != null)
                {
                    postMaxGroup = posts.First(p => p.PostID == maxGroup.PostID);
                    if (postMaxGroup != null)
                        listPostMaxGroup.Add(postMaxGroup);
                }

                i++;
            }
            var listPostMaxGroupOrder = listPostMaxGroup.OrderByDescending(p => p.PostID);

            listAll.AddRange(listPostMaxGroupOrder);
        } while (i < posts.Count);

        //اضافه کردن پست استاتوس
        //با هر 4 پابلیش استاتوس قبلی حذف می شود و استاتوس جدید اضافه می گردد
        var status = repo.SelectPostUser().Where(p => p.Status != null && (p.PublishCount == null ? 0 : p.PublishCount) <= 4).OrderBy(p => p.PostID).FirstOrDefault();
        if (status != null)
        {
            listAll.Insert(15, status);
        }

        //يک پست لينک اضافه مي کنيم
        if (listAll.Count >= 50)
        {
            var allFormatIDs = repoPubBase.SelectByParentName("PostFormat").Select(p => p.PubBaseID).ToList();

            var link = listAll[50];
            if ((link.BackgroundColor == null ? "" : link.BackgroundColor.Trim()) == "")
                link.BackgroundColor = "#cf3d2e";
            link.PostFormat.RemoveAt(0);
            link.PostFormat.Add(new VM_PubBase()
            {
                PubBaseID = 26,
                Active = true,
                NameEn = "link",
                ClassName = "format-link",
                NameFa = "پیوند"
            });

            listAll.Insert(10, link);
        }

        return listAll;
    }
}
