using System.Collections.Generic;
using System.Linq;
using MachineStream.Web.Data;
using MachineStream.Web.MachineInfos;
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

        public IEnumerable<MachineInfo> GetMachineInfos(MachineInfosFilter filter)
        {
            return _db.MachineEvents
                .Where(item => string.IsNullOrEmpty(filter.Status) || filter.Status == item.MachineInfo.Status)
                .Select(item => item.MachineInfo);
        }
    }
}