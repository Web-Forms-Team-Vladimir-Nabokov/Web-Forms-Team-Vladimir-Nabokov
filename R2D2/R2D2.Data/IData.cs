namespace R2D2.Data
{
    using R2D2.Data.Repositories;
    using R2D2.Models;

    public interface IData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Book> Books { get; }

        IRepository<BooksRead> Ratings { get; }

        int SaveChanges();
    }
}
