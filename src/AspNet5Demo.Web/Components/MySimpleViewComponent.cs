using Microsoft.AspNet.Mvc;

namespace AspNet5Demo.Web.Components
{
    public class MySimpleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string message)
        {
            return View((object) message);
        }

    }
}
