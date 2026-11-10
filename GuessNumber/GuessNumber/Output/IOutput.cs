using GuessNumber.Logics;
namespace GuessNumber.Output;

public interface IOutput
{
    public void GetResult(object? sender, RoundEvents e);
}
