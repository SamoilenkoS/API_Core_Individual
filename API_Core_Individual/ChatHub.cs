using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using API_Core_BL.DTOs;
using API_Core_BL.Services.ClientService;
using System.Collections.Generic;
using System;
using API_Core;

namespace API_Core_Individual
{
    public class ChatHub : Hub, IServerHub
    {
        private IClientService _clientService;
        private static HashSet<string> _usersID;

        static ChatHub()
        {
            _usersID = new HashSet<string>();
        }

        public ChatHub(IClientService clientService)
        {
            _clientService = clientService;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _usersID.Remove(Context.ConnectionId);

            return Task.CompletedTask;
        }

        public async Task SendMessageAsync(string message)
        {
            if (_usersID.Contains(Context.ConnectionId))
            {
                await Clients.Others.SendAsync("ReceiveMessage", message);
            }
        }

        public async Task<bool> LoginAsync(string login, string pass)
        {
            bool result = false;
            var loginDto = new LoginDto
            {
                Email = login,
                Password = pass
            };

            var token = await _clientService.LoginAsync(loginDto);

            if (!string.IsNullOrEmpty(token))
            {
                _usersID.Add(Context.ConnectionId);
                result = true;
            }

            return result;
        }
    }
}
