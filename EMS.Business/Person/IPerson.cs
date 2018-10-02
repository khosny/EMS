using EMS.Common.DTO.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Person
{
     public interface IPerson
    {
        bool CreateNewPerson(PersonDto personInfo);
        bool UpdatePerson(PersonDto personInfo);
    }
}
