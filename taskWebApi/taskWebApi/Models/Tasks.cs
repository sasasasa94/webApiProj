namespace taskWebApi.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime datetask { get; set; }
        public bool done { get; set; }
        public ToDoList toDoList { get; set; }
       
    }
}
