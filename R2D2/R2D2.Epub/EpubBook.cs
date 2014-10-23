namespace R2D2.Epub
{
    using System;

    public class EpubBook
    {
        public string Title { get; set; }

        public DateTime DatePublished { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public string CoverUrl { get; set; }
    }
}
