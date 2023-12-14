// ReponseHub.cs
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace QuestionFC.Hubs;


public class ReponseHub : Hub
{
    public async Task SendReponse(string repondentName, string reponseText)
    {
        await Clients.All.SendAsync("ReceiveReponse", repondentName, reponseText);
    }

    // Ajoutez d'autres méthodes de hub au besoin
}
