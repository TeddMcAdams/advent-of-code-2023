using System.Text;

namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public class Day2 : SolutionBase
{
    private static readonly StringBuilder _stringBuilder = new();

    public Day2() : base(nameof(Day2))
    {
    }

    private protected override string InitialSolutionForPartOne(IList<string> puzzleInput)
    {
        int sum = 0;

        foreach (var input in puzzleInput)
        {
            int gameNumber = GetGameNumber(input);

            sum += gameNumber;
        }

        return $"{sum}";
    }

    private protected override string FinalSolutionForPartTwo(IList<string> puzzleInput)
    {
        // TODO
        return string.Empty;
    }

    private static int GetGameNumber(string input)
    {
        _stringBuilder.Clear();

        for (int i = 5; i < input[5..].Length; i++)
        {
            if (input[i] == ':')
            {
                break;
            }
            else
            {
                _stringBuilder.Append(input[i]);
            }
        }

        return int.Parse(_stringBuilder.ToString());
    }
}
