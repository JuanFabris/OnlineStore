using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HelperToQuery
{
    public class ReviewQueryObject
    {
        public string Brand { get; set; } = string.Empty;
        public bool isDecsending { get; set; } = true;
    }
}