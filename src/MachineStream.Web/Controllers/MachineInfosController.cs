using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MachineStream.Web.Data;
using MachineStream.Web.Models;
using MachineStream.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineStream.Web.Controllers
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
        public ActionResult<MachineInfosResponse> Get(string status)
        {
            var result = string.IsNullOrEmpty(status)
                ? _machineEventsService.GetMachineInfos()
                : _machineEventsService.GetMachineInfoByStatus(status);

            return new MachineInfosResponse { Items = result.ToList() };
        }
    }
}
