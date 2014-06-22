using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Account
    {
        public enum AccountType {
            CHECKING = 0,
            SAVINGS = 1,
            MAXI_SAVINGS = 2,
            NONE = -1
        }

        private readonly AccountType accountType;
        public List<Transaction> transactions;

        public Account(AccountType accountType)
        {
            this.accountType = accountType;
            this.transactions = new List<Transaction>();
        }

        public void deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(amount));
            }
        }

        public void withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            if (amount > this.sumTransactions())
            {
                throw new ArgumentException("withdraw account is greater than funds in account");
            }
                
            transactions.Add(new Transaction(-amount));
        }

        public double interestEarned()
        {
            double amount = sumTransactions();
            double rate = 0.0;

            switch (accountType)
            {
                case AccountType.SAVINGS:
                    if (amount <= 1000)
                        return calculateInterestAmount(amount, 0.001);
                    else
                        return (calculateInterestAmount(1000, 0.001) + calculateInterestAmount((amount-1000), 0.002));
                case AccountType.MAXI_SAVINGS:
                    if (transactionInLast10Days())
                        return (calculateInterestAmount(amount, 0.001));
                    else
                        return (calculateInterestAmount(amount, 0.05));
                default:
                    return calculateInterestAmount(amount, 0.001);
            }
        }

        // This routine needs to be much, much, much more complicated than this.
        // if a person puts in 100 on Jan 1st and a million dollars yesterday
        // their interest should be calculated on the 100 for the total period
        // and intrest for the 1 million dollars for only one day.
        // So to get a good number you would need to calculate what the amount of
        // money is in the account on each and every day apply that accrued intrest to 
        // the account for that day.
        // Since this is only a two hour exercise I did not think you wanted me to 
        // go that far.
        private double calculateInterestAmount(double amount, double rate)
        {
            if (amount <= 0)
                return 0;
            return (amount * rate);
        }

        public double sumTransactions()
        {
            double amount = 0.0;
            foreach (Transaction t in transactions)
            {
                amount += t.amount;
            }
           return amount;
        }


        public AccountType getAccountType()
        {
            return accountType;
        }

        public String getStatement()
        {
            StringBuilder sb = new StringBuilder("");

            //Translate to pretty account type
            switch (this.getAccountType())
            {
                case AccountType.CHECKING:
                    sb.Append("Checking Account\n");
                    break;
                case AccountType.SAVINGS:
                    sb.Append("Savings Account\n");
                    break;
                case AccountType.MAXI_SAVINGS:
                    sb.Append("Maxi Savings Account\n");
                    break;
            }

            //Now total up all the transactions
            double total = 0.0;
            foreach (Transaction t in this.transactions)
            {
                sb.Append("  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + Utils.toDollars(t.amount) + "\n");
                total += t.amount;
            }
            sb.Append("Total " + Utils.toDollars(total));
            return sb.ToString();
        }

        // returns now if there are not transactions
        private DateTime getLastTransactionDate()
        {
            DateTime dt = DateProvider.getInstance().now().AddDays(-11);
            if ((transactions == null) || (transactions.Count == 0))
                return DateProvider.getInstance().now();
            foreach (Transaction t in this.transactions)
            {
                if (t.transactionDate > dt)
                    dt = t.transactionDate;
            }
            return dt;
        }

        private bool transactionInLast10Days()
        {
            DateTime ldt = getLastTransactionDate();
            return (ldt.AddDays(10) > DateProvider.getInstance().now());
        }

    }
}
