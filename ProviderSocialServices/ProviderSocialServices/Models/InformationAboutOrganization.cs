using System.Collections.Generic;
using ProviderSocialServices.ObjectBD;

namespace ProviderSocialServices.Models
{
    public class InformationAboutOrganization
    {
        public Organization Organization { get; set; }
        public string OrganizationLegalForm { get; set; }
        public IList<string> Activities { get; set; }
        public IList<string> AvailableServices { get; set; }
        public IList<string> CategoryOfClients { get; set; }
        public IList<Contact> Contacts { get; set; }
        public IList<string> GeographyOfActivities { get; set; }
        public IList<GroupPeoples> GroupsPeople { get; set; }
        public HeadOrganization HeadOrganization { get; set; }
        public IList<string> Projects { get; set; }
        public IList<Service> Services { get; set; }
        public IList<string> SourceFinances { get; set; } 

    }
}