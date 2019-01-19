using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net;
using System.Web;
using System.IO;

namespace FizzBuzzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValController : ControllerBase
    {

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string number = HttpContext.Request.Query["number"].ToString();
            string text;
            string URL = "http://localhost:1459/api/fizzbuzz?number="+number; 

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(URL));
            webReq.Method = "GET";
            using (WebResponse webResponse = webReq.GetResponse())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                    return new string[] { text };   
                }
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
