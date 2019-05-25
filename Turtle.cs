using System;

namespace TurtleChallenge
{
    public class Turtle{
        internal Position position;
        internal Direction direction;

        internal Turtle(){
        }

        public Position Position { get => position; set => position = value; }
        public Direction Direction { get => direction; set => direction = value; }

        public Position Move(){
            switch (this.Direction){
                case Direction.North:
                    this.Position.Y++;
                    break;
                case Direction.South:
                    this.Position.Y--;
                    break;
                case Direction.East:
                    this.Position.X++;
                    break;
                case Direction.West:
                    this.Position.X--;
                    break;
                default:
                    throw new NotSupportedException();
            }
            return this.Position;
        }

        public Direction Rotate(){
            this.Direction++;
            if(this.Direction > Direction.West){
                this.Direction = Direction.North;
            }

            return this.Direction;
        }
    }

    [Flags]
    public enum Direction { 
        North = 0,
        East = 1, 
        South = 2, 
        West = 3 
    }
}
