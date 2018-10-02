using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Common.DTO
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoomDto> ConferenceRooms { get; set; }
        public HotelDto()
        {
            this.ConferenceRooms = new List<RoomDto>();
        }
    }
}
