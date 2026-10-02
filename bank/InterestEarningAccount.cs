using System.Security.Cryptography.X509Certificates;

namespace bank;

public class InterestEarningAccount :BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance):base(name, initialBalance)
    {

    }
    //override позволяет в дочернем классе опеределить новую реализацию метода
    public override void PerformMonthAndTransactions()
    {
        if(Balance>500m)
        {
            decimal iterest = Balance * 0.02m;
            MakeDeposite(iterest, DateTime.UtcNow, "Apply month intetrest");
        }
    }
}
