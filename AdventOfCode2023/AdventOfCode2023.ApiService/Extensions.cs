using AdventOfCode2023.ApiService.Puzzles.Solutions;

namespace AdventOfCode2023.ApiService;

public static class Extensions
{
    public static IServiceCollection AddAdventOfCodeSolutions(this IServiceCollection services)
    {
        services.AddSingleton<Day1>();
        services.AddSingleton<Day2>();
        // services.AddSingleton<Day3>();
        // services.AddSingleton<Day4>();
        // services.AddSingleton<Day5>();
        // services.AddSingleton<Day6>();
        // services.AddSingleton<Day7>();
        // services.AddSingleton<Day8>();
        // services.AddSingleton<Day9>();
        // services.AddSingleton<Day10>();
        // services.AddSingleton<Day11>();
        // services.AddSingleton<Day12>();
        // services.AddSingleton<Day13>();
        // services.AddSingleton<Day14>();
        // services.AddSingleton<Day15>();
        // services.AddSingleton<Day16>();
        // services.AddSingleton<Day17>();
        // services.AddSingleton<Day18>();
        // services.AddSingleton<Day19>();
        // services.AddSingleton<Day20>();
        // services.AddSingleton<Day21>();
        // services.AddSingleton<Day22>();
        // services.AddSingleton<Day23>();
        // services.AddSingleton<Day24>();
        // services.AddSingleton<Day25>();

        services.AddSingleton<SolutionResolver>(serviceProvider => dayId => 
        {
            return dayId switch
            {
                1 => serviceProvider.GetRequiredService<Day1>(),
                2 => serviceProvider.GetRequiredService<Day2>(),
                // 3 => serviceProvider.GetRequiredService<Day3>(),
                // 4 => serviceProvider.GetRequiredService<Day4>(),
                // 5 => serviceProvider.GetRequiredService<Day5>(),
                // 6 => serviceProvider.GetRequiredService<Day6>(),
                // 7 => serviceProvider.GetRequiredService<Day7>(),
                // 8 => serviceProvider.GetRequiredService<Day8>(),
                // 9 => serviceProvider.GetRequiredService<Day9>(),
                // 10 => serviceProvider.GetRequiredService<Day10>(),
                // 11 => serviceProvider.GetRequiredService<Day11>(),
                // 12 => serviceProvider.GetRequiredService<Day12>(),
                // 13 => serviceProvider.GetRequiredService<Day13>(),
                // 14 => serviceProvider.GetRequiredService<Day14>(),
                // 15 => serviceProvider.GetRequiredService<Day15>(),
                // 16 => serviceProvider.GetRequiredService<Day16>(),
                // 17 => serviceProvider.GetRequiredService<Day17>(),
                // 18 => serviceProvider.GetRequiredService<Day18>(),
                // 19 => serviceProvider.GetRequiredService<Day19>(),
                // 20 => serviceProvider.GetRequiredService<Day20>(),
                // 21 => serviceProvider.GetRequiredService<Day21>(),
                // 22 => serviceProvider.GetRequiredService<Day22>(),
                // 23 => serviceProvider.GetRequiredService<Day23>(),
                // 24 => serviceProvider.GetRequiredService<Day24>(),
                // 25 => serviceProvider.GetRequiredService<Day25>(),
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
