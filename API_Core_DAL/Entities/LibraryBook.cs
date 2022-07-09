using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_DAL.Entities
{
    public class LibraryBook : BaseEntity
    {
        [ForeignKey("Library")]
        public Guid LibraryId { get; set; }
        [ForeignKey("BookRevision")]
        public Guid RevisionId { get; set; }
        public int CountTotal { get; set; }
        public int CountBorrowed { get; set; }
        public Library Library { get; set; }
        public BookRevision BookRevision { get; set; }
    }
}
