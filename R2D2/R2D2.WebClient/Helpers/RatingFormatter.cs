namespace R2D2.WebClient.Helpers
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public static class RatingFormatter
    {
        public static void ConvertToStars(Label ratingControl)
        {
            if (ratingControl.Text.Length > 3)
            {
                ratingControl.Text = "0";
            }

            double rating = Math.Round(double.Parse(ratingControl.Text));
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