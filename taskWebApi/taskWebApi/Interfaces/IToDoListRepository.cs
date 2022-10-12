using taskWebApi.Models;

namespace taskWebApi.Interfaces
{
    public interface IToDoListRepository
    {
        ICollection<ToDoList> GetLists();
        bool CreateList(ToDoList toDoList);
        bool UpdateList(ToDoList toDoList);
        bool DeleteList(ToDoList toDoList);
        ToDoList GetList(int listId);
        bool Save();
    }
}
