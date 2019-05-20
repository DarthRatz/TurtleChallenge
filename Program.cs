namespace TurtleChallenge
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Grid game =  p.DeserializeGrid("settings.xml");

            string instructions = File.ReadAllText("moves.txt");
            foreach (var instruction in instructions.ToCharArray())
            {
                switch (instruction)
                {
                    case 'M':
                        game.turtle.Move();
                        break;
                    case 'R':
                        game.turtle.Rotate();
                        break;
                }

                if (game.CheckOutOfBounds()){
                    Console.WriteLine("Out of bounds");
                }

                if (game.CheckReachedExit()){
                    Console.WriteLine("Success");
                }

                if (game.CheckHitMine()){
                    Console.WriteLine("Mine hit");
                }

                if(game.gameLost || game.gameWon){
                    break;
                }
            }
            
            if(!game.gameLost && !game.gameWon){
                Console.WriteLine("still in danger");
                game.gameLost = true;
            }
        }

        private Grid DeserializeGrid(string filename)
        {
            Grid grid = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Grid));
            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                grid = (Grid)serializer.Deserialize(reader);          
            }
            
            return grid;
        }
    }
    
    [Flags]
    public enum Direction { 
        North,
        East, 
        South, 
        West 
    };
}
