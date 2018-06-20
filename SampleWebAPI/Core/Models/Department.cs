using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Core.Models
{
    [Table("Departments")]

    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Department()
        {
            Users = new Collection<User>();
        }
    }
}
