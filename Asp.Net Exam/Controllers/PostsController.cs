using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Exam.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
