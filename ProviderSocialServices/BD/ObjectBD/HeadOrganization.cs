using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderSocialServices.ObjectBD
{
    public class HeadOrganization
    {
        public int Id_HeadOrganization { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string Photo { get; set; }
        public int Id_Organization { get; set; }
    }
}
