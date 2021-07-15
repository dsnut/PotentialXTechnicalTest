using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PotentialXTestWeb.Hubs
{
    public class EventHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
