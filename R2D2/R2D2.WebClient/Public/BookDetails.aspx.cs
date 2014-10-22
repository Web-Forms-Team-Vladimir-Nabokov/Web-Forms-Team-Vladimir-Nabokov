namespace R2D2.WebClient.Public
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;

    using R2D2.Models;
    using R2D2.Data;
    using R2D2.WebClient.Helpers;

    public partial class BookDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Book fvBook_GetItem([QueryString]Guid bookId)
        {
            var db = new BooksData();
            return db.Books
                .All()
                .FirstOrDefault(b => b.Id == bookId);
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

        protected void btnAddToBookshelf_Click(object sender, EventArgs e)
        {
            var masterPage = this.Master as SiteMaster;
            var bookId = Guid.Parse(this.Request.QueryString["bookId"]);

            var db = new BooksData();
            bool bookExist = db.Books.All().Any(b => b.Id == bookId);
            if (!bookExist)
            {
                masterPage.SetErrorMessage("Such book does not exist: " + bookId);
                return;
            }

            var currentUser = db.Users.Find(this.User.Identity.GetUserId());
            if (currentUser.Books.Any(b => b.BookId == bookId))
            {
                masterPage.SetErrorMessage("Book has already been added to your shelf.");
                return;
            }

            currentUser.Books.Add(new UsersBooks { BookId = bookId });
            db.SaveChanges();
            masterPage.SetInfoMessage("Book successfully added.");
        }
    }
}