using System.Collections.Generic;
using System.Linq;
using MachineStream.Web.Data;
using MachineStream.Web.Models;

namespace MachineStream.Web.Services
{
    public class MachineEventsService
    {
        private readonly MachineEventsContext _db;

        public MachineEventsService(MachineEventsContext db)
        {
            _db = db;
        }

        public IEnumerable<MachineInfo> GetMachineInfos()
        {
            return _db.MachineEvents.Select(e => e.MachineInfo);
        }

        public IEnumerable<MachineInfo> GetMachineInfoByStatus(string status)
        {
            return _db.MachineEvents.Where(e => e.MachineInfo.Status == status).Select(e => e.MachineInfo);
        }
    }
}