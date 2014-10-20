namespace R2D2.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public virtual ApplicationUser User { get; set; }

        public virtual Book Book { get; set; }

        [Range(0, 10)]
        public double Score { get; set; }
    }
}
