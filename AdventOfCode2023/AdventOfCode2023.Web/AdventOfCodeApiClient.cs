namespace AdventOfCode2023.Web;

public class AdventOfCodeApiClient(HttpClient httpClient)
{
    public async Task<AdventOfCodeDay> GetPuzzleDataForDay(int dayId)
    {
        return await httpClient.GetFromJsonAsync<AdventOfCodeDay>($"/day/{dayId}") ?? AdventOfCodeDay.EmptyDay(dayId);
    }
}

public record AdventOfCodeDay(int DayId, IList<Puzzle> Puzzles)
{
    public static AdventOfCodeDay EmptyDay(int dayId) => new(dayId, new List<Puzzle>());
}

public record Puzzle(int Type, string Name, IList<string> Input, string Solution, TimeSpan ElapsedRunTime)
{
    public static Puzzle EmptyPuzzle => new(-1, string.Empty, [], string.Empty, default);
}
