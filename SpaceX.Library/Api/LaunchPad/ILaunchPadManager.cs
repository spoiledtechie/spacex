using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    public interface ILaunchPadManager
    {
        PadModel GetPad(int id);
        List<PadModel> GetPads();
    }
}