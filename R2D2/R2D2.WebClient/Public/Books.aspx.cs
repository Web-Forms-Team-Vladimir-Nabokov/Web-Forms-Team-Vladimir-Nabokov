namespace R2D2.WebClient.Public
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    using R2D2.Data;
    using R2D2.Models;
    using R2D2.WebClient.Helpers;

    public partial class Books : Page
    {
        private const int DefaultPageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Book> gvListAllBooks_GetData()
        {
            string categoryString = Request.Params["category"];
            if (String.IsNullOrWhiteSpace(categoryString))
            {
                categoryString = String.Empty;
            }

            var dataBase = new BooksData();
            var bestReadings = dataBase.Books
                .All()
                .Where(b => b.Categories.Any(c => c.Name.Contains(categoryString)))
                .OrderByDescending(b => b.Rating)
                .ThenBy(b => b.Title)
                .Take(DefaultPageSize);
            return bestReadings;
        }

        public IQueryable<Category> gvListAllCategories_GetData()
        {
            var dataBase = new BooksData();
            var allCategories = dataBase.Categories
                .All();

            return allCategories;
        }

        protected void Rating_PreRender(object sender, EventArgs e)
        {
            var labelRating = (Label)sender;
            RatingFormatter.ConvertToStars(labelRating);
        }
    }
}