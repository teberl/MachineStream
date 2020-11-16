using System.Linq;
using System.Net;
using MachineStream.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineStream.Web.MachineInfos
{
    [ApiController]
    [Route("[controller]")]
    public class MachineInfoController : ControllerBase
    {
        private readonly MachineEventsService _machineEventsService;
        public MachineInfoController(MachineEventsService machineEventsService)
        {
            _machineEventsService = machineEventsService;
        }

        [HttpGet]
        [Route("/machine-infos")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<MachineInfosResponse> Get([FromQuery] MachineInfosFilter filter)
        {
            var result = _machineEventsService.GetMachineInfos(filter)?.ToArray();

            return new MachineInfosResponse(result);
        }
    }
}
