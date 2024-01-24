using Microsoft.Extensions.DependencyInjection;
using RubiksCubeShared;
using RubiksCubeShared.Interfaces;

namespace RubiksCubeTests
{
    public class RubiksCubePrintTests
    {
        private IRubiksCube rubiksCube;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection()
                .AddTransient<IRubiksCube, RubiksCube>()
                .BuildServiceProvider();
            rubiksCube = services.GetRequiredService<IRubiksCube>();
        }

        [Test]
        public void BaseCubePrintsCorrectly()
        {
            rubiksCube.PrintCube();
            Assert.Pass();
        }
    }
}