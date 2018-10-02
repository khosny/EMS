using EMS.DataAccess.Model;
using EMS.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace EMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EventManagementSystemEntities context = new EventManagementSystemEntities();

        private GenericRepository<Person> personRepository;
        private GenericRepository<LUT_Sector> lutSectorRepository;
        private GenericRepository<LUT_PersonType> lutPersonTypeRepository;
        private GenericRepository<PersonAvailability> personAvailabilityRepository;

        private GenericRepository<Hotel> hotelRepository;
        private GenericRepository<HotelRoom> roomRepository;
        private GenericRepository<HotelRoomAvailability> roomSlotRepository;


        public GenericRepository<Person> PersonRepository
        {
            get
            {

                if (this.personRepository == null)
                {
                    this.personRepository = new GenericRepository<Person>(context);
                }
                return personRepository;
            }
        }
        public GenericRepository<LUT_Sector> LUTSectorRepository
        {
            get
            {

                if (this.lutSectorRepository == null)
                {
                    this.lutSectorRepository = new GenericRepository<LUT_Sector>(context);
                }
                return lutSectorRepository;
            }
        }
        public GenericRepository<LUT_PersonType> LUTPersonTypeRepository
        {
            get
            {

                if (this.lutPersonTypeRepository == null)
                {
                    this.lutPersonTypeRepository = new GenericRepository<LUT_PersonType>(context);
                }
                return lutPersonTypeRepository;
            }
        }
        public GenericRepository<PersonAvailability> PersonAvailabilityRepository
        {
            get
            {

                if (this.personAvailabilityRepository == null)
                {
                    this.personAvailabilityRepository = new GenericRepository<PersonAvailability>(context);
                }
                return personAvailabilityRepository;
            }
        }

        public GenericRepository<Hotel> HotelRepository
        {
            get
            {

                if (this.hotelRepository == null)
                {
                    this.hotelRepository = new GenericRepository<Hotel>(context);
                }
                return hotelRepository;
            }
        }
        public GenericRepository<HotelRoom> RoomRepository
        {
            get
            {

                if (this.roomRepository == null)
                {
                    this.roomRepository = new GenericRepository<HotelRoom>(context);
                }
                return roomRepository;
            }
        }
        public GenericRepository<HotelRoomAvailability> RoomSlotRepository
        {
            get
            {

                if (this.roomSlotRepository == null)
                {
                    this.roomSlotRepository = new GenericRepository<HotelRoomAvailability>(context);
                }
                return roomSlotRepository;
            }
        }

        public IEnumerable<GetTimeMatchedPerson_Result> GetProcedure_GetTimeMatchedPerson(int? typeId, int? personId, int? sectorId)
        {
            IEnumerable<GetTimeMatchedPerson_Result> result = context.GetTimeMatchedPerson(typeId, personId, sectorId);
            return result;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        // this is used if we need to implement async db operations
        public async Task<bool> SaveAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                // TODO : LOG
                return false;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
