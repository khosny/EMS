using EMS.Business.SharedEntites;
using EMS.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.Web.Controllers.api
{
    public class SectorController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(Lookups.LoadSectors().OrderBy(o => o.Name));
        }
    }
}