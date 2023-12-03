namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public abstract class SolutionBase(string DayId) : ISolution
{
    private readonly string _examplePuzzleInputFileName = $"{DayId}Example.txt";
    private readonly string _puzzleInputFileName = $"{DayId}Input.txt";

    public abstract string SolveExample(IList<string> puzzleInput);
    public abstract string SolvePartOne(IList<string> puzzleInput);
    public abstract string SolvePartTwo(IList<string> puzzleInput);

    public IList<string> RetrievePuzzleInput(SolutionType solutionType = SolutionType.PartOne)
    {
        var fileName = solutionType switch
        {
            SolutionType.Example => _examplePuzzleInputFileName,
            SolutionType.PartOne or SolutionType.PartTwo => _puzzleInputFileName,
            _ => throw new ArgumentException("Invalid puzzle type", nameof(solutionType))
        };

        return File.ReadLines($"Puzzles/Inputs/{fileName}").ToList();;
    }
}
