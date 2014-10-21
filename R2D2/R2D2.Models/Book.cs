namespace R2D2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        private ICollection<Category> categories;
        private ICollection<UsersBooks> users;

        public Book()
        {
            this.Id = Guid.NewGuid();
            this.categories = new HashSet<Category>();
            this.users = new HashSet<UsersBooks>();
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

        public double RatingCount { get; set; }

        public double RatingSum { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }

        public virtual ICollection<UsersBooks> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public void SetRating()
        {
            this.Rating = this.RatingSum / this.RatingCount;
        }
    }
}
