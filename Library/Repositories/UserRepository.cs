using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;

namespace LibraryCorner.Repositories
{
    public class UserRepository : IRepository<User,RequestUser,UserRequest>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(User t)
        {
            _context.Users.Add(t);
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Delete(User t)
        {
           _context.Users.Remove(t);
            _context.SaveChanges();
        }

        public void Update(User t)
        {
           _context.Users.Update(t);
            _context.SaveChanges();
        }

        public User Find(RequestUser request)
        {
            return _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
        }



    }
}
