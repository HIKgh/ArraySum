using Application.Interfaces;

namespace Application.Implementations;

public class IntArrayRandomGenerator : IIntArrayRandomGenerator
{
    private readonly Random _random;

    public IntArrayRandomGenerator()
    {
        _random = new Random();
    }

    public int[] Generate(int length)
    {
        var result = new int[length];
        for (var i = 0; i < length; i++)
        {
            result[i] = _random.Next();
        }
        return result;
    }
}