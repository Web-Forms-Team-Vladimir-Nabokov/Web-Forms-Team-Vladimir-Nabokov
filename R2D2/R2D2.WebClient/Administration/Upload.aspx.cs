﻿using R2D2.Data;
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
        private SiteMaster master;

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
            this.master = this.Master.Master as SiteMaster;
        }

        protected void Upload_Clicked(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (!FileUploadControl.HasFile)
            {
                this.master.SetErrorMessage("No file was attached!");
                return;
            }

            string filename = Path.GetFileName(FileUploadControl.FileName);
            var fileType = filename.Substring(filename.LastIndexOf('.'));

            if (fileType.ToLowerInvariant() != ".epub")
            {
                this.master.SetErrorMessage("File must be epub format!");
                return;
            }

            var currentDateFolder = GetCurrentDateDirectoryName();
            var directory = Server.MapPath("~/Books/" + currentDateFolder);
            if (Directory.Exists(directory))
            {
                if (Directory.Exists(directory + "/" + filename))
                {
                    this.master.SetErrorMessage("Upload status: File upload failed, file with this name already exists!");
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
            try
            {
                FileUploadControl.SaveAs(directory + "/" + filename + "/" + filename);
            }
            catch (PathTooLongException ex)
            {
                this.master.SetErrorMessage("File name is too long.");
                return;
            }
            catch (Exception)
            {
                this.master.SetErrorMessage("Error occured while saving file.");
                return;
            }

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
                this.master.SetErrorMessage("Error reading epub file.");
                return;
            }

            var serverDirectory = "~/Books/" + currentDateFolder + "/" + filename;
            var book = new Book()
            {
                Author = epubBook.Author,
                BookUrl = serverDirectory + "/" + filename,
                CoverUrl = serverDirectory + "/" + epubBook.CoverUrl,
                DatePublished = epubBook.DatePublished,
                Description = epubBook.Description,
                Language = epubBook.Language,
                Rating = 0,
                Title = epubBook.Title,
            };

            var selectedCategories = this.chlCategories.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .ToList();

            for (int i = 0; i < selectedCategories.Count; i++)
            {
                var currentCategory = selectedCategories[i];
                var foundCategory = this.data.Categories.Find(int.Parse(currentCategory.Value));

                if (foundCategory != null)
                {
                    book.Categories.Add(foundCategory);
                }
            }

            try
            {
                data.Books.Add(book);

                data.SaveChanges();
            }
            catch (Exception ex)
            {
                this.master.SetErrorMessage("Upload status: Error saving to database!");
                return;
            }

            this.master.SetInfoMessage("Upload status: File uploaded!");
            this.LinkBook.Visible = true;
            this.LinkBook.NavigateUrl = "~/Public/BookDetails.aspx?bookId=" + book.Id;
        }


        private string GetCurrentDateDirectoryName()
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        }

        public IQueryable<Category> DdlCategories_GetData()
        {
            return this.data.Categories.All();
        }
    }
}