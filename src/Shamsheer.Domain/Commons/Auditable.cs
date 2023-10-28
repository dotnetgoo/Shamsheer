using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Commons
{
    public abstract class Auditable 
    {
        public long Id { get; set; }
        public long? DeletedBy { get; set; }
        public long? UpdatedBy { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
