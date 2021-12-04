namespace AdventOfCode.Day04Code;

public class BingoBoard
{
    public BoardSlot[,] Board { get; set; } = new BoardSlot[5, 5];
    public bool HasBingo { get; set; }

    public BingoBoard(IReadOnlyList<string> rows)
    {
        for (var rIdx = 0; rIdx < rows.Count; rIdx++)
        {
            var row = rows[rIdx].Split(' ').Where(x => !String.IsNullOrEmpty(x)).Select(Int32.Parse).ToArray();
            for (var cIdx = 0; cIdx < row.Length; cIdx++)
            {
                var number = row[cIdx];
                Board[rIdx, cIdx] = new BoardSlot {Number = number, IsMarked = false};
            }
        }
    }

    public void MarkSlot(int number)
    {
        int? row = null, col = null;
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                var slot = Board[i, j];
                if (slot.Number == number)
                {
                    slot.IsMarked = true;
                    row = i;
                    col = j;
                    break;
                }
            }
        }

        if (row.HasValue)
        {
            HasBingo = CheckForBingo(row.Value, col.Value);
        }
    }

    public override string ToString()
    {
        var board = "";
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                var slot = Board[i, j];
                
                board += slot.IsMarked ? "X " : slot.Number.ToString() + ' ';
            }

            board += '\n';
        }

        return board;
    }

    public int SumUnmarked()
    {
        var sum = 0;
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                var slot = Board[i, j];
                if (!slot.IsMarked)
                {
                    sum += slot.Number;
                }
            }
        }

        return sum;
    }

    private bool CheckForBingo(int row, int col)
    {
        return HasColumnBingo(row) || HasRowBingo(col) || HasDiagBingo(row, col);
    }

    private bool HasColumnBingo(int row)
    {
        var hasBingo = true;
        for (var colIdx = 0; colIdx < 5; colIdx++)
        {
            if (!Board[row, colIdx].IsMarked)
            {
                hasBingo = false;
                break;
            }
        }

        return hasBingo;
    }

    private bool HasRowBingo(int col)
    {
        var hasBingo = true;
        for (var rowIdx = 0; rowIdx < 5; rowIdx++)
        {
            if (!Board[rowIdx, col].IsMarked)
            {
                hasBingo = false;
                break;
            }
        }

        return hasBingo;
    }

    private bool HasDiagBingo(int row, int col)
    {
        switch (row)
        {
            case 0:
            case 4:
                if (col != 0 && col != 4)
                {
                    return false;
                }
                break;
            case 1:
            case 3:
                if (col != 1 && col != 3)
                {
                    return false;
                }
                break;
            case 2:
                if (col != 2)
                {
                    return false;
                }
                break;
        }

        var hasBingo = true;
        for (var i = 0; i < 5; i++)
        {
            if (!Board[i, i].IsMarked)
            {
                hasBingo = false;
                break;
            }
        }
        
        for (int x = 0, y = 4; y >= 0; x++, y--)
        {
            if (!Board[x, y].IsMarked)
            {
                hasBingo = false;
                break;
            }
        }

        return hasBingo;
    }
}

public class BoardSlot
{
    public int Number { get; set; }
    public bool IsMarked { get; set; }
}