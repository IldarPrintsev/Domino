using System.Collections.Generic;
using System.Linq;

namespace DominoApp.Models
{
    public class StoneCollection
    {
        public StoneCollection(IEnumerable<(int, int)> dominoes)
        {
            foreach ((int, int) domino in dominoes)
                Stones.Add(new Stone(domino));
        }

        private StoneCollection(List<Stone> stones)
        {
            foreach (Stone stone in stones)
                this.Stones.Add(stone.DeepCopy());
        }

        public List<Stone> Stones { get; } = new List<Stone>();

        public Stone Grab(Stone stone)
        {
            Stones.Remove(stone);
            return stone;
        }

        public List<Stone> AllMatches(int dotsToMatchLeft, int dotsToMatchRight) =>
            Stones.Where(s =>
                dotsToMatchLeft == s.Dots.LeftSide ||
                dotsToMatchLeft == s.Dots.RightSide ||
                dotsToMatchRight == s.Dots.LeftSide ||
                dotsToMatchRight == s.Dots.RightSide)
            .ToList();

        public StoneCollection DeepCopy() => new(this.Stones);
    }
}
