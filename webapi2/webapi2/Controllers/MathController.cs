using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi2.Controllers
{
    [Route("api/Math")]
    [ApiController]
    public class MathController : ControllerBase
    {
        // GET: api/<MathController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("Sum")]
        public int Sum(int a, int b)
        {
            return a + b;
        }

        // GET api/<MathController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MathController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MathController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MathController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
