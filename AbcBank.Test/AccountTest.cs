using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AbcBank.Test
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void deposit()
        {
            Account act = new Account(Account.AccountType.CHECKING);
            act.deposit(105.00);
            Assert.AreEqual(105.00, act.sumTransactions());
        }

        [Test]
        public void withdraw()
        {
            Account act = new Account(Account.AccountType.CHECKING);
            act.deposit(105.00);
            act.withdraw(5.00);
            Assert.AreEqual(100.00, act.sumTransactions());
        }

        [Test]
        public void sumTransactions()
        {
            Account act = new Account(Account.AccountType.CHECKING);
            act.deposit(105.00);
            act.withdraw(5.00);
            act.deposit(50.00);
            act.deposit(25.00);
            Assert.AreEqual(175.00, act.sumTransactions());
        }

        [Test]
        public void checkAccountType()
        {
            Account act = new Account(Account.AccountType.MAXI_SAVINGS);
            act.deposit(105.00);
            act.withdraw(100.00);
            Assert.AreEqual(Account.AccountType.MAXI_SAVINGS, act.getAccountType());
        }

    }
}
