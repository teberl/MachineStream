using System.Collections.Generic;
using MachineStream.Web.Models;

namespace MachineStream.Web.Controllers
{
    public class MachineInfosResponse
    {
        public IEnumerable<MachineInfo> Items {get; init;}
    }
}