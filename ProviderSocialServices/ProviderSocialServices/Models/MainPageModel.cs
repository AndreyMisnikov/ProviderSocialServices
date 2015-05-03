using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProviderSocialServices.Models
{
    public class MainPageModel
    {
        public class Organization
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Activity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class AvailableService
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class CategoryOfClient
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class GeographyOfActivity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class OrganizationLegalForm
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IList<Organization> Organizations { get; set; }
        public IList<Activity> Activities { get; set; }
        public IList<AvailableService> AvailableServices { get; set; }
        public IList<CategoryOfClient> CategoryOfClients { get; set; }
        public IList<GeographyOfActivity> GeographyOfActivities { get; set; }
        public IList<OrganizationLegalForm> OrganizationLegalForms { get; set; }

    }
}