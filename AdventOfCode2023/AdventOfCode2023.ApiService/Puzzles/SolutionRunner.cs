namespace AdventOfCode2023.ApiService.Puzzles;

public abstract class SolutionRunner(string DayId) : ISolutionRunner
{
    private readonly string _examplePuzzleInputFile = $"{nameof(DayId)}Example.txt";
    private readonly string _partOnePuzzleInputFile = $"{nameof(DayId)}PartOne.txt";
    private readonly string _partTwoPuzzleInputFile = $"{nameof(DayId)}PartTwo.txt";

    public abstract string RunExample();
    public abstract string RunPartOne();
    public abstract string RunPartTwo();

    public IList<string> LoadPuzzleInput(PuzzleType puzzleType)
    {
        var fileName = puzzleType switch
        {
            PuzzleType.Example => _examplePuzzleInputFile,
            PuzzleType.PartOne => _partOnePuzzleInputFile,
            PuzzleType.PartTwo => _partTwoPuzzleInputFile,
            _ => throw new ArgumentException("Invalid puzzle type", nameof(puzzleType))
        };

        return File.ReadLines($"Puzzles/Inputs/{fileName}").ToList();;
    }
}