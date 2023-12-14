// QuestionHub.cs
using Microsoft.AspNetCore.SignalR;
namespace QuestionFC.Hubs;
public class QuestionHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    // Ajoutez d'autres méthodes de hub au besoin
}
