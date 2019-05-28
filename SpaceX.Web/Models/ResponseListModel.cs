using System.Collections.Generic;

namespace SpaceX.Web.Models
{
    /// <summary>
    /// base class for all lists of models.
    /// </summary>
    public class ResponseListModel
    {
        /// <summary>
        /// list of items to return in the api.
        /// </summary>
        public List<object> Items { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
