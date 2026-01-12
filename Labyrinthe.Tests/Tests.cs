namespace Labyrinthe.Tests;

public class UnitTest1
{
    [Fact]
    public void Contrustor_Labyrinthe()
    {
        bool[,] grid =
        {
            { true, true, true, true },
            { true, false, false, true },
            { true, true, true, true }
        };
        var start = (1, 1);
        var exit = (1, 2);
        int[,] distances =
        {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 }
        };

        var labyrinthe = new Labyrinthe(grid, start, exit, distances);

        Assert.Equal(grid, labyrinthe.Grid);
        Assert.Equal(start, labyrinthe.Start);
        Assert.Equal(exit, labyrinthe.Exit);
        Assert.False(labyrinthe.Grid[1, 1]);
        Assert.False(labyrinthe.Grid[1, 2]);
        Assert.True(labyrinthe.Grid[0, 0]);
    }
    
    [Fact]
    public void Distance_Labyrinthe()
    {
        bool[,] grid =
        {
            { true, true, true, true },
            { true, false, false, true },
            { true, true, true, true }
        };
        var start = (1, 1);
        var exit = (1, 2);
        int[,] distances =
        {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 }
        };

        var labyrinthe = new Labyrinthe(grid, start, exit, distances);

        Assert.Equal(grid.Length, labyrinthe.Distances.Length);
        foreach (var d in labyrinthe.Distances)
        {
            Assert.Equal(0, d);
        }
    }

    [Fact]
    public void Case_voisines()
    {
        bool[,] falseGrid =
        {
            { false, false, false, false },
            { false, false, false, false },
            { false, false, false, false }
        };
        
        bool[,] trueGrid =
        {
            { true, true, true, true },
            { true, true, true, true },
            { true, true, true, true }
        };
        
        bool[,] normalGrid =
        {
            { false, false, false, false },
            { false, true, true, false },
            { false, false, false, false }
        };
        
        var start = (1, 1);
        var exit = (1, 2);
        int[,] distances =
        {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 }
        };

        var labyrinthe = new Labyrinthe(falseGrid, start, exit, distances);

        labyrinthe.Grid = falseGrid;
        
        Assert.Equal([], labyrinthe.GetNeighbours((1, 1)));
        
        labyrinthe.Grid = trueGrid;
        
        Assert.Equal([(0, 1), (1, 0), (1, 2), (2, 1)], labyrinthe.GetNeighbours((1, 1)));
        Assert.Equal([(0, 2), (1, 3), (2, 2)], labyrinthe.GetNeighbours((1, 2)));
        
        labyrinthe.Grid = normalGrid;
        
        Assert.Equal([(1, 2)], labyrinthe.GetNeighbours((1, 1)));
        Assert.Equal([], labyrinthe.GetNeighbours((1, 2)));
        Assert.Equal([], labyrinthe.GetNeighbours((0, 0)));
        Assert.Equal([], labyrinthe.GetNeighbours((2, 3)));
    }
}