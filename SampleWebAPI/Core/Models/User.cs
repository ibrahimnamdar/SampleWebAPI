using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Core.Models
{
    [Table("Users")]

    public class User
    {
        public int Id { get; set; }

        [EmailAddress]
        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [MinLength(6)]
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        
        [StringLength(255)]
        public string Firstname { get; set; }

        
        [StringLength(255)]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string CustomPropertyKey { get; set; }

        public string CustomPropertyValue { get; set; }

        public Department Department { get; set; }

        public int? DepartmentId { get; set; }
    }
}
