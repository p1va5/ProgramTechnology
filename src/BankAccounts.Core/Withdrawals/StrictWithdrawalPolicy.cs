namespace BankAccounts.Core.Withdrawals;
//Политика по умолчанию если баланс меньше минимума - отколоняем 
public sealed class StrictWithdrawalPolicy:IWithdrawalPolicy
{
    public WithdrawalDecision Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance) => currentBalance - amount < minimumBalance ? WithdrawalDecision.Reject("Not suffcient rubls for this withdrawl") : WithdrawalDecision.Allow();
}
