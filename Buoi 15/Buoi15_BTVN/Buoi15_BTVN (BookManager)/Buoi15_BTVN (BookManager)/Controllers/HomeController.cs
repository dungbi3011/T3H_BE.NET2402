using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buoi15_BTVN__BookManager_.Controllers
{
    public class HomeController : Controller
    {
        int i = 1;
        public ActionResult Index()
        {
            //Khoi tao model
            var model = new List<Models.Book>();

            //Dua du lieu vao model
            model.Add(new Models.Book
            {
                BookID = i,
                BookName = Convert.ToString(Session["AddBook"]),
            });
            
            //Tra ve model
            return View(model);
        }

        public ActionResult AddNew()
        {
            ViewBag.Message = "Điền tên sách cần add vào đây: ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Thông tin liên lạc: ";

            return View();
        }
    }
}