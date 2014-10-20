namespace R2D2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Categories = new HashSet<Category>();
            this.Ratings = new HashSet<BooksRead>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? DatePublished { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public string CoverUrl { get; set; }

        public string BookUrl { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<BooksRead> Ratings { get; set; }
    }
}
