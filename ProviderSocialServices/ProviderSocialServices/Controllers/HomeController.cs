using BD;
using ProviderSocialServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProviderSocialServices.Controllers
{
    public class HomeController : Controller
    {
        WorkWithBD bd = new WorkWithBD();
        public ActionResult Index()
        {
            MainPageModel main = new MainPageModel();
            bd.OpenConnection();
            main.Organizations = bd.GetOrganizations();
            bd.CloseConnection();
            return View(main);
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
    }
}