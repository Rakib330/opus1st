using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using opus1st.Models;
using opus1st.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace opus1st.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct ProductService;

        public HomeController(ILogger<HomeController> logger, IProduct ProductService)
        {
            _logger = logger;
            this.ProductService = ProductService;
        }

        public IActionResult Index()
        {
            return View(ProductService.Get());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product p)
        {
            if (ProductService.Insert(p))
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Edit(int id)
        {
            return View(ProductService.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ProductService.Update(p))
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Delete(int id)
        {
            if (ProductService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View(id);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
