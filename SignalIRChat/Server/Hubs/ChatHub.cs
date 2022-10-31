using Microsoft.AspNetCore.SignalR;

namespace SignalIRChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await AddMessageToChat("", "The user is connected");
            await base.OnConnectedAsync();
        }

        public async Task AddMessageToChat(string user, string message)
        {
            // El 1er parametro es para identificar el tipo de mensaje en el servidor
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
