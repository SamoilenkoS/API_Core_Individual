using System;
using System.ComponentModel.DataAnnotations;

namespace API_Core_DAL
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PagesCount { get; set; }
    }
}