using Microsoft.AspNetCore.Mvc;
using SignalR_Cshar_DB.Models;
using SignalR_Cshar_DB.Service.Interface;
using System.Diagnostics;
using System.Text.Json;

namespace SignalR_Cshar_DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _sv;

        public HomeController(IProductService productService)
        {
            _sv = productService;
        }

        public async Task<IActionResult> Index()
        {
            await Task.Delay(1000);

            var res = await _sv.GetAllProductAsync();

            ViewBag.product = res;

            return View(res);
        }

        //public IActionResult Index()
        //{
        //    //var res = _sv.GetAllProductAsync();
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        var res = await _sv.GetAllProductAsync();

        //        return View(res); //JsonSerializer.Serialize(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GuardarPordocut(MProducts product)
        {
            try
            {
                var _res = await _sv.PostProductAsync(product);

                return RedirectToAction("Privacy");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}