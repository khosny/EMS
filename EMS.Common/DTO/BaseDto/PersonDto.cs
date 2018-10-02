using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Common.DTO.BaseDto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public List<InterestedSectorDto> InterestedSectors { get; set; }

        public PersonDto()
        {
            this.InterestedSectors = new List<InterestedSectorDto>();
        }

    }
}
