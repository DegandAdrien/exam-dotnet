namespace Labyrinthe;

public class Labyrinthe
{
    public bool[,] Grid { get; set; }
    public (int, int) Start { get; set; }
    public (int, int) Exit { get; set; }
    public int[,] Distances { get; set; }

    public Labyrinthe(bool[,] grid, (int, int) start, (int, int) exit, int[,] distances)
    {
        Grid = grid;
        Start = start;
        Exit = exit;
        Distances = distances;
    }
}