using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;
using LibraryCorner.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryCorner.BorrowedMenu
{
    public class ReservedModel
    {
        private readonly IRepository<Author, RequestAuthor,AuthorRequest> _authorRepository;
        private readonly IRepository<Book, RequestBook,BookRequest> _bookRepository;
        private readonly IRepository<Library, RequestLibrary,LibraryRequest> _libraryRepository;
        private readonly DataContext dataContext;
        public ReservedModel(DataContext dataContext)
        { 
            this.dataContext = dataContext;
        }

        public ReservedModel(IRepository<Author, RequestAuthor,AuthorRequest> authorRepository,
            IRepository<Book, RequestBook,BookRequest> bookRepository,
            IRepository<Library, RequestLibrary,LibraryRequest> libraryRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _libraryRepository = libraryRepository;
        }
        
        public void ReservedBook(LibraryModel model)
        {
            var author = _authorRepository.Find(new RequestAuthor(model.Name, model.Surname));
            var book = _bookRepository.Find(new RequestBook(model.Title, model.Year));
            var library = _libraryRepository.Find(new RequestLibrary(model.Name));

            if (author != null && book != null && library != null)
            {
                if (book.Quanitity != 0)
                {
                        book.IsReserved = true;

                        book.Quanitity--;
                }
                else { throw new ArgumentException("Book is finished."); }
            }
            else { throw new ArgumentException("Book is not found."); }
        }

        public void ReturnBook(LibraryModel model)
        {
            BookRepository bookRepository = new BookRepository(dataContext);

            var book1 = bookRepository.Find1(new RequestBook(model.ISBN));

            if(book1 != null)
            {
                book1.IsReserved = false;
                book1.Quanitity++;
            }
            else { throw new ArgumentException("ISBN is not found."); }
        }
    }
}
