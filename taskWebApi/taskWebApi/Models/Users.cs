using System.ComponentModel.DataAnnotations;
using taskWebApi.Dto;

namespace taskWebApi.Models
{
    public class Users
    {
        // public int Id { get; set; }
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public ICollection<ToDoList> toDoList { get; set; }
    }
}
