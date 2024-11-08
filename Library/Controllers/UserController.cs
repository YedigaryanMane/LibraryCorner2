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
    public class UserController : ControllerBase
    {
        private readonly IRepository<User,RequestUser,UserRequest> _userRepository;

        public UserController(IRepository<User, RequestUser,UserRequest> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpDelete]
        public IActionResult Delete(User user)
        {
            _userRepository.Delete(user);

            return Ok();
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_userRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Add(UserRequest userRequest)
        {
            User user = new User();

            user.Name = userRequest.Name;
            user.Email = userRequest.Email;
            user.Password = userRequest.Password;
            user.OrderBook = userRequest.OrderBook;
            
            _userRepository.Add(user);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            _userRepository.Update(user);

            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }
    }
}
