using taskWebApi.Models;

namespace taskWebApi.Dto
{
    public class TasksDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime datetask { get; set; }
        public bool done { get; set; }
    }
}
