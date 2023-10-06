using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities
{
    public class Asset : Auditable
    {
        public long ChatId { get; set; }
        public Chat Chat { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}
