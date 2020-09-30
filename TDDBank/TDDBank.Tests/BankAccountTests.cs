using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDBank.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        ///Bankkonto
        ///	- Kontostand abfragen
        ///	- Betrag einzahlen(nicht Negativ) ✔
        ///	- Betrag abheben(nicht Negativ) ✔
        ///		- Darf nicht unter 0 fallen ✔
        ///	- Neues Konto hat 0 als Kontostand ✔

        [TestMethod]
        public void BankAccount_new_account_should_have_zero_as_balance()
        {
            var ba = new BankAccount();
            //🥰 👙 🍻🍻
            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);
            ba.Deposit(5m);

            Assert.AreEqual(10m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_deposit_a_negative_value_throwes()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-5m));
        }

        [TestMethod]
        public void BankAccount_deposit_a_zero_as_value_throws()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(0m));
        }

        [TestMethod]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount();

            ba.Deposit(10m);
            ba.Withdraw(3m);
            ba.Withdraw(2m);

            Assert.AreEqual(5m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_withdraw_a_negative_value_throwes()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-5m));
        }

        [TestMethod]
        public void BankAccount_withdraw_a_zero_as_value_throws()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(0m));
        }

        [TestMethod]
        public void BankAccount_withdrawing_should_not_be_below_zero()
        {
            var ba = new BankAccount();

            ba.Deposit(10m);
            ba.Withdraw(3m);

            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(8m));
        }


    }
}
