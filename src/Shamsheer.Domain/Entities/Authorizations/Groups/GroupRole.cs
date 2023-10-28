using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Domain.Entities.Authorizations.Groups
{
    public class GroupRole : Auditable
    {
        public ChatRole ChatRole { get; set; }

    }
}
