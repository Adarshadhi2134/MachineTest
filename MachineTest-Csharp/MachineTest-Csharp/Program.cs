using System;
using System.Collections.Generic;

// Define an interface for objects that can be used for payments
// It includes methods for deposit, withdrawal, and checking balance
interface IPayable
{
    void DepositAmount(double amount);
    void WithdrawAmount(double amount);
    void CheckBalance();
 
}

// Create a class Employee that implements the IPayable interface
class Employee : IPayable
{
    private double balance = 0;
    



    // Implement the DepositAmount method from the IPayable interface
    public void DepositAmount(double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Invalid deposit amount.");
            }
            balance += amount;
            Console.WriteLine($"Deposit successful. Current balance: {balance}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Implement the WithdrawAmount method from the IPayable interface
    public void WithdrawAmount(double amount)
    {
        try
        {
            if (amount <= 0 || amount > balance)
            {
                throw new ArgumentException("Invalid withdrawal amount.");
            }
            balance -= amount;
            Console.WriteLine($"Withdrawal successful. Current balance: {balance}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Implement the CheckBalance method from the IPayable interface
    public void CheckBalance()
    {
        Console.WriteLine($"Current balance: {balance}");
    }


}

class ATM
{
    static void Main(string[] args)
    {
        Dictionary<int, Employee> accounts = new Dictionary<int, Employee>();

        while (true)
        {
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit amount");
            Console.WriteLine("3. Withdraw amount");
            Console.WriteLine("4. Check balance");
            Console.WriteLine("5. Exit"); // Option 6 to exit
            Console.Write("Enter your choice: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter account number: ");
                    int accountNumber;

                    if (!int.TryParse(Console.ReadLine(), out accountNumber))
                    {
                        Console.WriteLine("Invalid account number. Try again.");
                        continue;
                    }

                    if (!accounts.ContainsKey(accountNumber))
                    {
                       
                        Employee newAccount = new Employee();
                        

                        accounts[accountNumber] = newAccount;
                        Console.WriteLine("Account created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Account number already exists. Try a different number.");
                    }
                    break;

                case 2:
                    Console.Write("Enter account number: ");
                    if (!int.TryParse(Console.ReadLine(), out accountNumber) || !accounts.ContainsKey(accountNumber))
                    {
                        Console.WriteLine("Account not found. Try a different account number.");
                        continue;
                    }

                    Employee acc = accounts[accountNumber];

                    Console.Write("Enter amount to deposit: ");
                    double depositAmount;

                    if (double.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        acc.DepositAmount(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid deposit amount.");
                    }
                    break;

                case 3:
                    Console.Write("Enter account number: ");
                    if (!int.TryParse(Console.ReadLine(), out accountNumber) || !accounts.ContainsKey(accountNumber))
                    {
                        Console.WriteLine("Account not found. Try a different account number.");
                        continue;
                    }

                    Employee acc2 = accounts[accountNumber];

                    Console.Write("Enter amount to withdraw: ");
                    double withdrawAmount;

                    if (double.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        acc2.WithdrawAmount(withdrawAmount);
                    }
                    else
                    {
                        Console.WriteLine("insufficient amount");
                    }
                    break;

 
                case 4:
                    Console.Write("Enter account number: ");
                    if (!int.TryParse(Console.ReadLine(), out accountNumber) || !accounts.ContainsKey(accountNumber))
                    {
                        Console.WriteLine("Account not found. Try a different account number.");
                        continue;
                    }

                    Employee accountBalance = accounts[accountNumber];
                    accountBalance.CheckBalance();
                    break;


                case 5: // Option 6 to exit
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}