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
            //reaches back to redis cache to check if it exists first.
            RedisCacheManager cache = new RedisCacheManager();
            var pads = cache.GetCache<List<PadModel>>("GetPads");

            //if it doesn't, it pulls from the service.
            if (pads == null)
            {
                pads = _launch.GetPads();
                //adds items to cache.
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
            //checks cache first to see if item exists
            RedisCacheManager cache = new RedisCacheManager();
            var pad = cache.GetCache<PadModel>("GetPad-" + id);

            //if it doesn't exist in cache, it gets item from service
            if (pad == null)
            {
                pad = _launch.GetPad(id);
                // then adds current item to cache.
                cache.AddCache(pad, "GetPad-" + id);
            }

            return pad;
        }
    }
}
