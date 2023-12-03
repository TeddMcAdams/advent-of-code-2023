using AdventOfCode2023.ApiService.Puzzles.Solutions;

namespace AdventOfCode2023.ApiService;

public static class Extensions
{
    public static IServiceCollection AddAdventOfCodeSolutions(this IServiceCollection services)
    {
        services.AddSingleton<Day1>();

        services.AddSingleton<SolutionResolver>(serviceProvider => dayId => 
        {
            return dayId switch
            {
                1 => serviceProvider.GetRequiredService<Day1>(),
                _ => throw new ArgumentOutOfRangeException(nameof(dayId), dayId, string.Empty),
            };
        });

        return services;
    }

    public static string ToFriendlyName(this SolutionType type) => type switch
    {
        SolutionType.Example => "Example",
        SolutionType.PartOne => "Part One",
        SolutionType.PartTwo => "Part Two",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, string.Empty)
    };
}
