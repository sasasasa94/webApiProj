using AutoMapper;
using taskWebApi.Dto;
using taskWebApi.Models;

namespace taskWebApi.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ToDoListDto, ToDoList>();
            CreateMap<ToDoList,ToDoListDto>();
            CreateMap<Tasks,TasksDto>();
            CreateMap<TasksDto,Tasks>();
        }
    }
}
