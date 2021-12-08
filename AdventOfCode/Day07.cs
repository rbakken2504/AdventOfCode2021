namespace AdventOfCode;

public sealed class Day07 : BaseDay
{
    private readonly string _input;

    public Day07()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var crabPositions = _input.Split(',').Select(Int32.Parse).OrderByDescending(x => x).ToList();
        var fuel = Int32.MaxValue;
        for (var i = crabPositions.First(); i >= 0; i--)
        {
            var curFuel = crabPositions.Sum(crabPosition => Math.Abs(i - crabPosition));
            if (curFuel < fuel)
            {
                fuel = curFuel;
            }
        }
        return new ValueTask<string>(fuel.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var crabPositions = _input.Split(',').Select(Int32.Parse).OrderByDescending(x => x).ToList();
        var fuel = Int32.MaxValue;
        for (var i = crabPositions.First(); i >= 0; i--)
        {
            var curFuel = 0;
            foreach (var spotsToMove in crabPositions.Select(crabPosition => Math.Abs(i - crabPosition)))
            {
                for (var j = 1; j <= spotsToMove; j++)
                {
                    curFuel += j;
                }
            }
            if (curFuel < fuel)
            {
                fuel = curFuel;
            }
        }
        return new ValueTask<string>(fuel.ToString());
    }
}