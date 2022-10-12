using taskWebApi.Models;

namespace taskWebApi.Interfaces
{
    public interface IUsersRepository
    {
        ICollection<Users> GetUsers();
        Users GetUser(string userNameId);
        bool CreateUser(string user,string pass);
        bool Save();
    }
}
