namespace R2D2.WebClient.Private
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;

    using R2D2.Models;
    using R2D2.Data;
    using R2D2.WebClient.Helpers;

    public partial class MyBooks : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Book> ListViewBooks_GetData()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var db = new BooksData();
            return db.UsersBooks
                .All()
                .Where(b => b.ApplicationUserId == currentUserId)
                .OrderByDescending(b => b.Rating)
                .Select(b => b.Book);
        }

        protected void Rating_PreRender(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var labelRating = (Label)sender;
            RatingFormatter.ConvertToStars(labelRating);
        }
    }
}