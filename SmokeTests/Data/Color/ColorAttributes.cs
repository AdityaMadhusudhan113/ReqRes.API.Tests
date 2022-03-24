using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.Data.Color
{
    public partial class ColorAttributes
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }
    }
}
