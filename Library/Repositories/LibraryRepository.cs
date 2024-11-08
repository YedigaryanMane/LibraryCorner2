using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;

namespace LibraryCorner.Repositories
{
    public class LibraryRepository : IRepository<Library,RequestLibrary,LibraryRequest>
    {
        private readonly DataContext _context;

        public LibraryRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Library t)
        {
            _context.Libraries.Add(t);
            _context.SaveChanges();
        }

        public Library Get(int id)
        {
            return _context.Libraries.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Library> GetAll()
        {
            return _context.Libraries.ToList();
        }

        public void Delete(Library t)
        {
           _context.Libraries.Remove(t);
            _context.SaveChanges();
        }

        public void Update(Library t)
        {
            _context.Libraries.Update(t);
            _context.SaveChanges();
        }

        public Library Find(RequestLibrary request)
        {
            return _context.Libraries.FirstOrDefault(x => x.Name == request.Name);
        }
    }
}
