using SampleWebAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleDbContext context;

        public UnitOfWork(SampleDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
