using System.Collections.Generic;

namespace TurtleChallenge
{
    public class Grid{
        public int width { get; set; }
        public int height { get; set; }
        public Turtle turtle { get; set; }
        public Exit exit { get; set; }
        public List<Mine> mines { get; set; }
        public bool gameWon = false;
        public bool gameLost = false;

        public Grid(){
        }

        public override string ToString(){
            return "width:" + width.ToString() + " height:" + height.ToString();
        }

        public bool CheckOutOfBounds(){
            if (this.turtle.position.X > this.width || this.turtle.position.X < 0 
            || this.turtle.position.Y > this.height || this.turtle.position.Y < 0){
                
                this.gameLost = true;
            }

            return this.gameLost;
        }

        public bool CheckReachedExit(){
            if (this.turtle.position.Equals(this.exit.position)){
                this.gameWon = true;
                this.exit.reached = true;
            }

            return this.gameWon;
        }

        public bool CheckHitMine(){
            foreach(Mine mine in this.mines){
                if (this.turtle.position.Equals(mine.position)){
                    this.gameLost = true;
                    mine.detonated = true;
                }
            }

            return this.gameLost;
        }
    }   
}
