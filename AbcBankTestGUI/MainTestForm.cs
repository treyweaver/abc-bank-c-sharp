using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbcBank;
using AbcBank.Test;


// did not have nunit installed.
namespace AbcBankTestGUI
{
    public partial class MainTestForm : Form
    {
        public MainTestForm()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            writeLine("Test has started.");
            testBank();
            testAccount();
            testCustomer();
            testTransaction();
        }

        private void testBank()
        {
            BankTest bt;
            bt = new BankTest();
            try
            {
                bt.addCustomers();
                writeLine("TestBank.addCustomers Passed");
            }
            catch (Exception ex) { writeError("TestBank.addCustomers Failed.", ex); }

            bt = new BankTest();
            try
            {
                bt.customerSummary();
                writeLine("TestBank.customerSummary Passed");
            }
            catch (Exception ex) { writeError("TestBank.customerSummary Failed.", ex); }

            bt = new BankTest();
            try
            {
                bt.checkingAccount();
                writeLine("TestBank.checkingAccount Passed");
            }
            catch (Exception ex) { writeError("TestBank.checkingAccount Failed.", ex); }

            bt = new BankTest();
            try
            {
                bt.savings_account();
                writeLine("TestBank.savings_account Passed");
            }
            catch (Exception ex) { writeError("TestBank.savings_account Failed.", ex); }

            bt = new BankTest();
            try
            {
                bt.maxi_savings_account();
                writeLine("TestBank.maxi_savings_account Passed");
            }
            catch (Exception ex) { writeError("TestBank.maxi_savings_account Failed.", ex); }

            
        }

        private void testAccount()
        {
            AccountTest at;

            at = new AccountTest();
            try
            {
                at.deposit();
                writeLine("TestAccount.deposit Passed");
            }
            catch (Exception ex) { writeError("TestAccount.deposit Failed.", ex); }

            at = new AccountTest();
            try
            {
                at.withdraw();
                writeLine("TestAccount.withdraw Passed");
            }
            catch (Exception ex) { writeError("TestAccount.withdraw Failed.", ex); }

            at = new AccountTest();
            try
            {
                at.checkAccountType();
                writeLine("TestAccount.checkAccountType Passed");
            }
            catch (Exception ex) { writeError("TestAccount.checkAccountType Failed.", ex); }

            at = new AccountTest();
            try
            {
                at.sumTransactions();
                writeLine("TestAccount.sumTransactions Passed");
            }
            catch (Exception ex) { writeError("TestAccount.sumTransactions Failed.", ex); }

        }

        private void testCustomer()
        {
            CustomerTest ct;

            ct = new CustomerTest();
            try
            {
                ct.testApp();
                writeLine("TestCustomer.testApp Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.testApp Failed.", ex); }

            ct = new CustomerTest();
            try
            {
                ct.testOneAccount();
                writeLine("TestCustomer.testOneAccount Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.testOneAccount Failed.", ex); }

            ct = new CustomerTest();
            try
            {
                ct.testTwoAccounts();
                writeLine("TestCustomer.testTwoAccounts Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.testTwoAccounts Failed.", ex); }

            ct = new CustomerTest();
            try
            {
                ct.testThreeAccounts();
                writeLine("TestCustomer.testThreeAccounts Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.testThreeAccounts Failed.", ex); }

            ct = new CustomerTest();
            try
            {
                ct.transferMoney();
                writeLine("TestCustomer.transferMoney Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.transferMoney Failed.", ex); }

            ct = new CustomerTest();
            try
            {
                ct.checkStatement();
                writeLine("TestCustomer.checkStatement Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.checkStatement Failed.", ex); }

            ct = new CustomerTest();
            try
            {
                ct.duplicateAccount();
                writeLine("TestCustomer.duplicateAccount Passed");
            }
            catch (Exception ex) { writeError("TestCustomer.duplicateAccount Failed.", ex); }


        }


        private void testTransaction()
        {
            TransactionTest tt;

            tt = new TransactionTest();
            try
            {
                tt.transaction();
                writeLine("TransactionTest.transaction Passed.");
            }
            catch (Exception ex) { writeError("TransactionTest.transaction Failed.", ex); }

            tt = new TransactionTest();
            try
            {
                tt.amountOK();
                writeLine("TransactionTest.amountOK Passed.");
            }
            catch (Exception ex) { writeError("TransactionTest.amountOK Failed.", ex); }

            tt = new TransactionTest();
            try
            {
                tt.dateOK();
                writeLine("TransactionTest.dateOK Passed.");
            }
            catch (Exception ex) { writeError("TransactionTest.dateOK Failed.", ex); }
        }

        private void write(String msg)
        {
            txbxOut.AppendText(msg);
        }

        private void writeLine(String msg)
        {
            txbxOut.AppendText(msg + "\n");
        }

        private void writeError(String msg, Exception ex)
        {
            writeLine("ERROR: " + msg);
            if (ex != null)
            {
                writeLine("----------------------------------------");
                writeLine(ex.Message);
                writeLine("----------------------------------------");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
