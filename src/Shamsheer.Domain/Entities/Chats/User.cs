using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Chats
{
    public class User : Chat
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public ICollection<UserAsset> Assets { get; set; }
    }
}
