
namespace TestBlazorWASM.Server;

public class ChatHub:Hub
{

    public async Task BroadCast(NotificationMessage message) => await Clients.All.SendAsync("BroadCast",message);

}
