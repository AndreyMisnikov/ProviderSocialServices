using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProviderSocialServices.Models
{
    public class Procedure
    {
        public string NameProcedure { get; set; }
        public List<object> Params { get; set; }
        public string Answer { get; set; }
    }
}