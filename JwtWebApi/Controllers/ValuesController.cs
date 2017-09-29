using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JwtWebApi.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JwtWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize(Roles = "Viewer")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var db = new MyDbContext();

            new MyDbInitializer().InitializeDatabase(db);
            var dbUsers = db.Users;

            return "value " + dbUsers.Count();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
    }
}
