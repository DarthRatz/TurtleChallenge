namespace TurtleChallenge
{
    public class Exit{
        internal Position position;
        internal bool reached = false;

        internal Exit(){
        }

        public Position Position { get => position; set => position = value; }
        public bool Reached { get => reached; set => reached = value; }        
    }
}
