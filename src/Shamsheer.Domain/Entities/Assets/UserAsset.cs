using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Domain.Entities.Assets
{
    public class UserAsset : Asset
    {
        public long? UserId { get; set; }
        public User User { get; set; }
    }
}