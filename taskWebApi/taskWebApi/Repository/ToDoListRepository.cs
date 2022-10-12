using Microsoft.EntityFrameworkCore;
using taskWebApi.Data;
using taskWebApi.Interfaces;
using taskWebApi.Models;

namespace taskWebApi.Repository
{
    public class ToDoListRepository:IToDoListRepository
    {
        private readonly DataContext _context;
        public ToDoListRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateList(ToDoList toDoList)
        {
            _context.Add(toDoList);
            return Save();
        }

        public bool DeleteList(ToDoList toDoList)
        {
            _context.Remove(toDoList);
            return Save();
        }

        public ICollection<ToDoList> GetLists()
        {
            return _context.ToDoList.Include(user => user.tasks).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateList(ToDoList toDoList)
        {
            _context.Update(toDoList);
            return Save();
        }

        public ToDoList GetList(int listId)
        {
            return _context.ToDoList.Where(o => o.Id == listId).FirstOrDefault();
        }
    }
}
