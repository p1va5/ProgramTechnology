using BankAccounts.Core.Accounts;

namespace BankAccounts.Core.MonthEnd;
//Процентны на долг (для линии кредита)

public class InterestNegativeBalanceRule : IMonthEndRule
{
    private readonly decimal _rate;
    public InterestNegativeBalanceRule(decimal rate)
    {
        _rate = rate;
    }
    public void Apply(IAccountOperations account, DateTime asOf)
    {
        if(account.Balance <0) account.Withdrawal(-account.Balance*_rate, asOf, "Charge mothly interest");
    }
}
