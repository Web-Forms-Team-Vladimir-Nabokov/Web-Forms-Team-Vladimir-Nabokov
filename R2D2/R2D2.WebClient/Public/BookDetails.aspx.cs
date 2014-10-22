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
            var labelRating = (Label)sender;
            RatingFormatter.ConvertToStars(labelRating);
        }
    }
}