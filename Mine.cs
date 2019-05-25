namespace TurtleChallenge
{
    public class Mine{
        internal Position position;
        internal bool detonated;

        internal Mine(){
            detonated = false;
        }

        public bool Detonated { get => detonated; set => detonated = value; }
        public Position Position { get => position; set => position = value; }
    }
}
