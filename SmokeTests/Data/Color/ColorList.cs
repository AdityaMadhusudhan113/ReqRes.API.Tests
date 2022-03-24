using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.Data.Color
{
    public partial class ColorList
    {

            public long Page { get; set; }
            public long PerPage { get; set; }
            public long Total { get; set; }
            public long TotalPages { get; set; }
            public List<ColorAttributes> Data { get; set; }
            public Support Support { get; set; }
        
    }
}
