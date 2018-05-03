using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private DataSettings _data;

        public ValuesController(IOptions<DataSettings> data)
        {
            _data = data.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {


            if (_data.Value != null)
            {
                Console.Error.WriteLine("Error: " + "Get");
                Trace.WriteLine("ValuesController.Get " + _data.Value, "DataCateg");
                return new string[] { _data.Value };
            }
            else
            {
              //  Console.Error.WriteLine("Error2: " + "Get");
             //   Console.WriteLine("Je suis tannée, peux-tu intercepter celle foutu erreur!");
                Trace.WriteLine("ValuesController.Get2 " + string.Join(", ", new string[] { "static value1", "static values2" }), "DataCateg");
                Trace.TraceInformation("This is an information");
                Trace.TraceWarning("This is a warning");
                Debug.WriteLine("This is a debug message");
                return new string[] { "static value1", "static values2" };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
