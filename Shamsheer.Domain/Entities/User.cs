using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shamsheer.Domain.Enums;
using Shamsheer.Domain.Commons;
using System.Collections.Generic;


namespace Shamsheer.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
