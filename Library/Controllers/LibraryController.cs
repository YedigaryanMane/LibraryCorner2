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
    public class LibraryController : ControllerBase
    {
        private readonly IRepository<Library,RequestLibrary,LibraryRequest> libraryRepository;

        public LibraryController(IRepository<Library, RequestLibrary,LibraryRequest> libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(libraryRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Add(LibraryRequest libraryRequest)
        {
            Library library = new Library();

            library.Name = libraryRequest.Name;
            libraryRepository.Add(library);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Library library)
        {
            libraryRepository.Update(library);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(libraryRepository.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(Library library)
        {
            libraryRepository.Delete(library);
            return Ok();
        }
    }
}
