using Buoi17_BTVN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buoi17_BTVN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index(int? id)
        {
            var model = new List<BookModel>();

            return View(model);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Them()
        {
            var model = new List<BookModel>();
                
            //dua du lieu vao model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModel
                {
                    BookID = i + 1,
                    BookName = "Sach so " + (i + 1)
                });
            }
            return PartialView(model);
        }

        public ActionResult DemoLoadAjaxView()
        {
            var model = new List<BookModel>();

            //dua du lieu vao model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModel
                {
                    BookID = i + 1,
                    BookName = "Sach so " + (i + 1)
                });
            }
            return PartialView(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
