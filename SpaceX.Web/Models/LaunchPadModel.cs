namespace SpaceX.Web.Models
{
    /// <summary>
    /// model used to transfer the item from a service model, to the controller model.
    /// </summary>
    public class LaunchPadModel
    {
        public LaunchPadModel() { }

        public LaunchPadModel(string id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

    }
}
