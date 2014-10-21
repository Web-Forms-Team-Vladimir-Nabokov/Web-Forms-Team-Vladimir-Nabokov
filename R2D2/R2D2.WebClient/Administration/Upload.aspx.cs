using R2D2.Data;
using R2D2.Epub;
using R2D2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R2D2.WebClient.Administration
{
    public partial class Upload : System.Web.UI.Page
    {
        private IData data;

        public Upload(IData data)
        {
            this.data = data;
        }

        public Upload()
            : this(new BooksData())
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "";
            if (FileUploadControl.HasFile)
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                var fileType = filename.Substring(filename.LastIndexOf('.'));

                if (fileType.ToLowerInvariant() != ".epub")
                {
                    StatusLabel.Text = "File must be epub format";
                    return;
                }
                var currentDateFolder = GetCurrentDateDirectoryName();
                var directory = Server.MapPath("~/Books/" + currentDateFolder);
                if (Directory.Exists(directory))
                {
                    if (Directory.Exists(directory + "/" + filename))
                    {
                        // TODO: Add error to UI

                        StatusLabel.Text = "Upload status: File upload failed, file with this name already exists!";
                        return;
                    }
                    else
                    {
                        Directory.CreateDirectory(directory + "/" + filename);
                    }
                }
                else
                {
                    Directory.CreateDirectory(directory);
                    Directory.CreateDirectory(directory + "/" + filename);
                }

                FileUploadControl.SaveAs(directory + "/" + filename + "/" + filename);

                var finalDirectory = directory + "/" + filename;
                var filePath = directory + "/" + filename + "/" + filename;

                var logic = new Logic();
                EpubBook epubBook;
                try
                {
                    epubBook = logic.GetEpubModel(finalDirectory, filePath);
                }
                catch (Exception)
                {
                    StatusLabel.Text = "Error reading epub file.";
                    return;
                }

                var book = new Book()
                {
                    Author = epubBook.Author,
                    BookUrl = filePath,
                    CoverUrl = epubBook.CoverUrl,
                    DatePublished = epubBook.DatePublished,
                    Description = epubBook.Description,
                    Language = epubBook.Language,
                    RatingCount = 0,
                    RatingSum = 0,
                    Title = epubBook.Title,
                };

                try
                {
                    data.Books.Add(book);

                    data.SaveChanges();
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: Error saving to database!";
                    return;
                }

                StatusLabel.Text = "Upload status: File uploaded!";
            }
        }


        private string GetCurrentDateDirectoryName()
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        }
    }
}