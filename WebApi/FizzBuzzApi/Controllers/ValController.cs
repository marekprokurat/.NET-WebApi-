using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Microsoft.Extensions.Options;


namespace FizzBuzzApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValController : ControllerBase
    {
        private readonly IOptions<MyConfig> _myConfig;
        public ValController(IOptions<MyConfig> myConfig)
        {
            _myConfig = myConfig;
        }

        // GET: api/fizzbuzz?number=x
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string number = HttpContext.Request.Query["number"].ToString();
            string text;
            string adres = _myConfig.Value.Url + number;

             HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(adres);
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

    }
}
