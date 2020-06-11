using GpBooking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GpBooking.Startup))]

namespace GpBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles("admin");
            CreateRoles("user");
            CreateUser("admin@admin.com", "admin", "TT123456", "admin");
        }

        private void CreateRoles(string roleName)
        {
            using (var db = new ApplicationDbContext())
            {
                RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db);
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

                IdentityRole role;

                if (!roleManager.RoleExists(roleName))
                {
                    role = new IdentityRole
                    {
                        Name = roleName
                    };
                    roleManager.Create(role);
                }
            }
        }

        private void CreateUser(string username, string email, string password, string role)
        {
            using (var db = new ApplicationDbContext())
            {
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
                ApplicationUser user = new ApplicationUser() {UserName = username, Email = email};
                IdentityResult result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, role);
                }
            }

        }
    }
}
