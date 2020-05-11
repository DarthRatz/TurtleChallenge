namespace TurtleChallenge
{
    public class Grid
    {
        internal int width1;
        internal int height1;

        internal Grid(){
        }

        public int width { get => width1; set => width1 = value; }
        public int height { get => height1; set => height1 = value; }

        public Grid(int width, int height){
            this.width = width;
            this.height = height;
        }

        public override string ToString()
        {
            return "width:" + width.ToString() + " height:" + height.ToString();
        }
    }
}
