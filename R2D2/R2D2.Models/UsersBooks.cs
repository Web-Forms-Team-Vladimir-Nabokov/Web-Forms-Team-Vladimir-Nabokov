namespace R2D2.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users_Books")]
    public class UsersBooks
    {
        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

        [Key, Column(Order = 1),]
        public Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public string CurrentChapterSource { get; set; }

        public string CurrentChapterId { get; set; }
    }
}
