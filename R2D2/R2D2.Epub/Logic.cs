namespace R2D2.Epub
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using eBdb.EpubReader;
    using HtmlAgilityPack;

    public class Logic
    {
        private string linkToCover;

        public IEnumerable<Tuple<string, string, int>> GetChapterNames(string filePath)
        {
            var epub = new Epub(filePath);
            var chapters = epub.TOC
                .Select(c => new Tuple<string, string, int>(c.Source, c.Title, c.Order));

            return chapters;
        }

        public string GetChapterContentAsPlainText(string filePath, string chapterSource)
        {
            var epub = new Epub(filePath);
            var content = epub.TOC
                .FirstOrDefault(c => c.Source == chapterSource)
                .ContentData;

            return content.GetContentAsPlainText();
        }

        public string GetChapterContent(string filePath, string chapterSource)
        {
            var epub = new Epub(filePath);
            var html = epub.TOC
                .FirstOrDefault(c => c.Source == chapterSource)
                .ContentData;

            var document = new HtmlDocument();
            document.LoadHtml(html.Content);
            var content = document
                .DocumentNode
                .SelectNodes("//p | //h1 | //h2 | //h3 | //h4 | //h5 | //h6")
                .Select(c => c.OuterHtml);

            return string.Join("", content);
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

            var links = SaveExternalFiles(epub, directory);

            var coverUrl = linkToCover;

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
                catch (FormatException)
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

        private IEnumerable<string> SaveExternalFiles(Epub epub, string directory)
        {
            //TODO: make this put all external files outside and return a list of their strings
            var pathCollection = new HashSet<string>();
            var keys = epub.ExtendedData.Keys;

            foreach (var key in keys)
            {
                var data = epub.ExtendedData[key] as ExtendedData;
                var keyAsString = key as string;
                if (keyAsString == null)
                {
                    continue;
                }

                var currentFilePath = directory + "/" + key;
                FileInfo file = new System.IO.FileInfo(currentFilePath);
                file.Directory.Create();

                if (data.IsText)
                {
                    File.WriteAllText(currentFilePath, data.Content);
                }
                else
                {
                    var byteArr = Convert.FromBase64String(data.Content);
                    File.WriteAllBytes(currentFilePath, byteArr);
                    pathCollection.Add(currentFilePath);
                }

                if (keyAsString.ToLowerInvariant().Contains("cover."))
                {
                    linkToCover = keyAsString;
                }
            }

            return new List<string>();
        }
    }
}
