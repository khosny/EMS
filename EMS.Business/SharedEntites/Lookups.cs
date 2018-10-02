using EMS.Common.DTO;
using EMS.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.SharedEntites
{
    public class Lookups
    {
        public static IEnumerable<InterestedSectorDto> LoadSectors()
        {
            UnitOfWork unitOfWorkDb = new UnitOfWork();
            return unitOfWorkDb.LUTSectorRepository.Get().Select(s => new InterestedSectorDto()
            {
                Id = s.Id,
                Name = s.SectorName
            });
        }
    }
}
