using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;
using taskWebApi.Dto;
using taskWebApi.Interfaces;
using taskWebApi.Models;
using taskWebApi.Repository;

namespace taskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public ToDoListController(IToDoListRepository toDoListRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            this._toDoListRepository = toDoListRepository;
            this._usersRepository = usersRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateList([FromQuery ] string userNameId, [FromBody] ToDoListDto listCreate)
        {
            var listmap =_mapper.Map<ToDoList>(listCreate);
            listmap.users = _usersRepository.GetUser(userNameId);
            if (listmap.users == null)
                return NotFound("Not found username " + userNameId);

            if (!_toDoListRepository.CreateList(listmap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{toDoListId}")]
        public IActionResult UpdateList(int toDoListId, [FromBody] ToDoListDto listUpdate)
        {

            var listMap = _mapper.Map<ToDoList>(listUpdate);
            var list = _toDoListRepository.GetList(toDoListId);
            listMap.Id = toDoListId;           
            if (list == null)
                return NotFound("Not found listId " + toDoListId);


            if (!_toDoListRepository.UpdateList(listMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteList(int listid)
        {
            var listToDelete = _toDoListRepository.GetList(listid);
            if (listToDelete == null)
                return NotFound("Not found listId " + listid);

            if (!_toDoListRepository.DeleteList(listToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
