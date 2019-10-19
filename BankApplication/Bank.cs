using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();

        public static Account CreateAccount(string emailAddress, TypeOfAccounts accountType, decimal initialDeposit)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);

            }
            accounts.Add(account);
            return account;
        }
        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
             return accounts.Where(a => a.EmailAddress == emailAddress);
           
        }

        public static void Deposit(int accountNumer, decimal amount)

        {
           var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumer);
            if(account == null)
            {
                //throw exception 
                return;
            }

            account.Deposit(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionTpe = TypeOfTransaction.Credit,
                Description = "Deposit",
                Balance = account.Balance
            };

        }
        public static void Withdraw(int accountNumer, decimal amount)

        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumer);
            if (account == null)
            {
                //throw exception 
                return;
            }

            account.Withdraw(amount);

        }
    }

   
}
