using API_Core;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Api_Core_Console
{
    class Program
    {
        static string _login;
        static string _pass;
        static async Task Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chat")
                .Build();

            connection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            await connection.StartAsync();

            bool successed;
            do
            {
                Console.WriteLine("Login");
                _login = Console.ReadLine();
                Console.WriteLine("Pass");
                _pass = Console.ReadLine();
                successed = await connection.InvokeAsync<bool>(nameof(IServerHub.LoginAsync), _login, _pass);
            } while (!successed);

            string input;
            do
            {
                input = Console.ReadLine();
                await connection.InvokeAsync(nameof(IServerHub.SendMessageAsync), input);
            } while (!string.IsNullOrEmpty(input));
        }
    }
}
