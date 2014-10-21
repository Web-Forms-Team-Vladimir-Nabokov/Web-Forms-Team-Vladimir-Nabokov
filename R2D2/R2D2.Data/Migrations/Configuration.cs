namespace R2D2.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using R2D2.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.AddAdminRole(context);
            this.AddInitialAdmin(context);
        }

        private void AddInitialAdmin(ApplicationDbContext context)
        {
            string username = "admin@gmail.com";
            string password = "123456";
            var admin = new ApplicationUser() 
            { 
                UserName = username, 
                Email = username 
            };

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!userManager.Users.Any(u => u.UserName == username))
            {
                userManager.Create(admin, password);
                userManager.AddToRole(admin.Id, "Admin");
            }
        }

        private void AddAdminRole(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleName = "Admin";
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }
    }
}
