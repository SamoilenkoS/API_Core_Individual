using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_DAL.Entities
{
    public class LibraryRent : BaseEntity
    {
        [ForeignKey("Library")]
        public Guid LibraryId { get; set; }
        [ForeignKey("BookRevision")]
        public Guid BookRevisionId { get; set; }
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Library Library { get; set; }
        public BookRevision BookRevision { get; set; }
        public Client Client { get; set; }
    }
}
