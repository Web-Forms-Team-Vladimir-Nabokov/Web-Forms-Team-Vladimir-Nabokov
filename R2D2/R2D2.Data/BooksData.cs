namespace R2D2.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using R2D2.Data.Repositories;
    using R2D2.Models;

    public class BooksData : IData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BooksData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<UsersBooks> UsersBooks
        {
            get { return this.GetRepository<UsersBooks>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}