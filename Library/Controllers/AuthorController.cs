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
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author,RequestAuthor,AuthorRequest> _authorRepository;

        public AuthorController(IRepository<Author, RequestAuthor,AuthorRequest> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_authorRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Add(AuthorRequest authorRequest)
        {
            Author author = new Author();
            author.AuthorSurname = authorRequest.AuthorSurname;
            author.AuthorName = authorRequest.AuthorName;
            _authorRepository.Add(author);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(Author author)
        {
            return Ok(_authorRepository.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(Author author)
        {
            _authorRepository.Delete(author);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Author author)
        {
            _authorRepository.Update(author);
            return Ok();
        }

    }
}
