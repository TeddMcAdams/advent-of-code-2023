using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/day/{id}", (int id) =>
{
    // fetch & run puzzles
    var stopWatch = Stopwatch.StartNew();
    Thread.Sleep(2000);
    stopWatch.Stop();
    Puzzle examplePuzzle = new(0, "Example", ["abc", "123"], "Solution", stopWatch.Elapsed);
    
    stopWatch = Stopwatch.StartNew();
    Thread.Sleep(1000);
    stopWatch.Stop();
    Puzzle partOnePuzzle = new(1, "Part One", ["def", "456"], "Solution", stopWatch.Elapsed);

    stopWatch = Stopwatch.StartNew();
    Thread.Sleep(200);
    stopWatch.Stop();
    Puzzle partTwoPuzzle = new(2, "Part Two", ["zzz", "666"], "Solution", stopWatch.Elapsed);

    return new AdventOfCodeDay(id, new List<Puzzle> { examplePuzzle, partOnePuzzle, partTwoPuzzle });
});

app.MapDefaultEndpoints();

app.Run();

record AdventOfCodeDay(int DayId, IList<Puzzle> Puzzles)
{

}

record Puzzle(int Id, string Name, IList<string> Input, string Solution, TimeSpan ElapsedRunTime)
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
