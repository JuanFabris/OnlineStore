using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HelperToQuery
{
    public class QueryObject
    {
        public string? Brand { get; set; } = null;
        public string? Color { get; set; } = null;
        public string? Season { get; set; } = null;
        
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
    }
}