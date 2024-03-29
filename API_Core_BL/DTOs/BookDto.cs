﻿using System;
using System.Collections.Generic;

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
