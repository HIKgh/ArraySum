using Application.Interfaces;

namespace Application.Implementations;

public class ParallelForEachCalcArraySumService : ICalcArraySumService
{
    public long Calc(int[] array)
    {
        long sum = 0;
        Parallel.ForEach<int>(array, (item) =>
        {
            Interlocked.Add(ref sum, item);
        });
        return sum;
    }

    public string GetServiceType()
    {
        return "Параллельное суммирование Parallel.ForEach";
    }
}