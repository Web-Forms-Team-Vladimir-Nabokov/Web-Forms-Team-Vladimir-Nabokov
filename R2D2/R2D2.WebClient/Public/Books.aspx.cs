using R2D2.Data;
using R2D2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R2D2.WebClient.Public
{
    public partial class Books : System.Web.UI.Page
    {
        private const int DefaultPageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Book> gvListAllBooks_GetData()
        {
            var dataBase = new BooksData();
            var bestReadings = dataBase.Books
                .All()
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
    }
}