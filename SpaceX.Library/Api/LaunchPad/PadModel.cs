using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// launch pad json model.
    /// </summary>
    public class PadModel
    {
        [JsonProperty("padid")]
        public int PadId { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        //[JsonProperty("name")]
        [JsonProperty("full_name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("attempted_launches")]
        public long AttemptedLaunches { get; set; }
        [JsonProperty("successful_launches")]
        public long SuccessfulLaunches { get; set; }
        [JsonProperty("wikipedia")]
        public string Wikipedia { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
        [JsonProperty("location")]
        public LocationModel Location { get; set; }
        [JsonProperty("vehicles_launched")]
        public List<string> VehiclesLaunched { get; set; }
    }
}
