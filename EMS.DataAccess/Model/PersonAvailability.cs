//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonAvailability
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SectorId { get; set; }
        public System.DateTime AvailabilityTimeStart { get; set; }
        public System.DateTime AvailabilityTimeEnd { get; set; }
    
        public virtual LUT_Sector LUT_Sector { get; set; }
        public virtual Person Person { get; set; }
    }
}
