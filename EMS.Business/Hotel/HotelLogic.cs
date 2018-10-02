using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Common.DTO;
using EMS.DataAccess.Model;
using EMS.DataAccess.Repository;

namespace EMS.Business.Hotel
{
    public class HotelLogic : IHotel
    {
        private UnitOfWork unitOfWorkDb;
        public HotelLogic()
        {
            this.unitOfWorkDb = new UnitOfWork();
        }
        public bool CreateNewHotel(HotelDto hotelInfo)
        {
            if (string.IsNullOrEmpty(hotelInfo.Name))
                return false;

            // Check name duplications
            var _hotel = new EMS.DataAccess.Model.Hotel();
            _hotel.Name = hotelInfo.Name;

            if (hotelInfo.ConferenceRooms.Count > 0)
                AttachRooms(_hotel, hotelInfo.ConferenceRooms);

            unitOfWorkDb.HotelRepository.Insert(_hotel);
            try
            {
                unitOfWorkDb.Save();
                return true;
            }
            catch(Exception e)
            {
                // LOG
                return false;
            }
        }

        private void AttachRooms(DataAccess.Model.Hotel hotel, List<RoomDto> conferenceRooms)
        {
            foreach(var room in conferenceRooms)
            {
                if (!string.IsNullOrEmpty(room.Name))
                {
                    var _room = new HotelRoom() { Hotel = hotel, Name = room.Name };

                    unitOfWorkDb.RoomRepository.Insert(_room);

                    if (room.Slots.Count > 0)
                        AttachTimeSlots(_room, room.Slots);
                }
            }
        }

        private void AttachTimeSlots(HotelRoom room, List<RoomTimeSlotDto> slots)
        {
            foreach (var slot in slots)
            {
                while(slot.End > slot.Start)
                {
                    var _slot = new HotelRoomAvailability()
                    {
                        HotelRoom = room,
                        TimeSlotStart = slot.Start,
                        TimeSlotEnd = slot.Start.AddHours(1)
                    };
                    unitOfWorkDb.RoomSlotRepository.Insert(_slot);
                    slot.Start = slot.Start.AddHours(1);
                }
            }
        }

        public HotelDto GetHotelById(int hotelId)
        {
            if (hotelId > 0)
            {
                var _hotel = unitOfWorkDb.HotelRepository.GetByID(hotelId);
                if (_hotel == null)
                    return new HotelDto();

                var hotelData = new HotelDto() { Id = _hotel.Id, Name = _hotel.Name };
                foreach (var room in _hotel.HotelRooms)
                {
                    var r = new RoomDto() { Id = room.Id, Name = room.Name };
                    r.Slots = room.HotelRoomAvailabilities.Select(x => new RoomTimeSlotDto()
                    {
                        Start = x.TimeSlotStart,
                        End = x.TimeSlotEnd,
                        IsReserved = x.IsReserved
                    }).ToList();
                    hotelData.ConferenceRooms.Add(r);
                }

                return hotelData;
            }
            else
                return new HotelDto();
        }

        public bool UpdateRoomInformation(RoomDto roomInfo)
        {
            throw new NotImplementedException();
        }
    }
}
