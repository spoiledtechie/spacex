using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpaceX.Library.Api.LaunchPad;
using SpaceX.Library.Settings;
using SpaceX.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceX.Web.Controllers
{
    /// <summary>
    /// launch pad controller for the api.
    /// </summary>
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
        /// <summary>
        /// gets all the launch pads within the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            ResponseListModel model = new ResponseListModel();
            try
            {
                _log.LogInformation("Get All Launch Pads " + _appSettings.SpaceXApiVersion);

                List<PadModel> pads = _manager.GetPads();

                model.IsSuccess = true;
                model.Items = pads.Select(x => new LaunchPadModel { Id = x.Id, Name = x.Name, Status = x.Status }).Cast<object>().ToList();

                return JsonConvert.SerializeObject(model);
            }
            catch (Exception exception)
            {
                _log.LogError(exception, "Get All launch pads Error ");
                model.IsSuccess = false;
                model.Message = "Error: Exception occurred, Error Logged. " + exception.Message;

                return JsonConvert.SerializeObject(model);
            }

        }


        //TODO: AUTHORIZE ATTRIBUTE
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                if (id == 0)
                {
                    model.IsSuccess = false;
                    model.Message = "Error: Id needs to be larger than 0";
                    return JsonConvert.SerializeObject(model);
                }
                _log.LogInformation("Get Launch Pads " + id);
                PadModel pad = _manager.GetPad(id);

                model.IsSuccess = true;
                model.Item = new LaunchPadModel(pad.Id, pad.Name, pad.Status) as object;

                _log.LogInformation("GOT Launch Pads " + id);

                return JsonConvert.SerializeObject(model);
            }
            catch (Exception exception)
            {
                _log.LogError(exception, "Get Error: " + id);
                model.IsSuccess = false;
                model.Message = "Error: Exception occurred, Error Logged. " + exception.Message;

                return JsonConvert.SerializeObject(model);
            }


        }


    }
}
