
using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;

namespace LibraryCorner.Repositories
{
    public class BookRepository : IRepository<Book,RequestBook,BookRequest>
    {
        private readonly DataContext _dataContext;
        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Book t)
        {
            _dataContext.Books.Add(t);
            _dataContext.SaveChanges();
        }

        public Book Get(int id)
        {
            return _dataContext.Books.FirstOrDefault(x => x.BookId == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _dataContext.Books.ToList();
        }

        public void Delete(Book t)
        {
            _dataContext.Books.Remove(t);
            _dataContext.SaveChanges();
        }

        public void Update(Book t)
        {
            _dataContext.Books.Update(t);
            _dataContext.SaveChanges();
        }

        public Book Find(RequestBook request)
        {
           return _dataContext.Books.FirstOrDefault(x => x.Title == request.Title && x.Year == request.Year);
        }

        public Book Find1(RequestBook request)
        {
            return _dataContext.Books.FirstOrDefault(x => x.ISBN == request.ISBN);
        }
    }
}
