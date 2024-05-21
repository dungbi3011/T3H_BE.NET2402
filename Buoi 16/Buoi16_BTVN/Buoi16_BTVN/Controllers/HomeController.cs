using Buoi16_BTVN.CommonLib;
using Buoi16_BTVN.IServices;
using Buoi16_BTVN.Models;
using Buoi16_BTVN.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buoi16_BTVN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly StudentServices _studentServices; // Inject StudentServices
        public HomeController(ILogger<HomeController> logger, StudentServices studentServices)
        {
            _logger = logger;
            _studentServices = studentServices;
        }

        public async Task<IActionResult> Index()
        {
            //Khoi tao model
            var model = new List<Models.Student>();

            //Dua du lieu vao model
            var studentList = await _studentServices.GetStudent();
            foreach (var student in studentList)
            {
                model.Add(student);
            }

            //Tra ve model
            return View(model);
        }

        public IActionResult Them()
        {
            var studentList = _studentServices.GetStudent();
            if (ValidationData.KiemTraInputChu(@Request["ten"]) && ValidationData.KiemTraInputNgaySinh(Request["ngaysinh"]) && ValidationData.KiemTraInputChu(Request["diachi"]))
            {
                Student student = new Student(@Request["ten"], Convert.ToDateTime(Request["ngaysinh"]), Request["diachi"]);
                _studentServices.Student_Insert(student);
            }
            return View();
        }
        public IActionResult Xoa()
        {
            if (ValidationData.KiemTraInputChu(@Request["ten"]))
            {
                Student student = _studentServices.Student_Find(@Request["ten"]);
                _studentServices.Student_Delete(student);
            } else
            {
                Console.WriteLine("Du lieu dau vao khong hop le.");
            }
            return View();
        }
        public IActionResult Sua()
        {
            if (ValidationData.KiemTraInputSo(@Request["vitri"]) && ValidationData.KiemTraInputChu(@Request["ten"]) && ValidationData.KiemTraInputNgaySinh(Request["ngaysinh"]) && ValidationData.KiemTraInputChu(Request["diachi"]))
            {
                Student student = new Student(@Request["ten"], Convert.ToDateTime(Request["ngaysinh"]), Request["diachi"]);
                _studentServices.Student_Update(@Request["vitri"], student);
            }
            else
            {
                Console.WriteLine("Du lieu dau vao khong hop le.");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
