using System.Collections.Generic;

namespace TurtleChallenge
{
    public class Grid{
        public int width { get; set; }
        public int height { get; set; }
        public Turtle turtle { get; set; }
        public Exit exit { get; set; }
        public List<Mine> mines { get; set; }

        public Grid(){
        }

        public override string ToString()
        {
            return "width:" + width.ToString() + " height:" + height.ToString();
        }
    }   
}
