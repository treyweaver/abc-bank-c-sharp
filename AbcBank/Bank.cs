using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Bank
    {
        private List<Customer> customers;

        public Bank()
        {
            customers = new List<Customer>();
        }

        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public String customerSummary()
        {
            StringBuilder sb = new StringBuilder("Customer Summary");
            foreach (Customer c in customers)
                sb.Append("\n - " + c.getName() + " (" + Utils.makeWordPluralIfNeeded(c.getNumberOfAccounts(), "account") + ")");
            return sb.ToString();
        }

        public double totalInterestPaid()
        {
            double total = 0;
            foreach (Customer c in customers)
                total += c.totalInterestEarned();
            return total;
        }

        public String getFirstCustomer()
        {
            if ((customers == null) || (customers.Count == 0))
            {
                return "";
            }
            return customers[0].getName();
        }

        public int getNumberOfCustomers()
        {
            if (customers == null)
                return 0;
            return customers.Count;
        }
    }
}
