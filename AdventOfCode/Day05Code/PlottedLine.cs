namespace AdventOfCode.Day05Code;

public class PlottedLine
{
    public (int x, int y) Start { get; set; }
    public (int x, int y) End { get; set; }

    public bool IsHorizontal => Start.x == End.x;
    public bool IsVertical => Start.y == End.y;
    public bool IsDiagonal => !IsVertical && !IsHorizontal;

    /*
     * line must be in the format x1,y1 -> x2,y2
     */
    public PlottedLine(string line)
    {
        var startEndCoordinates = line.Split(" -> ");
        var startCoordinates = startEndCoordinates[0].Split(',');
        var endCoordinates = startEndCoordinates[1].Split(',');

        Start = (Int32.Parse(startCoordinates[0]), Int32.Parse(startCoordinates[1]));
        End = (Int32.Parse(endCoordinates[0]), Int32.Parse(endCoordinates[1]));
    }

    public IEnumerable<(int x, int y)> GetPlotsAlongLine()
    {
        if (IsHorizontal)
        {
            return Enumerable.Range(Start.y < End.y ? Start.y : End.y, Math.Abs(End.y - Start.y) + 1).Select(y => (Start.x, y));
        }
        if (IsVertical)
        {
            return Enumerable.Range(Start.x < End.x ? Start.x : End.x, Math.Abs(End.x - Start.x) + 1).Select(x => (x, Start.y));
        }
        
        if (Start.x < End.x && Start.y > End.y)
        {
            return Enumerable.Range(0, Math.Abs(End.x - Start.x) + 1).Select(delta => (Start.x + delta, Start.y - delta));
        }

        if (Start.x > End.x && Start.y < End.y)
        {
            return Enumerable.Range(0, Math.Abs(End.x - Start.x) + 1).Select(delta => (Start.x - delta, Start.y + delta));
        }

        return Start.x < End.x 
            ? Enumerable.Range(0, Math.Abs(End.x - Start.x) + 1).Select(delta => (Start.x + delta, Start.y + delta)) 
            : Enumerable.Range(0, Math.Abs(End.x - Start.x) + 1).Select(delta => (Start.x - delta, Start.y - delta));
    }

    public override string ToString()
    {
        return $"{Start.Item1}, {Start.Item2} -> {End.Item1}, {End.Item2}";
    }
}