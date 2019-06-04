using System;
using System.IO;
using Xunit;

namespace TurtleChallenge
{
    public static class UnitTests{
        [Fact]
        public static void PositionTest()
        {
            // Arrange
            Position pos1 = new Position(3,3);
            Position pos2 = new Position(3,3);
            Position pos3 = new Position(1,1);

            // Assert
            Assert.Equal(pos1, pos2);
            Assert.True(pos1.Equals(pos2));
            Assert.False(pos1.Equals(pos3));
            Assert.Equal("X:3 Y:3", pos1.ToString());
        }

        [Fact]
        public static void TurtleTest()
        {
            Turtle t1 = new Turtle();
            t1.Position = new Position(1,1);
            t1.Direction = Direction.North;
            
            t1.Move();
            Assert.Equal(new Position(1,2), t1.Position);
            t1.Rotate();
            Assert.Equal(Direction.East, t1.Direction);

            t1.Move();
            Assert.Equal(new Position(2,2), t1.Position);
            t1.Rotate();
            Assert.Equal(Direction.South, t1.Direction);

            t1.Move();
            Assert.Equal(new Position(2,1), t1.Position);
            t1.Rotate();
            Assert.Equal(Direction.West, t1.Direction);

            t1.Move();
            Assert.Equal(new Position(1,1), t1.Position);
            t1.Rotate();
            Assert.Equal(Direction.North, t1.Direction);
        }

        [Fact]
        public static void MineTest()
        {
            Mine m1 = new Mine();
            m1.Position = new Position(1,1);

            Assert.False(m1.Detonated);
            Assert.Equal(new Position(1,1), m1.Position);
        }

        [Fact]
        public static void ExitTest()
        {
            Exit e1 = new Exit();
            e1.Position = new Position(1,1);

            Assert.False(e1.Reached);
            Assert.Equal(new Position(1,1), e1.Position);
        }

        [Fact]
        public static void GridTest()
        {
            Grid g1 = new Grid(2,4);
            
            Assert.Equal(2, g1.width);
            Assert.Equal(4, g1.height);

            Assert.Equal("width:2 height:4", g1.ToString());
        }

        [Fact]
        public static void GameSuccessTest()
        {
            Game g1 = new Game("inputs/testSettings1.xml");

            string instructions = File.ReadAllText("inputs/testMoves1.txt");
            foreach (var instruction in instructions)
            {
                if(g1.ExecuteInstruction(instruction) > GamesState.Playing){
                    break;
                }
            }
            
            if(g1.GameState == GamesState.Playing){
                g1.GameState = GamesState.StillInDanger;
            }

            Assert.Equal(GamesState.Success, g1.GameState);
        }

        [Fact]
        public static void GameOutOfBoundsTest()
        {
            Game g1 = new Game("inputs/testSettings1.xml");

            string instructions = File.ReadAllText("inputs/testMoves2.txt");
            foreach (var instruction in instructions)
            {
                if(g1.ExecuteInstruction(instruction) > GamesState.Playing){
                    break;
                }
            }
            
            if(g1.GameState == GamesState.Playing){
                g1.GameState = GamesState.StillInDanger;
            }

            Assert.Equal(GamesState.OutOfBounds, g1.GameState);
        }

        [Fact]
        public static void GameMineHitTest()
        {
            Game g1 = new Game("inputs/testSettings1.xml");

            string instructions = File.ReadAllText("inputs/testMoves3.txt");
            foreach (var instruction in instructions)
            {
                if(g1.ExecuteInstruction(instruction) > GamesState.Playing){
                    break;
                }
            }
            
            if(g1.GameState == GamesState.Playing){
                g1.GameState = GamesState.StillInDanger;
            }

            Assert.Equal(GamesState.MineHit, g1.GameState);
        }

        [Fact]
        public static void GameStillInDangerTest()
        {
            Game g1 = new Game("inputs/testSettings1.xml");

            string instructions = File.ReadAllText("inputs/testMoves4.txt");
            foreach (var instruction in instructions)
            {
                if(g1.ExecuteInstruction(instruction) > GamesState.Playing){
                    break;
                }
            }
            
            if(g1.GameState == GamesState.Playing){
                g1.GameState = GamesState.StillInDanger;
            }

            Assert.Equal(GamesState.StillInDanger, g1.GameState);
        }
    }
}
