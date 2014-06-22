using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Customer
    {
        private String name;
        private List<Account> accounts;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        public String getName()
        {
            return name;
        }

        public Customer openAccount(Account account)
        {
            foreach (Account a in accounts)
            {
                if (a.getAccountType() == account.getAccountType())
                {
                    throw new ArgumentException("account type already exist for this customer");
                }
            }
            accounts.Add(account);
            return this;
        }

        public void transferMoney(Account.AccountType withdrawAccountType, Account.AccountType depositAccountType, double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("value of transfer must be greather than zero");

            Account withdrawAccount = getAccount(withdrawAccountType);
            if (withdrawAccount == null)
                throw new ArgumentException("withdraw account not found");
            Account depositAccount = getAccount(depositAccountType);
            if (depositAccount == null)
                throw new ArgumentException("deposit account not found");

            try
            {
                withdrawAccount.withdraw(amount);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("not enough money in withdraw account");
            }
            depositAccount.deposit(amount);
        }

        private Account getAccount(Account.AccountType accountType)
        {
            foreach (Account a in accounts)
            {
                if (a.getAccountType() == accountType)
                    return a;
            }
            return null;
        }


        public int getNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double totalInterestEarned()
        {
            double total = 0;
            foreach (Account a in accounts)
                total += a.interestEarned();
            return total;
        }

        /*******************************
         * This method gets a statement
         *********************************/
        public String getStatement()
        {
            StringBuilder  sb = new StringBuilder("Statement for " + name + "\n");
            double total = 0.0;
            foreach (Account a in accounts)
            {
                sb.Append("\n" + a.getStatement() + "\n");
                total += a.sumTransactions(); 
            }
            sb.Append("\nTotal In All Accounts " + Utils.toDollars(total));
            string s = sb.ToString();
            return sb.ToString();

        }
    }
}
