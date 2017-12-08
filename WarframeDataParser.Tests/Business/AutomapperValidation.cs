using AutoMapper;
using WarframeDataParser.Business;
using NUnit.Framework;

namespace WarframeDataParser.Tests.Business
{
    [TestFixture]
    public class AutomapperValidation {
        private IMapper _mapper;
        private MapperConfiguration _config;

        [SetUp]
        public void SetUp() {
            _config = new MapperConfiguration(opt => opt.AddProfile<AutomapperProfile>());
            _mapper = _config.CreateMapper();
        }

        [Test]
        public void Assert_Automapper_Profile() {
            _config.AssertConfigurationIsValid();
        }
    }
}
