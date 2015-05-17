using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderSocialServices.ObjectBD;

namespace ProviderSocialServices.Models
{
    public class MainPageModel
    {
        public IList<Organization> Organizations { get; set; }
        public IList<Activity> Activities { get; set; }
        public IList<AvailableService> AvailableServices { get; set; }
        public IList<CategoryOfClient> CategoryOfClients { get; set; }
        public IList<GeographyOfActivity> GeographyOfActivities { get; set; }
        public IList<OrganizationLegalForm> OrganizationLegalForms { get; set; }

    }
}