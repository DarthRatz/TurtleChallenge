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
            }
            return this.position;
        }

        public Direction Rotate(){
            switch (this.direction){
                case Direction.North:
                    this.direction = Direction.East;
                    break;
                case Direction.South:
                    this.direction = Direction.West;
                    break;
                case Direction.East:
                    this.direction = Direction.South;
                    break;
                case Direction.West:
                    this.direction = Direction.North;
                    break;
            }
            return this.direction;
        }
    }
}
