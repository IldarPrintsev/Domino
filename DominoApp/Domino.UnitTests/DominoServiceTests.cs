using DominoApp.Concrete;
using System.Collections.Generic;
using Xunit;

namespace DominoApp.UnitTests
{
    public class DominoServiceTests
    {
        private DominoService service = new ();

        [Fact]
        public void DominoServiceTest_Ok()
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
    }
}
