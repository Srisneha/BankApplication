using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{


    /// <summary>
    /// This is a bank account
    /// where user can deposit and withdraw
    /// money from it
    /// </summary>
    /// 
    enum TypeOfAccounts
    {
        Checking,
        Savings,
        CD,
        Loan
    }
    class Account
    {
        #region Properties
        public int AccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public DateTime CreatedDate { get; private set; }
        #endregion
        private static int lastAccountNumber = 0;



        #region Constructor

        public Account()
        {
            AccountNumber = ++lastAccountNumber;

            CreatedDate = DateTime.Now;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Deposit money into the account
        /// </summary>
        /// <param name="ammount">Amount to depoist</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;

        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;

        }
        #endregion

    }
}