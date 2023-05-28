using Application.Interfaces;

namespace Application.Implementations;

public class ParallelPLinqCalcArraySumService : ICalcArraySumService
{
    public long Calc(int[] array)
    {
        var sum = array
            .AsParallel()
            .Aggregate<int, long>(0, (current, item) => current + item);
        return sum;
    }

    public string GetServiceType()
    {
        return "Параллельное суммирование PLinq AsParallel";
    }
}