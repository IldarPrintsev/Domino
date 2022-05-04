namespace DominoApp.Models
{
    public struct Stone
    {
        public Stone((int LeftSide, int RightSide) dots)
        {
            Dots = dots;
        }

        public (int LeftSide, int RightSide) Dots { get; set; }

        public static readonly Stone Invalid = new((-1, -1));

        public void Flip() => Dots = (Dots.RightSide, Dots.LeftSide);

        public Stone DeepCopy() => new((this.Dots.LeftSide, this.Dots.RightSide));

        public static bool operator ==(Stone s1, Stone s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Stone s1, Stone s2)
        {
            return !s1.Equals(s2);
        }

        public override bool Equals(object obj)
        {
            var stone = (Stone)obj;

            return (this.Dots.LeftSide == stone.Dots.LeftSide
                && this.Dots.RightSide == stone.Dots.RightSide) ||
                (this.Dots.LeftSide == stone.Dots.RightSide
                && this.Dots.RightSide == stone.Dots.LeftSide);
        }

        public override int GetHashCode()
        {
            var result = Dots.LeftSide + Dots.RightSide;
            return result.GetHashCode();
        }
    }
}
