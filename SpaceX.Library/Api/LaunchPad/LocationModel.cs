using Newtonsoft.Json;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// laucnh pad location model
    /// </summary>
    public class LocationModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

    }
}
