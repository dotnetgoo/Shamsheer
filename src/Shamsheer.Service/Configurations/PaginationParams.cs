using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Configurations
{
    public class PaginationParams
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 20;
    }
}
