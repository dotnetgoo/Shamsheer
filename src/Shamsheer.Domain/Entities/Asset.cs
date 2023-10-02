using Shamsheer.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities
{
    public class Asset : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}
