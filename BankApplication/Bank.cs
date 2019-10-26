﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    static class Bank
    {
        private static BankContext db = new BankContext();

        public static Account CreateAccount(string accountName,string emailAddress, TypeOfAccounts accountType=TypeOfAccounts.Checking, decimal initialDeposit =0)
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
                TransactionTpe = TypeOfTransaction.Credit,
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

        }
    }

   
}
