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
    
    public partial class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int InvestorId { get; set; }
        public int PresenterId { get; set; }
        public System.DateTime ReservationTimeStart { get; set; }
        public System.DateTime ReservationTimeEnd { get; set; }
    
        public virtual HotelRoom HotelRoom { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
    }
}
