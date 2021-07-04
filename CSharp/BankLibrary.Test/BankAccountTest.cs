using System;
using Xunit;

namespace BankLibrary.Test
{
    public class BankAccountTest
    {
        private BankAccount _account;

        public BankAccountTest()
        {
            _account = new BankAccount("Kendra", 1000);
        }

        [Fact]
        public void should_throw_exception_when_doing_negative_deposit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _account.MakeDeposit(
                    -200,
                    DateTime.Now,
                    "Attempt to do an invalid deposit")
            );
        }

        [Fact]
        public void should_throw_exception_when_creating_an_invalid_account()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new BankAccount("Invalid", -2000)
            );
        }

        [Fact]
        public void should_throw_exception_when_trying_to_overdraw()
        {
            Assert.Throws<InvalidOperationException>(() =>
                _account.MakeWithdrawal(500000, DateTime.Now, "Attempt to overdraw")
            );
        }
    }
}