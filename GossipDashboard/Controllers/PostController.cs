using GossipDashboard.Models;
using GossipDashboard.Repository;
using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GossipDashboard.Controllers
{
    public class PostController : Controller
    {
        UserRepository repo = new UserRepository();
        public ActionResult Index()
        {
            return View(new VM_Post());
        }

        public ActionResult ShowImage(int id)
        {
            var imageData = repo.Select(id).Image;
            return File(imageData, "image/jpg");
        }


        [Authorize]
        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase UploadFile, int RequestIDFormAtt, string type)
        {
            if (UploadFile != null)
            {

                byte[] fileContect = new byte[UploadFile.InputStream.Length];
                UploadFile.InputStream.Read(fileContect, 0, fileContect.Length);

                var user = new User
                {
                    FirstName = "ارسلان",
                    AboutUser = "يکي از نويسنده هاي نامدار ايران",
                    Image = fileContect,
                    LastName = "آرماني",
                    ModifyDate = DateTime.Now,
                    ModifyUserID = 1,
                    Password = "123",
                    Salt = "123",
                    UserName = "admin",
                };

                repo.Add(user);
                return Json("OK");
            }


            return Json("Fails");
        }
    }
}