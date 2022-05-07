using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class CounterHub : Hub
{
    private static int _counter = 0;

    public void IncrementCounter()
    {
        _counter++;
        Clients.All.SendAsync("UpdateCounter", _counter);
    }
}