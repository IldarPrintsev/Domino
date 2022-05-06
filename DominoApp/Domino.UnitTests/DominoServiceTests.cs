using DominoApp.Concrete;
using System.Collections.Generic;
using Xunit;

namespace DominoApp.UnitTests
{
    public class DominoServiceTests
    {
        private DominoService service = new ();

        [Fact]
        public void DominoServiceTest_True()
        {
            var data = new List<(int, int)>
            {
                (2, 1),
                (2, 3),
                (1, 3)
            };

            var result = service.GetChain(data);

            Assert.True(result.EndsMatch);
        }

        [Fact]
        public void DominoServiceTest_False()
        {
            var data = new List<(int, int)>
            {
                (2, 1),
                (2, 3),
                (4, 5)
            };

            var result = service.GetChain(data);

            Assert.False(result.EndsMatch);
        }

        [Fact]
        public void DominoServiceTestEmpty_False()
        {
            var data = new List<(int, int)>();

            var result = service.GetChain(data);

            Assert.False(result.EndsMatch);
        }
    }
}
