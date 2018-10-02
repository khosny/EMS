using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Common.DTO;
using EMS.Common.DTO.BaseDto;
using EMS.DataAccess.Model;
using EMS.DataAccess.Repository;

namespace EMS.Business.Person
{
    public class PersonLogic : IPerson
    {
        private PersonTypeEnum _peronType;
        private UnitOfWork unitOfWorkDb;

        public PersonLogic(PersonTypeEnum personType)
        {
            this._peronType = personType;
            this.unitOfWorkDb = new UnitOfWork();
        }

        public IEnumerable<PersonDto> GetPerson()
        {
            var type = this.ResolveType();
            // we can use automapper here
            return unitOfWorkDb.PersonRepository.Get(p => p.TypeId == type.Id)
                .Select(a => new PersonDto()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Mobile = a.MobileNum
                });
        }

        public IEnumerable<PersonDto> GetTimeMatchedPersons(int personId, int sectorId)
        {
            // get the time matched presenter/investor from stored procedure 
            throw new NotImplementedException();

        }

        public PersonDto GetPerson(int id)
        {
            var person = unitOfWorkDb.PersonRepository.Get(p => p.Id == id)
                 .Select(a => new PersonDto()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Mobile = a.MobileNum,
                     InterestedSectors = a.PersonAvailabilities
                         .Select(b => new InterestedSectorDto()
                         {
                             Id = b.SectorId,
                             Name = b.LUT_Sector.SectorName,
                             Start = b.AvailabilityTimeStart,
                             End = b.AvailabilityTimeEnd
                         }).ToList()
                 });
            if (person.Count() > 0)
                return person.FirstOrDefault();
            else
                return null;
        }

        public bool CreateNewPerson(PersonDto personInfo)
        {
            if (personInfo != null && !string.IsNullOrEmpty(personInfo.Name))
            {
                var _person = new EMS.DataAccess.Model.Person();
                _person.Name = personInfo.Name;
                _person.MobileNum = string.IsNullOrEmpty(personInfo.Mobile) ? null : personInfo.Mobile;
                _person.LUT_PersonType = this.ResolveType();

                if (_person.LUT_PersonType != null)
                {
                    AttachAvialabilities(_person, personInfo.InterestedSectors);
                    unitOfWorkDb.PersonRepository.Insert(_person);
                }
                else
                    return false;

                try
                {
                    unitOfWorkDb.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    //LOG
                    return false;
                }
            }
            else
                return false;
        }

        private void AttachAvialabilities(DataAccess.Model.Person person, List<InterestedSectorDto> interestedSectors)
        {
            foreach(var interest in interestedSectors)
            {
                while (interest.End > interest.Start)
                {
                    person.PersonAvailabilities.Add(new PersonAvailability()
                    {
                        AvailabilityTimeStart = interest.Start,
                        AvailabilityTimeEnd = interest.Start.AddHours(1),
                        SectorId = interest.Id
                    });
                    interest.Start = interest.Start.AddHours(1);
                }
            }
        }

        private LUT_PersonType ResolveType()
        {
            string currentType = this._peronType.ToString().ToLower();
            var lutTypes = unitOfWorkDb.LUTPersonTypeRepository.Get(a => a.Type.ToLower() == currentType);
            if (lutTypes.Count() > 0)
                return lutTypes.FirstOrDefault();
            else
                return null;
        }

        public bool UpdatePerson(PersonDto personInfo)
        {
            throw new NotImplementedException();
        }
    }
}
