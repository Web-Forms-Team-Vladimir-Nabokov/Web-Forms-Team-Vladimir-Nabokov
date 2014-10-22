﻿namespace R2D2.WebClient.Helpers
{
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public static class RatingFormatter
    {
        public static void ConvertToStars(Label ratingControl)
        {
            int rating = int.Parse(ratingControl.Text);
            if (rating <= 0)
            {
                ratingControl.Text = "Not rated";
                return;
            }

            for (int i = 0; i < rating; i++)
            {
                var spanStar = new HtmlGenericControl("span");
                spanStar.Attributes.Add("class", "glyphicon glyphicon-star text-warning");

                ratingControl.Controls.Add(spanStar);
            }
        }
    }
}