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

    public partial class MyBooks : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Book> RepeaterMyBooks_GetData()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var db = new BooksData();
            return db.UsersBooks
                .All()
                .Where(b => b.ApplicationUserId == currentUserId)
                .Select(b => b.Book);
        }
    }
}