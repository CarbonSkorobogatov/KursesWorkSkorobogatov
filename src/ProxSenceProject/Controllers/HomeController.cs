using Microsoft.AspNetCore.Mvc;
using ProxSenceProject.Models.Interfaces;
using System.Linq;

namespace ProxSenceProject.Controllers
{
    public class HomeController : Controller
    {
        private INewsData _newsData;
        public int PageSize = 5;
        public HomeController(INewsData newsData)
        {
            _newsData = newsData;
        }
        
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult About(int page = 1)
            => View(_newsData.NewsData
                .OrderBy(a => a.NewsId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)); 
        public ViewResult AboutWork()
        {
            return View();
        }
        public ViewResult Contact()
        {
            return View();
        }
    }
}
