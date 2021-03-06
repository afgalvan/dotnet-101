using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humanizer;

namespace BankLibrary
{
    public class BankAccount
    {
        public string Id { get; }
        public string Owner { get; set; }
        public decimal Balance => _transactionHistory.Sum(transaction => transaction.Amount);

        private readonly List<Transaction> _transactionHistory = new List<Transaction>();
        private static int _accountNumberSeed = 123456789;

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            Id = _accountNumberSeed.ToString();
            _accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
            }

            var deposit = new Transaction(amount, date, note);
            _transactionHistory.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not enough funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            _transactionHistory.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            static string AmountInWords(Transaction transaction) =>
                ((int) transaction.Amount).ToWords();

            var report = new StringBuilder();
            report.AppendLine("Date\t\t\tAmount\t\tNote");
            _transactionHistory.ForEach(transaction =>
                report.AppendLine($"{transaction.Date}\t{AmountInWords(transaction)}\t\t{transaction.Notes}"));
            return report.ToString();
        }
    }
}
