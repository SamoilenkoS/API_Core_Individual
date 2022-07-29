using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API_Core_Individual
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}
