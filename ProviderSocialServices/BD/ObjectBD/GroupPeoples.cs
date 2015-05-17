using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderSocialServices.ObjectBD
{
    public class GroupPeoples
    {
        public int Id_GroupPeoples { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public int Id_Organization { get; set; }
    }
}
