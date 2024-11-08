using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;
using LibraryCorner.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCorner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book, RequestBook,BookRequest> bookRepository;

        public BookController(IRepository<Book, RequestBook,BookRequest> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(bookRepository.Get(id));
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            bookRepository.Update(book);
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(BookRequest bookRequest)
        {
            Book book = new Book();

            book.AuthorName = bookRequest.AuthorName;
            book.AuthorSurname = bookRequest.AuthorSurname;
            book.Title = bookRequest.Title;
            book.Year = bookRequest.Year;
            book.Quanitity = bookRequest.Quanitity;
            book.IsReserved = bookRequest.IsReserved;
            book.ISBN = bookRequest.ISBN;
           
            bookRepository.Add(book);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Book book)
        {
            bookRepository.Delete(book);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(bookRepository.GetAll());
        }
    }
}
