using System;
using System.Threading.Tasks;

namespace API_Core
{
    public interface IServerHub
    {
        Task<bool> LoginAsync(string login, string pass);
        Task SendMessageAsync(string message);
    }
}
