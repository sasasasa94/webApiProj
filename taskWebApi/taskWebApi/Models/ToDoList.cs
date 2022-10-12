using System.Data;

namespace taskWebApi.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateProperties { get;  set; }
        public ICollection<Tasks> tasks { get; set; }
        public Users users { get; set; }
    }
}
