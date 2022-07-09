using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_BL.DTOs
{
    public class BookRevisionDto
    {
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public int PublishedCount { get; set; }
        public double LostPrice { get; set; }
    }
}
