using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JwtWebApi.EF
{
    public class MyDbContext : IdentityDbContext<MyUser>
    {
        public MyDbContext() : base("muratConnStr")
        {

        }
    }
}