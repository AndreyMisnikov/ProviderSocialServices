using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderSocialServices.ObjectBD
{
    public class Contact
    {
        public int Id_Contact { get; set; }
        public string TypeContact { get; set; }
        public string ValueContact { get; set; }
        public int Id_Organization { get; set; }
    }
}
