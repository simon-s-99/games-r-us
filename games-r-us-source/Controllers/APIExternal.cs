using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace games_r_us_source.Controllers
{
    // change route name if we add more api's in the future 
    [Route("api")]
    [ApiController]
    public class APIExternal : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
