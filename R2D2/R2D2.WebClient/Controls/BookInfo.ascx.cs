using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using R2D2.WebClient.Helpers;

namespace R2D2.WebClient.Controls
{
    public partial class BookInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Author
        {
            get
            {
                return ViewState["Author"].ToString();
            }
            set
            {
                ViewState["Author"] = value;
            }
        }

        public string Title
        {
            get
            {
                return ViewState["Title"] == null ? "" : ViewState["Title"].ToString();
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        public string CoverUrl
        {
            get
            {
                return ViewState["CoverUrl"].ToString();
            }
            set
            {
                ViewState["CoverUrl"] = value;
            }
        }

        public string Rating
        {
            get
            {
                return ViewState["Rating"].ToString();
            }
            set
            {
                ViewState["Rating"] = value;
            }
        }

        public string Target
        {
            get
            {
                return ViewState["TargetUrl"].ToString();
            }
            set
            {
                ViewState["TargetUrl"] = value;
            }
        }

        protected void image_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Target);
        }

        protected void Rating_PreRender(object sender, EventArgs e)
        {
            var labelRating = (Label)sender;
            RatingFormatter.ConvertToStars(labelRating);
        }
    }
}