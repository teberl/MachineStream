using MachineStream.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineStream.Web.Data
{
    public class MachineEventsContext : DbContext
    {
        public MachineEventsContext(DbContextOptions<MachineEventsContext> options) : base(options)
        {
        }

        public DbSet<MachineEvent> MachineEvents { get; set; }
    }
}