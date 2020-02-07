using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
