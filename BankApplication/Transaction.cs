using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{

    enum TypeOfTransaction
    {
        Credit,
        Debit
    }
    class Transaction
    {
        public  int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TypeOfTransaction TransactionTpe { get; set; }
        public decimal Balance { get; set; }

        public int AccountNumber { get; set; }
    }
}
