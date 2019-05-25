using System;
using System.IO;
    
namespace TurtleChallenge
{
    class Program
    {
        public static void Main(String[] args)
        {
            GamesState gs = GamesState.Playing;
            Game game =  new Game("settings.xml");

            string instructions = File.ReadAllText("moves.txt");
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'M':
                    case 'm':
                        game.Turtle.Move();
                        break;
                    case 'R':
                    case 'r':
                        game.Turtle.Rotate();
                        break;
                    default:
                        throw new NotSupportedException();
                }

                if (game.CheckOutOfBounds()){
                    gs = GamesState.OutOfBounds;
                }

                if (game.CheckReachedExit()){
                    gs = GamesState.Success;
                }

                if (game.CheckHitMine()){
                    gs = GamesState.MineHit;
                }

                if(gs > GamesState.Playing){
                    break;
                }
            }
            
            if(gs == GamesState.Playing){
                gs = GamesState.StillInDanger;
            }

            Console.Out.Write(gs.ToString());
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
