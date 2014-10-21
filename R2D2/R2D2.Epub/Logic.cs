namespace R2D2.Epub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eBdb.EpubReader;

    public class Logic
    {
        private ICollection<string> SaveExternalFiles(Epub epub, string directory)
        {
            //TODO: make this put all external files outside and return a list of their strings
            return new List<string>();
        }

        public EpubBook GetEpubModel(string directory, string filePath)
        {
            //Init epub object.
            Epub epub = new Epub(filePath);

            ////Get book title (Every epub file can have multiple titles)
            //string title = epub.Title[0];

            ////Get book authors (Every epub file can have multiple authors)
            //string author = epub.Creator[0];

            ////Get all book content as plain text
            //string plainText = epub.GetContentAsPlainText();

            ////Get all book content as html text
            //string htmlText = epub.GetContentAsHtml();

            ////Get some part of book content
            //ContentData contentData = epub.Content[0] as ContentData;

            ////Get Table Of Contents (TOC)
            //List<NavPoint> navPoints = epub.TOC;
            var title = "";
            if (epub.Title.Count > 0)
            {
                title = epub.Title[0];
            }

            var author = "";
            if (epub.Creator.Count > 0)
            {
                author = string.Join(", ", epub.Creator);
            }

            var coverUrl = "";

            var links = SaveExternalFiles(epub, directory);

            foreach (var link in links)
            {
                if (link.ToLowerInvariant().Contains("cover"))
                {
                    coverUrl = link;
                    break;
                }
            }

            DateTime published = DateTime.Now;

            
            
            if (epub.Date.Count > 0)
            {
                try
                {
                    published = DateTime.Parse(epub.Date[0].Date);

                }
                catch (ArgumentNullException)
                {
                }
                catch(FormatException)
                {
                }
            }

            var book = new EpubBook()
            {
                Author = author,
                Title = title,
                Language = epub.Language[0],
                Description = string.Join(".", epub.Description),
                CoverUrl = coverUrl,
                DatePublished = published,
            };

            return book;
        }
    }
}
