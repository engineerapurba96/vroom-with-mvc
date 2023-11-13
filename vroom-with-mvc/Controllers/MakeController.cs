using Microsoft.AspNetCore.Mvc;
using vroom_with_mvc.Models;

namespace vroom_with_mvc.Controllers
{
    public class MakeController : Controller
    {
        public IActionResult Bikes()
        {
            return View();
        }
    }
}
