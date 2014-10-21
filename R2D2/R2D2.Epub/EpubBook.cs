namespace R2D2.Epub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
