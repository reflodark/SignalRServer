public interface IDeviceHub
{
    Task ReceiveMessage(string user, string message);
}