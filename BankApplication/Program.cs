using System;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of an acount  == object

            var account = Bank.CreateAccount("test@test.com", TypeOfAccounts.Checking, 200);


            Console.WriteLine($"AN : {account.AccountNumber}," +
                $"Balance : {account.Balance:c}," +
                $"Created Date : {account.CreatedDate}," +
                $"Created Date : {account.AccountType}"

                );

            var account2 = Bank.CreateAccount("test2@test.com", TypeOfAccounts.Savings, 300);


            Console.WriteLine($"AN : {account2.AccountNumber}," +
     $"Balance : {account2.Balance}," +
     $"Created Date : {account2.CreatedDate}," +
              $"Created Date : {account2.AccountType}");

            Console.WriteLine("Welcome to my bank");

            while (true)
            {


                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all account");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting my bank!");
                        return;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;

                }
            }




        }
    }
}

