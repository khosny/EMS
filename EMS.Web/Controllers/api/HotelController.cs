using EMS.Business.Hotel;
using EMS.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.Web.Controllers.api
{
    public class HotelController : ApiController
    {
        HotelLogic hotelBLL = null;
        public HotelController()
        {
           this.hotelBLL = new HotelLogic();
        }

        // GET: api/Hotel
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hotel/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                    return Ok(hotelBLL.GetHotelById(id));
                else
                    return BadRequest();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        // POST: api/Hotel
        [HttpPost]
        public IHttpActionResult Post([FromBody]HotelDto hotelInfo)
        {
            try
            {
                if (hotelInfo != null)
                    return Ok(hotelBLL.CreateNewHotel(hotelInfo));
                else
                    return BadRequest();
            }
            catch(Exception e)
            {
                // LOG ERROR
                return InternalServerError(e);
            }
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
