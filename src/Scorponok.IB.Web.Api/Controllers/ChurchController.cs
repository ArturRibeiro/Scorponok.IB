using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scorponok.IB.Application.Churchs.Interfaces;
using Scorponok.IB.Application.Churchs.Views;
using Scorponok.IB.Core.Notifications;

namespace Scorponok.IB.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Church")]
    public class ChurchController : ApiController
    {
        private readonly IChurchApplication _app;

        public ChurchController(IChurchApplication app, IDomainNotificationHandler<DomainNotification> notifications) 
            : base(notifications)
                => _app = app;

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
        [HttpPost, Route("register")]
        public IActionResult Post([FromBody]RegisterChurchViewModel view)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(view);
            }

            _app.RegisterChurch(view);

            return Response(view);
        }
        
        // PUT: api/Church/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new ObjectResult(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new ObjectResult(id);
        }
    }
}
