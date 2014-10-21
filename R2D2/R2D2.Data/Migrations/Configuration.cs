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
            this.AddInitialCategories(context);
        }

        private void AddInitialCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var adventure = new Category() { Name = "Adventure" };
                context.Categories.Add(adventure);
                var art = new Category() { Name = "Art" };
                context.Categories.Add(art);
                var biography = new Category() { Name = "Biography" };
                context.Categories.Add(biography);
                var comics = new Category() { Name = "Comics" };
                context.Categories.Add(comics);
                var computers = new Category() { Name = "Computers" };
                context.Categories.Add(computers);
                var cooking = new Category() { Name = "Cooking" };
                context.Categories.Add(cooking);
                var education = new Category() { Name = "Education" };
                context.Categories.Add(education);
                var erotic = new Category() { Name = "Erotic" };
                context.Categories.Add(erotic);
                var fantasy = new Category() { Name = "Fantasy" };
                context.Categories.Add(fantasy);
                var fiction = new Category() { Name = "Fiction" };
                context.Categories.Add(fiction);
                var history = new Category() { Name = "History" };
                context.Categories.Add(history);
                var horror = new Category() { Name = "Horror" };
                context.Categories.Add(horror);
                var law = new Category() { Name = "Law" };
                context.Categories.Add(law);
                var medical = new Category() { Name = "Medical" };
                context.Categories.Add(medical);
                var music = new Category() { Name = "Music" };
                context.Categories.Add(music);
                var mystery = new Category() { Name = "Mystery" };
                context.Categories.Add(mystery);
                var philosophy = new Category() { Name = "Philosophy" };
                context.Categories.Add(philosophy);
                var poetry = new Category() { Name = "Poetry" };
                context.Categories.Add(poetry);
                var thriller = new Category() { Name = "Thriller" };
                context.Categories.Add(thriller);

                context.SaveChanges();
            }
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
