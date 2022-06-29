using Microsoft.AspNetCore.Mvc;
using opus1st.Models;
using opus1st.Services;

namespace opus1st.Controllers
{
    public class OrderController : Controller
    {
        
        private readonly IOrder Order;

        public OrderController(IOrder Order)
        {
            
            this.Order = Order;
        }

        public IActionResult Index()
        {
            return View(Order.Get());
        }
        public IActionResult Add()
        {
            ViewBag.product = Order.GetProduct();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Order p)
        {
            if (Order.Insert(p))
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.product = Order.GetProduct();
            return View(Order.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(Order p)
        {
            if (Order.Update(p))
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Delete(int id)
        {
            if (Order.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View(id);
        }
    }
}
