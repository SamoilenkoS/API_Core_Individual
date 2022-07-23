using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Api_Core_Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HubConnection connection;
            connection = new HubConnectionBuilder()
              .WithUrl("https://localhost:5001/chat")
              .Build();
            connection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            await connection.StartAsync();

            string input;
            do
            {
                input = Console.ReadLine();
                await connection.InvokeAsync("SendMessage", input);
            } while (!string.IsNullOrEmpty(input));
        }
    }
}
