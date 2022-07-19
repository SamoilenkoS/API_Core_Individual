using API_Core_BL.DTOs;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.ClientService
{
    public interface IClientService
    {
        Task<Client> GetClientByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Guid> AddClientAsync(Client client);
        Task<bool> DeleteClientAsync(Guid id);
        Task<bool> UpdateClientAsync(Client client);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
