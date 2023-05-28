namespace Application.Interfaces;

public interface ICalcArraySumService
{
    long Calc(int[] array);

    string GetServiceType();
}