﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Core_DAL.Entities
{
    public class BookRevision : BaseEntity
    {
        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public int PublishedCount { get; set; }
        public double LostPrice { get; set; }
    }
}
