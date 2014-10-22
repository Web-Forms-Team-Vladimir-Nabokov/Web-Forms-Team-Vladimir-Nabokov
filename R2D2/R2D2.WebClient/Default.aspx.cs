namespace R2D2.WebClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    using R2D2.Models;
    using R2D2.Data;

    public partial class _Default : Page
    {
        private const int DefaultPageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Book> gvBestReadings_GetData()
        {
            var dataBase = new BooksData();
            var bestReadings = dataBase.Books
                .All()
                .OrderByDescending(b => b.Rating)
                .ThenBy(b => b.Title)
                .Take(DefaultPageSize);

            return bestReadings;
        }

        public IQueryable<Book> gvLatestBooks_GetData()
        {
            var dataBase = new BooksData();
            var bestReadings = dataBase.Books
                .All()
                .OrderByDescending(b => b.DatePublished)
                .ThenBy(b => b.Title)
                .Take(DefaultPageSize);

            return bestReadings;
        }

        protected void Rating_PreRender(object sender, EventArgs e)
        {
            var labelRating = (Label)sender;
            int rating = int.Parse(labelRating.Text);
            for (int i = 0; i < rating; i++)
            {
                var spanStar = new HtmlGenericControl("span");
                
            }
        }
    }
}