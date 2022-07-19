using API_Core_BL.DTOs;
using API_Core_BL.Services.TokenService;
using API_Core_DAL;
using API_Core_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly ITokenService _tokenService;

        public ClientService(
            IGenericRepository<Client> clientRepository,
            ITokenService tokenService
            )
        {
            _clientRepository = clientRepository;
            _tokenService = tokenService;
        }

        public async Task<Guid> AddClientAsync(Client client)
        {
            return await _clientRepository.AddAsync(client);
        }

        public async Task<bool> DeleteClientAsync(Guid id)
        {
            return await _clientRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            return await _clientRepository.UpdateAsync(client);
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var client = await _clientRepository.GetByPredicate(x => 
            x.Email == loginDto.Email && x.Password == loginDto.Password)
                .FirstOrDefaultAsync();

            if(client != null)
            {
                return _tokenService.GenerateToken(client.Email, "Reader");
            }

            return string.Empty;
        }
    }
}
