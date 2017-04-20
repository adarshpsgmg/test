using Microsoft.AspNet.SignalR;

namespace SignalRTest.SignalR
{
    public class NotificationHub : Hub
    {
        public string Activate()
        {
            return "Monitor Activated";
        }
    }
}