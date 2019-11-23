using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    public static class Bank
    {
        private static BankContext db = new BankContext();

        public static Account CreateAccount(string emailAddress, TypeOfAccounts accountType, decimal initialDeposit=0)
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
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress)|| string.IsNullOrWhiteSpace(emailAddress.Trim()))
            {
                throw new ArgumentNullException("emailAddress", "Email adress is required");
            }
             return db.Accounts.Where(a => a.EmailAddress == emailAddress);
           
        }
        
        public static IEnumerable<Transaction> GetAllTransactionByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber)
                .OrderByDescending(t=> t.TransactionDate);

        }

        public static void Deposit(int accountNumer, decimal amount)

        {
           var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumer);
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
                TransactionTpe = TypeOfTransaction.Debit,
                Description = "Deposit",
                Balance = account.Balance
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();

        }
        public static void Withdraw(int accountNumer, decimal amount)

        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumer);
            if (account == null)
            {
                //throw exception 
                return;
            }

            account.Withdraw(amount);
            var transaction1 = new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionTpe = TypeOfTransaction.Debit,
                Description = "Deposit",
                Balance = account.Balance
            };
            db.Transactions.Add(transaction1);
            db.SaveChanges();

        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
           return db.Accounts.Find(accountNumber);
        }

        public static void UpdateAccount(Account updatedAccount)
        {
            var oldAccount = GetAccountByAccountNumber(updatedAccount.AccountNumber);
            oldAccount.EmailAddress = updatedAccount.EmailAddress;
            oldAccount.AccountType = updatedAccount.AccountType;
            db.SaveChanges();

        }
    }

   
}
