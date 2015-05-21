using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISSU.Web.Areas.API.Controllers
{
    public class SUSIController : ApiController
    {
        // GET api/susi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/susi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/susi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/susi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/susi/5
        public void Delete(int id)
        {
        }
    }
}
