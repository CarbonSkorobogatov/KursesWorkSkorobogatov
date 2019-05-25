using Microsoft.AspNetCore.Mvc;
using ProxSenceProject.Models;
using System.Linq;
using ProxSenceProject.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ProxSenceProject.Controllers
{
    public class OrderController : Controller
    {
        private IOrderProcesser orderProcesser;
        private Cart cart;
        public OrderController(IOrderProcesser orderprocesser, Cart cartService)
        {
            orderProcesser = orderprocesser;
            cart = cartService;
        }
        [Authorize]
        public ViewResult PassedData() =>
            View(orderProcesser.Orders.Where(a => !a.Passed));
        [HttpPost]
        [Authorize]
        public IActionResult PassedProject(int orderId)
        {
            Order order = orderProcesser.Orders
                .FirstOrDefault(a => a.OrderId == orderId);
            if(order != null)
            {
                order.Passed = true;
                orderProcesser.SaveOrder(order);
            }
            return RedirectToAction(nameof(PassedData));
        }
        public ViewResult Checkout()
                => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                orderProcesser.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
