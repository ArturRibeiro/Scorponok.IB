using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scorponok.IB.Application.Views;

namespace Scorponok.IB.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Church")]
    public class ChurchController : Controller
    {
        // GET: api/Church
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Church/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Church
        [HttpPost]
        public void Post([FromBody]ChurchRegisteringViewModel view)
        {
        }
        
        // PUT: api/Church/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
