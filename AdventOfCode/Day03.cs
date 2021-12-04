namespace AdventOfCode;

public sealed class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var bitStrings = _input.Split('\n');
        var strLen = bitStrings.First().Length;
        var gamma = "";
        var epsilon = "";
        for (var bitIdx = 0; bitIdx < strLen; bitIdx++)
        {
            var onCount = 0;
            var offCount = 0;
            foreach (var bitString in bitStrings)
            {
                if (bitString[bitIdx] == '1')
                {
                    onCount++;
                }
                else
                {
                    offCount++;
                }
            }

            if (onCount > offCount)
            {
                gamma += "1";
                epsilon += "0";
            }
            else
            {
                gamma += "0";
                epsilon += "1";
            }
        }
        
        
        return new ValueTask<string>((Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2)).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var oxygenRating = GetRating(false);
        var co2Rating = GetRating(true);
        return new ValueTask<string>((Convert.ToInt32(oxygenRating, 2) * Convert.ToInt32(co2Rating, 2)).ToString());
    }

    private string GetRating(bool isCo2)
    {
        var bitStrings = _input.Split('\n');
        var strLen = bitStrings.First().Length;
        for (var bitIdx = 0; bitIdx < strLen; bitIdx++)
        {
            var containsTarget = new Dictionary<char, List<string>>
            {
                { '1', new List<string>() },
                { '0', new List<string>() }
            };
            foreach (var bitString in bitStrings)
            {
                containsTarget[bitString[bitIdx]] = containsTarget[bitString[bitIdx]].Append(bitString).ToList();
            }
            
            bitStrings = containsTarget['1'].Count >= containsTarget['0'].Count 
                ? containsTarget['1'].ToArray() 
                : containsTarget['0'].ToArray();

            if (isCo2)
            {
                bitStrings = containsTarget['0'].Count <= containsTarget['1'].Count
                    ? containsTarget['0'].ToArray()
                    : containsTarget['1'].ToArray();
            }

            if (bitStrings.Length == 1)
            {
                return bitStrings.First();
            }
        }

        throw new Exception("Couldn't find rating!");
    }
}