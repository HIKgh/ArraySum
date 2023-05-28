using Application.Implementations;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IIntArrayRandomGenerator, IntArrayRandomGenerator>();
        services.AddSingleton<ICalcArraySumService, SimpleCalcArraySumService>();
        services.AddSingleton<ICalcArraySumService, ParallelThreadsCalcArraySumService>();
        services.AddSingleton<ICalcArraySumService, ParallelForEachCalcArraySumService>();
        services.AddSingleton<ICalcArraySumService, ParallelPLinqCalcArraySumService>();
        services.AddSingleton<IArraySumService, ArraySumService>();

        return services.BuildServiceProvider();
    }
}