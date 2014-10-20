namespace R2D2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Id = Guid.NewGuid();
            this.Categories = new HashSet<Category>();
            this.Ratings = new HashSet<Rating>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DatePublished { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public string CoverUrl { get; set; }

        public string BookUrl { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
