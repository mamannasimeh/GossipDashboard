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

        public ActionResult CreateAllCategory()
        {
            string path = ControllerContext.HttpContext.Server.MapPath("~");
            BizarreController bizarre = new BizarreController(path);
            bizarre.CreateContentCategory();

            AmazingController amazing = new AmazingController(path);
            amazing.CreateContentCategory();

            CuteController cute = new CuteController(path);
            cute.CreateContentCategory();

            EntertainmentController entertainment = new EntertainmentController(path);
            entertainment.CreateContentCategory();

            FilmsController films = new FilmsController(path);
            films.CreateContentCategory();

            PlacesController places = new PlacesController(path);
            places.CreateContentCategory();

            QuizController quiz = new QuizController(path);
            quiz.CreateContentCategory();

            SexyController sexy = new SexyController(path);
            sexy.CreateContentCategory();

            return View("/Home/Index");
        }


        public ActionResult ShowImage(int id)
        {
            var imageData = repo.Select(id).Image;
            if (imageData == null)
                return null;
            return File(imageData, "image/jpg");
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase UploadFile)
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