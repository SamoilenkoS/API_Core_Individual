using API_Core_BL.DTOs;
using API_Core_BL.Services.BooksService;
using API_Core_BL.Services.GenericService;
using API_Core_DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_Individual.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GenericController<T> : ControllerBase
        where T : BaseEntity, new()
    {
        private readonly ILogger<BooksController> _logger;
        private readonly GenericService<T> where T : BaseEntity _genericService;

        public GenericController(
            IGenericService genericService,
            ILogger<BooksController> logger)
        {
            _genericService = genericService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            _logger.LogInformation("Called get all");

            return await _genericService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(Guid id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(Guid id, T generic)
        {
            generic.Id = id;

            return await _genericService.UpdateAsync(generic);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(Guid id)
        {
            return await _genericService.DeleteAsync(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<Guid> CreateBook(Book book)
        {
            return await _genericService.AddAsync(book);
        }
    }
}
