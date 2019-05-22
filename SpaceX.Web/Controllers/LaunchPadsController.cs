using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpaceX.Library.Api.LaunchPad;
using SpaceX.Library.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceX.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchPadsController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ILaunchPadService _launch;
        readonly ILogger<LaunchPadsController> _log;
        private ILaunchPadManager _manager;

        public LaunchPadsController(IOptions<AppSettings> appSettings,
            ILogger<LaunchPadsController> log,
            ILaunchPadService launch,
            ILaunchPadManager manager)
        {
            _appSettings = appSettings.Value;
            _log = log;
            _launch = launch;
            _manager = manager;
        }


        //TODO: AUTHORIZE ATTRIBUTE
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _log.LogInformation("Get All Launch Pads " + _appSettings.SpaceXApiVersion);

                List<PadModel> pads = _manager.GetPads();

                return JsonConvert.SerializeObject(pads.Select(x => new { x.Id, x.Name, x.Status }).ToList());

            }
            catch (Exception exception)
            {
                _log.LogError(exception, "Get All Error ");
                return "Error: Exception occurred, Error Logged. " + exception.Message;
            }

        }


        //TODO: AUTHORIZE ATTRIBUTE
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id == 0)
                    return "Error: Id needs to be larger than 0";

                _log.LogInformation("Get Launch Pads " + id);
                PadModel pad = _manager.GetPad(id);

                dynamic dynPad = new { pad.Id, pad.Name, pad.Status };

                _log.LogInformation("GOT Launch Pads " + id);
                return JsonConvert.SerializeObject(dynPad);
            }
            catch (Exception exception)
            {
                _log.LogError(exception, "Get Error: " + id);
                return "Error: Exception occurred, Error Logged. " + exception.Message;
            }


        }


    }
}
