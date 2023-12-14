// OptionHub.cs
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace QuestionFC.Hubs;



public class OptionHub : Hub
{
    public async Task SendOption(string optionText)
    {
        await Clients.All.SendAsync("ReceiveOption", optionText);
    }

    // Ajoutez d'autres méthodes de hub au besoin
}
