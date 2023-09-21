using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Messenger.Desktop.Models
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FriendName { get; set; }
        public string FriendMessage { get; set; }

        public DateTime CreatedAt = new DateTime();

        public DateTime UpdatedAt = new DateTime();
    }
}
