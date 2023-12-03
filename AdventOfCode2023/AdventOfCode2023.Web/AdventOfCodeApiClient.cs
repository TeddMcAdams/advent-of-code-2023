namespace AdventOfCode2023.Web;

public class AdventOfCodeApiClient(HttpClient httpClient)
{
    public async Task<AdventOfCodeDay> GetPuzzleDataForDay(int dayId)
    {
        return await httpClient.GetFromJsonAsync<AdventOfCodeDay>($"/day/{dayId}") ?? AdventOfCodeDay.EmptyDay(dayId);
    }
}

public record AdventOfCodeDay(int DayId, string LinkToAdventOfCodeDay, string LinkToSolutionCode, IList<Puzzle> Puzzles)
{
    public static AdventOfCodeDay EmptyDay(int dayId) => new(dayId, string.Empty, string.Empty, new List<Puzzle>());
}

public record Puzzle(int Type, string Name, IList<string> Input, string Answer, TimeSpan ElapsedRunTime)
{
    public static Puzzle EmptyPuzzle => new(-1, string.Empty, [], string.Empty, default);
}
