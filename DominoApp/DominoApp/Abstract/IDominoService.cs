using System.Collections.Generic;

namespace DominoApp.Abstract
{
    public interface IDominoService
    {
        List<(int, int)> ParseInputs();

        bool ValidateAndDisplay(IEnumerable<(int, int)> data);
    }
}
