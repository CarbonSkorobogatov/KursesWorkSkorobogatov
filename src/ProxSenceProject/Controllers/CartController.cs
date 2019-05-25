using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProxSenceProject.Models.Interfaces;
using ProxSenceProject.Models;
using ProxSenceProject.Models.CartData;
using ProxSenceProject.ProjectDataSet;

namespace ProxSenceProject.Controllers
{
    public class CartController : Controller
    {
        private IProjectData portfolioProjects;
        private Cart cart;
        public CartController(IProjectData portfProjects, Cart cartService)
        {
            portfolioProjects = portfProjects;
            cart = cartService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new ProjectCartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int projectId, string returnUrl)
        {
            Project project = portfolioProjects.ProjectData
                .FirstOrDefault(p => p.ProjectId == projectId);

            if (project != null)
            {
                cart.AddItem(project, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int projectId,
                string returnUrl)
        {
            Project project = portfolioProjects.ProjectData
               .FirstOrDefault(p => p.ProjectId == projectId);

            if (project != null)
            {
                cart.RemoveLine(project);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
