using System;

namespace ProviderSocialServices.ObjectBD
{
    public class Organization
    {
        public int Id_Organization { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime DateReg {get;set;}
        public string Mission { get; set; }
        public string MaterialTechnicalBase { get; set; }
        public string SettlementAccount { get; set; }
        public int Id_OrganizationLegalForm { get; set; }
        public string InformationMaterialTechnicalBase { get; set; }
    }
}
