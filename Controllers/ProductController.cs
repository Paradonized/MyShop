using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductController.Controllers
{
    public class ProductController : Controller
    {
        private MyShopDbContext Context { get; }

        public ProductViewModel ProductViewModel { get; } = new ProductViewModel();
        private IEnumerable<SelectListItem> GetCategories()
        {
            return servicePr.GetCategories();
        }
        public ProductService servicePr { get; set; }
        public ProductController(ProductService service)
        {
            servicePr = service;
            ProductViewModel.Categories = GetCategories();
        }

        public async Task<IActionResult> Index()
        {
            return View(await servicePr.GetAll());
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View("AddProduct", ProductViewModel);
        }
        [HttpGet]
        public IActionResult EditProduct()
        {
            return View("EditProduct", ProductViewModel);
        }
        [HttpGet]
        public IActionResult DeleteProductById(string Id)
        {
            if (Id != null)
            {
                var product = servicePr.GetProductById(Id);
                return View("DeleteProduct", product);
            }
            return View();
        }
        public IActionResult GetProductById(string id)
        {
            if (id != null)
            {
                var product = servicePr.GetProductById(id);
                return View("Index", product);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                servicePr.Add(product);

                return Redirect("~/Home/Index");
            }
            return Redirect("~/Home/Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            if (ModelState.IsValid)
            {
                servicePr.Delete(Id);
                return Redirect("~/Home/Index");
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                servicePr.Edit(product);

                return Redirect("~/Home/Index");
            }
            return Redirect("~/Home/Index");
        }
    }
}