using Application;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArraySum;

static class Program
{
    private static void Main(string[] args)
    {
        var provider = DependencyInjection.ConfigureServices();
        var service = provider.GetRequiredService<IArraySumService>();
        service.Process();
    }
}