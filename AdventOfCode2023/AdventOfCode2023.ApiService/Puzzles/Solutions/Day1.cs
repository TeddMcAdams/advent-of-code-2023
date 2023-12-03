namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public class Day1 : SolutionBase
{
    private static int? _firstMatch = null;
    private static int? _lastMatch = null;
    private static Dictionary<string, int> _wordNumberToInt = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public Day1() : base(nameof(Day1))
    {
    }

    private protected override string InitialSolutionForPartOne(IList<string> puzzleInput)
    {
        return puzzleInput
            .Select(m => $"{m.First(n => char.IsDigit(n))}{m.Last(o => char.IsDigit(o))}")
			.Select(int.Parse).Sum()
            .ToString();
    }

    private protected override string FinalSolutionForPartTwo(IList<string> puzzleInput)
    {
        int sum = 0;

        foreach (var input in puzzleInput)
        {
            _firstMatch = null;
            _lastMatch = null;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    int parsedInt = int.Parse($"{input[i]}");

                    _firstMatch ??= parsedInt;
                    _lastMatch = parsedInt;

                    continue;
                }
                
                var wordNumberAsInt = CheckForWordNumber(input[i..]);
                
                if (wordNumberAsInt > -1)
                {
                    _firstMatch ??= wordNumberAsInt;
                    _lastMatch = wordNumberAsInt;
                }
            }

            sum += int.Parse($"{_firstMatch}{_lastMatch}");
        }

        return sum.ToString();
    }

    private static int CheckForWordNumber(string input)
    {
        foreach (var word in _wordNumberToInt)
        {
            if (input.StartsWith(word.Key))
            {
                return word.Value;
            }
        }

        return -1;
    }
}
