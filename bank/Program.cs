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
            Console.WriteLine(account1.GetAccountHistory());
            try
            {
                account2.MakeWithdrawal(12232, DateTime.UtcNow, "help");
            }
            catch(InvalidOperationException e)
            { Console.WriteLine(e.Message);}
            LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Yana", 0m, 1000m);
            lineOfCredit.MakeWithdrawal(500m, DateTime.UtcNow, "credit");
            GiftCardAccount giftCard = new GiftCardAccount("Yana", 1000, 5000);



            InterestEarningAccount interest = new InterestEarningAccount("Вовчик", 1000);

            interest.PerformMonthAndTransactions();
            Console.WriteLine(interest.GetAccountHistory());
            List<BankAccount> account = new List<BankAccount>();
            account.Add(account1);
            account.Add(interest);
            account.Add(lineOfCredit);
            account.Add(giftCard);
            foreach (var acount in account)
            {
                Console.WriteLine(acount);
                acount.PerformMonthAndTransactions();
                Console.WriteLine(acount.GetAccountHistory());
            }
            lineOfCredit.MakeWithdrawal(600m, DateTime.UtcNow, "credit");
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}
