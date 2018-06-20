using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Controllers.Resources
{
    public class DepartmentResource
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<UserResource> Users { get; set; }

        public DepartmentResource()
        {
            Users = new Collection<UserResource>();
        }
    }
}
