using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpaceX.Library.Cache;
using SpaceX.Library.Settings;
using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// launch pad manager
    /// </summary>
    public class LaunchPadManager : ILaunchPadManager
    {

        private readonly AppSettings _appSettings;
        private readonly ILaunchPadService _launch;
        readonly ILogger<LaunchPadManager> _log;
        public LaunchPadManager(IOptions<AppSettings> appSettings, ILogger<LaunchPadManager> log, ILaunchPadService launch)
        {
            _appSettings = appSettings.Value;
            _log = log;
            _launch = launch;
        }
        
        /// <summary>
        /// gets the pads for launch
        /// </summary>
        /// <returns></returns>
        public List<PadModel> GetPads()
        {
            RedisCacheManager cache = new RedisCacheManager();
            var pads = cache.GetCache<List<PadModel>>("GetPads");

            if (pads == null)
            {
                pads = _launch.GetPads();
                cache.AddCache(pads, "GetPads");
            }
            _log.LogInformation("GOT All Launch Pads " + _appSettings.SpaceXApiVersion);
            return pads;
        }
        /// <summary>
        /// gets 1 pad for launch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PadModel GetPad(int id)
        {
            RedisCacheManager cache = new RedisCacheManager();
            var pad = cache.GetCache<PadModel>("GetPad-" + id);

            if (pad == null)
            {
                pad = _launch.GetPad(id);

                cache.AddCache(pad, "GetPad-" + id);
            }

            return pad;
        }
    }
}
