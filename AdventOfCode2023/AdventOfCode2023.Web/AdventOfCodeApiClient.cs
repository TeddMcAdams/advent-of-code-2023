namespace AdventOfCode2023.Web;

public class AdventOfCodeApiClient(HttpClient httpClient)
{
    public async Task<AdventOfCodeDay> GetPuzzleDataForDay(int dayId)
    {
        return await httpClient.GetFromJsonAsync<AdventOfCodeDay>($"/day/{dayId}") ?? AdventOfCodeDay.EmptyDay(dayId);
    }
}

public record AdventOfCodeDay(int DayId, string LinkToAdventOfCodeDay, string LinkToSolutionCode, IList<Solution> Solutions, IList<string> ExampleInput, IList<string> Input)
{
    public static AdventOfCodeDay EmptyDay(int dayId) => new(dayId, string.Empty, string.Empty, [], [], []);
}

public record Solution(int Type, string Name, string Answer, TimeSpan ElapsedRunTime)
{
    public static Solution EmptySolution => new(-1, string.Empty, string.Empty, default);
}
