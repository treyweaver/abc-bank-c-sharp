using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class BankTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;
        [Test]
        public void addCustomers()
        {
            Bank bank = new Bank();
            Assert.AreEqual(0, bank.getNumberOfCustomers());
            Assert.AreEqual("", bank.getFirstCustomer());
            Customer trey = new Customer("trey");
            bank.addCustomer(trey);
            Assert.AreEqual(1, bank.getNumberOfCustomers());
            Assert.AreEqual("trey", bank.getFirstCustomer());
        }
            

        [Test]
        public void customerSummary()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            john.openAccount(new Account(Account.AccountType.CHECKING));
            bank.addCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.customerSummary());
        }

        [Test]
        public void checkingAccount()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.AccountType.CHECKING);
            Customer bill = new Customer("Bill").openAccount(checkingAccount);
            bank.addCustomer(bill);

            checkingAccount.deposit(100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void savings_account()
        {
            Bank bank = new Bank();
            Account savingsAccount = new Account(Account.AccountType.SAVINGS);
            bank.addCustomer(new Customer("Bill").openAccount(savingsAccount));

            savingsAccount.deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void maxi_savings_account()
        {
            Bank bank = new Bank();
            Account maxAccount = new Account(Account.AccountType.MAXI_SAVINGS);
            bank.addCustomer(new Customer("Bill").openAccount(maxAccount));

            maxAccount.deposit(3000.0);

            // only three because the deposit was today.
            Assert.AreEqual(3.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

    }
}
