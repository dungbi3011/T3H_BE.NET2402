using Buoi15_BaiTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buoi15_BaiTap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //khoi tao model
            var model = new List<BookModels>();

            //dua du lieu vao model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sach so" + (i+1)
                }); 
            }

            //tra ve model
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}