namespace R2D2.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BooksRead
    {
        [Key, Column(Order=0)]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Key, Column(Order = 1)]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Range(0, 10)]
        public double? Rating { get; set; }
    }
}
