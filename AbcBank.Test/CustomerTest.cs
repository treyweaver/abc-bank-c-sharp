using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class CustomerTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test] //Test customer statement generation
        public void testApp()
        {

            Account checkingAccount = new Account(Account.AccountType.CHECKING);
            Account savingsAccount = new Account(Account.AccountType.SAVINGS);

            Customer henry = new Customer("Henry").openAccount(checkingAccount).openAccount(savingsAccount);

            checkingAccount.deposit(100.0);
            savingsAccount.deposit(4000.0);
            savingsAccount.withdraw(200.0);

            Assert.AreEqual("Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", henry.getStatement());
        }

        [Test]
        public void testOneAccount()
        {
            Customer oscar = new Customer("Oscar").openAccount(new Account(Account.AccountType.SAVINGS));
            Assert.AreEqual(1, oscar.getNumberOfAccounts());
        }

        [Test]
        public void testTwoAccounts()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(new Account(Account.AccountType.SAVINGS));
            oscar.openAccount(new Account(Account.AccountType.CHECKING));
            Assert.AreEqual(2, oscar.getNumberOfAccounts());
        }

        [Test]
        public void testThreeAccounts()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(new Account(Account.AccountType.SAVINGS));
            oscar.openAccount(new Account(Account.AccountType.CHECKING));
            oscar.openAccount(new Account(Account.AccountType.MAXI_SAVINGS));
            Assert.AreEqual(3, oscar.getNumberOfAccounts());
        }

        [Test]
        public void transferMoney()
        {

            Account checkingAccount = new Account(Account.AccountType.CHECKING);
            Account savingsAccount  = new Account(Account.AccountType.SAVINGS);
            Account maxAccount      = new Account(Account.AccountType.MAXI_SAVINGS);

            Customer bill = new Customer("Bill");
            bill.openAccount(checkingAccount);
            bill.openAccount(savingsAccount);
            bill.openAccount(maxAccount);

            checkingAccount.deposit(100.00);
            savingsAccount.deposit(100.00);
            bill.transferMoney(Account.AccountType.SAVINGS, Account.AccountType.CHECKING, 75.00);

            Assert.AreEqual(175.00, checkingAccount.sumTransactions(), DOUBLE_DELTA);
        }

        [Test]
        public void duplicateAccount()
        {

            Account checkingAccount = new Account(Account.AccountType.CHECKING);
            Account savingsAccount = new Account(Account.AccountType.SAVINGS);
            Account maxAccount = new Account(Account.AccountType.MAXI_SAVINGS);

            Customer bill = new Customer("Bill");
            bill.openAccount(checkingAccount);
            bill.openAccount(savingsAccount);
            bill.openAccount(maxAccount);

            try
            {
                bill.openAccount(checkingAccount);
                Assert.Fail();   // should of got an exception
            }
            catch
            {
                //Assert.Pass();
            }
        }

        [Test]
        public void checkStatement()
        {
            Account checkingAccount = new Account(Account.AccountType.CHECKING);
            Account savingsAccount = new Account(Account.AccountType.SAVINGS);

            Customer bill = new Customer("Bill");
            bill.openAccount(checkingAccount);

            checkingAccount.deposit(100.00);

            Assert.AreEqual("Statement for Bill\n\nChecking Account\n  deposit $100.00\nTotal $100.00\n\nTotal In All Accounts $100.00",
                bill.getStatement());
        }
    }
}
