using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using publisherApi.MediatR.Queries;
namespace publisherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
         private readonly ILogger<UserController> _logger;
       
 

        public UserController(ILogger<UserController> logger,IMediator mediator)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public  async Task<IEnumerable<User>> Get() =>  await mediator.Send( new GetUserQuery());
       

        [HttpPost]
        public IActionResult Post([FromBody] string payload)
        {
            return Ok("{\"success\": \"true\"}");
        }
    }
}
