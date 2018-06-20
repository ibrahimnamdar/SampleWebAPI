using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Persistence
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {

        }
    }
}
