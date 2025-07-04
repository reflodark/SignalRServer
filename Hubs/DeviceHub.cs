
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class SIoTHub : Hub<IDeviceHub>
{
    public async Task SendMessage(string user, string message)
        => await Clients.All.ReceiveMessage(user, message);

    public async Task SendMessageToCaller(string user, string message)
        => await Clients.Caller.ReceiveMessage(user, message);

    public async Task SendMessageToGroup(string user, string message)
        => await Clients.Group("SIoTUsers").ReceiveMessage(user, message);
}