using Application.Interfaces;

namespace Application.Implementations;

public class ParallelThreadsCalcArraySumService : ICalcArraySumService
{
    private const int MaxThreadCount = 100;
    private const int MinThreadCount = 1;
    private readonly List<Thread> _threads = new();
    private static long _arraySum;

    public long Calc(int[] array)
    {
        var threadCount = array.Length % MaxThreadCount == 0
            ? MaxThreadCount
            : MinThreadCount;
        _arraySum = 0;
        _threads.Clear();
        for (var i = 1; i <= threadCount; i++)
        {
            _threads.Add(StartHandlerThread(array, i, threadCount));
        }
        _threads.ForEach(x => x.Join());
        return _arraySum;
    }

    public string GetServiceType()
    {
        return $"Параллельное суммирование Threads {MaxThreadCount} потоков";
    }

    private Thread StartHandlerThread(int[] array, int threadKey, int threadCount)
    {
        var handler = new ArraySumHandler(array, threadKey, threadCount);
        var thread = new Thread(handler.Handle);
        thread.Start();
        return thread;
    }

    private class ArraySumHandler
    {
        private readonly int[] _array;
        private readonly int _threadKey;
        private readonly int _threadCount;

        public ArraySumHandler(int[] array, int threadKey, int threadCount)
        {
            _array = array;
            _threadKey = threadKey;
            _threadCount = threadCount;
        }

        public void Handle()
        {
            var bucketLength = _array.Length / _threadCount;
            for (var i = (_threadKey - 1) * bucketLength; i < _threadKey * bucketLength; i++)
            {
                Interlocked.Add(ref _arraySum, _array[i]);
            }
        }
    }
}