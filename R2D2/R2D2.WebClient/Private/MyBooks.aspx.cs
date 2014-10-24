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
        private IData data;

        public MyBooks(IData data)
        {
            this.data = data;
        }

        public MyBooks()
            : this(new BooksData())
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.masterPage = this.Master as SiteMaster;           
        }

        public IQueryable<Book> ListViewBooks_GetData()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var db = this.data;
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
                var db = this.data;
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
            var db = this.data;
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

        protected void LbReadCurrent_Command(object sender, CommandEventArgs e)
        {
            var currentUser = this.data.Users.Find(this.User.Identity.GetUserId());
            var bookIdAsStr = e.CommandArgument as string;
            var bookId = Guid.Parse(bookIdAsStr);
            var userBook = currentUser.Books.FirstOrDefault(b => b.BookId == bookId);
            var currentChapterId = userBook.CurrentChapterId;
            var currentChapterSource = userBook.CurrentChapterSource;

            var linkBtn = sender as LinkButton;
            var link = "~/Private/ReadBook.aspx?bookId=" + bookIdAsStr;
            if (!string.IsNullOrWhiteSpace(currentChapterId) && !string.IsNullOrWhiteSpace(currentChapterSource))
            {
                link += "&cId=" + currentChapterId + "&cSource=" + currentChapterSource;
            }

            Response.Redirect(link);
        }
    }
}