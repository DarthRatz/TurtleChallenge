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
            Grid init =  p.DeserializeGrid("init.xml");
            Console.WriteLine(init.ToString());
            Console.WriteLine(init.mines.Count);

            Turtle user = init.turtle;
            String instructions = File.ReadAllText("input.txt");
            foreach (var instruction in instructions.ToCharArray())
            {
                switch (instruction)
                {
                    case 'M':
                        user.Move();
                        break;
                    case 'R':
                        user.Rotate();
                        break;
                }
            }
        }

        private Grid DeserializeGrid(string filename)
        {
            Grid grid = new Grid();
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
