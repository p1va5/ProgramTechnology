namespace bank;

internal class GiftCardAccount:BankAccount
{
    private readonly decimal _monthyDeposit=0m;
    //monthyDeposit по умолчанию принимает 0 при создание обекта new GiftCardAccount("Yana", 1000) monthyDeposit=0
    // new GiftCardAccount("Yana", 1000, 1000) monthyDeposit=1000
    public GiftCardAccount(string name, decimal initialBalance, decimal monthyDeposit) : base(name, initialBalance) => _monthyDeposit = monthyDeposit;
    public override void PerformMonthAndTransactions()
    {
        if(_monthyDeposit != 0)
        {
            MakeDeposite(_monthyDeposit, DateTime.UtcNow, "Add monthy deposit");
        }
    }
    public override string ToString()
    {
        return base.ToString()+$"monthy deposit: {_monthyDeposit}";
    }
}
