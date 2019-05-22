using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SpaceX.Library.Api.LaunchPad
{
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

        public List<PadModel> GetPads()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(string.Format(_padsApiUrl, _version));
            var pads = JsonConvert.DeserializeObject<List<PadModel>>(json);

            return pads;
        }

        public PadModel GetPad(int id)
        {
            var pads = GetPads();
            return pads.FirstOrDefault(x => x.PadId == id);
        }
    }
}
