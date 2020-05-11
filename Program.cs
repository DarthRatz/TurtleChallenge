using System;
using System.IO;

namespace TurtleChallenge
{
    class Program
    {
        public static void Main(String[] args)
        {
            Game game =  new Game("inputs/settings.xml");
            string instructions = File.ReadAllText("inputs/moves.txt");

            foreach (var instruction in instructions)
            {
                game.ExecuteInstruction(instruction);

                if(game.GameState > GamesState.Playing){
                    break;
                }
            }

            if(game.GameState == GamesState.Playing){
                game.GameState = GamesState.StillInDanger;
            }

            Console.Out.Write(game.GameState.ToString());
        }
    }
}
