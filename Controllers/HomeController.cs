using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.ViewModels;
using Data;
using Services;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService productService;

        //private readonly ILogger<HomeController> _logger;
        private readonly MyShopDbContext _db;

        public HomeController(/*ILogger<HomeController> logger,*/ ProductService productService, MyShopDbContext db)
        {
            this.productService = productService;

            //_logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var res = await productService.GetAll();
            return View(res);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LearnMore(string id)
        {
            var res = productService.GetProductById(id);
            return PartialView("_ProductInfo", res);
        }
        public IActionResult Product()
        {
            return View("Product");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
