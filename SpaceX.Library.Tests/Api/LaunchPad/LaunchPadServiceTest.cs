using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SpaceX.Library.Api.LaunchPad;

namespace SpaceX.Library.Tests.Api.LaunchPad
{
    [TestClass]
    public class LaunchPadServiceTest
    {
        //TODO: Add Mock Tests
        [TestCategory("Mock")]
        [TestMethod]
        [DataRow(2, 2)]
        public void TestGetPadMock(int version, int id)
        {
            //TODO: didn't get totally working.

            //var mockery = new MockFactory();
            //var launchService = mockery.CreateMock<ILaunchPadManager>();

            //Expect.On<ILaunchPadManager>(launchService.MockObject).AtLeastOne
            //    .MethodWith(x => x.GetPad(id))
            //    .WillReturn(new PadModel() { PadId = id });

            //LaunchPadService service = new LaunchPadService(version);
            //var pad = service.GetPad(id);

            //Assert.IsTrue(pad.PadId == id, JsonConvert.SerializeObject(pad));
        }

        /// <summary>
        /// tests get pads from the api for v2 and 3
        /// </summary>
        /// <param name="version"></param>
        [TestCategory("Integration")]
        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        public void TestGetPads(int version)
        {
            LaunchPadService service = new LaunchPadService(version);
            var pads = service.GetPads();

            Assert.IsTrue(pads.Count > 0, JsonConvert.SerializeObject(pads));
        }


        [TestCategory("Integration")]
        [TestMethod]
        [DataRow(2, 1)]
        public void TestGetPad(int version, int id)
        {
            LaunchPadService service = new LaunchPadService(version);
            var pad = service.GetPad(id);

            Assert.IsNotNull(pad, JsonConvert.SerializeObject(pad));
            Assert.IsNotNull(pad.PadId == id, JsonConvert.SerializeObject(pad));
        }

    }
}
