using System.Diagnostics;
using AdventOfCode2023.ApiService;
using AdventOfCode2023.ApiService.Puzzles.Solutions;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add my Advent of Code Solutions.
builder.Services.AddAdventOfCodeSolutions();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/day/{id}", (SolutionResolver solutionResolver, int id) =>
{
    if (id < 1 || id > 25)
    {
        return new AdventOfCodeDay(0, string.Empty, string.Empty, [], [], []);
    }

    var solution = solutionResolver(id);

    // Retrieve puzzle inputs
    var exampleInput = solution.RetrievePuzzleInput(SolutionType.Example);
    var input = solution.RetrievePuzzleInput();

    // run example input against part one solution
    var exampleStopWatch = Stopwatch.StartNew();
    var exampleAnswer = solution.SolveExample(exampleInput);
    exampleStopWatch.Stop();
    
    Solution examplePuzzle = new(SolutionType.Example, SolutionType.Example.ToFriendlyName(), exampleAnswer, exampleStopWatch.Elapsed);
    
    // run part one solution
    var partOneStopWatch = Stopwatch.StartNew();
    var partOneAnswer = solution.SolvePartOne(input);
    partOneStopWatch.Stop();
    
    Solution partOnePuzzle = new(SolutionType.PartOne, SolutionType.PartOne.ToFriendlyName(), partOneAnswer, partOneStopWatch.Elapsed);

    // run part two solution
    var partTwoStopWatch = Stopwatch.StartNew();
    var partTwoAnswer = solution.SolvePartTwo(input);
    partTwoStopWatch.Stop();

    Solution partTwoPuzzle = new(SolutionType.PartTwo, SolutionType.PartTwo.ToFriendlyName(), partTwoAnswer, partTwoStopWatch.Elapsed);

    return new AdventOfCodeDay(id, solution.LinkToAdventOfCodeDay, solution.LinkToSolutionCode, new List<Solution> { examplePuzzle, partOnePuzzle, partTwoPuzzle }, exampleInput, input);
});

app.MapDefaultEndpoints();

app.Run();

record AdventOfCodeDay(int DayId, string LinkToAdventOfCodeDay, string LinkToSolutionCode, IList<Solution> Solutions, IList<string> ExampleInput, IList<string> Input)
{

}

record Solution(SolutionType Type, string Name, string Answer, TimeSpan ElapsedRunTime)
{

}
