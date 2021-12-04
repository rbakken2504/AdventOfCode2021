using AdventOfCode.Day04Code;

namespace AdventOfCode;

public sealed class Day04 : BaseDay
{
    private readonly string _input;

    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var inputLines = _input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).ToArray();
        var drawnNumbers = inputLines.First().Split(',').Select(Int32.Parse).ToArray();
        var boards = BoardBuilder.BuildBoards(inputLines.Skip(1).ToArray());
        var firstFive = drawnNumbers.Take(5);
        var remainingNumbers = drawnNumbers.Skip(5);

        foreach (var number in firstFive)
        {
            foreach (var board in boards)
            {
                board.MarkSlot(number);
            }
        }

        foreach (var number in remainingNumbers)
        {
            foreach (var board in boards)
            {
                board.MarkSlot(number);
                if (board.HasBingo)
                {
                    return new ValueTask<string>($"{board.SumUnmarked() * number}");
                }
            }
        }

        return new ValueTask<string>("NONE");
    }

    public override ValueTask<string> Solve_2()
    {
        var inputLines = _input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).ToArray();
        var drawnNumbers = inputLines.First().Split(',').Select(Int32.Parse).ToArray();
        var boards = BoardBuilder.BuildBoards(inputLines.Skip(1).ToArray());
        var firstFive = drawnNumbers.Take(5);
        var remainingNumbers = drawnNumbers.Skip(5);

        foreach (var number in firstFive)
        {
            foreach (var board in boards)
            {
                board.MarkSlot(number);
            }
        }

        foreach (var number in remainingNumbers)
        {
            var boardsToRemove = new List<BingoBoard>();
            foreach (var board in boards)
            {
                board.MarkSlot(number);
                if (!board.HasBingo)
                {
                    continue;
                }
                if (boards.Count == 1)
                {
                    return new ValueTask<string>($"{board.SumUnmarked() * number}");
                }
                boardsToRemove.Add(board);
            }

            foreach (var boardToRemove in boardsToRemove)
            {
                boards.Remove(boardToRemove);
            }
        }

        return new ValueTask<string>("NONE");
    }
}