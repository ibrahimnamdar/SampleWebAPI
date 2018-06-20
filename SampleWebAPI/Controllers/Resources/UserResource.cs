using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Controllers.Resources
{
    public class UserResource : KeyValuePairUserResource
    {  
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }

        public string Address { get; set; }

        public int? DepartmentId { get; set; }

        public string CustomPropertyKey { get; set; }

        public string CustomPropertyValue { get; set; }
    }
}
