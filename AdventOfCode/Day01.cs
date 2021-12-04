namespace AdventOfCode
{
    public sealed class Day01 : BaseDay
    {
        private readonly string _input;

        public Day01()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            var depths = _input.Split('\n').Select(Int32.Parse).ToArray();
            var prevDepth = depths.First();
            var increases = 0;
            foreach (var depth in depths.Skip(1))
            {
                if (depth > prevDepth)
                {
                    increases++;
                }

                prevDepth = depth;
            }
            return new ValueTask<string>(increases.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var depths = _input.Split('\n').Select(Int32.Parse).ToArray();
            var prevSum = depths.Take(3).Sum();
            var increases = 0;
            for (var i = 1; i < depths.Length - 2; i++)
            {
                var sum = depths[i] + depths[i + 1] + depths[i + 2];
                if (sum > prevSum)
                {
                    increases++;
                }

                prevSum = sum;
            }
            return new ValueTask<string>(increases.ToString());
        }
    }
}