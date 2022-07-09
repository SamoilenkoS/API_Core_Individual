using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_DAL
{
    public interface IBookRevisionRepository
    {
        Task<IEnumerable<BookRevision>> GetAllAboutBook(Guid id);
    }
}