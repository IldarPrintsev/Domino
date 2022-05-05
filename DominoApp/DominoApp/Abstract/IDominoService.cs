using DominoApp.Models;
using System.Collections.Generic;

namespace DominoApp.Abstract
{
    public interface IDominoService
    {
        List<(int, int)> ParseInputs();

        Chain GetChain(IEnumerable<(int, int)> data);

        void Display(Chain chain);
    }
}
