﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EventManagementSystemEntities : DbContext
    {
        public EventManagementSystemEntities()
            : base("name=EventManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelRoom> HotelRooms { get; set; }
        public virtual DbSet<LUT_PersonType> LUT_PersonType { get; set; }
        public virtual DbSet<LUT_Sector> LUT_Sector { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonAvailability> PersonAvailabilities { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<HotelRoomAvailability> HotelRoomAvailabilities { get; set; }
    
        public virtual ObjectResult<GetTimeMatchedPerson_Result> GetTimeMatchedPerson(Nullable<int> typeId, Nullable<int> personId, Nullable<int> sectorId)
        {
            var typeIdParameter = typeId.HasValue ?
                new ObjectParameter("TypeId", typeId) :
                new ObjectParameter("TypeId", typeof(int));
    
            var personIdParameter = personId.HasValue ?
                new ObjectParameter("PersonId", personId) :
                new ObjectParameter("PersonId", typeof(int));
    
            var sectorIdParameter = sectorId.HasValue ?
                new ObjectParameter("SectorId", sectorId) :
                new ObjectParameter("SectorId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTimeMatchedPerson_Result>("GetTimeMatchedPerson", typeIdParameter, personIdParameter, sectorIdParameter);
        }
    }
}
