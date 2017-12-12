using System.Web.Mvc;

namespace TeduShop.Web.Controllers
{
    public class HomeHelpController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Help");
        }
    }
}