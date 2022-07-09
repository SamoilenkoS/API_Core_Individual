﻿using API_Core_BL.DTOs;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_BL.DTOs
{
    public class BookDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public IEnumerable<BookRevisionDto> BookRevisions { get; set; }
    }
}
