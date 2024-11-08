using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;

namespace LibraryCorner.Repositories
{
    public class AuthorRepository : IRepository<Author, RequestAuthor,AuthorRequest>
    {
        private readonly DataContext _dataContext;

        public AuthorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Author author)
        {
            _dataContext.Author.Add(author);
            _dataContext.SaveChanges();
        }

        public Author Get(int id)
        {
            return _dataContext.Author.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _dataContext.Author.ToList();
        }

        public void Delete(Author t)
        {
            _dataContext.Author.Remove(t);
            _dataContext.SaveChanges();
        }

        public void Update(Author t)
        {
            _dataContext.Author.Update(t);
            _dataContext.SaveChanges();
        }

        public Author Find(RequestAuthor request)
        {
            return _dataContext.Author.FirstOrDefault(x => x.AuthorName == request.Name && x.AuthorSurname == request.Surname);
        }
    }
}
