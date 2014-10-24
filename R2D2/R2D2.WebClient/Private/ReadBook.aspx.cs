namespace R2D2.WebClient.Private
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;

    using R2D2.Data;
    using R2D2.Epub;

    public partial class ReadBook : Page
    {
        private IData data;

        public ReadBook(IData data)
        {
            this.data = data;
        }

        public ReadBook()
            : this(new BooksData())
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ShowChapter_Command(object sender, CommandEventArgs e)
        {
            var currentBookId = Guid.Parse(this.Request.QueryString["bookId"]);
            var db = new BooksData();
            var currentBookPath = this.MapPath(db.Books.Find(currentBookId).BookUrl);

            var cmdArguments = e.CommandArgument.ToString().Split(new char[] { ',' });
            var chapterSource = cmdArguments[0];
            var chapterId = cmdArguments[1];

            var hashIndex = chapterSource.IndexOf('#');
            var hash = hashIndex < 0 ? "#" : chapterSource.Substring(hashIndex);

            this.hiddenField.InnerText = chapterId.ToString();
            this.hiddenField.InnerText += "," + hash;

            var readLogic = new Logic();
            var chapterContent = readLogic.GetChapterContent(currentBookPath, chapterSource);
            this.lblChapterContent.Text = chapterContent;
            var currentUser = this.data.Users.Find(User.Identity.GetUserId());
            var currentUserBook = currentUser.Books.FirstOrDefault(b => b.BookId == currentBookId);
            if (currentUserBook == null)
	        {
		        return;
	        }
            currentUserBook.CurrentChapterId = chapterId;
            currentUserBook.CurrentChapterSource = chapterSource;
            this.data.SaveChanges();
        }

        protected void RepeaterChapters_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var currentBookId = Guid.Parse(this.Request.QueryString["bookId"]);
            var db = new BooksData();
            var currentBookPath = this.MapPath(db.Books.Find(currentBookId).BookUrl);

            var readLogic = new Logic();
            this.RepeaterChapters.DataSource = readLogic.GetChapterNames(currentBookPath);
            this.RepeaterChapters.DataBind();
        }
    }
}