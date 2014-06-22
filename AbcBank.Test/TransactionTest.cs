using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank.Test
{
    [TestFixture]
    public class TransactionTest
    {
        [Test]
        public void transaction()
        {
            Transaction t = new Transaction(5);
            Assert.AreEqual(true, t is Transaction);
        }

        public void amountOK()
        {
            Transaction t = new Transaction(5);
            Assert.AreEqual(5, t.amount);
        }

        public void dateOK()
        {
            Transaction t = new Transaction(5);
            DateTime low = DateProvider.getInstance().now().AddSeconds(-10);
            DateTime high = low.AddSeconds(20);
            Assert.AreEqual(true, ((t.transactionDate > low) && (t.transactionDate < high)));
        }
    }
}
