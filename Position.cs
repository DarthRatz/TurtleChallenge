namespace TurtleChallenge
{
    public class Position{
        public int X, Y;
        public Position(){
        }

        public Position(int x, int y){
            this.X = x;
            this.Y = y;
        }

        public override string ToString(){
            return "X:" + X.ToString() + " Y:" + Y.ToString();
        }

        public override bool Equals(object obj)
        {         
            if (obj == null || GetType() != obj.GetType()){
                return false;
            }
            
            Position p = (Position)obj;
            return (this.X == p.X) && (this.Y == p.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
