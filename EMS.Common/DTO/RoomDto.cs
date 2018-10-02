using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Common.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoomTimeSlotDto> Slots { get; set; }

        public RoomDto()
        {
            this.Slots = new List<RoomTimeSlotDto>();
        }
    }
}
