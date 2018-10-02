using EMS.Business.Person;
using EMS.Common.DTO;
using EMS.Common.DTO.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.Web.Controllers.api
{
    public class InvestorController : ApiController
    {
        PersonLogic personBLL = null;
        public InvestorController()
        {
            this.personBLL = new PersonLogic(PersonTypeEnum.Investor);
        }
        // GET: api/Investor
        public IEnumerable<PersonDto> Get()
        {
            return personBLL.GetPerson();
        }

        // GET: api/Investor/5
        public PersonDto Get(int id)
        {
            return personBLL.GetPerson(id);
        }

        // POST: api/Investor
        [HttpPost]
        public IHttpActionResult Post([FromBody]InvestorDto investor)
        {
            try
            {
                if (investor != null)
                    return Ok(personBLL.CreateNewPerson(investor));
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                // LOG ERROR
                return InternalServerError(e);
            }
        }
    }
}
