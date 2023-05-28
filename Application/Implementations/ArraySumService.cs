using System.Diagnostics;
using Application.Interfaces;

namespace Application.Implementations;

public class ArraySumService : IArraySumService
{
    private readonly List<ICalcArraySumService> _calcServices;
    private readonly IIntArrayRandomGenerator _generator;
    private readonly int[] _arrayItemsCount = { 100_000, 1_000_000, 10_000_000 };

    public ArraySumService(IEnumerable<ICalcArraySumService> calcServices,
        IIntArrayRandomGenerator generator)
    {
        _calcServices = calcServices.ToList();
        _generator = generator;
    }

    public void Process()
    {
        Console.Clear();
        Console.WriteLine("Суммирование массива Int");
        var stopWatch = new Stopwatch();
        try
        {
            foreach (var item in _arrayItemsCount)
            {
                Console.WriteLine($"Суммирование массива с количеством элементов {item:# ### ###}");
                var array = _generator.Generate(item);
                foreach (var service in _calcServices)
                {
                    Console.WriteLine($"Суммирование тип: {service.GetServiceType()}");
                    stopWatch.Start();
                    var sum = service.Calc(array);
                    stopWatch.Stop();
                    Console.WriteLine($"Суммирование тип: {service.GetServiceType()} завершено за {stopWatch.Elapsed}. Сумма {sum}");
                }
                Console.WriteLine($"Суммирование массива с количеством элементов {item:# ### ###} завершено");
                Console.WriteLine();
            }
        }
        catch
        {
            Console.WriteLine("Произошла ошибка при суммировании");
        }
        Console.WriteLine("Суммирование завершено. Нажмите любую клавишу...");
        Console.ReadKey();
    }
}