using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace webapi2.Controllers
{
    [Route("api/[Values]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("/getvalues")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       
    }
}
