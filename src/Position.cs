using System;

namespace TurtleChallenge
{
    public class Position : IEquatable<Position>{
        internal int x;
        internal int y;

        internal Position(){
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Position(int x, int y){
            this.X = x;
            this.Y = y;
        }

        public override string ToString(){
            return "X:" + X.ToString() + " Y:" + Y.ToString();
        }

        public bool Equals(Position other)
        {
            return (this.X == other.X) && (this.Y == other.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * Y.GetHashCode();
        }
    }
}
