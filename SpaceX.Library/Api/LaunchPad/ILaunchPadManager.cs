using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    /// <summary>
    /// manager for launch pad
    /// </summary>
    public interface ILaunchPadManager
    {
        PadModel GetPad(int id);
        List<PadModel> GetPads();
    }
}