using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Domain.Entities.Chats
{
    public abstract class Chat : Auditable
    {
        public string Description { get; set; }
        public string Username { get; set; }
        public ChatType ChatType { get; set; }
    }
}
