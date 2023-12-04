namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public class Day2 : SolutionBase
{
    private static readonly char[] _delimters = [',', ';'];
    private static readonly int _maxRedCubes = 12;
    private static readonly int _maxGreenCubes = 13;
    private static readonly int _maxBlueCubes = 14;

    public Day2() : base(nameof(Day2))
    {
    }

    private protected override string InitialSolutionForPartOne(IList<string> puzzleInput)
    {
        int sum = 0;

        foreach (var input in puzzleInput)
        {
            // [0] will be game number
            // [1] will be game details
            string[] inputSplit = input.Split(':', 2, StringSplitOptions.TrimEntries);

            int gameNumber = GetGameNumber(inputSplit[0]);

            if (IsPossibleGame(inputSplit[1]))
            {
                sum += gameNumber;
            }
        }

        return $"{sum}";
    }

    private protected override string FinalSolutionForPartTwo(IList<string> puzzleInput)
    {
        int minRedCubes;
        int minGreenCubes;
        int minBlueCubes;
        int sum = 0;

        foreach (var input in puzzleInput)
        {
            minRedCubes = 0;
            minGreenCubes = 0;
            minBlueCubes = 0;

            // [0] will be game number
            // [1] will be game details
            string[] inputSplit = input.Split(':', 2, StringSplitOptions.TrimEntries);

            string[] allRevealedCubes = inputSplit[1].Split(_delimters, StringSplitOptions.TrimEntries);

            foreach (var reveal in allRevealedCubes)
            {
                // [0] is count
                // [1] is color
                string[] revealInfo = reveal.Split(' ', 2, StringSplitOptions.None);
                int revealCount = int.Parse(revealInfo[0]);

                if (revealInfo[1][0] == 'r' && revealCount > minRedCubes)
                {
                    minRedCubes = revealCount;
                }
                else if (revealInfo[1][0] == 'g' && revealCount > minGreenCubes)
                {
                    minGreenCubes = revealCount;
                }
                else if (revealInfo[1][0] == 'b' && revealCount > minBlueCubes)
                {
                    minBlueCubes = revealCount;
                }
            }

            sum += minRedCubes * minGreenCubes * minBlueCubes;
        }

        return $"{sum}";
    }

    private static bool IsPossibleGame(string inputSecondHalf)
    {
        string[] allRevealedCubes = inputSecondHalf.Split(_delimters, StringSplitOptions.TrimEntries);

        foreach (var reveal in allRevealedCubes)
        {
            // [0] is count
            // [1] is color
            string[] revealInfo = reveal.Split(' ', 2, StringSplitOptions.None);
            int revealCount = int.Parse(revealInfo[0]);

            if (revealInfo[1][0] == 'r' && revealCount > _maxRedCubes)
            {
                return false;
            }
            else if (revealInfo[1][0] == 'g' && revealCount > _maxGreenCubes)
            {
                return false;
            }
            else if (revealInfo[1][0] == 'b' && revealCount > _maxBlueCubes)
            {
                return false;
            }
        }

        return true;
    }

    private static int GetGameNumber(string inputFirstHalf)
    {
        // drop 'Game ' from first half of full game input
        return int.Parse(inputFirstHalf[5..]);
    }
}
