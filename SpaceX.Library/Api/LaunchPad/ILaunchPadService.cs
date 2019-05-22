using System.Collections.Generic;

namespace SpaceX.Library.Api.LaunchPad
{
    public interface ILaunchPadService
    {
        
        PadModel GetPad(int id);
        List<PadModel> GetPads();
    }
}