using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.Data.User
{
    public partial class UserList
    {
      
            public long Page { get; set; }
            public long PerPage { get; set; }
            public long Total { get; set; }
            public long TotalPages { get; set; }
            public List<UserAttribute> Data { get; set; }
            public Support Support { get; set; }
        
    }
}
