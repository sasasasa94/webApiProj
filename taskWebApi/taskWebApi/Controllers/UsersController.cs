using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskWebApi.Data;
using taskWebApi.Dto;
using taskWebApi.Interfaces;
using taskWebApi.Models;

namespace taskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepository usersRepository, IMapper mapper )
        {
            this._usersRepository = usersRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        public IActionResult GetUsers()
        {
            var users = _usersRepository.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }

        [HttpGet("{userName}")]
        public IActionResult GetUser(string userName)
        {
            var user = _usersRepository.GetUser(userName);
            if (user == null)
                return NotFound("Not found user " + userName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromQuery] string username, [FromQuery] string password)
        {
            
            var user = _usersRepository.GetUser(username);
            if (user != null)
                return BadRequest("There is user with same username" );
            var users = _usersRepository.CreateUser(username, password);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }
    }
}
