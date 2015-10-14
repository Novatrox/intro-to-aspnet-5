using AspNet5Demo.Common;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNet5Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGreetingService _greeting;

        public HomeController(IGreetingService greeting)
        {
            _greeting = greeting;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View((object)_greeting.GetGreeting());
        }
    }
}
