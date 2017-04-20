using Microsoft.AspNet.SignalR;
using SignalRTest.SignalR;
using System.Web.Mvc;

namespace SignalRTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SendMessage("Index Action Invoked");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        void SendMessage(string message)
        {
            GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients.sendMessage(message);
        }
    }
}