namespace TurtleChallenge
{
    using System.Collections.Generic;
    using Xunit;

    public class UnitTests{
        [Fact]
        public void GridTest()
        {
            // Arrange
            Grid grid = new Grid();
            grid.width = 3;
            grid.height = 2;
            grid.turtle = new Turtle();
            grid.turtle.position = new Position(3,3);
            grid.exit = new Exit();
            grid.exit.position = new Position(3,3);
            Mine mine = new Mine();
            mine.position = new Position(3,3);
            grid.mines = new List<Mine>();
            grid.mines.Add(mine);

            // Assert
            Assert.True(grid.CheckReachedExit());
            Assert.True(grid.CheckHitMine());
            Assert.True(grid.CheckOutOfBounds());
            Assert.Equal("width:3 height:2", grid.ToString());
        }

        [Fact]
        public void PositionTest()
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
    }
}
