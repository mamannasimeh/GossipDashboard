using GossipDashboard.ViewModel;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GossipDashboard.Controllers
{
    public class DashboardController : Controller
    {

        Repository.ManagementPostRepository repo = new Repository.ManagementPostRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Pages()
        {
            return View();
        }


        public ActionResult Posts()
        {
            var repo = new Repository.PubBaseRepository();
            ViewData["PostCategory"] = repo.SelectByParentName("PostCategory");
            ViewData["PostFormat"] = repo.SelectByParentName("PostFormat");
            ViewData["PostCol"] = repo.SelectByParentName("PostCol");

            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult ReadPost([DataSourceRequest]DataSourceRequest request)
        {
            var res = repo.ReadPost().ToList();
            return Json(res.ToDataSourceResult(request));
        }

        public JsonResult CreatePost(VM_PostManage vm)
        {
            var res = repo.Add(vm);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePost(int id)
        {
            return null;
        }

        public ActionResult DestroyPost(int id)
        {
            return null; ;
        }
    }
}