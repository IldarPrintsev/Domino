namespace DominoApp.Models
{
    public class Chain
    {
        public Chain()
        {
            CurrentLeftStone = Stone.Invalid;
            CurrentRightStone = Stone.Invalid;
        }

        private Chain(Stone leftStone, Stone rightStone)
        {
            CurrentLeftStone = leftStone;
            CurrentRightStone = rightStone;
        }

        public Stone CurrentLeftStone { get; private set; }
        public Stone CurrentRightStone { get; private set; }
        public int OuterLeftDots { get => CurrentLeftStone.Dots.LeftSide; }
        public int OuterRightDots { get => CurrentRightStone.Dots.RightSide; }
        public bool EndsMatch { get => OuterLeftDots == OuterRightDots; }

        public bool AddNeighbor(Stone newStone)
        {
            if (CurrentLeftStone == Stone.Invalid)
            {
                CurrentLeftStone = newStone;
                CurrentRightStone = newStone;
                return true;
            }

            if (AddNeighborToLeft(newStone) || AddNeighborToRight(newStone))
            {
                return true;
            }
                
            newStone.Flip();

            return AddNeighborToLeft(newStone) || AddNeighborToRight(newStone);
        }

        public Chain DeepCopy() =>
            new(CurrentLeftStone.DeepCopy(), CurrentRightStone.DeepCopy());

        private bool AddNeighborToLeft(Stone newStone)
        {
            if (StonesMatch(newStone, CurrentLeftStone))
            {
                CurrentLeftStone = newStone;
                return true;
            }

            return false;
        }

        private bool AddNeighborToRight(Stone newStone)
        {
            if (StonesMatch(CurrentRightStone, newStone))
            {
                CurrentRightStone = newStone;
                return true;
            }

            return false;
        }

        private static bool StonesMatch(Stone leftStone, Stone rightStone) =>
            leftStone.Dots.RightSide == rightStone.Dots.LeftSide;
    }
}
