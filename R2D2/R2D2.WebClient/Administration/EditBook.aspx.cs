using R2D2.Data;
using R2D2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R2D2.WebClient.Administration
{
    public partial class EditBook : System.Web.UI.Page
    {
        private IData data;

        public EditBook(IData data)
        {
            this.data = data;
        }

        public EditBook()
            : this(new BooksData())
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //var categoryBox = this.FvEdit.FindControl("chlCategories") as CheckBoxList;
            //var book = this.data.Books.Find(Request.QueryString["id"]);
            //foreach (var cat in book.Categories)
            //{
            //    var stuff = categoryBox.Items.Cast<ListItem>().FirstOrDefault(li => int.Parse(li.Value) == cat.Id);
            //    stuff.Selected = true;
            //}

            //categoryBox.DataBind();
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Book FvEdit_GetItem([QueryString]Guid id)
        {
            var book = this.data.Books.Find(id);
            return book;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FvEdit_UpdateItem(Guid id)
        {
            var item = this.data.Books.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            item.Categories.Clear();
            var categoriesList = this.FvEdit.FindControl("chlCategories") as CheckBoxList;
            foreach (ListItem categoryItem in categoriesList.Items)
            {
                if (categoryItem.Selected)
                {
                    var catId = int.Parse(categoryItem.Value);
                    var category = this.data.Categories.Find(catId);
                    category.Books.Add(item);
                }
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                this.data.SaveChanges();
            }

            Response.Redirect("~/Administration/EditBook.aspx?id=" + id.ToString());
        }

        public IQueryable<Category> DdlCategories_GetData()
        {
            return this.data.Categories.All();
        }

        protected void chlCategories_PreRender(object sender, EventArgs e)
        {
            var currentId = Guid.Parse(this.Request.QueryString["id"]);
            var currentBook = this.data.Books.Find(currentId);
            if (currentBook == null)
            {
                return;
            }

            var categoriesList = (CheckBoxList)sender;
            foreach (ListItem item in categoriesList.Items)
            {
                if (currentBook.Categories.Any(c => c.Id.ToString() == item.Value))
                {
                    item.Selected = true;
                }
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/EditBook.aspx?id=" + Request.QueryString["id"]);
        }
    }
}