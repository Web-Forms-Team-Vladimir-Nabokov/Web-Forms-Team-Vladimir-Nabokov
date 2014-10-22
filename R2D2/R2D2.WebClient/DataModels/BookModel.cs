using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2D2.WebClient.DataModels
{
    public class BookModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string CoverUrl { get; set; }
    }
}