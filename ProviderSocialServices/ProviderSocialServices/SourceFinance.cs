//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProviderSocialServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class SourceFinance
    {
        public SourceFinance()
        {
            this.Organization_SourceFinance = new HashSet<Organization_SourceFinance>();
        }
    
        public int Id_SourceFinance { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Organization_SourceFinance> Organization_SourceFinance { get; set; }
    }
}
