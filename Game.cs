using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TurtleChallenge
{
    public class Game
    {
        internal bool gameWon = false;
        internal bool gameLost = false;
        internal List<Mine> mines1;
        internal Exit exit1;
        internal Turtle turtle1;
        internal Grid grid1;

        internal Game(){
        }

        public Grid Grid { get => grid1; set => grid1 = value; }
        public Turtle Turtle { get => turtle1; set => turtle1 = value; }
        public Exit Exit { get => exit1; set => exit1 = value; }
        public List<Mine> Mines { get => mines1; set => mines1 = value; }
        public bool GameWon { get => gameWon; set => gameWon = value; }
        public bool GameLost { get => gameLost; set => gameLost = value; } 

        public Game(string filename)
        {
            Game g = new Game();
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                g = (Game)serializer.Deserialize(reader);
            }

            this.Grid = g.Grid;
            this.Turtle = g.Turtle;
            this.Exit = g.Exit;
            this.Mines = g.Mines;
        }

        public bool CheckOutOfBounds()
        {
            if (this.Turtle.Position.X > this.Grid.width || this.Turtle.Position.X < 0
            || this.Turtle.Position.Y > this.Grid.height || this.Turtle.Position.Y < 0)
            {
                this.GameLost = true;
                return true;
            }

            return false;
        }

        public bool CheckReachedExit()
        {
            if (this.Turtle.Position.Equals(this.Exit.Position))
            {
                this.GameWon = true;
                this.Exit.Reached = true;
                return true;
            }

            return false;
        }

        public bool CheckHitMine()
        {
            foreach (Mine mine in this.Mines)
            {
                if (this.Turtle.Position.Equals(mine.Position))
                {
                    this.GameLost = true;
                    mine.Detonated = true;
                    return true;
                }
            }

            return false;
        }
    }
}
