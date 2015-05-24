using System.Web.Mvc;
using ProviderSocialServices.Models;

namespace ProviderSocialServices.Controllers
{
    public class OrganizationController : Controller
    {
        WorkWithBD bd = new WorkWithBD();
        // GET: Organization
        public ActionResult Information(int id)
        {
            bd.OpenConnection();
            InformationAboutOrganization infOrg = new InformationAboutOrganization();
            infOrg.Organization = bd.GetOrganizationById(id);
            infOrg.HeadOrganization = bd.GetHeadOrganization(id);
            infOrg.Activities = bd.GetActivitiesNamesToOrganization(id);
            infOrg.AvailableServices = bd.GetAvailableServicesNamesToOrganization(id);
            infOrg.CategoryOfClients = bd.GetCategoriesOfClientNamesToOrganization(id);
            infOrg.Contacts = bd.GetContacts(id);
            infOrg.GeographyOfActivities = bd.GetGeographyOfActivitiesNamesToOrganization(id);
            infOrg.GroupsPeople = bd.GetGroupsPeoplesByIdOrganization(id);
            infOrg.OrganizationLegalForm = bd.GetOrganizationLegalFormOrganizationById(id);
            infOrg.Projects = bd.GetProjectsByIdOrganization(id);
            infOrg.Services = bd.GetServicesByIdOrganization(id);
            infOrg.SourceFinances = bd.GetSourcesFinanceNamesToOrganization(id);
            bd.CloseConnection();
            return View(infOrg);
        }

        [HttpPost]
        public ActionResult Add(InformationAboutOrganization inf)
        {
           return View();
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}