using System.Collections.Generic;

namespace SpaceX.Web.Models
{
    /// <summary>
    /// base class for all models.
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// item to return in the api
        /// </summary>
        public object Item { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
