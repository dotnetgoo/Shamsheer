using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shamsheer.Domain.Entities.Chats
{
    public class UserGroup : Auditable
    {

        public long MemberId { get; set; }
        public User Member { get; set; }

        public long GroupId { get; set; }
        public Group Group { get; set; }
        public long RoleId { get; set; }
        public GroupRole Role { get; set; }

    }
}
