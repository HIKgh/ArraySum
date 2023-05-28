using Application.Interfaces;

namespace Application.Implementations;

public class SimpleCalcArraySumService : ICalcArraySumService
{
    public long Calc(int[] array)
    {
        long result = 0;
        for (var i = 0; i < array.Length; i++)
        {
            result += array[i];
        }
        return result;
    }

    public string GetServiceType()
    {
        return "Обычное суммирование";
    }
}