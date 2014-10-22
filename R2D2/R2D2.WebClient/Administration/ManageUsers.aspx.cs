using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using R2D2.Data;
using R2D2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R2D2.WebClient.Administration
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private IData data;
        private SiteMaster master;

        public ManageUsers(IData data)
        {
            this.data = data;
        }

        public ManageUsers()
            : this(new BooksData())
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ApplicationUser> LvUsers_GetData()
        {
            return this.data.Users.All().OrderBy(u => u.UserName);
        }

        protected void Btn_Command(object sender, CommandEventArgs e)
        {
            var user = this.data.Users.Find(e.CommandArgument);


            if (user.Roles.Count() == 1)
            {
                user.Roles.Remove(user.Roles.FirstOrDefault());
                data.SaveChanges();
            }
            else
            {
                var context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.AddToRole(user.Id, "Admin");
            }

            var queryStr = Request.QueryString.ToString();

            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryStr = "?" + queryStr;
            }

            Response.Redirect("~/Administration/ManageUsers.aspx" + queryStr);
        }
    }
}