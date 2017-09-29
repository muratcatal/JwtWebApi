using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JwtWebApi.EF
{
    public class MyUser : IdentityUser
    {
        public string HomeTown { get; set; }
    }
}