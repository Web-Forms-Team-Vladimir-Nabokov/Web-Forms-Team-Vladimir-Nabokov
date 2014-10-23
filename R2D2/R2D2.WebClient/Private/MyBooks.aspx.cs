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
        private SiteMaster masterPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.masterPage = this.Master as SiteMaster;           
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
            var labelRating = (Label)sender;
            RatingFormatter.ConvertToStars(labelRating);
        }

        protected void btnRate_Command(object sender, CommandEventArgs e)
        {
            var arguments = e.CommandArgument.ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Guid bookId = Guid.Parse(arguments[0]);
            double vote = double.Parse(arguments[1]);

            try
            {
                var db = new BooksData();
                string currentUserId = this.User.Identity.GetUserId();

                var currentBook = db.UsersBooks.All()
                    .FirstOrDefault(b =>
                        b.ApplicationUserId == currentUserId &&
                        b.BookId == bookId);

                currentBook.Rating = vote;
                currentBook.Book.SetRating();
                db.SaveChanges();
                this.ListViewBooks.DataBind();
                this.masterPage.SetInfoMessage("Ranking accepted successfully.");
            }
            catch (Exception ex)
            {
                this.masterPage.SetErrorMessage(ex.Message);
            }
        }

        protected void btnRemoveBook_Command(object sender, CommandEventArgs e)
        {
            var db = new BooksData();
            string currentUserId = this.User.Identity.GetUserId();
            Guid bookId = Guid.Parse(e.CommandArgument.ToString());

            var currentBook = db.UsersBooks
                .All()
                .FirstOrDefault(b => 
                    b.ApplicationUserId == currentUserId && 
                    b.BookId == bookId);

            db.UsersBooks.Delete(currentBook);
            db.SaveChanges();
            this.ListViewBooks.DataBind();
        }
    }
}