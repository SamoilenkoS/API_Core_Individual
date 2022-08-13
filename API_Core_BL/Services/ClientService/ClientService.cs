using API_Core_BL.DTOs;
using API_Core_BL.Services.PasswordSecurityService;
using API_Core_BL.Services.TokenService;
using API_Core_DAL;
using API_Core_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Core_BL.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;
        private readonly IConfiguration _configuration;
        private readonly string _salt;

        public ClientService(
            IGenericRepository<Client> clientRepository,
            ITokenService tokenService, IPasswordService passwordService, IConfiguration configuration
            )
        {
            _clientRepository = clientRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _configuration = configuration;
            _salt = _configuration["SecuritySettings:Salt"];
        }

        public async Task<Guid> AddClientAsync(Client client)
        {
            
            client.Password = _passwordService.PasswordHashing(client.Password,
                _salt);
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
            var client = (await _clientRepository.GetByPredicateEnumerable(x =>
            x.Email == loginDto.Email)).FirstOrDefault();

            if (client != null)
            {
                bool samePassword = _passwordService.ValidatePassword(loginDto.Password,
                    client.Password, _salt);
                if (samePassword)
                {
                    return _tokenService.GenerateToken(client.Email, "Reader");
                }
            }

            return string.Empty;
        }
    }
}
