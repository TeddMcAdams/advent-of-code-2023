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
    var solution = solutionResolver(id);

    // Retrieve puzzle inputs
    var exampleInput = solution.RetrievePuzzleInput(SolutionType.Example);
    var input = solution.RetrievePuzzleInput();

    // run example input against part one solution
    var exampleStopWatch = Stopwatch.StartNew();
    var exampleAnswer = solution.SolveExample(exampleInput);
    exampleStopWatch.Stop();
    
    Puzzle examplePuzzle = new(SolutionType.Example, SolutionType.Example.ToFriendlyName(), exampleInput, exampleAnswer, exampleStopWatch.Elapsed);
    
    // run part one solution
    var partOneStopWatch = Stopwatch.StartNew();
    var partOneAnswer = solution.SolvePartOne(input);
    partOneStopWatch.Stop();
    
    Puzzle partOnePuzzle = new(SolutionType.PartOne, SolutionType.PartOne.ToFriendlyName(), input, partOneAnswer, partOneStopWatch.Elapsed);

    // run part two solution
    var partTwoStopWatch = Stopwatch.StartNew();
    var partTwoAnswer = solution.SolvePartTwo(input);
    partTwoStopWatch.Stop();

    Puzzle partTwoPuzzle = new(SolutionType.PartTwo, SolutionType.PartTwo.ToFriendlyName(), input, partTwoAnswer, partTwoStopWatch.Elapsed);

    return new AdventOfCodeDay(id, new List<Puzzle> { examplePuzzle, partOnePuzzle, partTwoPuzzle });
});

app.MapDefaultEndpoints();

app.Run();

record AdventOfCodeDay(int DayId, IList<Puzzle> Puzzles)
{

}

record Puzzle(SolutionType Type, string Name, IList<string> Input, string Solution, TimeSpan ElapsedRunTime)
{
    // public static Puzzle EmptyPuzzle => new(0, "Empty", [], string.Empty, default);
}

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// });

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
