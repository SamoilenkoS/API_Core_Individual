using API_Core_BL.Services.ClientService;
using API_Core_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_Individual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientService _clientService;

        public ClientsController(
            IClientService clientService,
            ILogger<ClientsController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            _logger.LogInformation("Called get all clients");

            return await _clientService.GetAllClientsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Client> GetClientById(Guid id)
        {
            return await _clientService.GetClientByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateClient(Guid id, Client client)
        {
            client.Id = id;

            return await _clientService.UpdateClientAsync(client);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteClient(Guid id)
        {
            return await _clientService.DeleteClientAsync(id);
        }

        [HttpPost]
        public async Task<Guid> CreateClient(Client client)
        {
            return await _clientService.AddClientAsync(client);
        }
    }
}
