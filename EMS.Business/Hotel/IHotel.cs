using EMS.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Hotel
{
    public interface IHotel
    {
        bool CreateNewHotel(HotelDto hotelInfo);
        bool UpdateRoomInformation(RoomDto roomInfo);
        HotelDto GetHotelById(int hotelId);
    }
}
