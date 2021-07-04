using System;
using BankLibrary;

namespace Bank
{
    class Program
    {
        private static void Main()
        {
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            var bankAccount = new BankAccount("Kendra", 1000);
            Console.WriteLine(
                $"Account {bankAccount.Id} was created for {bankAccount.Owner} with ${bankAccount.Balance}");
            bankAccount.MakeWithdrawal(300, DateTime.Now, "Xbox One");
            Console.WriteLine(bankAccount.Balance);
            Console.WriteLine(bankAccount.GetAccountHistory());
        }
    }
}