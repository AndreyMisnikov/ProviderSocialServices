using System;
using System.Collections.Generic;
using System.Linq;
using ProviderSocialServices.Models;
using System.Web.Mvc;
using ProviderSocialServices.ObjectBD;

namespace ProviderSocialServices.Controllers
{
    public class HomeController : Controller
    {
        private WorkWithBD bd = new WorkWithBD();

        public ActionResult Index()
        {
            MainPageModel main = new MainPageModel();
            bd.OpenConnection();
            main.Organizations = bd.GetOrganizations();
            bd.CloseConnection();
            return View(main);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StoredProcedures(Procedure pr)
        {
            bd.OpenConnection();
            try
            {
                switch (pr.NameProcedure.Trim())
                {
                    case ("Количество фактических адресов"):
                        pr.Answer = bd._CountActrualAddress(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количесвто юридических адресов"):
                        pr.Answer = bd._CountActrualAddress(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количество emails"):
                        pr.Answer = bd._CountEmail(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количество проектов"):
                        pr.Answer = bd._CountProject(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количество услуг"):
                        pr.Answer = bd._CountService(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количество сайтов"):
                        pr.Answer = bd._CountSite(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количество дней существования организации"):
                        pr.Answer = bd._LifeTimeOfTheOrganization(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Количество телефонов"):
                        pr.Answer = bd._CountTelephone(Convert.ToInt32(pr.Params[0])).ToString();
                        break;
                    case ("Максимальное значение"):
                        pr.Answer = bd.MaxValue().ToString();
                        break;
                    case ("Минимальное значение"):
                        pr.Answer = bd.MinValue().ToString();
                        break;

                }
            }
            catch (Exception ex)
            {
                pr.Answer = ex.Message;
            }
            bd.CloseConnection();
            return View(pr);
        }

    }
}