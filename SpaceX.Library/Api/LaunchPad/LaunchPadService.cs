using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// launch pad service that reaches back to spacex.
    /// </summary>
    public class LaunchPadService : ILaunchPadService
    {
        string _padsApiUrl = "https://api.spacexdata.com/v{0}/launchpads";

        private int _version { get; set; }
        /// <summary>
        /// service for connecting to space x launch pad api
        /// </summary>
        /// <param name="version">version of api to use.</param>
        public LaunchPadService(int version)
        {
            _version = version;
        }
        /// <summary>
        /// gets all the pads from the api
        /// </summary>
        /// <returns></returns>
        public List<PadModel> GetPads()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(string.Format(_padsApiUrl, _version));
            var pads = JsonConvert.DeserializeObject<List<PadModel>>(json);

            return pads;
        }
        /// <summary>
        /// gets 1 pad from the api.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PadModel GetPad(int id)
        {
            var pads = GetPads();
            return pads.FirstOrDefault(x => x.PadId == id);
        }
    }
}
