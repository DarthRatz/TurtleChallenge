namespace TurtleChallenge
{
    public class Turtle{
        public Position position;
        public Direction direction;
        public Turtle(){
        }

        public Position Move(){
            switch (this.direction){
                case Direction.North:
                    this.position.Y++;
                    break;
                case Direction.South:
                    this.position.Y--;
                    break;
                case Direction.East:
                    this.position.X++;
                    break;
                case Direction.West:
                    this.position.X--;
                    break;
                default:
                    break;
            }
            return this.position;
        }

        public Direction Rotate(){
            this.direction++;
            if(this.direction > Direction.West){
                this.direction = Direction.North;
            }

            return this.direction;
        }
    }
}
