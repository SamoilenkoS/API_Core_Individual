using API_Core_BL.DTOs;
using API_Core_BL.Services.PasswordSecurityService;
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
        private readonly IPasswordService _passwordService;

        public ClientService(
            IGenericRepository<Client> clientRepository,
            ITokenService tokenService, IPasswordService passwordService
            )
        {
            _clientRepository = clientRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<Guid> AddClientAsync(Client client)
        {
            client.Salt = _passwordService.GenerateSalted();
            client.Password = _passwordService.PasswordHashing(client.Password,
                client.Salt);
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
            x.Email == loginDto.Email)
                .FirstOrDefaultAsync();
            if (client != null)
            {
                bool samePassword = _passwordService.ValidatePassword(loginDto.Password,
                    client.Password, client.Salt);
                if (samePassword)
                {
                    return _tokenService.GenerateToken(client.Email, "Reader");
                }
            }

            return string.Empty;
        }
    }
}
