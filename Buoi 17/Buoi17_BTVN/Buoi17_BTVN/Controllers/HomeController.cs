using Buoi17_BTVN.Models;
using Console_NetCore.CommonLibs;
using Console_NetCore.DTO;
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
            var model = new List<Models.SanPham>();

            return View(model);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DemoLoadAjaxView()
        {
            var model = new List<Console_NetCore.DTO.SanPham>();
            try
            {
                model = await new Console_NetCore.Services.ProductServices().GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return PartialView(model);
        }

        public async Task<JsonResult> SaveProduct(SanPhamUpdate requestData)
        {
            var model = new SanPhamInsertResponse();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.TenSanPham))
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "D? li?u không ???c tr?ng";
                    return Json(model);
                }

                var rs = await new Console_NetCore.Services.ProductServices().Product_Insert(requestData);


                model.ResponseCode = rs.ReturnCode;
                model.ResponseMessage = rs.ReturnMsg;
                return Json(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(model);
        }


        public async Task<JsonResult> Product_Delete(SanPhamXoa requestData)
        {
            var model = new SanPhamDeleteResponse();
            try
            {
                if (requestData == null || requestData.SanPhamID <= 0)
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Id s?n ph?m không h?p l?";
                    return Json(model);
                }

                var rs = await new Console_NetCore.Services.ProductServices().Product_Remove(requestData);

                if (rs.ReturnCode <= 0)
                {
                    model.ResponseCode = rs.ReturnCode;
                    model.ResponseMessage = rs.ReturnMsg;
                    return Json(model);
                }

                model.ResponseCode = 1;
                model.ResponseMessage = "Xóa s?n ph?m thành công!";
                return Json(model);
            }
            catch (Exception ex)
            {

                model.ResponseCode = -969;
                model.ResponseMessage = "H? th?ng ?ang b?n!";
                return Json(model);
            }
        }

        public async Task<JsonResult> Product_Buy(OrdersCreateRequestData requestData)
        {

            var model = new SanPhamDeleteResponse();
            try
            {
                if (requestData == null || requestData.Gia <= 0)
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Id s?n ph?m không h?p l?";
                    return Json(model);
                }

                var rs = await new Console_NetCore.Services.OrderServices().Order_Create(requestData);

                if (rs.ReturnCode <= 0)
                {
                    model.ResponseCode = rs.ReturnCode;
                    model.ResponseMessage = rs.ReturnMsg;
                    return Json(model);
                }

                model.ResponseCode = 1;
                model.ResponseMessage = "Mua s?n ph?m thành công!";
                return Json(model);
            }
            catch (Exception ex)
            {

                model.ResponseCode = -969;
                model.ResponseMessage = "H? th?ng ?ang b?n!";
                return Json(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
