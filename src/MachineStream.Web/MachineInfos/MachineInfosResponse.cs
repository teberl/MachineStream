using MachineStream.Web.Models;

namespace MachineStream.Web.MachineInfos
{
    public class MachineInfosResponse
    {
        public MachineInfosResponse(MachineInfo[] items)
        {
            Items = items;
        }

        public MachineInfo[] Items {get; }
    }
}