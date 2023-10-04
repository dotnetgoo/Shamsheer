using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities
{
    public class User : Auditable
    {
        [Required]
        [MinLength(1), MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(5), MaxLength(32)]
        public string Username { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MinLength(8), MaxLength(64)]
        public string Password { get; set; }
        
        public UserRole Role { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
