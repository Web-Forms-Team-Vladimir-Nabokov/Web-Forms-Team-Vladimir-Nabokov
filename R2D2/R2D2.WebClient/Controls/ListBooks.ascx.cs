using R2D2.WebClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R2D2.WebClient.Controls
{
    public partial class ListBooks : System.Web.UI.UserControl
    {
        public GridView GridViewBooks { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.GridViewBooks = this.GvBestReadings;
        }

        protected void Rating_PreRender(object sender, EventArgs e)
        {
            var labelRating = (Label)sender;
            RatingFormatter.ConvertToStars(labelRating);
        }
    }
}