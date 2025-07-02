using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class SIoTHub : Hub
{
    // Diese Methode wird VON DER MIDDLEWARE aufgerufen, um Daten AN ALLE WEB-CLIENTS zu senden.
    public async Task ReceiveDeviceData(string topic, string payload)
    {
        // "UpdateData" ist der Name des Events, auf das die Web-Clients (z.B. JavaScript) lauschen.
        await Clients.All.SendAsync("UpdateData", topic, payload);
    }

    // Diese Methode wird VOM WEB-CLIENT (z.B. JavaScript) aufgerufen, um einen Befehl AN DIE MIDDLEWARE zu senden.
    public async Task SendCommandToDevice(string deviceId, string command)
    {
        // Ruft die Methode "SendCommandToDevice" auf dem verbundenen Client (unserer Middleware) auf.
        // Wir gehen davon aus, dass nur ein Client (die Middleware) auf dieses Ereignis lauscht.
        // Für komplexere Szenarien könnte man die Verbindungs-ID der Middleware speichern.
        await Clients.All.SendAsync("SendCommandToDevice", deviceId, command);
    }
}