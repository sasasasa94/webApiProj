using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using taskWebApi.Dto;
using taskWebApi.Interfaces;
using taskWebApi.Models;
using taskWebApi.Repository;

namespace taskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IMapper _mapper;
        public TasksController(ITasksRepository tasksRepository, IToDoListRepository toDoListRepository, IMapper mapper)
        {
            this._tasksRepository = tasksRepository;
            this._toDoListRepository = toDoListRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreateTask([FromQuery] int listId, [FromBody] TasksDto taskCreate)
        {
            var taskMap = _mapper.Map<Tasks>(taskCreate);
            taskMap.toDoList = _toDoListRepository.GetList(listId);

            if(taskMap.toDoList==null)
                return NotFound("Not found listId "+listId);

            if (!_tasksRepository.CreateTask(taskMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{taskId}")]
        public IActionResult UpdateTasks(int taskId, [FromBody] TasksDto taskUpadate)
        {

            var taskMap = _mapper.Map<Tasks>(taskUpadate);
            var task = _tasksRepository.GetTask(taskId);
            taskMap.Id = taskId;
            if (task == null)
                return NotFound("Not found listId " + taskId);

            if (!_tasksRepository.UpdateTask(taskMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteTask(int taskId)
        {

            var taskToDelete = _tasksRepository.GetTask(taskId);
            if(taskToDelete == null)
                return NotFound("Not found listId " + taskId);

            if (!_tasksRepository.DeleteTask(taskToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
