namespace bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Dimas", 100000);
            BankAccount account2 = new BankAccount("Dima", 100);
            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}\n{account2.Owner} {account2.Balance} {account2.Number}");
            account1.MakeDeposite(12000, DateTime.UtcNow, ";)");
            Console.WriteLine($"{account1.Owner} {account1.Balance}");
            account1.MakeWithdrawal(123, DateTime.UtcNow, ":(");
            Console.WriteLine($"{account1.Owner} {account1.Balance}");
            try
            {
                account2.MakeWithdrawal(12232, DateTime.UtcNow, "help");
            }
            catch(InvalidOperationException e)
            { Console.WriteLine(e.Message);}
        }
    }
}
