using System;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {


                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all account");
                Console.WriteLine("5.Get all Transactions");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting my bank!");
                        return;
                    case "1":
                        Console.Write("Email Address:");
                        var email= Console.ReadLine();
                        Console.WriteLine("Account Name:");
                        var accountName = Console.ReadLine();
                        Console.WriteLine("Account type: ");
                        //Convert enum to array
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        //Loop through the array

                        for(var i=0; i<accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{accountTypes[i]}");

                        }

                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());
                        Console.Write("Initial Deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                       var account = Bank.CreateAccount(accountName, email, accountType, amount);
                        Console.WriteLine($"AN:{account.AccountNumber}, CD: {account.CreatedDate}, AT :{account.AccountType}, B: {account.Balance},EA :{account.EmailAddress}");
                        break;
                    case "2":
                        PrintAllAcoounts();
                        Console.Write("Account number");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit:");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposited successfully");
                        break;
                    case "3":
                        PrintAllAcoounts();
                        Console.Write("Account number");
                        var accountNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw:");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNum, amount);
                        Console.WriteLine("Withdraw successfully");
                        break;
                    case "4":
                        PrintAllAcoounts();
                        break;
                    case "5":
                        Console.WriteLine("account Number:");
                        var acctNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactionByAccountNumber(acctNumber);

                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;

                }
            }




        }

        private static void PrintAllAcoounts()
        {
            Console.Write("EmailAddress: ");
            var emailAddress = Console.ReadLine();
            var accounts
               = Bank.GetAllAccountsByEmailAddress(emailAddress);
            foreach (var myaccount in accounts)
            {
                Console.WriteLine($"AN:{myaccount.AccountNumber}, CD: {myaccount.CreatedDate}, AT :{myaccount.AccountType}, B: {myaccount.Balance},EA :{myaccount.EmailAddress}");


            }
        }
    }
}

