using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JwtWebApi.EF
{
    public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        private MyDbContext _context;
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);

            _context = context;

            string username = "Murat";
            string[] roleNames = new string[] { "Admin" };
            string password = "123456";
            CreateUser(username, password, roleNames);

            username = "Tunca";
            roleNames = new string[] { "Admin", "Operator" };
            password = "123456";
            CreateUser(username, password, roleNames);

            username = "Gokalp";
            roleNames = new string[] { "Viewer" };
            password = "123456";
            CreateUser(username, password, roleNames);

        }

        private void CreateUser(string userName, string password, string[] roleNames)
        {
            var UserManager = new UserManager<MyUser>(new UserStore<MyUser>(_context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    var roleresult = RoleManager.Create(new IdentityRole(roleName));
                }
            }
            var user = new MyUser();
            user.UserName = userName;
            var adminresult = UserManager.Create(user, password);
            if (adminresult.Succeeded)
            {
                foreach (var roleName in roleNames)
                {
                    var result = UserManager.AddToRole(user.Id, roleName);
                }
            }
        }
    }
}