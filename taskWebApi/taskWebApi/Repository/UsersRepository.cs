using Microsoft.EntityFrameworkCore;
using System.Linq;
using taskWebApi.Data;
using taskWebApi.Dto;
using taskWebApi.Interfaces;
using taskWebApi.Models;

namespace taskWebApi.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(string user, string pass)
        {
            var user1 = new Users()
            {
                username = user,
                password = pass,
            };
            _context.Users.Add(user1);
            return Save();
        }

        public Users GetUser(string userNameId)
        {
            //return _context.Users.Where(c=>c.username==userNameId).FirstOrDefault();
            return _context.Users.Where(r => r.username == userNameId).Include(e => e.toDoList).ThenInclude(list => list.tasks).FirstOrDefault();
        }

        public  ICollection<Users> GetUsers()
        {
            //return  _context.Users.Include(user => user.toDoList).OrderBy(p => p.username).ToList();
            return _context.Users.Include(user => user.toDoList).ThenInclude(list=>list.tasks).ToList();
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
