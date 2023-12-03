namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public interface ISolution
{
    public string LinkToAdventOfCodeDay { get; }
    public string LinkToSolutionCode { get; }
    
    public string SolveExample(IList<string> puzzleInput);
    public string SolvePartOne(IList<string> puzzleInput);
    public string SolvePartTwo(IList<string> puzzleInput);
    public IList<string> RetrievePuzzleInput(SolutionType solutionType = SolutionType.PartOne);
}
