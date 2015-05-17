using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderSocialServices.ObjectBD
{
    public class Organization_SourceFinance
    {
        public int Id_Organization { get; set; }
        public int Id_SourceFinance { get; set; }
        public int Id { get; set; }
        public string SettlementAccount { get; set; }
    }
}
