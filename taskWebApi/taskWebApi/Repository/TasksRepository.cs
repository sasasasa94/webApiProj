using System.Collections.Generic;
using taskWebApi.Data;
using taskWebApi.Interfaces;
using taskWebApi.Models;

namespace taskWebApi.Repository
{
    public class TasksRepository : ITasksRepository
    {
        private readonly DataContext _context;
        public TasksRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateTask(Tasks tasks)
        {
            _context.Add(tasks);
            return Save();
        }

        public bool DeleteTask(Tasks tasks)
        {
            _context.Remove(tasks);
            return Save();
        }

        public ICollection<Tasks> GetLists()
        {
            throw new NotImplementedException();
        }

        public Tasks GetTask(int taskId)
        {
            return _context.Tasks.Where(o => o.Id == taskId).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTask(Tasks tasks)
        {
            _context.Update(tasks);
            return Save();
        }
    }
}
