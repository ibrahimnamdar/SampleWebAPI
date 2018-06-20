using System.Collections.Generic;
using System.Threading.Tasks;
using SampleWebAPI.Core.Models;

namespace SampleWebAPI.Core
{
    public interface IUserRepository
    {
        Task<User> Login(string username, string password);

        Task<User> GetUser(int id);

        Task<List<User>> GetUserListByDepartment(int departmentId);

        void Add(User user);

        Task<User> GetSingleUserInDepartment(int id, int userId);
    }
}