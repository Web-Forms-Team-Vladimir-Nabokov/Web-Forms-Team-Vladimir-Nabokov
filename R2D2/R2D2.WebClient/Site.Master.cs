using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Gma.DataStructures.StringSearch;
using R2D2.Data;
using R2D2.Models;
using R2D2.WebClient.DataModels;

namespace R2D2.WebClient
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        private BooksData booksData = new BooksData();

        private ITrie<BookModel> Trie { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CacheBooksInfo();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.errorMsg.InnerText))
            {
                this.error.Visible = false;
            }
            else
            {
                this.error.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(this.infoMsg.InnerText))
            {
                this.info.Visible = false;
            }
            else
            {
                this.info.Visible = true;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        public void SetErrorMessage(string errorMsg)
        {
            this.errorMsg.InnerText = errorMsg;
        }

        public void SetInfoMessage(string infoMsg)
        {
            this.infoMsg.InnerText = infoMsg;
        }

        protected virtual ITrie<BookModel> CreateTrie()
        {
            return new PatriciaSuffixTrie<BookModel>(1);
        }

        private IList<BookModel> RetrieveDataFromDb()
        {
            var booksCollection = booksData.Books
                .All()
                .Select(b => new BookModel
                {
                    Author = b.Author,
                    Title = b.Title,
                    CoverUrl = b.CoverUrl
                }).ToList();

            return booksCollection;
        }

        private void PopulateTrieOfBooks(IList<BookModel> collectionOfBooks)
        {
            this.Trie = CreateTrie();
            for (int i = 0; i < collectionOfBooks.Count; i++)
            {
                var currentBook = collectionOfBooks[i];
                Trie.Add(currentBook.Title, currentBook);
            }
        }

        private void CacheBooksInfo()
        {
            if (this.Cache["books"] == null)
            {
                var booksCollection = RetrieveDataFromDb();
                PopulateTrieOfBooks(booksCollection);

                Cache.Insert("books", Trie, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration, CacheItemPriority.Default, OnRemoveCallback);
            }
        }

        private void OnRemoveCallback(string key, object value, CacheItemRemovedReason reason)
        {
            CacheBooksInfo();
        }
    }

}