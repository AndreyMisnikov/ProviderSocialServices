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
    
    public partial class Organization_AvailableService
    {
        public int Id { get; set; }
        public int Id_Organization { get; set; }
        public int Id_AvailableService { get; set; }
    
        public virtual AvailableService AvailableService { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
