using System.Web.Mvc;

namespace MarketBattleNet.Interface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}