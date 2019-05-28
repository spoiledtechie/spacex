using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// service for launch pad
    /// </summary>
    public interface ILaunchPadService
    {
        PadModel GetPad(int id);
        List<PadModel> GetPads();
    }
}