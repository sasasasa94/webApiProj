using taskWebApi.Models;

namespace taskWebApi.Dto
{
    public class ToDoListDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateProperties { get; set; }
    }
}
