using AdventOfCode.Day05Code;

namespace AdventOfCode;

public sealed class Day05 : BaseDay
{
    private readonly string _input;

    public Day05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split('\n');
        var plottedLines = lines.Select(line => new PlottedLine(line));
        var plotDictionary = new Dictionary<(int x, int y), int>();

        foreach (var plottedLine in plottedLines)
        {
            if (!plottedLine.IsHorizontal && !plottedLine.IsVertical)
            {
                continue;
            }

            foreach (var tuple in plottedLine.GetPlotsAlongLine())
            {
                if (!plotDictionary.ContainsKey(tuple))
                {
                    plotDictionary.Add(tuple, 0);
                }

                plotDictionary[tuple] += 1;
            }
        }

        return new ValueTask<string>(plotDictionary.Sum(kvp => kvp.Value >= 2 ? 1 : 0).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split('\n');
        var plottedLines = lines.Select(line => new PlottedLine(line));
        var plotDictionary = new Dictionary<(int x, int y), int>();

        foreach (var plottedLine in plottedLines)
        {
            foreach (var tuple in plottedLine.GetPlotsAlongLine())
            {
                if (!plotDictionary.ContainsKey(tuple))
                {
                    plotDictionary.Add(tuple, 0);
                }

                plotDictionary[tuple] += 1;
            }
        }

        return new ValueTask<string>(plotDictionary.Sum(kvp => kvp.Value >= 2 ? 1 : 0).ToString());
    }
}