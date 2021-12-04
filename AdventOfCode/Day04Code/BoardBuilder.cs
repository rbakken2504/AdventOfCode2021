namespace AdventOfCode.Day04Code;

public static class BoardBuilder
{
    public static List<BingoBoard> BuildBoards(string[] boardLines)
    {
        const int take = 5;
        var skip = 0;
        var boards = new List<BingoBoard>();
        while (skip < boardLines.Length)
        {
            var newBoard = new BingoBoard(boardLines.Skip(skip).Take(take).ToArray());
            boards.Add(newBoard);
            skip += take;
        }

        return boards;
    }
}