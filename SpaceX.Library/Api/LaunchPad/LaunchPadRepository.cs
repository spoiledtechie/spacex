using System;
using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// launch pad repository to be switched out with the service when the api service is placed into the database
    /// </summary>
    public class LaunchPadRepository : ILaunchPadService
    {
        public PadModel GetPad(int id)
        {
            throw new NotImplementedException();
        }

        public List<PadModel> GetPads()
        {
            throw new NotImplementedException();
        }
    }
}
