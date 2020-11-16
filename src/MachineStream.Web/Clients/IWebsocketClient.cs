using System.Threading;
using System.Threading.Tasks;

namespace MachineStream.Web.Clients
{
    public interface IWebsocketClient
    {
        Task ConnectAndReceive(CancellationToken stoppingToken);
    }
}