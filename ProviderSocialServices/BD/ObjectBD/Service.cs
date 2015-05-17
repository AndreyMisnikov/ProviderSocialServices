namespace ProviderSocialServices.ObjectBD
{
    public class Service
    {
        public int Id_Service { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Conditions { get; set; }
        public int Id_Organization { get; set; }
    }
}
