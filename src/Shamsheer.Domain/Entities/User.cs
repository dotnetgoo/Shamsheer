using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
