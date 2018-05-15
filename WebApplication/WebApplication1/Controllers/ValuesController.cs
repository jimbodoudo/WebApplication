using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private Grocery _grocery;
        private BranchEntity _branch;
        private Urls _urls;

        public ValuesController(IOptionsSnapshot<Grocery> grocery, IOptions<BranchEntity> branch, IOptions<Urls> urls)
        {
            _grocery = grocery.Value;
            _branch = branch.Value;
            _urls = urls.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> items = new List<string>(_grocery.Stocks);
            items.Add(_branch.Name);
            items.Add("carottes crues");

            // Call app2 from app1
            HttpClient client = new HttpClient();
            var response = client.GetAsync(_urls.SubService);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            string[] values = JsonConvert.DeserializeObject<string[]>(result);

            items.AddRange(values);

           // Console.Error.WriteLine("Error2: " + String.Join(", ", items.ToArray()));
           // Console.WriteLine("Je suis tannée, peux-tu intercepter cette foutu erreur!");
            Trace.WriteLine("ValuesController.Get2: " + String.Join(", ", items.ToArray()), "GroceryCateg");
            Trace.TraceInformation("This is an information");
            Trace.TraceWarning("This is a warning");
            Debug.WriteLine("This is a debug message");

            return items.ToArray();
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
