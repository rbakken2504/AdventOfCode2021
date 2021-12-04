namespace AdventOfCode
{
    public sealed class Day02 : BaseDay
    {
        private readonly string _input;

        public Day02()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            var commands = _input.Split("\n");
            var (horizontal, depth) = commands.Aggregate((0, 0), (acc, command) =>
            {
                var actionAndUnit = command.Split(' ');
                var action = actionAndUnit[0];
                var units = Int32.Parse(actionAndUnit[1]);

                switch (action)
                {
                    case "forward":
                        acc.Item1 += units;
                        break;
                    case "down":
                        acc.Item2 += units;
                        break;
                    case "up":
                        acc.Item2 -= units;
                        break;
                    default:
                        throw new NotImplementedException($"{action} not implemented");
                }

                return acc;
            });
            
            return new ValueTask<string>((horizontal * depth).ToString());
        }

        public override ValueTask<string> Solve_2()
        {

            var commands = _input.Split("\n");
            var (horizontal, depth, aim) = commands.Aggregate((0, 0, 0), (acc, command) =>
            {
                var actionAndUnit = command.Split(' ');
                var action = actionAndUnit[0];
                var units = Int32.Parse(actionAndUnit[1]);

                switch (action)
                {
                    case "forward":
                        acc.Item1 += units;
                        acc.Item2 += acc.Item3 * units;
                        break;
                    case "down":
                        acc.Item3 += units;
                        break;
                    case "up":
                        acc.Item3 -= units;
                        break;
                    default:
                        throw new NotImplementedException($"{action} not implemented");
                }

                return acc;
            });
            
            return new ValueTask<string>((horizontal * depth).ToString());
        }
    }
}