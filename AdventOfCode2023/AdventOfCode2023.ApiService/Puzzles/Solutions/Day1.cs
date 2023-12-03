namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public class Day1 : SolutionBase
{
    public Day1() : base(nameof(Day1))
    {
    }

    public override string SolveExample(IList<string> examplePuzzleInput)
    {
        return InitialSolutionForPartOne(examplePuzzleInput);
    }

    public override string SolvePartOne(IList<string> puzzleInput)
    {
        return InitialSolutionForPartOne(puzzleInput);
    }

    public override string SolvePartTwo(IList<string> puzzleInput)
    {
        return "TBD";
    }

    private static string InitialSolutionForPartOne(IList<string> puzzleInput)
    {
        return puzzleInput
            .Select(m => $"{m.First(n => char.IsDigit(n))}{m.Last(o => char.IsDigit(o))}")
			.Select(int.Parse).Sum()
            .ToString();
    }
}
