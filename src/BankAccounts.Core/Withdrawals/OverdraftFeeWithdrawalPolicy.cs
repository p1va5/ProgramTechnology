namespace BankAccounts.Core.Withdrawals;
//политика с овердрафтом разрешаем но берем комиссию
public sealed class OverdraftFeeWithdrawalPolicy : IWithdrawalPolicy
{
    private decimal _fee;
    public OverdraftFeeWithdrawalPolicy(decimal fee) => _fee = fee;
    public WithdrawalDecision Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance) => currentBalance - amount < minimumBalance ? WithdrawalDecision.AllowWithFee(_fee) : WithdrawalDecision.Allow();
}
