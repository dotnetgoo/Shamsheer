using Shamsheer.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities
{
    public class MessageContent : Auditable
    { 
        public string Text { get; set; }

        public long FileId { get; set; }
    }
}
