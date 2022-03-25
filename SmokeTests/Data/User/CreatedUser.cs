using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.Data.User
{
    public partial class CreatedUser
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
