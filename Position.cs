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
            this.x = x;
            this.y = y;
        }

        public override string ToString(){
            return "X:" + x.ToString() + " Y:" + y.ToString();
        }

        public override bool Equals(object obj)
        {         
            if (obj == null || GetType() != obj.GetType()){
                return false;
            }
            
            Position p = (Position)obj;
            return (this.X == p.X) && (this.Y == p.Y);
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
