using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TurtleChallenge
{
    public class Game : IDisposable
    {
        readonly XmlSerializer serializer = new XmlSerializer(typeof(Game));
        private FileStream fs;

        internal List<Mine> mines1;
        internal Exit exit1;
        internal Turtle turtle1;
        internal Grid grid1;
        internal GamesState gs1;

        internal Game(){
            this.GameState = GamesState.Playing;
        }

        public GamesState GameState { get => gs1; set => gs1 = value; }
        public Grid Grid { get => grid1; set => grid1 = value; }
        public Turtle Turtle { get => turtle1; set => turtle1 = value; }
        public Exit Exit { get => exit1; set => exit1 = value; }
        public List<Mine> Mines { get => mines1; set => mines1 = value; }

        public Game(string filename)
        {
            this.GameState = GamesState.Playing;
            OpenResource(filename);

            using (Stream reader = fs)
            {
                var g = (Game)serializer.Deserialize(reader);

                this.Grid = g.Grid;
                this.Turtle = g.Turtle;
                this.Exit = g.Exit;
                this.Mines = g.Mines;
            }

            CloseResource();
            Dispose();
        }

        public bool CheckOutOfBounds()
        {
            if (this.Turtle.Position.X > this.Grid.width || this.Turtle.Position.X < 0
            || this.Turtle.Position.Y > this.Grid.height || this.Turtle.Position.Y < 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckReachedExit()
        {
            if (this.Turtle.Position.Equals(this.Exit.Position))
            {
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
                    mine.Detonated = true;
                    return true;
                }
            }

            return false;
        }

        public GamesState ExecuteInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'M':
                case 'm':
                    this.Turtle.Move();
                    break;
                case 'R':
                case 'r':
                    this.Turtle.Rotate();
                    break;
                default:
                    throw new NotSupportedException();
            }

            if (this.CheckOutOfBounds()){
                GameState = GamesState.OutOfBounds;
            }

            if (this.CheckReachedExit()){
                GameState = GamesState.Success;
            }

            if (this.CheckHitMine()){
                GameState = GamesState.MineHit;
            }

            return GameState;
        }

        public void OpenResource(string path)
        {
            this.fs = new FileStream(path, FileMode.Open);
        }

        public void CloseResource()
        {
            this.fs.Close();
        }

        public void Dispose()
        {
            this.fs.Dispose();
        }
    }

    [Flags]
    public enum GamesState {
        Playing = 0,
        OutOfBounds = 1,
        Success = 2,
        MineHit = 3,
        StillInDanger = 4
    }
}
