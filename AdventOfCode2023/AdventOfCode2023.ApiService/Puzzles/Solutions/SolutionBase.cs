namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public abstract class SolutionBase(string DayName) : ISolution
{
    private readonly string _examplePuzzleInputFileName = $"{DayName}Example.txt";
    private readonly string _puzzleInputFileName = $"{DayName}Input.txt";

    public string LinkToAdventOfCodeDay => $"https://adventofcode.com/2023/day/{DayName[3..]}";
    public string LinkToSolutionCode => $"https://github.com/TeddMcAdams/advent-of-code-2023/blob/main/AdventOfCode2023/AdventOfCode2023.ApiService/Puzzles/Solutions/{DayName}.cs";

    public string SolveExample(IList<string> examplePuzzleInput)
    {
        return InitialSolutionForPartOne(examplePuzzleInput);
    }

    public string SolvePartOne(IList<string> puzzleInput)
    {
        return InitialSolutionForPartOne(puzzleInput);
    }

    public string SolvePartTwo(IList<string> puzzleInput)
    {
        return FinalSolutionForPartTwo(puzzleInput);
    }

    private protected abstract string InitialSolutionForPartOne(IList<string> puzzleInput);
    private protected abstract string FinalSolutionForPartTwo(IList<string> puzzleInput);

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
