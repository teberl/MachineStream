using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MachineStream.Web.Data;
using MachineStream.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MachineStream.Web.Clients
{
    public class WebsocketClient : IWebsocketClient
    {
        private const string baseUrl = "ws://machinestream.herokuapp.com/ws";
        private const int receiveChunkSize = 256;
        private readonly ILogger _logger;
        private readonly MachineEventsContext _db;

        public WebsocketClient(ILogger<WebsocketClient> logger, MachineEventsContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task ConnectAndReceive(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ClientWebSocket client = null;
                try
                {
                    client = new ClientWebSocket();
                    await client.ConnectAsync(new Uri(baseUrl), CancellationToken.None);
                    await Receive(client);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception: {0}", ex);
                }
                finally
                {
                    client?.Dispose();
                }
            }
        }

        private async Task Receive(ClientWebSocket webSocket)
        {
            byte[] buffer = new byte[receiveChunkSize];
            while (webSocket.State == WebSocketState.Open)
            {
                var response = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (response.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    break;
                }

                var machineEvent = DeserializeResponse(buffer, response.Count);
                _logger.LogInformation("{Timestamp}: Received new event for machine:{Ids} => {Status}", DateTime.UtcNow, machineEvent.MachineInfo.Id, machineEvent.MachineInfo.Status);

                _db.MachineEvents.Attach(machineEvent);
                await _db.SaveChangesAsync();
                _logger.LogInformation("New event stored.");
            }
        }

        private static MachineEvent DeserializeResponse(byte[] eventResponse, int numberOfReceivedBytes)
        {
            byte[] copy = new byte[numberOfReceivedBytes];
            Array.Copy(eventResponse, copy, numberOfReceivedBytes);
            var bytesAsString = Encoding.UTF8.GetString(copy);

            return JsonSerializer.Deserialize<MachineEvent>(bytesAsString);
        }
    }
}