using AdventOfCode.Day06Code;

namespace AdventOfCode;

public sealed class Day06 : BaseDay
{
    private readonly string _input;

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        const int daysToSimulate = 80;
        var lanternFishInput = _input.Split(',').Select(Int32.Parse);
        var lanternFishies = lanternFishInput.Select(x => new LanternFish(x)).ToList();

        for (var i = 1; i < daysToSimulate + 1; i++)
        {
            var newFish = lanternFishies.Select(fishy => fishy.ElapseDay()).Where(newFish => newFish != null);
            lanternFishies = lanternFishies.Concat(newFish).ToList();
        }

        return new ValueTask<string>(lanternFishies.Count.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        const int daysToSimulate = 256;
        var defaultDictionary = new Dictionary<int, long>
        {
            {0, 0},
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
            {7, 0},
            {8, 0},
        };
        defaultDictionary = _input.Split(',').Select(Int32.Parse).Aggregate(defaultDictionary, (acc, daysUntilBirth) =>
        {
            acc[daysUntilBirth] += 1;
            return acc;
        });

        var lanternFishies = Enumerable.Range(1, daysToSimulate).Aggregate(defaultDictionary, (acc, day) =>
        {
            var zero = acc[0];
            var one = acc[1];
            var two = acc[2];
            var three = acc[3];
            var four = acc[4];
            var five = acc[5];
            var six = acc[6];
            var seven = acc[7];
            var eight = acc[8];
            
            acc[8] = zero;
            acc[7] = eight;
            acc[6] = seven + zero;
            acc[5] = six;
            acc[4] = five;
            acc[3] = four;
            acc[2] = three;
            acc[1] = two;
            acc[0] = one;
            return acc;
        }).Values.Sum();
        
        return new ValueTask<string>(lanternFishies.ToString());
    }
}