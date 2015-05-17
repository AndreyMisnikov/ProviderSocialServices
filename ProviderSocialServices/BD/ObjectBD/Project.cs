using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderSocialServices.ObjectBD
{
    public class Project
    {
        public int Id_Project { get; set; }
        public string Name { get; set; }
        public int Id_Organization { get; set; }
    }
}
