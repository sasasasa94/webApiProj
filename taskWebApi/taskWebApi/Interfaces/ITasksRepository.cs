using taskWebApi.Models;

namespace taskWebApi.Interfaces
{
    public interface ITasksRepository
    {
        ICollection<Tasks> GetLists();
        bool CreateTask(Tasks tasks);
        bool UpdateTask(Tasks tasks);
        bool DeleteTask(Tasks tasks);
        Tasks GetTask(int taskId);
        bool Save();
    }
}
