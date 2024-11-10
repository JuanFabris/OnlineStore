using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class QueryObject
    {
        public string? FavouriteFoot { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }

    }
}