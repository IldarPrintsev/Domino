using System.Collections.Generic;

namespace DominoApp.Models
{
    public class Chain
    {
        public Chain()
        {
            Nodes = new LinkedList<Stone>(new List<Stone>{Stone.Invalid});
        }

        private Chain(LinkedList<Stone> stones)
        {
            Nodes = new LinkedList<Stone>(stones);
        }

        public int OuterLeftDots { get => Nodes.First.Value.Dots.LeftSide; }
        public int OuterRightDots { get => Nodes.Last.Value.Dots.RightSide; }
        public bool EndsMatch { get => OuterLeftDots == OuterRightDots && OuterLeftDots != -1; }
        public LinkedList<Stone> Nodes { get; private set; }

        public bool AddNeighbor(Stone newStone)
        {
            if (Nodes.Last.Value == Stone.Invalid)
            {
                Nodes.Last.Value = newStone;
                return true;
            }

            if (AddNeighborToLeft(newStone) || AddNeighborToRight(newStone))
            {
                return true;
            }
                
            newStone.Flip();

            return AddNeighborToLeft(newStone) || AddNeighborToRight(newStone);
        }

        public Chain DeepCopy() => new(Nodes);

        private bool AddNeighborToLeft(Stone newStone)
        {
            if (StonesMatch(newStone, Nodes.First.Value))
            {
                Nodes.AddFirst(new LinkedListNode<Stone>(newStone));
                return true;
            }

            return false;
        }

        private bool AddNeighborToRight(Stone newStone)
        {
            if (StonesMatch(Nodes.Last.Value, newStone))
            {
                Nodes.AddLast(new LinkedListNode<Stone>(newStone));
                return true;
            }

            return false;
        }

        private static bool StonesMatch(Stone leftStone, Stone rightStone) =>
            leftStone.Dots.RightSide == rightStone.Dots.LeftSide;
    }
}
