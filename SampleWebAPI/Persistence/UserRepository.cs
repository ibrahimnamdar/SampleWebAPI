using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Core;
using SampleWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly SampleDbContext context;

        public UserRepository(SampleDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUserListByDepartment(int departmentId)
        {
            return await context.Users.Where(x => x.DepartmentId == departmentId).ToListAsync();
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public async Task<User> Login(string username, string password)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<User> GetSingleUserInDepartment(int id, int userId)
        {
            return await context.Users.Where(x => x.DepartmentId == id && x.Id == userId).SingleOrDefaultAsync();
        }
    }
}
