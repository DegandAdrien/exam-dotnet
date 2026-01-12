namespace Labyrinthe.Tests;

public class UnitTest1
{
    [Fact]
    public void Contrustor_Labyrinthe()
    {
        bool[,] grid =
        {
            {true, true, true, true}, 
            {true, false, false, true},
            {true, true, true, true}
        };
        var start = (1, 1);
        var exit = (1, 2);
        int[,] distances =
        {
            {0, 0, 0, 0}, 
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };
        
        var labyrinthe = new Labyrinthe(grid, start, exit, distances);
        
        Assert.Equal(grid, labyrinthe.Grid);
        Assert.Equal(start, labyrinthe.Start);
        Assert.Equal(exit, labyrinthe.Exit);
        Assert.False(labyrinthe.Grid[1, 1]);
        Assert.False(labyrinthe.Grid[1, 2]);
        Assert.True(labyrinthe.Grid[0, 0]);
    }
    
    public void Distance_Labyrinthe()
    {
        bool[,] grid =
        {
            {true, true, true, true}, 
            {true, false, false, true},
            {true, true, true, true}
        };
        var start = (1, 1);
        var exit = (1, 2);
        int[,] distances =
        {
            {0, 0, 0, 0}, 
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };
        
        var labyrinthe = new Labyrinthe(grid, start, exit, distances);
        
        Assert.Equal(grid.Length, labyrinthe.distances.Length);
        Assert.All(labyrinthe.distances, d => Assert.Equal(0, d));
    }