namespace Labyrinthe;

public class Labyrinthe
{
    public bool[,] Grid { get; set; }
    public (int, int) Start { get; set; }
    public (int, int) Exit { get; set; }
    public int[,] Distances { get; set; }
    
    public Queue<(int, (int, int))> File { get; set; }

    public Labyrinthe(bool[,] grid, (int, int) start, (int, int) exit, int[,] distances)
    {
        Grid = grid;
        Start = start;
        Exit = exit;
        Distances = distances;
        File = new Queue<(int, (int, int))>();
        File.Enqueue((0, start));
    }
    
    public IList<(int, int)> GetNeighbours((int, int) position)
    {
        List<(int, int)> neighbours = new List<(int, int)>();
        
        if (position.Item1 > 0)
        {
            if ((position.Item1 - 1, position.Item2) != Start && Grid[position.Item1 - 1, position.Item2])
            {
                neighbours.Add((position.Item1 - 1, position.Item2));   
            }
        }

        if (position.Item1 < Grid.GetLength(0) - 1)
        {
            if ((position.Item1 + 1, position.Item2) != Start && Grid[position.Item1 + 1, position.Item2])
            {
                neighbours.Add((position.Item1 + 1, position.Item2));   
            }
        }

        if (position.Item2 > 0)
        {
            if ((position.Item1, position.Item2-1) != Start && Grid[position.Item1, position.Item2-1])
            {
                neighbours.Add((position.Item1, position.Item2 -1));   
            }
        }
        
        if (position.Item2 < Grid.GetLength(1) - 1)
        {
            if ((position.Item1, position.Item2+1) != Start && Grid[position.Item1, position.Item2+1])
            {
                neighbours.Add((position.Item1, position.Item2 +1));   
            }
        }

        return neighbours;
    }
    
    public bool Fill()
    {
        var item = this.File.Dequeue();

        if (item.Item2 == Exit)
        {
            return true;
        }
        if (Distances[item.Item2.Item1, item.Item2.Item2] != 0)
        {
            return false;
        }
        else
        {
            Distances[item.Item2.Item1, item.Item2.Item2] = item.Item1+1;
            foreach (var neighbour in GetNeighbours(item.Item2))
            {
                File.Enqueue((item.Item1+1, neighbour));
            }

            return false;
        }
    }
    
    public int GetDistance()
    {
        int distance = 0;
        while (Fill() != true)
        {
            distance++;
        }

        return distance;
    }
}