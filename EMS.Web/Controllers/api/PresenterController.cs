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
    public class PresenterController : ApiController
    {
        PersonLogic personBLL = null;
        public PresenterController()
        {
            this.personBLL = new PersonLogic(PersonTypeEnum.Presenter);
        }

        // GET: api/Presenter
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Presenter/5
        public string Get(int id)
        {
            return "value";
        }

        // get matched presenter for particular investor in a certain sector
        public IEnumerable<PersonDto> Get([FromUri]int personId, [FromUri]int sectorId)
        {
            try
            {
                //var result = personBLL.GetTimeMatchedPersons(personId, sectorId);
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // POST: api/Presenter
        [HttpPost]
        public IHttpActionResult Post([FromBody]PresenterDto presenter)
        {
            try
            {
                if (presenter != null)
                    return Ok(personBLL.CreateNewPerson(presenter));
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
